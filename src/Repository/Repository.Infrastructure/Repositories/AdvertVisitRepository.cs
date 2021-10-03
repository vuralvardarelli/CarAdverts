using Dapper;
using Microsoft.Extensions.Configuration;
using Repository.Application.Interfaces;
using Repository.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Infrastructure.Repositories
{
    public class AdvertVisitRepository : IAdvertVisitRepository
    {
        private readonly IConfiguration configuration;

        public AdvertVisitRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(AdvertVisits entity)
        {
            var sql = "Insert into AdvertVisits (advertId,iPAdress,visitDate) VALUES (@advertId,@iPAdress,@visitDate)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("AdvertConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<AdvertVisits>> GetAllAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<AdvertVisits> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
