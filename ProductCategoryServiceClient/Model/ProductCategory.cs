using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCategoryServiceClient.Model
{
    /// <summary>
    /// Model class for Product Category
    /// </summary>
    public class ProductCategory
    {
        public string Name { get; set; }

        public static implicit operator List<object>(ProductCategory v)
        {
            throw new NotImplementedException();
        }
    }
}
