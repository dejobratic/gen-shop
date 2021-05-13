using FluentAssertions;
using GenShop.Invoicing.Domain.Models;
using GenShop.Invoicing.Domain.Tests.Unit.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenShop.Invoicing.Domain.Tests.Unit.Models
{
    [TestClass]
    [TestCategory("Unit")]
    public class JuridicalPersonTests
    {
        [TestMethod]
        public void Able_to_create_instance()
        {
            var expectedFullName = "John Smith";
            var expectedAddress = AddressMockBuilder.BuildGermany();
            var expectedPaysVAT = true;

            var actual = new JuridicalPerson(
                expectedFullName,
                expectedAddress,
                expectedPaysVAT);

            actual.Id.Should().NotBeEmpty();
            actual.FullName.Should().Be(expectedFullName);
            actual.Address.Should().Be(expectedAddress);
            actual.PaysVAT.Should().Be(expectedPaysVAT);
            actual.InEU.Should().Be(true);
        }

        [TestMethod]
        public void Able_to_create_instance_with_persistence_constructor()
        {
            var expectedId = Guid.NewGuid();
            var expectedFullName = "John Smith";
            var expectedAddress = AddressMockBuilder.BuildMontenegro();
            var expectedPaysVAT = true;

            var actual = new JuridicalPerson(
                expectedId,
                expectedFullName,
                expectedAddress,
                expectedPaysVAT);

            actual.Id.Should().Be(expectedId);
            actual.FullName.Should().Be(expectedFullName);
            actual.Address.Should().Be(expectedAddress);
            actual.PaysVAT.Should().Be(expectedPaysVAT);
            actual.InEU.Should().Be(false);
        }
    }
}
