using FluentAssertions;
using GenShop.Invoicing.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenShop.Invoicing.Domain.Tests.Unit.Models
{
    [TestClass]
    [TestCategory("Unit")]
    public class ProductTests
    {
        [TestMethod]
        public void Able_to_create_instance()
        {
            var expectedDescription = "Clean Code";
            var expectedAmount = 30.0;
            var expectedSupplierId = Guid.NewGuid();

            var actual = new Product(
                expectedDescription,
                expectedAmount,
                expectedSupplierId);

            actual.Id.Should().NotBeEmpty();
            actual.Description.Should().Be(expectedDescription);
            actual.Amount.Should().Be(expectedAmount);
            actual.SupplierId.Should().Be(expectedSupplierId);
        }

        [TestMethod]
        public void Able_to_create_instance_with_persistence_constructor()
        {
            var expectedId = Guid.NewGuid();
            var expectedDescription = "Clean Code";
            var expectedAmount = 30.0;
            var expectedSupplierId = Guid.NewGuid();

            var actual = new Product(
                expectedId,
                expectedDescription,
                expectedAmount,
                expectedSupplierId);

            actual.Id.Should().Be(expectedId);
            actual.Description.Should().Be(expectedDescription);
            actual.Amount.Should().Be(expectedAmount);
            actual.SupplierId.Should().Be(expectedSupplierId);
        }
    }
}
