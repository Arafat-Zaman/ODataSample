using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ODataSample.Controllers
{
    public class ProductsController : ODataController
    {
        private static readonly List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000, Category = "Electronics" },
            new Product { Id = 2, Name = "Phone", Price = 500, Category = "Electronics" },
            new Product { Id = 3, Name = "Table", Price = 100, Category = "Furniture" },
        };

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(Products.AsQueryable());
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            var product = Products.SingleOrDefault(p => p.Id == key);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
