using FluentAssertions;
using GenShop.Invoicing.App.UseCases;
using GenShop.Invoicing.Contract.Requests;
using GenShop.Invoicing.Domain.Repositories;
using GenShop.Invoicing.Domain.Tests.Unit.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Threading.Tasks;

using Contract = GenShop.Invoicing.Contract.Models;

namespace GenShop.Invoicing.App.Tests.Unit.UseCases
{
    [TestClass]
    [TestCategory("Unit")]
    public class GetInvoiceUseCaseTests
    {
        [TestMethod]
        public void Able_to_create_instance()
        {
            _ = new GetInvoiceUseCase(
                Substitute.For<IInvoiceRepository>());
        }

        [TestMethod]
        public async Task Able_to_get_invoice()
        {
            var invoiceId = Guid.NewGuid();

            var invoice = InvoiceMockBuilder.Build(id: invoiceId);
            var invoiceRepo = Substitute.For<IInvoiceRepository>();
            invoiceRepo.Get(Arg.Any<Guid>()).Returns(invoice);

            var sut = new GetInvoiceUseCase(invoiceRepo);
            var actual = await sut.Execute(new GetInvoiceRequest());
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
