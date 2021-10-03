using Adverts.Core.Models;
using System.Threading.Tasks;

namespace Adverts.Infrastructure.Services.Interfaces
{
    public interface IRequestService
    {
        Task<GenericResult> GetAll(int page, int pageSize);

        Task<GenericResult> GetById(string id);
        Task<GenericResult> CreateVisit(string advertId, string ip);
    }
}
