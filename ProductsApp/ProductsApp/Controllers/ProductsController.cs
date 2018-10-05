using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductsApp.Models;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Rachel", Category = "Groceries", Price = 3 },
            new Product { Id = 2, Name = "Nigella", Category = "Toys", Price = 3.88M },
            new Product { Id = 3, Name = "Justeene", Category = "Hardware", Price = 20.99M }
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        public object Post([FromBody]Product model)
        {
            try
            {
                var product = new Product(){Id = model.Id, Category = model.Category, Name = model.Name, Price = model.Price};
                products.ToList().Add(product);
                return null;
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Put([FromBody]Product model)
        {
            var product = products.FirstOrDefault((p) => p.Id == model.Id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        public IHttpActionResult Delete(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
