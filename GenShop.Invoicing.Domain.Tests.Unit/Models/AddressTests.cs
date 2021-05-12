using FluentAssertions;
using GenShop.Invoicing.Domain.Models;
using GenShop.Invoicing.Domain.Tests.Unit.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenShop.Invoicing.Domain.Tests.Unit.Models
{
    [TestClass]
    [TestCategory("Unit")]
    public class AddressTests
    {
        [TestMethod]
        public void Able_to_create_instance()
        {
            var expectedStreetLine = "Hermanstrasse 35a";
            var expectedCity = "Augsburg";
            var expectedPostalCode = "86154";
            var expectedCountry = CountryMockBuilder.BuildGermany();

            var actual = new Address(
                expectedStreetLine,
                expectedCity,
                expectedPostalCode,
                expectedCountry);

            actual.StreetLine.Should().Be(expectedStreetLine);
            actual.City.Should().Be(expectedCity);
            actual.PostalCode.Should().Be(expectedPostalCode);
            actual.Country.Should().Be(expectedCountry);
        }
    }
}
