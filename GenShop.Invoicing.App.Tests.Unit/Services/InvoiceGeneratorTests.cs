using FluentAssertions;
using GenShop.Invoicing.App.Services;
using GenShop.Invoicing.Domain.Models;
using GenShop.Invoicing.Domain.Tests.Unit.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Threading.Tasks;

namespace GenShop.Invoicing.App.Tests.Unit.Services
{
    [TestClass]
    [TestCategory("Unit")]
    public class InvoiceGeneratorTests
    {
        [TestMethod]
        public void Able_to_create_instance()
        {
            _ = new InvoiceGenerator(
                Substitute.For<IProductRepository>(),
                Substitute.For<ISupplierRepository>(),
                Substitute.For<ICustomerRepository>());
        }

        [TestMethod]
        public async Task Able_to_generate_invoice()
        {
            var product = ProductMockBuilder.Build();
            var productRepo = Substitute.For<IProductRepository>();
            productRepo.Get(Arg.Any<Guid>()).Returns(product);

            var supplier = SupplierMockBuilder.Build();
            var supplierRepo = Substitute.For<ISupplierRepository>();
            supplierRepo.Get(Arg.Any<Guid>()).Returns(supplier);

            var customer = CustomerMockBuilder.Build();
            var customerRepo = Substitute.For<ICustomerRepository>();
            customerRepo.Get(Arg.Any<Guid>()).Returns(customer);

            var sut = new InvoiceGenerator(productRepo, supplierRepo, customerRepo);
            var actual = await sut.Generate(OrderMockBuilder.Build());

            actual.Customer.Should().Be(customer);
            actual.Supplier.Should().Be(supplier);
            actual.Product.Should().Be(product);
            actual.Amount.Should().Be(new InvoiceAmount(30, 0.19));
        }
    }
}
