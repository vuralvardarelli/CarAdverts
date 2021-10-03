using Adverts.Core.Models;
using Adverts.Core.Entities;
using Adverts.Infrastructure.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Adverts.Infrastructure.Services
{
    public class RequestService : IRequestService
    {
        private readonly IHttpClientFactory _clientFactory;

        public RequestService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<GenericResult> Get()
        {
            GenericResult result = new GenericResult();

            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "advert");

                HttpClient client = _clientFactory.CreateClient("repositoryService");

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    List<Core.Entities.Adverts> adverts = JsonConvert.DeserializeObject<List<Core.Entities.Adverts>>(await response.Content.ReadAsStringAsync());
                    adverts = new List<Core.Entities.Adverts>();
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

        public Task Post()
        {
            throw new NotImplementedException();
        }
    }
}
