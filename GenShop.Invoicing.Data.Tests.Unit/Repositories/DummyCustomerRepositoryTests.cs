using FluentAssertions;
using GenShop.Invoicing.Data.Repositories;
using GenShop.Invoicing.Domain.Models;
using GenShop.Invoicing.Domain.Tests.Unit.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace GenShop.Invoicing.Data.Tests.Unit.Repositories
{
    [TestClass]
    [TestCategory("Unit")]
    public class DummyCustomerRepositoryTests :
        BaseRepositoryTests<Customer>
    {
        [TestMethod]
        public override async Task Able_to_get_existing_entity()
        {
            var customer = CustomerMockBuilder.Build();
            await _sut.Save(customer);

            var actual = await _sut.Get(customer.Id);

            actual.Should().Be(customer);
        }

        [TestMethod]
        public override async Task Able_to_update_existing_entity()
        {
            var customer = CustomerMockBuilder.Build();
            await _sut.Save(customer);
            await _sut.Save(customer);

            var actual = await _sut.Get(customer.Id);

            actual.Should().Be(customer); ;
        }

        protected override void CreateSut()
            => _sut = new DummyCustomerRepository();
    }
}
