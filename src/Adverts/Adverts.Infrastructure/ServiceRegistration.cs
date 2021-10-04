using Adverts.Infrastructure.Services;
using Adverts.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adverts.Infrastructure
{
    public static class ServiceRegistration
    {
        /// <summary>
        /// For adding newly created services to have cleaner Startup.cs
        /// </summary>
        /// <param name="services"></param>
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IRequestService, RequestService>();
        }
    }
}
