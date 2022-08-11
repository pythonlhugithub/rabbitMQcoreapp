 
using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;

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

var consumer =new EventingBasicConsumer(channel);
consumer.Received+=(sender,e)=>{
var body=e.Body.ToArray();
var message=Encoding.UTF8.GetString(body);
Console.WriteLine(message);
};

channel.BasicConsume("davidqueue",true, consumer);

//now consumer is ready

Console.ReadLine();