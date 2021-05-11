using System;

namespace GenShop.Invoicing.Domain.Models
{
    public class Invoice
    {
        public string Number { get; set; }
        public DateTime CreatedAt { get; set; }
        public Customer BillTo { get; set; }
        public Product Product { get; set; }
        public InvoiceAmount Amount { get; set; }

    }
}
