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
    public class DummyProductRepositoryTests :
        BaseRepositoryTests<Product>
    {
        [TestMethod]
        public override async Task Able_to_get_existing_entity()
        {
            var product = ProductMockBuilder.Build();
            await _sut.Save(product);

            var actual = await _sut.Get(product.Id);

            actual.Should().Be(product);
        }

        [TestMethod]
        public override async Task Able_to_update_existing_entity()
        {
            var product = ProductMockBuilder.Build();
            await _sut.Save(product);
            await _sut.Save(product);

            var actual = await _sut.Get(product.Id);

            actual.Should().Be(product); ;
        }

        protected override void CreateSut()
            => _sut = new DummyProductRepository();
    }
}
