using FluentAssertions;
using GenShop.Invoicing.App.Services;
using GenShop.Invoicing.App.UseCases;
using GenShop.Invoicing.Contract.Requests;
using GenShop.Invoicing.Domain.Models;
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
    public class GenerateInvoiceUseCaseTests
    {
        [TestMethod]
        public void Able_to_create_instance()
        {
            _ = new GenerateInvoiceUseCase(
                Substitute.For<IOrderRepository>(),
                Substitute.For<IInvoiceGenerator>(),
                Substitute.For<IInvoiceRepository>());
        }

        [TestMethod]
        public async Task Able_to_generate_invoice()
        {
            var invoiceId = Guid.NewGuid();

            var orderRepo = Substitute.For<IOrderRepository>();
            orderRepo.Get(Arg.Any<Guid>()).Returns(OrderMockBuilder.Build());

            var invoice = InvoiceMockBuilder.Build(id: invoiceId);
            var invoiceGen = Substitute.For<IInvoiceGenerator>();
            invoiceGen.Generate(Arg.Any<Order>()).Returns(invoice);

            var invoiceRepo = Substitute.For<IInvoiceRepository>();

            var sut = new GenerateInvoiceUseCase(orderRepo, invoiceGen, invoiceRepo);
            var actual = await sut.Execute(new GenerateInvoiceRequest());
            var expected = CreateExpectedInvoice(id: invoiceId);

            actual.Should().BeEquivalentTo(expected);
            await invoiceRepo.Received().Save(invoice);
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
