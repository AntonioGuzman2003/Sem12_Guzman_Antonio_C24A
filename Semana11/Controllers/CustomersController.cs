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
    public class CustomersController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public CustomersController(InvoiceContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public List <Customer> GetCustomers()
        {
            return  _context.Customers.ToList();
        }

        // GET: api/Customers
        [HttpGet("{id}")]
        public Customer  GetById(int Id)
        {
            return _context.Customers.Where(x => x.CustomerID == Id).FirstOrDefault();


        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id,Customer customer)
        {
            if (id != customer.CustomerID)
            {
                return NotFound();
            }

            var existingCustomer = _context.Customers.Find(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            _context.Entry(existingCustomer).CurrentValues.SetValues(customer);
            _context.SaveChanges();

            return NoContent();
        }

        

        // POST: api/Customers
        [HttpPost]
        public void Insert(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
            var customer =  _context.Customers.Find(id);
            if (customer == null)
            {
                 NotFound();
            }
            customer.Active = false;
            _context.Entry(customer).State = EntityState.Modified;
             _context.SaveChanges();

        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerID == id);
        }
    }
}
