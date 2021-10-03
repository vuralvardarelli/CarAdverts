﻿using Adverts.API.Util;
using Adverts.Core.Entities;
using Adverts.Core.Models;
using Adverts.Core.Models.Request;
using Adverts.Infrastructure.Services.Interfaces;
using EventBusRabbitMQ.Common;
using EventBusRabbitMQ.Events;
using EventBusRabbitMQ.Producer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Adverts.API.Controllers
{
    [Route("/advert")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly EventBusRabbitMQProducer _eventBus;
        private readonly IRequestService _requestService;

        public AdvertController(EventBusRabbitMQProducer eventBus, IRequestService requestService)
        {
            _eventBus = eventBus;
            _requestService = requestService;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(List<Core.Entities.Adverts>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> GetAll()
        {
            GenericResult result = await _requestService.GetAll();

            if (result.StatusCode == 200)
            {
                return Ok(result.Data);
            }
            else if (result.StatusCode == 204)
            {
                return StatusCode(204, "No adverts found");
            }
            else
            {
                return StatusCode(500, "Internal error occurred");
            }
        }

        [HttpGet("get")]
        [ProducesResponseType(typeof(AdvertDetails), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> GetById(string id)
        {
            GenericResult result = await _requestService.GetById(id);

            if (result.StatusCode == 200)
            {
                return Ok(result.Data);
            }
            else if (result.StatusCode == 204)
            {
                return StatusCode(204, "No advert found");
            }
            else
            {
                return StatusCode(500, "Internal error occurred");
            }
        }

        [HttpPost("visit")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Visit([FromBody] AdvertVisitRequest request)
        {
            try
            {
                AdvertVisitEvent eventMessage = new AdvertVisitEvent()
                {
                    advertId = Convert.ToInt32(request.advertId),
                    iPAdress = RequestInformation.GetIp(HttpContext),
                    RequestId = Guid.NewGuid(),
                    visitDate = DateTime.Now
                };

                _eventBus.PublishAdvertVisit(EventBusConstants.AdvertVisitQueue, eventMessage);

                return StatusCode(201, "visit created");
            }
            catch
            {
                return StatusCode(500, "Internal error occured");
            }
        }
    }
}
