using Repository.Application.Interfaces;
using Repository.Core.Entities;
using Repository.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Infrastructure.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly IUnitOfWork _unitOfwork;

        public RepositoryService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public async Task<IReadOnlyList<Adverts>> GetAllAsync(int page,int pageSize)
        {
            return await _unitOfwork.Adverts.GetAllAsync(page, pageSize);
        }

        public async Task<Adverts> GetByIdAsync(int id)
        {
            return await _unitOfwork.Adverts.GetByIdAsync(id);
        }
    }
}
