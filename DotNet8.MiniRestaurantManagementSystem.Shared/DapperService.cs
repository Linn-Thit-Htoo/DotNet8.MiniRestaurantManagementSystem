using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.MiniRestaurantManagementSystem.Shared
{
    public class DapperService
    {
        private readonly IConfiguration _configuration;

        public DapperService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object? parameters = null)
        {
            using IDbConnection db = GetSqlConnection();
            var lst = await db.QueryAsync<T>(query, parameters);

            return lst;
        }

        private SqlConnection GetSqlConnection() => new(_configuration.GetConnectionString("DbConnection"));
    }
}
