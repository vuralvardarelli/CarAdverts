using Adverts.Core.Models;
using System.Threading.Tasks;

namespace Adverts.Infrastructure.Services.Interfaces
{
    /// <summary>
    /// A service to use in AdvertController with DI.
    /// </summary>
    public interface IRequestService
    {
        /// <summary>
        /// Getting all Adverts depending on pagination or filtering or sorting.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortByColumn"></param>
        /// <param name="isDescending"></param>
        /// <param name="categoryId"></param>
        /// <param name="price"></param>
        /// <param name="gear"></param>
        /// <param name="fuel"></param>
        /// <returns></returns>
        Task<GenericResult> GetAll(int page, int pageSize, string sortByColumn, bool isDescending, string categoryId, string price, string gear, string fuel);

        /// <summary>
        /// Getting AdvertDetails by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GenericResult> GetById(string id);

        /// <summary>
        /// Sending AdvertVisitEvent to RabbitMQ.
        /// </summary>
        /// <param name="advertId"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        Task<GenericResult> CreateVisit(string advertId, string ip);
    }
}
