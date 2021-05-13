using GenShop.Invoicing.Domain.Kernel;
using System;

namespace GenShop.Invoicing.Domain.Models
{
    public class Order :
        Entity<Guid>
    {
        public Guid CustomerId { get; }
        public Guid ProductId { get; }

        public Order(
            Guid customerId,
            Guid productId)
            : this(Guid.NewGuid(), customerId, productId)
        {
        }

        public Order(
            Guid id,
            Guid customerId,
            Guid productId)
            : base(id)
        {
            CustomerId = customerId;
            ProductId = productId;
        }
    }
}
