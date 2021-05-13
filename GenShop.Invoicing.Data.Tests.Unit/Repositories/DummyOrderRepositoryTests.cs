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
    public class DummyOrderRepositoryTests :
        BaseRepositoryTests<Order>
    {
        [TestMethod]
        public override async Task Able_to_get_existing_entity()
        {
            var order = OrderMockBuilder.Build();
            await _sut.Save(order);

            var actual = await _sut.Get(order.Id);

            actual.Should().Be(order);
        }

        [TestMethod]
        public override async Task Able_to_update_existing_entity()
        {
            var order = OrderMockBuilder.Build();
            await _sut.Save(order);
            await _sut.Save(order);

            var actual = await _sut.Get(order.Id);

            actual.Should().Be(order); ;
        }

        protected override void CreateSut()
            => _sut = new DummyOrderRepository();
    }
}
