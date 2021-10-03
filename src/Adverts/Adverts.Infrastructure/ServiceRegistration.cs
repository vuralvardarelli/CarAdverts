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
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IRequestService, RequestService>();
        }
    }
}
