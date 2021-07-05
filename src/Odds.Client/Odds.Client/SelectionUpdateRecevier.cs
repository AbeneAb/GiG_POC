using ConsoleTables;
using EventBus.Messages;
using EventBus.Messages.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Odds.Client.Contracts;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
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
        private readonly ISelectionService _selectionUpdateRecevier;
        private readonly string _hostname;
        private readonly string _queueName;
        private readonly string _username;
        private readonly string _password;
        private readonly int _port;
        public SelectionUpdateRecevier(IOptions<RabbitMqConfiguration> rabbitMqOptions, ISelectionService selectionUpdateRecevier, IServiceProvider sp)
        {
            _hostname = rabbitMqOptions.Value.Hostname;
            _queueName = rabbitMqOptions.Value.QueueName;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;
            _port = Convert.ToInt32(rabbitMqOptions.Value.Port);
            _selectionUpdateRecevier = selectionUpdateRecevier;
            InitializeRabbitMqListener();
            InitializeData();
            
        }
        private async Task InitializeData() 
        {
            Console.WriteLine("First call to Selections");
            var response = await _selectionUpdateRecevier.GetSelections();
            var groupByMarket = response.GroupBy(x => x.MarketGuid);
            var table = new ConsoleTable("Index", "Label", "Odds", "Deadline", "Status");

            foreach (var marketGroup in groupByMarket)
            {
                string str = marketGroup.FirstOrDefault().MarketLabel;
                table.AddRow("", "", str, "", "");
                foreach (var selection in marketGroup)
                {
                    table.AddRow(selection.Index, selection.Label, selection.Odds, selection.DeadLine, selection.Status);
                }
                table.Write();
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
            _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
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
            Console.WriteLine("One row Updated.");
            var singleRow = new ConsoleTable("Guid" ,"Index", "Label", "Odds", "Deadline", "Status");
            singleRow.AddRow(selectionUpdate.Id, selectionUpdate.Index, selectionUpdate.Label, selectionUpdate.Odds, selectionUpdate.Odds, selectionUpdate.Status);

            var response = await _selectionUpdateRecevier.GetSelections();
            var groupByMarket = response.GroupBy(x => x.MarketGuid);
            var table = new ConsoleTable("Index", "Label", "Odds", "Deadline", "Status");

            foreach (var marketGroup in groupByMarket)
            {
                string str = marketGroup.FirstOrDefault().MarketLabel;
                table.AddRow("", "", str, "", "");
                foreach (var selection in marketGroup)
                {
                    table.AddRow(selection.Index, selection.Label, selection.Odds, selection.DeadLine, selection.Status);
                }
                table.Write();
            }
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
