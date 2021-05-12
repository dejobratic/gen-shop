using GenShop.Invoicing.Domain.Kernel;
using System;

namespace GenShop.Invoicing.Domain.Models
{
    public class Product :
        Entity<Guid>
    {
        public string Description { get; }
        public double Amount { get; }

        public Product(
            string description,
            double amount)
            : base(Guid.NewGuid())
        {
            Description = description;
            Amount = amount;
        }
    }
}
