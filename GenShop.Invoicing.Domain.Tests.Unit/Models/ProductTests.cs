using FluentAssertions;
using GenShop.Invoicing.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenShop.Invoicing.Domain.Tests.Unit.Models
{
    [TestClass]
    [TestCategory("Unit")]
    public class ProductTests
    {
        [TestMethod]
        public void Able_to_create_instance()
        {
            var description = "Clean Code";
            var amount = 30.0;

            var actual = new Product(
                description,
                amount);

            actual.Description.Should().Be(description);
            actual.Amount.Should().Be(amount);
        }
    }
}
