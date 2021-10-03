﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IAdvertRepository Adverts { get; }
        IAdvertVisitRepository AdvertVisits { get; }
    }
}
