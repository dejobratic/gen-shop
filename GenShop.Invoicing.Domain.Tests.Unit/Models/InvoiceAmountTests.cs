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

        [TestMethod]
        public void All_numbers_should_be_rounded_to_two_decimals()
        {
            var expectedSubtotal = 10.01;
            var expectedVATRate = 0.2;
            var expectedVAT = 2.0;
            var expectedTotal = 12.01;

            var actual = new InvoiceAmount(
                10.0099,
                0.1999);

            actual.Subtotal.Should().Be(expectedSubtotal);
            actual.VATRate.Should().Be(expectedVATRate);
            actual.VAT.Should().Be(expectedVAT);
            actual.Total.Should().Be(expectedTotal);
        }
    }
}
