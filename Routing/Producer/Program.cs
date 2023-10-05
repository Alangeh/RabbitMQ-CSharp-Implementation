using System;
using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory() { HostName = "localhost" };

using var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

//channel.ExchangeDeclare(exchange: "routing", type: ExchangeType.Direct);
channel.ExchangeDeclare(exchange: "topicrouting", type: ExchangeType.Topic);

var paymentmessage = "User Payment routing braodcast messge";

var body = Encoding.UTF8.GetBytes(paymentmessage);

channel.BasicPublish(exchange: "topicrouting", "user.europe.payments", null, body);

Console.WriteLine($"Send message: {paymentmessage}");

var analyticsmessage = "Analytics routing braodcast messge";

var body1 = Encoding.UTF8.GetBytes(analyticsmessage);

channel.BasicPublish(exchange: "topicrouting", "goods.europe.routing", null, body1);

Console.WriteLine($"Send message: {analyticsmessage}");