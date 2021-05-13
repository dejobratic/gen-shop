using FluentAssertions;
using GenShop.Invoicing.Data.Repositories;
using GenShop.Invoicing.Domain.Exceptions;
using GenShop.Invoicing.Domain.Models;
using GenShop.Invoicing.Domain.Tests.Unit.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace GenShop.Invoicing.Data.Tests.Unit.Repositories
{
    [TestClass]
    [TestCategory("Unit")]
    public class DummyInvoiceRepositoryTests :
        BaseRepositoryTests<Invoice>
    {
        [TestMethod]
        public override async Task Able_to_get_existing_entity()
        {
            var invoice = InvoiceMockBuilder.Build();
            await _sut.Save(invoice);

            var actual = await _sut.Get(invoice.Id);

            actual.Should().Be(invoice);
        }

        [TestMethod]
        public override async Task Able_to_update_existing_entity()
        {
            var invoice = InvoiceMockBuilder.Build();
            await _sut.Save(invoice);
            await _sut.Save(invoice);

            var actual = await _sut.Get(invoice.Id);

            actual.Should().Be(invoice); ;
        }

        [TestMethod]
        public async Task Throws_exception_when_trying_to_save_invoice_wit_existing_order()
        {
            var order = OrderMockBuilder.Build();

            var firstInvoice = InvoiceMockBuilder.Build(order: order);
            await _sut.Save(firstInvoice);

            var secondInvoice = InvoiceMockBuilder.Build(order: order);
            Func<Task> action = () => _sut.Save(secondInvoice);

            action.Should().Throw<EntityAlreadyExistsException>()
                .WithMessage("Invoice already exists.");
        }

        protected override void CreateSut()
            => _sut = new DummyInvoiceRepository();

    }
}
