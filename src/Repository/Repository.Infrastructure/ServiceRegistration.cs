using Microsoft.Extensions.DependencyInjection;
using Repository.Application.Interfaces;
using Repository.Infrastructure.Repositories;
using Repository.Infrastructure.Services;
using Repository.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IAdvertRepository, AdvertRepository>();
            services.AddTransient<IAdvertVisitRepository, AdvertVisitRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepositoryService, RepositoryService>();
        }
    }
}
