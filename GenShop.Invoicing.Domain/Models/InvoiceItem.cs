using GenShop.Invoicing.Domain.Kernel;

namespace GenShop.Invoicing.Domain.Models
{
    public class InvoiceItem :
        ValueObject<InvoiceItem>
    {
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}
