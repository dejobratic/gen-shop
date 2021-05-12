using GenShop.Invoicing.Domain.Models;
using System;

namespace GenShop.Invoicing.Domain.Tests.Unit.Fakes
{
    public static class ProductMockBuilder
    {
        public static Product Build(
            string name = "Clean Code",
            double amount = 30,
            Guid? supplierId = null)
        {
            return new Product(
                name, 
                amount, 
                supplierId ?? Guid.NewGuid());
        }
    }
}
