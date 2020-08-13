using ProductCategoryService.Model;
using System.Collections.Generic;

namespace ProductCategoryService.Repository
{
    /// <summary>
    /// Interface for Product Category Repository
    /// </summary>
    public interface IProductCategoryRepository
    {
        List<Product> GetFeaturedProducts();
        List<ProductCategory> GetProductCategories();
        List<Product> GetProductsByCategory(int categoryId);
    }
}