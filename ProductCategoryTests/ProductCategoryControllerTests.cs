using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductCategoryService.Controllers;
using ProductCategoryService.Model;
using ProductCategoryService.Repository;
using System.Collections.Generic;

namespace ProductCategoryTests
{
    [TestClass]
    public class ProductCategoryControllerTests
    {
        private ProductCategoryController _target;

        private Mock<IProductCategoryRepository> _repository;

        private Mock<ILogger<ProductCategoryController>> _logger;

        private List<ProductCategory> _productCategories;


        public ProductCategoryControllerTests()
        {
            _repository = new Mock<IProductCategoryRepository>();
            _logger = new Mock<ILogger<ProductCategoryController>>();
            _target = new ProductCategoryController(_logger.Object, _repository.Object);

        }

        [TestInitialize]
        public void testInit()
        {
            _productCategories = new List<ProductCategory>()
            {
                new ProductCategory ()
                {

                Name = "testName"

                },
                 new ProductCategory ()
                {

                Name = "testName1"

                }
            };
        }

        /// <summary>
        /// Test method to verify that api method GetProductCategories invokes repository method GetProductCategories
        /// </summary>
        [TestMethod]
        public void GetProductCategories_InvokesRepository_GetProductCategories_Method_Test()
        {
            _repository.Setup(x => x.GetProductCategories()).Returns(_productCategories);
            var testOutput = _target.GetProductCategories();

            Assert.IsNotNull(testOutput);
            _repository.Verify(x => x.GetProductCategories(), Times.Once);
        }


        [TestMethod]
        public void GetProductCategories_Methods_Logs_Error_On_Exception_Test()
        {
            _repository.Setup(x => x.GetProductCategories()).Throws(new System.Exception());
            var testOutput = _target.GetProductCategories();
            Assert.AreEqual(1, _logger.Invocations.Count);
        }
    }
}
