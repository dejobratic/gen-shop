using GenShop.Invoicing.Domain.Models;
using System;

namespace GenShop.Invoicing.Domain.Tests.Unit.Fakes
{
    public static class OrderMockBuilder
    {
        public static Order Build(
            Guid? customerId = null,
            Guid? productId = null)
        {
            return new Order(
                customerId ?? Guid.NewGuid(),
                productId ?? Guid.NewGuid());
        }
    }
}
