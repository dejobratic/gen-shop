using FluentAssertions;
using GenShop.Invoicing.Domain.Kernel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenShop.Invoicing.Domain.Tests.Unit.Kernel
{
    [TestClass]
    [TestCategory("Unit")]
    public class ValueObjectTest
    {
        private class FakeValueObject : 
            ValueObject<FakeValueObject>
        {
            private int _integerField;
            private bool BooleanProperty { get; }
            public string StringProperty { get; }

            public FakeValueObject(
                int integerField, 
                string stringProperty, 
                bool booleanProperty)
            {
                BooleanProperty = booleanProperty;
                StringProperty = stringProperty;
                _integerField = integerField;
            }
        }

        private class DerrivedFakeValueObject : 
            FakeValueObject
        {
            public int IntegerField;

            public DerrivedFakeValueObject(
                int integerField, 
                string stringProperty, 
                bool booleanProperty)
                : base(integerField, stringProperty, booleanProperty)
            {
            }
        }

        [TestMethod]
        public void Null_value_objects_are_considered_equal()
        {
            FakeValueObject first = null;
            FakeValueObject second = null;

            AssertAreEqual(first, second);
        }

        [TestMethod]
        public void Non_null_value_objects_are_not_equal_to_null()
        {
            var first = new FakeValueObject(1, "first", true);

            AssertAreNotEqual(first, null);
            AssertAreNotEqual(null, first);
        }

        [TestMethod]
        public void Value_objects_are_equal_if_they_have_the_same_properties_and_fields()
        {
            var first = new FakeValueObject(1, "first", true);
            var second = new FakeValueObject(1, "first", true);

            AssertAreEqual(first, second);
        }

        [TestMethod]
        public void Value_objects_are_not_equal_if_they_have_at_least_one_private_field_different()
        {
            var first = new FakeValueObject(1, "first", true);
            var second = new FakeValueObject(2, "first", true);

            AssertAreNotEqual(first, second);
        }

        [TestMethod]
        public void Value_objects_are_not_equal_if_they_have_at_least_one_public_property_different()
        {
            var first = new FakeValueObject(1, "first", true);
            var second = new FakeValueObject(1, "second", true);

            AssertAreNotEqual(first, second);
        }

        [TestMethod]
        public void Value_objects_are_not_equal_if_they_have_at_least_one_private_property_different()
        {
            var first = new FakeValueObject(1, "first", true);
            var second = new FakeValueObject(1, "second", false);

            AssertAreNotEqual(first, second);
        }

        [TestMethod]
        public void Equal_value_objects_have_the_same_hash_code()
        {
            var first = new FakeValueObject(1, "first", true);
            var second = new FakeValueObject(1, "first", true);

           first.GetHashCode().Should().Be(second.GetHashCode());
        }

        [TestMethod]
        public void Non_equal_value_objects_have_different_hash_codes()
        {
            var a = new FakeValueObject(1, "a", true);
            var b = new FakeValueObject(2, "a", true);

            Assert.AreNotEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestMethod]
        public void Derrived_value_objects_are_equal_if_all_their_fields_are_equal()
        {
            var first = new DerrivedFakeValueObject(1, "first", true) { IntegerField = 2 };
            var second = new DerrivedFakeValueObject(1, "first", true) { IntegerField = 2 };

            AssertAreEqual(first, second);
        }

        [TestMethod]
        public void Derrived_value_objects_are_not_equal_if_all_their_fields_are_not_equal()
        {
            var first = new DerrivedFakeValueObject(1, "first", true) { IntegerField = 2 };
            var second = new DerrivedFakeValueObject(1, "first", true) { IntegerField = 4 };

            AssertAreNotEqual(first, second);
        }

        [TestMethod]
        public void Derrived_value_objects_are_not_equal_if_all_their_base_fields_are_not_equal()
        {
            var first = new DerrivedFakeValueObject(1, "first", true) { IntegerField = 2 };
            var second = new DerrivedFakeValueObject(2, "second", true) { IntegerField = 2 };

            Assert.AreNotEqual(first, second);
        }

        [TestMethod]
        public void Value_objects_are_not_equal_if_they_have_different_types()
        {
            var first = new FakeValueObject(1, "first", true);

            first.Should().NotBe("");
        }

        private static void AssertAreEqual(
            FakeValueObject first, FakeValueObject second)
        {
            first.Should().Be(second);
            (first == second).Should().BeTrue();
            (first != second).Should().BeFalse();
        }

        private static void AssertAreNotEqual(
            FakeValueObject first, FakeValueObject second)
        {
            first.Should().NotBe(second);
            (first == second).Should().BeFalse();
            (first != second).Should().BeTrue();
        }
    }
}
