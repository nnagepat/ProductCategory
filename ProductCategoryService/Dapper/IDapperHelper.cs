using ProductCategoryService.Model;
using System.Collections.Generic;

namespace ProductCategoryService.Dapper
{
    public interface IDapperHelper
    {
        List<Product> GetFeaturedProducts();
        List<ProductCategory> GetProductCategories();
        List<Product> GetProductsByCategory(int categoryId);
    }
}