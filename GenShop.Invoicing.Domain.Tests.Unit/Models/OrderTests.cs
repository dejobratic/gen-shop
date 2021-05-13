using FluentAssertions;
using GenShop.Invoicing.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenShop.Invoicing.Domain.Tests.Unit.Models
{
    [TestClass]
    [TestCategory("Unit")]
    public class OrderTests
    {
        [TestMethod]
        public void Able_to_create_instance()
        {
            var expectedCustomerId = Guid.NewGuid();
            var expectedProductId = Guid.NewGuid();

            var actual = new Order(
                expectedCustomerId,
                expectedProductId);

            actual.Id.Should().NotBeEmpty();
            actual.CustomerId.Should().Be(expectedCustomerId);
            actual.ProductId.Should().Be(expectedProductId);
        }

        [TestMethod]
        public void Able_to_create_instance_with_persistence_constructor()
        {
            var expectedId = Guid.NewGuid();
            var expectedCustomerId = Guid.NewGuid();
            var expectedProductId = Guid.NewGuid();

            var actual = new Order(
                expectedId,
                expectedCustomerId,
                expectedProductId);

            actual.Id.Should().Be(expectedId);
            actual.CustomerId.Should().Be(expectedCustomerId);
            actual.ProductId.Should().Be(expectedProductId);
        }
    }
}
