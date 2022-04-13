using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Entities.ValueObjects
{
  public abstract class ValueObject<T> where T : ValueObject<T>
    {
        private int? _cachedHashCode;

        public override bool Equals(object? other)
        {
            var otherValueObject = other as T;

            if (otherValueObject is null)
                return false;

            if (GetType() != other!.GetType())
            {
                return false;
            }

            return EqualsCore(otherValueObject);
        }

        protected abstract bool EqualsCore(T other);

        public override int GetHashCode()
        {
            if (!_cachedHashCode.HasValue)
            {
                _cachedHashCode = GetHashCodeCore();
            }

            return _cachedHashCode.Value;
        }

        protected abstract int GetHashCodeCore();

        public static bool operator ==(ValueObject<T>? left, ValueObject<T>? right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(ValueObject<T>? left, ValueObject<T>? right)
        {
            return !(left == right);
        }
    }
    
    public abstract class ValueObject : IComparable, IComparable<ValueObject>
    {
        private int? _cachedHashCode;

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? other)
        {
            if (other == null)
            {
                return false;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            var valueObject = (ValueObject)other;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            if (!_cachedHashCode.HasValue)
            {
                _cachedHashCode = GetEqualityComponents()
                    .Aggregate(1, (current, obj) =>
                    {
                        unchecked
                        {
                            return current * 23 + (obj?.GetHashCode() ?? 0);
                        }
                    });
            }

            return _cachedHashCode.Value;
        }

        public virtual int CompareTo(object? source)
        {
            if (source == null)
            {
                return 1;
            }
            
            var thisType = GetType();
            var otherType = source.GetType();

            if (thisType != otherType)
            {
                return string.Compare(thisType.ToString(), otherType.ToString(), StringComparison.Ordinal);
            }

            var other = (ValueObject)source;

            object[] components = GetEqualityComponents().ToArray();
            object[] otherComponents = other.GetEqualityComponents().ToArray();

            for (int i = 0; i < components.Length; i++)
            {
                int comparison = CompareComponents(components[i], otherComponents[i]);
                
                if (comparison != 0)
                {
                    return comparison;
                }
            }

            return 0;
        }

        private int CompareComponents(object? left, object? right)
        {
            if (left is null && right is null)
                return 0;

            if (left is null)
                return -1;

            if (right is null)
                return 1;

            if (left is IComparable leftComparable && right is IComparable rightComparable)
                return leftComparable.CompareTo(rightComparable);

            return left.Equals(right) ? 0 : -1;
        }

        public virtual int CompareTo(ValueObject? other)
        {
            return CompareTo(other as object);
        }

        public static bool operator ==(ValueObject? left, ValueObject? right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(ValueObject? left, ValueObject? right)
        {
            return !(left == right);
        }
    }
}