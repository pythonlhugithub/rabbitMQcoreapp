
using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;

var factory=new ConnectionFactory{
Uri=new Uri("amqp://guest:guest@localhost:5672")

};

using var connection=factory.CreateConnection();
using var channel=connection.CreateModel();

channel.QueueDeclare("davidqueue",
durable:true,
exclusive:false,
autoDelete:false,
arguments:null

);

//5672 is used by internal container docker

var message =new {Name="producer", Message="first message from producer"};

var body=Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));


channel.BasicPublish("","davidqueue", null, body);

//noe producer is ready to pass body to the queue

Console.ReadLine();