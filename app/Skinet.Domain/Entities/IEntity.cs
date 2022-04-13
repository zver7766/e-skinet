using System;

namespace Core.Entities
{
    public interface IEntity<TId> where TId : IComparable, IEquatable<TId>
    {
        TId Id { get; }
    }
}