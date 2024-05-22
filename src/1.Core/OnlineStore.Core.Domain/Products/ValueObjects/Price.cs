using OnlineStore.Core.Domain.Exceptions;

namespace OnlineStore.Core.Domain.Products.ValueObjects;

public sealed class Price : IEquatable<Price>
{
    public decimal Value { get; private set; }

    private Price() { }
    private Price(decimal value)
    {
        if (value < 1)
            throw new ValueObjectInvalidStateException("Price cannot be less than 1$");

        Value = value;
    }
    public static Price Set(decimal value) => new Price(value);
    public bool Equals(Price? other)
    {
        if (other is null) return false;
        return Value == other.Value;
    }
    public override bool Equals(object? obj)
    {
        var other = obj as Price;
        if (other is null) return false;
        return Value == other.Value;
    }
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
    public static explicit operator decimal(Price value) => value.Value;
    public static explicit operator Price(int value) => new Price(value);

    public static bool operator ==(Price left, Price right)
    {
        if (left is null && right is null) return true;
        if (left is null || right is null) return false;
        return right.Equals(left);
    }
    public static bool operator !=(Price right, Price left)
    {
        return !(right == left);
    }
}
