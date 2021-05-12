using System;
using System.Collections.Generic;
using System.Reflection;

namespace GenShop.Invoicing.Domain.Kernel
{
    public class ValueObject<T> :
        IEquatable<T>
        where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            return Equals(obj as T);
        }

        public override int GetHashCode()
        {
            int startValue = 17;
            int multiplier = 59;

            int hashCode = startValue;

            foreach (FieldInfo field in GetFieldsRecursively())
            {
                object value = field.GetValue(this);

                if (value is { })
                    hashCode = hashCode * multiplier + value.GetHashCode();
            }

            return hashCode;
        }

        public virtual bool Equals(T other)
        {
            if (other is null)
                return false;

            if (!IsOfSameTypeAs(other))
                return false;

            foreach (FieldInfo field in GetFieldsRecursively())
            {
                object value1 = field.GetValue(other);
                object value2 = field.GetValue(this);

                if (!Equals(value1, value2))
                    return false;
            }

            return true;
        }

        public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
            => Equals(x, y);

        public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
            => !Equals(x, y);

        private bool IsOfSameTypeAs(T other)
        {
            Type type = GetType();
            Type otherType = other.GetType();
            return type == otherType;
        }

        private IEnumerable<FieldInfo> GetFieldsRecursively()
        {
            Type type = GetType();
            while (type != typeof(object))
            {
                var fields = type.GetFields(
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                foreach (var fieldInfo in fields)
                    yield return fieldInfo;

                type = type.BaseType;
            }
        }
    }
}