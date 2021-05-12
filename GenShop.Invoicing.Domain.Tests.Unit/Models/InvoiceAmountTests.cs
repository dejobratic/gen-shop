using FluentAssertions;
using GenShop.Invoicing.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenShop.Invoicing.Domain.Tests.Unit.Models
{
    [TestClass]
    [TestCategory("Unit")]
    public class InvoiceAmountTests
    {
        [TestMethod]
        public void Able_to_create_instance()
        {
            var expectedSubtotal = 10.0;
            var expectedVATRate = 0.2;
            var expectedVAT = 2.0;
            var expectedTotal = 12.0;

            var actual = new InvoiceAmount(
                expectedSubtotal,
                expectedVATRate);

            actual.Subtotal.Should().Be(expectedSubtotal);
            actual.VATRate.Should().Be(expectedVATRate);
            actual.VAT.Should().Be(expectedVAT);
            actual.Total.Should().Be(expectedTotal);
        }
    }
}
