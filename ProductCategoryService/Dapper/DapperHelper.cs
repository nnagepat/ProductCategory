using Dapper;
using ProductCategoryService.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCategoryService.Dapper
{
    public class DapperHelper : IDapperHelper
    {
        private readonly IDbConnectionProvider _connectionProvider;

        public DapperHelper(IDbConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        /// <summary>
        /// Method to get featured products
        /// </summary>
        /// <returns></returns>
        public List<Product> GetFeaturedProducts()
        {
            using (var connection = _connectionProvider.GetDbConnection())
            {
                var productCategories = connection.Query<Product>("spGetFeaturedProducts",
                    commandType: CommandType.StoredProcedure).ToList();
                return productCategories;
            }
        }

        /// <summary>
        /// Method to get product categories
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> GetProductCategories()
        {
            using (var connection = _connectionProvider.GetDbConnection())
            {
                var productCategories = connection.Query<ProductCategory>("spGetProductCategories",
                    commandType: CommandType.StoredProcedure).ToList();
                return productCategories;
            }
        }

        /// <summary>
        /// Method to get products by category
        /// </summary>
        /// <param name="categoryId">
        /// Category Id
        /// </param>
        /// <returns></returns>
        public List<Product> GetProductsByCategory(int categoryId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProductCategoryId", categoryId);  

            using (var connection = _connectionProvider.GetDbConnection())
            {
                var productCategories = connection.Query<Product>("spGetProductsByCategory",
                    parameters,commandType: CommandType.StoredProcedure).ToList();
                return productCategories;
            }
        }
    }
}
