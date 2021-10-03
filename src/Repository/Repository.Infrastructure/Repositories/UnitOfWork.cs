using Repository.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IAdvertRepository advertRepository, IAdvertVisitRepository advertVisitRepository)
        {
            Adverts = advertRepository;
            AdvertVisits = advertVisitRepository;
        }

        public IAdvertRepository Adverts { get; }
        public IAdvertVisitRepository AdvertVisits { get; }
    }
}
