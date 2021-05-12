using System;

namespace GenShop.Invoicing.Domain.Kernel
{
    public class Entity<TId> : 
        IEquatable<Entity<TId>>
    {
        public TId Id { get; protected set; }

        protected Entity(TId id)
        {
            ThrowIfDefault(id);
            Id = id;
        }

        public bool Equals(Entity<TId> other)
            => !IsNull(other) && Equals(Id, other.Id);

        public override bool Equals(object obj)
            => Equals(obj as Entity<TId>);

        public override int GetHashCode()
            => Id.GetHashCode();

        public static bool operator ==(Entity<TId> x, Entity<TId> y)
            => IsNull(x) ? IsNull(y) : x.Equals(y);

        public static bool operator !=(Entity<TId> x, Entity<TId> y)
            => !(x == y);

        private static void ThrowIfDefault(TId id)
        {
            if (Equals(id, default(TId)))
                throw new Exception("The Id cannot be the type's default value.");
        }

        private static bool IsNull(Entity<TId> entity)
            => entity is null;
    }
}
