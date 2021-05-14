using FluentAssertions;
using GenShop.Invoicing.Domain.Models.VATRateCalculation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenShop.Invoicing.Domain.Tests.Unit.Models.VATRateCalculation
{
    [TestClass]
    [TestCategory("Unit")]
    public class VATRateCalculationResultTests
    {
        [TestMethod]
        public void Able_to_create_success_result()
        {
            var actual = VATRateCalculationResult.Success(0.5);

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(0.5);
        }

        [TestMethod]
        public void Able_to_create_failure_result()
        {
            var actual = VATRateCalculationResult.Failure();

            actual.IsSuccess.Should().BeFalse();
            actual.Value.Should().Be(0);
        }
    }
}
