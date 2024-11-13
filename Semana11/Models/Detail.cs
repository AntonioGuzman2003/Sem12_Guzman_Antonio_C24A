namespace Semana11.Models
{
    public class Detail
    {
        public int DetailId { get; set; }
        public string Amount { get; set; }
        public string Price { get; set; }
        public string SubTotal { get; set; }

        // Llave foranea

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
