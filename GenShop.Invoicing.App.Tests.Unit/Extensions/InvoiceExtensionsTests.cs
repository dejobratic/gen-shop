using FluentAssertions;
using GenShop.Invoicing.App.Extensions;
using GenShop.Invoicing.Domain.Tests.Unit.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using Contract = GenShop.Invoicing.Contract.Models;

namespace GenShop.Invoicing.App.Tests.Unit.Extensions
{
    [TestClass]
    [TestCategory("Unit")]
    public class InvoiceExtensionsTests
    {
        [TestMethod]
        public void Able_to_map_domain_to_contract_model()
        {
            var invoiceId = Guid.NewGuid();
            var invoice = InvoiceMockBuilder.Build(id: invoiceId);

            var actual = invoice.ToContractModel();
            var expected = CreateExpectedInvoice(id: invoiceId);

            actual.Should().BeEquivalentTo(expected);
        }

        private static Contract::Invoice CreateExpectedInvoice(
            Guid id)
        {
            return new Contract::Invoice
            {
                Id = id,
                Number = "Invoice #",
                CreatedAt = DateTime.UtcNow.Date,
                Issuer = new Contract::Contact
                {
                    FullName = "Gen Shop Supplier #1",
                    Address = new Contract::Address
                    {
                        StreetLine = "Hermanstrasse 35a",
                        City = "Augsburg",
                        PostalCode = "86154",
                        Country = "Germany"
                    }
                },
                Receiver = new Contract::Contact
                {
                    FullName = "John Smith",
                    Address = new Contract::Address
                    {

                        StreetLine = "Champs-Élysées",
                        City = "Paris",
                        PostalCode = "75008",
                        Country = "France"
                    }
                },
                Items = new[]
                {
                    new Contract::InvoiceItem
                    {
                        Description = "Clean Code",
                        Amount = 30
                    }
                },
                Amount = new Contract::InvoiceAmount
                {
                    Subtotal = 30,
                    VAT = 5.7,
                    Total = 35.7
                }
            };
        }
    }
}
