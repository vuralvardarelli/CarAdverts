using Adverts.Core.Models;
using System.Threading.Tasks;

namespace Adverts.Infrastructure.Services.Interfaces
{
    public interface IRequestService
    {
        Task<GenericResult> Get();
        Task Post();
    }
}
