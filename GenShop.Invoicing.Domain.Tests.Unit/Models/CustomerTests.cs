﻿using FluentAssertions;
using GenShop.Invoicing.Domain.Models;
using GenShop.Invoicing.Domain.Tests.Unit.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenShop.Invoicing.Domain.Tests.Unit.Models
{
    [TestClass]
    [TestCategory("Unit")]
    public class CustomerTests
    {
        [TestMethod]
        public void Able_to_create_instance()
        {
            var expectedFullName = "John Smith";
            var expectedAddress = AddressMockBuilder.BuildMontenegro();
            var expectedPaysVAT = true;

            var actual = new Customer(
                expectedFullName,
                expectedAddress,
                expectedPaysVAT);

            actual.Id.Should().NotBeEmpty();
            actual.FullName.Should().Be(expectedFullName);
            actual.Address.Should().Be(expectedAddress);
            actual.PaysVAT.Should().Be(expectedPaysVAT);
            actual.InEU.Should().Be(false);
        }
    }
}