using Repository.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Infrastructure.Services.Interfaces
{
    public interface IRepositoryService
    {
        Task<IReadOnlyList<Adverts>> GetAllAsync(int page, int pageSize, string sortByColumn, bool isDescending, string categoryId, string price, string gear, string fuel);

        Task<Adverts> GetByIdAsync(int id);
    }
}
