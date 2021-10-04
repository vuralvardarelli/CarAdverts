using Repository.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Infrastructure.Services.Interfaces
{
    /// <summary>
    /// Repository Service Interface for using DI in AdvertController.
    /// </summary>
    public interface IRepositoryService
    {
        Task<IReadOnlyList<Adverts>> GetAllAsync(int page, int pageSize, string sortByColumn, bool isDescending, string categoryId, string price, string gear, string fuel);

        Task<Adverts> GetByIdAsync(int id);
    }
}
