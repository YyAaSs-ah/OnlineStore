using OnlineStore.Core.Domain.Exceptions;
using System.Runtime.CompilerServices;

namespace OnlineStore.Core.Domain.Common.ValueObjects;

public sealed class Count : IEquatable<Count>
{
    public int Value { get; private set; }

    private Count() { }
    private Count(int value)
    {
        if (value < 0)
            throw new ValueObjectInvalidStateException("Count cannot be less than 0");
        Value = value;
    }
    public static Count Set(int value) => new Count(value);
    public bool Equals(Count? other)
    {
        if (other is null) return false;
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        var other = obj as Count;
        if (other is null) return false;
        return Value == other.Value;
    }
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static explicit operator int(Count count) => count.Value;
    public static explicit operator Count(int count) => new Count(count);
    public static bool operator ==(Count left, Count right)
    {
        if (left is null && right is null) return true;
        if (left is null || right is null) return false;
        return right.Equals(left);
    }
    public static bool operator !=(Count right, Count left)
    {
        return !(right == left);
    }
}