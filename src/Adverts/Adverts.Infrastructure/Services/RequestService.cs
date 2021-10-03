﻿using Adverts.Core.Models;
using Adverts.Core.Entities;
using Adverts.Infrastructure.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Adverts.Infrastructure.Services
{
    public class RequestService : IRequestService
    {
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient _client;

        public RequestService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _client = _clientFactory.CreateClient("repositoryService");
        }

        public async Task<GenericResult> GetAll()
        {
            GenericResult result = new GenericResult();

            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "advert/all");

                HttpResponseMessage response = await _client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    List<Core.Entities.Adverts> adverts = JsonConvert.DeserializeObject<List<Core.Entities.Adverts>>(await response.Content.ReadAsStringAsync());
                    result.Data = adverts;

                    if (adverts.Count > 0)
                    {
                        result.IsSuccess = true;
                        result.StatusCode = 200;
                    }
                    else
                    {
                        result.IsSuccess = true;
                        result.StatusCode = 204;
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.StatusCode = 500;
                }
            }
            catch
            {
                result.IsSuccess = false;
                result.StatusCode = 500;
            }

            return result;
        }

        public async Task<GenericResult> GetById(string id)
        {
            GenericResult result = new GenericResult();

            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"advert/get?id={id}");

                HttpResponseMessage response = await _client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    AdvertDetails advertDetails = JsonConvert.DeserializeObject<AdvertDetails>(await response.Content.ReadAsStringAsync());
                    result.Data = advertDetails;

                    if (advertDetails != null)
                    {
                        result.IsSuccess = true;
                        result.StatusCode = 200;
                    }
                    else
                    {
                        result.IsSuccess = true;
                        result.StatusCode = 204;
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.StatusCode = 500;
                }
            }
            catch
            {
                result.IsSuccess = false;
                result.StatusCode = 500;
            }

            return result;
        }

        public Task Post()
        {
            throw new NotImplementedException();
        }
    }
}
