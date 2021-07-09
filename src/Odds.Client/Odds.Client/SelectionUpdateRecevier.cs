using ConsoleTables;
using EventBus.Messages;
using EventBus.Messages.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Odds.Client.Contracts;
using Odds.Client.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;

namespace Odds.Client
{
    public class SelectionUpdateRecevier : BackgroundService
    {
        private IModel _channel;
        private IConnection _connection;
        private readonly IEventService _selectionUpdateRecevier;
        private readonly ISelectionService _selectionService;
        private readonly string _hostname;
        private string _queueName;
        private readonly string _username;
        private readonly string _password;
        private readonly int _port;
        public SelectionUpdateRecevier(IOptions<RabbitMqConfiguration> rabbitMqOptions, IEventService selectionUpdateRecevier,ISelectionService selectionService)
        {
            _hostname = rabbitMqOptions.Value.Hostname;
            _queueName = rabbitMqOptions.Value.QueueName;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;
            _port = Convert.ToInt32(rabbitMqOptions.Value.Port);
            _selectionUpdateRecevier = selectionUpdateRecevier;
            _selectionService = selectionService;
            InitializeRabbitMqListener();
            InitializeData();
            
        }
        private async Task InitializeData() 
        {
            Console.WriteLine("First call to Selections");
            var response = await _selectionUpdateRecevier.GetEvents();
            DrawTable(response);
        }
        private void DrawTable(IEnumerable<EventModel> events) 
        {

            foreach(var @event in events) 
            {
                var table = new ConsoleTable("Event Name", "Status", "Competition", "Category");
                table.AddRow(@event.Label, @event.EventStatus, @event.Competition, @event.Category);
               
                table.Write();
                Console.WriteLine("Participants for this event are...");
                var participantTable = new ConsoleTable("Index","Label");
                foreach(var participant in @event.ParticipantDetails) 
                {
                    participantTable.AddRow(participant.Index, participant.Description);
                }
               
                participantTable.Write();
                Console.WriteLine("Market for this event are...");
                foreach (var market in @event.Market) 
                {
                    var marketTable = new ConsoleTable("Market Label","Deadline","Status");
                    marketTable.AddRow(market.Label, market.DeadLine, market.MarketStatus);
                    marketTable.Write();
                    Console.WriteLine($"Available Odds or Selections for Market => {market.Label } are : ");
                    var selectionTable = new ConsoleTable("odds", "index", "label", "status");
                    foreach (var selection in market.Selections) 
                    {
                        selectionTable.AddRow(selection.Odds, selection.Index, selection.Label, selection.Status);
                    }
                    selectionTable.Write();

                }

            }
        }
        private void InitializeRabbitMqListener()
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password,
                Port = _port
            };

            _connection = factory.CreateConnection();
            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "SelectionExchange", type: ExchangeType.Fanout);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _queueName,
                              exchange: "SelectionExchange",
                              routingKey: "");


           // _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var updateCustomerFullNameModel = System.Text.Json.JsonSerializer.Deserialize<SelectionUpdatedEvent>(content);

                HandleMessage(updateCustomerFullNameModel);

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerCancelled;

            _channel.BasicConsume(_queueName, false, consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(SelectionUpdatedEvent selectionUpdate)
        {
            Console.WriteLine("One Selection row Updated.");
            var singleRow = new ConsoleTable("Guid" ,"Index", "Label", "Odds", "Deadline", "Status");
            singleRow.AddRow(selectionUpdate.Id, selectionUpdate.Index, selectionUpdate.Label, selectionUpdate.Odds, selectionUpdate.Odds, selectionUpdate.Status);
            Console.WriteLine("Here is an updated Table");
            var response = await _selectionUpdateRecevier.GetEvents();
            DrawTable(response);
        }
        private void OnConsumerCancelled(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerRegistered(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerShutdown(object sender, ShutdownEventArgs e)
        {
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
        }
    }
}
