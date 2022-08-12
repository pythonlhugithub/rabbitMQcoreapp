using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

public class QueueProducer{
    public static void publish(IModel channel){
        
channel.QueueDeclare("davidqueue",
durable:true,
exclusive:false,
autoDelete:false,
arguments:null

);

//5672 is used by internal container docker
var count=0;

while(true){
            var message =new {Name="producer", 
            Message="first message from producer: {count}"
            };

            var body=Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish("","davidqueue", null, body);
            count++;
    }
//noe producer is ready to pass body to the queue
 
    }
}