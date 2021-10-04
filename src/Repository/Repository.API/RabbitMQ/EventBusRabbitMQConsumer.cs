using EventBusRabbitMQ;
using EventBusRabbitMQ.Common;
using EventBusRabbitMQ.Events;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Repository.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.API.RabbitMQ
{
    /// <summary>
    /// RabbitMQ Queue Consumer Class.
    /// </summary>
    public class EventBusRabbitMQConsumer
    {
        private readonly IRabbitMQConnection _connection;
        private readonly IUnitOfWork _unitOfWork;

        public EventBusRabbitMQConsumer(IRabbitMQConnection connection, IUnitOfWork unitOfWork)
        {
            _connection = connection;
            _unitOfWork = unitOfWork;
        }

        public void Consume()
        {
            var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: EventBusConstants.AdvertVisitQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            //Create event when something receive
            consumer.Received += ReceivedEvent;

            channel.BasicConsume(queue: EventBusConstants.AdvertVisitQueue, autoAck: true, consumer: consumer);
        }

        private async void ReceivedEvent(object sender, BasicDeliverEventArgs e)
        {
            if (e.RoutingKey == EventBusConstants.AdvertVisitQueue)
            {
                var message = Encoding.UTF8.GetString(e.Body.Span);
                var advertVisitEvent = JsonConvert.DeserializeObject<AdvertVisitEvent>(message);

                // EXECUTION : Insert Internal Advert Visit Action
                var advertVisit = _unitOfWork.AdvertVisits.AddAsync(new Core.Entities.AdvertVisits()
                {
                    advertId = advertVisitEvent.advertId,
                    iPAdress = advertVisitEvent.iPAdress,
                    visitDate = advertVisitEvent.visitDate
                });
            }
        }

        public void Disconnect()
        {
            _connection.Dispose();
        }
    }
}
