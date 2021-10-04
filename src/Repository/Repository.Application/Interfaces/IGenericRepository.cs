using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Application.Interfaces
{
    /// <summary>
    /// Generic Repository Interface for CRUD operations to use in our CarAdverts project.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync(int page, int pageSize, string sortByColumn, bool isDescending, string categoryId, string price, string gear, string fuel);
        Task<int> AddAsync(T entity);
        Task<int> DeleteAsync(int id);
    }
}
