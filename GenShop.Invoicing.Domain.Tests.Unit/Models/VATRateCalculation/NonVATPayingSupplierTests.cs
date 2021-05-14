using FluentAssertions;
using GenShop.Invoicing.Domain.Models.VATRateCalculation;
using GenShop.Invoicing.Domain.Tests.Unit.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenShop.Invoicing.Domain.Tests.Unit.Models.VATRateCalculation
{
    [TestClass]
    [TestCategory("Unit")]
    public class NonVATPayingSupplierTests
    {
        private NonVATPayingSupplier _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new NonVATPayingSupplier();
        }

        [TestMethod]
        public void Returns_success_result_for_non_VAT_paying_supplier()
        {
            var supplier = SupplierMockBuilder.Build(
                address: AddressMockBuilder.BuildGermany(),
                paysVat: false);

            var customer = CustomerMockBuilder.Build(
                address: AddressMockBuilder.BuildGermany(),
                paysVat: true);

            var actual = _sut.Execute(supplier, customer);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(0);
        }

        [TestMethod]
        public void Returns_failure_result_for_VAT_paying_supplier()
        {
            var supplier = SupplierMockBuilder.Build(
                address: AddressMockBuilder.BuildGermany(),
                paysVat: true);

            var customer = CustomerMockBuilder.Build(
                address: AddressMockBuilder.BuildGermany(),
                paysVat: true);

            var actual = _sut.Execute(supplier, customer);

            actual.IsSuccess.Should().BeFalse();
            actual.Value.Should().Be(0);
        }
    }
}
