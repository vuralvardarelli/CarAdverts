using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync(int page, int pageSize, string sortByColumn, bool isDescending);
        Task<int> AddAsync(T entity);
        Task<int> DeleteAsync(int id);
    }
}
