using Dapper;
using Microsoft.Extensions.Configuration;
using Repository.Application.Interfaces;
using Repository.Core;
using Repository.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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

        public Task<int> AddAsync(Adverts entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Adverts>> GetAllAsync(int page, int pageSize, string sortByColumn, bool isDescending, string categoryId, string price, string gear, string fuel)
        {
            IEnumerable<Adverts> response = null;

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@PageNumber", page);
            parameters.Add("@PageSize", pageSize);

            string sortDirection = "";
            if (isDescending)
            {
                sortDirection = "DESC";
            }

            // To check sorting column is empty or valid for available sorting fields.
            if (!string.IsNullOrEmpty(sortByColumn) && !Utilities.FilterableAdvertColumnNames.Contains(sortByColumn))
                throw new ArgumentOutOfRangeException(nameof(sortByColumn), "Unknown column " + sortByColumn);

            using (var connection = new SqlConnection(configuration.GetConnectionString("AdvertConnection")))
            {
                await connection.OpenAsync();

                // For filtering only desired fields.
                var builder = new SqlBuilder();

                // to get dynamic where clauses for filtering desired fields.
                var selector = builder.AddTemplate("select a.* from Adverts a /**where**/");

                var AdvertModel = new Adverts();

                if (!string.IsNullOrEmpty(categoryId))
                {
                    int cId = Convert.ToInt32(categoryId);
                    builder.Where("categoryId = @cId", new { AdvertModel.categoryId });
                    parameters.Add("@cId", cId);
                }

                if (!string.IsNullOrEmpty(price))
                {
                    int prc = Convert.ToInt32(price);
                    builder.Where("price = @prc", new { AdvertModel.price });
                    parameters.Add("@prc", prc);
                }

                if (!string.IsNullOrEmpty(gear))
                {
                    builder.Where("gear = @gear", new { AdvertModel.gear });
                    parameters.Add("@gear", gear);
                }


                if (!string.IsNullOrEmpty(fuel))
                {
                    builder.Where("fuel = @fuel", new { AdvertModel.fuel });
                    parameters.Add("@fuel", fuel);
                }

                response = await connection.QueryAsync<Adverts>(sql: $@"{selector.RawSql} ORDER BY {sortByColumn} {sortDirection} OFFSET @PageSize * (@PageNumber-1) ROWS FETCH NEXT @PageSize ROWS ONLY", param: parameters, commandType: CommandType.Text);

                return response.ToList();
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
