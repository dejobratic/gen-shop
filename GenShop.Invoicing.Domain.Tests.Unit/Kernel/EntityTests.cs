using FluentAssertions;
using GenShop.Invoicing.Domain.Kernel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenShop.Invoicing.Domain.Tests.Unit.Kernel
{
    [TestClass]
    [TestCategory("Unit")]
    public class EntityTest
    {
        private class FakeEntity :
            Entity<int>
        {
            public string Property { get; }

            public FakeEntity(
                int id, string property)
                : base(id)
            {
                Property = property;
            }
        }

        [TestMethod]
        public void Throws_exception_when_trying_to_create_entity_with_default_id()
        {
            Action action = ()
                => new FakeEntity(0, "a");

            action.Should().Throw<Exception>()
                .WithMessage("The Id cannot be the type's default value.");
        }

        [TestMethod]
        public void Entities_are_equal_if_they_have_the_same_id()
        {
            var first = new FakeEntity(1, "first");
            var second = new FakeEntity(1, "second");

            AssertAreEqual(first, second);
        }

        [TestMethod]
        public void Equal_entities_have_the_same_hash_code()
        {
            var first = new FakeEntity(1, "first");
            var second = new FakeEntity(1, "second");

            first.GetHashCode().Should().Be(second.GetHashCode());
        }

        [TestMethod]
        public void Entities_are_not_equal_if_they_have_different_ids()
        {
            var first = new FakeEntity(1, "first");
            var second = new FakeEntity(2, "second");

            AssertAreNotEqual(first, second);
        }

        [TestMethod]
        public void Non_equal_entities_have_different_hash_codes()
        {
            var first = new FakeEntity(1, "first");
            var second = new FakeEntity(2, "second");

            first.GetHashCode().Should().NotBe(second.GetHashCode());
        }

        [TestMethod]
        public void Null_entities_are_considered_equal()
        {
            FakeEntity first = null;
            FakeEntity second = null;

            AssertAreEqual(first, second);
        }

        [TestMethod]
        public void Non_null_entities_are_not_equal_to_null()
        {
            var first = new FakeEntity(1, "first");

            AssertAreNotEqual(first, null);
            AssertAreNotEqual(null, first);
        }

        private static void AssertAreEqual(
            FakeEntity first, FakeEntity second)
        {
            first.Should().Be(second);
            (first == second).Should().BeTrue();
            (first != second).Should().BeFalse();
        }

        private static void AssertAreNotEqual(
            FakeEntity first, FakeEntity second)
        {
            first.Should().NotBe(second);
            (first == second).Should().BeFalse();
            (first != second).Should().BeTrue();
        }
    }
}
