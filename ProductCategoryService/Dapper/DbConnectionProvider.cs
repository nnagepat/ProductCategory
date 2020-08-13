using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

using System.Data;
using System.Data.SqlClient;

namespace ProductCategoryService.Dapper
{
    /// <summary>
    /// Class for getting Db connection object
    /// </summary>
    public class DbConnectionProvider : IDbConnectionProvider
    {
        private readonly IConfiguration _configuration;
        public DbConnectionProvider(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public IDbConnection GetDbConnection()
        {
            string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            return new SqlConnection(connectionString);
        }
    }
}
