using ProductCategoryServiceClient.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductCategoryServiceClient
{
    /// <summary>
    /// Client test class to test Service api methods
    /// </summary>
    public class ServiceTestClient
    {
        private const string _getCategoriesEndPoint = "API/ProductCategory";
        private const string _getProductsByCategoryEndPoint = "API/ProductCategory/GetProducts/3";
        private const string _getFeaturedProductsEndPoint = "API/ProductCategory/GetFeaturedProducts";
        private const string _baseAddress = "http://localhost:50314/";

        private HttpClient _client;


        /// <summary>
        /// Method for testing api services
        /// </summary>
        public void TestService()
        {
            GetCategoriesTest().Wait();
            GetProductsByCategoryTest().Wait();
            GetFeaturedProductTest().Wait();
            Console.ReadLine();
        }

        /// <summary>
        /// method to test API service GetCategories 
        /// </summary>
        private async Task<List<ProductCategory>> GetCategoriesTest()
        {
            List<ProductCategory> categories = null;
            int recordCount = 0;
            try 
            {
                Console.WriteLine("Invoking GetCategories method");
                
                using (_client = new HttpClient())
                {
                    _client.BaseAddress = new Uri(_baseAddress);

                    HttpResponseMessage response = await _client.GetAsync(_getCategoriesEndPoint); 
                    if(response.IsSuccessStatusCode)
                    {
                         categories = await response.Content.ReadAsAsync<List<ProductCategory>>();
                        if (categories != null)
                        {
                            recordCount = categories.Count;
                        }

                        Console.WriteLine("No of categories returned - {0}", recordCount);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());  
            }

            return categories;
        }

        /// <summary>
        ///  methGetCategoriesTest()od to test API service GetProductsByCategory
        /// </summary>
        private async Task<List<Product>> GetProductsByCategoryTest()
        {
            List<Product> products = null;
            int recordCount = 0;
            try
            {
                Console.WriteLine("Invoking GetProductsByCategory method");

                using (_client = new HttpClient())
                {
                    _client.BaseAddress = new Uri(_baseAddress);

                    HttpResponseMessage response = await _client.GetAsync(_getProductsByCategoryEndPoint);
                    if (response.IsSuccessStatusCode)
                    {
                        products = await response.Content.ReadAsAsync<List<Product>>();
                        if (products != null)
                        {
                            recordCount = products.Count;
                        }
                        Console.WriteLine("No of Products returned - {0}", recordCount);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return products;
        }

        /// <summary>
        /// method to test API service GetFeaturedProduct
        /// </summary>
        private async Task<List<Product>> GetFeaturedProductTest()
        {
            List<Product> products = null;
            int recordCount = 0;
            try
            {
                Console.WriteLine("Invoking GetFeaturedProduct method");

                using (_client = new HttpClient())
                {
                    _client.BaseAddress = new Uri(_baseAddress);

                    HttpResponseMessage response = await _client.GetAsync(_getFeaturedProductsEndPoint);
                    if (response.IsSuccessStatusCode)
                    {
                        products = await response.Content.ReadAsAsync<List<Product>>();
                        if (products != null)
                        {
                            recordCount = products.Count;
                        }
                        Console.WriteLine("No of Products returned - {0}", recordCount);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return products;
        }

    }



}
