namespace Semana11.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        // Llave foranea

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
