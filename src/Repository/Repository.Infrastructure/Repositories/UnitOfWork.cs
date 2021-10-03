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
        public UnitOfWork(IAdvertRepository advertRepository)
        {
            Adverts = advertRepository;
        }

        public IAdvertRepository Adverts { get; }
    }
}
