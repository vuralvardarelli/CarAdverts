using Adverts.API.Util;
using Adverts.Core.Models.Request;
using EventBusRabbitMQ.Common;
using EventBusRabbitMQ.Events;
using EventBusRabbitMQ.Producer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adverts.API.Controllers
{
    [Route("/advert")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly EventBusRabbitMQProducer _eventBus;

        public AdvertController(EventBusRabbitMQProducer eventBus)
        {
            _eventBus = eventBus;
        }

        [HttpPost("visit")]
        public async Task<ActionResult> Visit([FromBody] AdvertVisitRequest request)
        {
            AdvertVisitEvent eventMessage = new AdvertVisitEvent()
            {
                advertId = Convert.ToInt32(request.advertId),
                iPAdress = RequestInformation.GetIp(HttpContext),
                RequestId = Guid.NewGuid(),
                visitDate = DateTime.Now
            };

            _eventBus.PublishAdvertVisit(EventBusConstants.AdvertVisitQueue, eventMessage);

            return Accepted();
        }
    }
}
