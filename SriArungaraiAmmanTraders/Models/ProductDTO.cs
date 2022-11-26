using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SriArungaraiAmmanTraders.Models
{
    public partial class Product
    {
        private readonly NutritionDBContext dB;
        public Product()
        {
            dB = new NutritionDBContext();
        }

        public List<Product> ListProducts()
        {
            var ListOfProducts = dB.Products.ToList();
            return ListOfProducts;
        }

        
    }
}



