using FluentAssertions;
using GenShop.Invoicing.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenShop.Invoicing.Domain.Tests.Unit.Models
{
    [TestClass]
    [TestCategory("Unit")]
    public class CountryTests
    {
        [TestMethod]
        public void Able_to_create_instance()
        {
            var expectedName = "Germany";
            var expectedIso2Code = "DE";
            var expectedVATRate = 0.2;
            var expectedInEU = true;

            var actual = new Country(
                expectedName,
                expectedIso2Code,
                expectedVATRate,
                expectedInEU);

            actual.Name.Should().Be(expectedName);
            actual.Iso2Code.Should().Be(expectedIso2Code);
            actual.VATRate.Should().Be(expectedVATRate);
            actual.InEU.Should().Be(expectedInEU);
        }
    }
}
