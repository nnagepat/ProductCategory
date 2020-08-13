using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCategoryService.Model
{
    /// <summary>
    /// Model class for Products
    /// </summary>
    public class Product
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public decimal Price { get; set; }
    }
}

        