using FluentAssertions;
using GenShop.Invoicing.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenShop.Invoicing.Domain.Tests.Unit.Models
{
    [TestClass]
    [TestCategory("Unit")]
    public class IndividualTests
    {
        [TestMethod]
        public void Able_to_create_instance()
        {
            var expectedFullName = "John Smith";
            var expectedPaysVAT = true;

            var actual = new Individual(
                expectedFullName,
                expectedPaysVAT);

            actual.FullName.Should().Be(expectedFullName);
            actual.PaysVAT.Should().Be(expectedPaysVAT);
        }
    }
}
