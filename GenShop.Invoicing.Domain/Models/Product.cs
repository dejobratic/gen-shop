using GenShop.Invoicing.Domain.Kernel;
using System;

namespace GenShop.Invoicing.Domain.Models
{
    public class Product :
        Entity<Guid>
    {
        public string Description { get; }
        public double Amount { get; }
        public Guid SupplierId { get; }

        public Product(
            string description,
            double amount,
            Guid supplierId)
            : this(
                  Guid.NewGuid(),
                  description,
                  amount,
                  supplierId)
        {

        }

        public Product(
            Guid id,
            string description,
            double amount,
            Guid supplierId)
            : base(id)
        {
            Description = description;
            Amount = amount;
            SupplierId = supplierId;
        }
    }
}
