using FluentAssertions;
using GenShop.Invoicing.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenShop.Invoicing.Domain.Tests.Unit.Models
{
    [TestClass]
    [TestCategory("Unit")]
    public class SupplierTests
    {
        [TestMethod]
        public void Able_to_create_instance()
        {
            var expectedFullName = "Gen Shop Supplier #1";
            var expectedPaysVAT = true;

            var actual = new Supplier(
                expectedFullName,
                expectedPaysVAT);

            actual.FullName.Should().Be(expectedFullName);
            actual.PaysVAT.Should().Be(expectedPaysVAT);
        }
    }
}
