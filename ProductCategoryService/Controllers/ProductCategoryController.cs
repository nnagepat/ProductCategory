using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductCategoryService.Model;
using ProductCategoryService.Repository;
using System.Collections.Generic;

namespace ProductCategoryService.Controllers
{
    /// <summary>
    /// API controller class 
    /// </summary>
    [ApiController]
    [Route("API/[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ILogger<ProductCategoryController> _logger;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryController(ILogger<ProductCategoryController> logger,
            IProductCategoryRepository productCategoryRepository)
        {
            _logger = logger;
            _productCategoryRepository = productCategoryRepository;
        }

        /// <summary>
        /// API method to get product categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public ActionResult<List<ProductCategory>> GetProductCategories()
        {
            try
            {
                var productCategories = _productCategoryRepository.GetProductCategories();
                return Ok(productCategories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// API method to get products by category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProducts/{categoryId}")]
        public ActionResult<List<Product>> GetProducts(int categoryId)
        {
            try
            {
                var products = _productCategoryRepository.GetProductsByCategory(categoryId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }


        /// <summary>
        /// API method to get featured products
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFeaturedProducts")]
        public ActionResult<List<Product>> GetProducts()
        {
            try
            {
                var products = _productCategoryRepository.GetFeaturedProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}



