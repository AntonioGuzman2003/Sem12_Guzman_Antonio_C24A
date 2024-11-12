using Microsoft.EntityFrameworkCore;

namespace Semana11.Models
{
    public class InvoiceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DELL\\SQLEXPRESS; Database=Apisemana11; Integrated Security=True;Trust Server Certificate=True ");
        }
    }
}
