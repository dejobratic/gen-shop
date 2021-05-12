using System;

namespace GenShop.Invoicing.Contract.Models
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public DateTime CreatedAt { get; set; }
        public Contact Issuer { get; set; }
        public Contact Receiver { get; set; }
        public InvoiceItem[] Items { get; set; }
        public InvoiceAmount Amount { get; set; }

        public Invoice()
        {
            Items = Array.Empty<InvoiceItem>();
        }
    }
}
