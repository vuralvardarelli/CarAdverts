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
    public class AdvertRepository : IAdvertRepository
    {
        private readonly IConfiguration configuration;

        public AdvertRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Adverts entity)
        {
            entity.date = DateTime.Now;

            var sql = "Insert into Adverts (id,memberId,cityId,CityName,townId,TownName,modelId,modelName,year,price,title,date,categoryId,category,km,color,gear,fuel,firstPhoto,secondPhoto,userInfo,userPhone,text) VALUES (@id,@memberId,@cityId,@CityName,@townId,@TownName,@modelId,@modelName,@year,@price,@title,@date,@categoryId,@category,@km,@color,@gear,@fuel,@firstPhoto,@secondPhoto,@userInfo,@userPhone,@text)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("AdvertConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Adverts WHERE id = @id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("AdvertConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Adverts>> GetAllAsync()
        {
            var sql = "SELECT * FROM Adverts";
            using (var connection = new SqlConnection(configuration.GetConnectionString("AdvertConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Adverts>(sql);
                return result.ToList();
            }
        }

        public async Task<Adverts> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Adverts WHERE id = @id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("AdvertConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Adverts>(sql, new { id = id });
                return result;
            }
        }
    }
}
