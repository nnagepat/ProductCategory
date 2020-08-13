using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ProductCategoryService.Model;
using ProductCategoryService.Dapper;

namespace ProductCategoryService.Repository
{
    /// <summary>
    /// Repository class for Database operations.
    /// </summary>
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly IDapperHelper _dapperHelper;

        public ProductCategoryRepository(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }


        /// <summary>
        /// Method to get Product categories
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> GetProductCategories()
        {
            return _dapperHelper.GetProductCategories();
        }

        /// <summary>
        /// Method to get Products by Category
        /// </summary>
        /// <param name="categoryId">
        /// Category Id
        /// </param>
        /// <returns></returns>
        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _dapperHelper.GetProductsByCategory(categoryId);
        }

        /// <summary>
        ///  Method to get featured products
        /// </summary>
        /// <returns></returns>
        public List<Product> GetFeaturedProducts()
        {
            return _dapperHelper.GetFeaturedProducts();
        }
    }

}
