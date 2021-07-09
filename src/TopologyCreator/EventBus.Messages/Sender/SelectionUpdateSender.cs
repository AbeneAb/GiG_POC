using EventBus.Messages.Events;
using EventBus.Messages.Interface;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Sender
{
    public class SelectionUpdateSender : ISelectionUpdateSender
    {
        private readonly string _hostname;
        private readonly string _password;
        private readonly string _queueName;
        private readonly string _username;
        private readonly int _port;
        private IConnection _connection;
        public SelectionUpdateSender(IOptions<RabbitMqConfiguration> rabbitMqOptions)
        {
            _queueName = rabbitMqOptions.Value.QueueName;
            _hostname = rabbitMqOptions.Value.Hostname;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;
            _port = Convert.ToInt32(rabbitMqOptions.Value.Port);
            CreateConnection();
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostname,
                    UserName = _username,
                    Password = _password,
                    Port = _port
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create connection: {ex.Message}");
            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }

            CreateConnection();

            return _connection != null;
        }

        public void SendSelection(SelectionEvent customer)
        {
            if (ConnectionExists())
            {
               
                using (var channel = _connection.CreateModel())
                {

                    channel.ExchangeDeclare(exchange: "SelectionExchange", type: ExchangeType.Fanout);

                   // channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                    var json = System.Text.Json.JsonSerializer.Serialize(customer);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: "SelectionExchange", routingKey: "", basicProperties: null, body: body);
                }
            }
        }
    }
}
