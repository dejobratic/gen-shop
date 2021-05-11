using System;

namespace GenShop.Invoicing.Domain.Models
{
    public class Order
    {
        public Guid CustomerId { get; set; }
        public Guid SupplierId { get; set; }
        public Guid ProductId { get; set; }
    }
}
