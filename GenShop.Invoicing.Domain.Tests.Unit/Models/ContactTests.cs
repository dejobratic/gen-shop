using FluentAssertions;
using GenShop.Invoicing.Domain.Models;
using GenShop.Invoicing.Domain.Tests.Unit.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenShop.Invoicing.Domain.Tests.Unit.Models
{
    [TestClass]
    [TestCategory("Unit")]
    public class ContactTests
    {
        [TestMethod]
        public void Able_to_create_instance()
        {
            var expectedFullName = "Contact Name";
            var expectedAddress = AddressMockBuilder.BuildGermany();

            var actual = new Contact(
                expectedFullName,
                expectedAddress);

            actual.FullName.Should().Be(expectedFullName);
            actual.Address.Should().Be(expectedAddress);
        }
    }
}
