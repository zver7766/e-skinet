using System;

namespace Core.Entities
{
    public abstract class Entity<TId> : IEntity<TId> 
        where TId : IComparable, IEquatable<TId>
    {
        public TId Id { get; protected set; } = default!;

        protected Entity()
        {
        }

        protected Entity(TId id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Entity<TId> other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return $"{GetType()}{Id.ToString()}".GetHashCode();
        }
    }
}