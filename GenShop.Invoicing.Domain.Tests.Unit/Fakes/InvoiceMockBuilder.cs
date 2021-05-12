using GenShop.Invoicing.Domain.Models;
using System;

namespace GenShop.Invoicing.Domain.Tests.Unit.Fakes
{
    public static class InvoiceMockBuilder
    {
        public static Invoice Build(
            Guid? id = null,
            string number = "Invoice #",
            DateTime? createdAt = null,
            Product product = null,
            Supplier supplier = null,
            Customer customer = null,
            InvoiceAmount amount = null)
        {
            return new Invoice(
                id ?? Guid.NewGuid(),
                number,
                createdAt ?? DateTime.UtcNow.Date,
                supplier ?? SupplierMockBuilder.Build(),
                customer ?? CustomerMockBuilder.Build(),
                product ?? ProductMockBuilder.Build(),
                amount ?? new InvoiceAmount(30, 0.19));
        }
    }
}
