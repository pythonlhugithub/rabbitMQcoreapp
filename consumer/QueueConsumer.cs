using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public static class QueueConsumer{
    public static void consume(IModel channel){
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

 Console.WriteLine("consumer started");

  Console.ReadLine();
    }
}