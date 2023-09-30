﻿using System;
using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory{ 
    HostName = "localhost"
};

using var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.QueueDeclare(
    queue: "letterbox", 
    durable:false, 
    exclusive:false,
    autoDelete:false,
    arguments: null
    );

var message = "First message of RABBITMQ using c#";

var encodedMessage = Encoding.UTF8.GetBytes(message);

channel.BasicPublish("", "letterbox", null, encodedMessage);

Console.WriteLine($"Published message: {message}");

Console.ReadKey();