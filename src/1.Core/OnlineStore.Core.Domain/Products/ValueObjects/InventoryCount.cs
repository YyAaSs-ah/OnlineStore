using OnlineStore.Core.Domain.Exceptions;
using System.Runtime.CompilerServices;

namespace OnlineStore.Core.Domain.Products.ValueObjects;

public sealed class InventoryCount : IEquatable<InventoryCount>
{
    public int Value { get; private set; }

    private InventoryCount() { }
    private InventoryCount(int value)
    {
        if (value < 0)
            throw new ValueObjectInvalidStateException("InventoryCount cannot be less than 0");
        Value = value;
    }
    public static InventoryCount Set(int value) => new InventoryCount(value);
    public bool Equals(InventoryCount? other)
    {
        if (other is null) return false;
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        var other = obj as InventoryCount;
        if (other is null) return false;
        return Value == other.Value;
    }
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static explicit operator int(InventoryCount count) => count.Value;
    public static explicit operator InventoryCount(int count) => new InventoryCount(count);
    public static bool operator ==(InventoryCount left, InventoryCount right)
    {
        if (left is null && right is null) return true;
        if (left is null || right is null) return false;
        return right.Equals(left);
    }
    public static bool operator !=(InventoryCount right, InventoryCount left)
    {
        return !(right == left);
    }
}