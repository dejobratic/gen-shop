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
    public class DummySupplierRepositoryTests :
        BaseRepositoryTests<Supplier>
    {
        [TestMethod]
        public override async Task Able_to_get_existing_entity()
        {
            var supplier = SupplierMockBuilder.Build();
            await _sut.Save(supplier);

            var actual = await _sut.Get(supplier.Id);

            actual.Should().Be(supplier);
        }

        [TestMethod]
        public override async Task Able_to_update_existing_entity()
        {
            var supplier = SupplierMockBuilder.Build();
            await _sut.Save(supplier);
            await _sut.Save(supplier);

            var actual = await _sut.Get(supplier.Id);

            actual.Should().Be(supplier); ;
        }

        protected override void CreateSut()
            => _sut = new DummySupplierRepository();
    }
}
