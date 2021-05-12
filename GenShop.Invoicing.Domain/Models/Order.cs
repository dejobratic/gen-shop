using GenShop.Invoicing.Domain.Kernel;
using System;

namespace GenShop.Invoicing.Domain.Models
{
    public class Order :
        Entity<Guid>
    {
        public Guid CustomerId { get; }
        public Guid ProductId { get;  }

        public Order(
            Guid customerId, 
            Guid productId)
            : base(Guid.NewGuid())
        {
            CustomerId = customerId;
            ProductId = productId;
        }
    }
}
