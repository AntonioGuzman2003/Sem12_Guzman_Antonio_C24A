using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semana11.Models;

namespace Semana11.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public ProductsController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        [HttpGet("{id}")]
        public Product GetById(int Id)
        {
            return  _context.Products.Where(x => x.ProductID == Id).FirstOrDefault();
        }
       

    

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult PutProducto(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            var existingProduct = _context.Products.Find(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public void Insert(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                NotFound();
            }
            product.Active = false;
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

        }


        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
