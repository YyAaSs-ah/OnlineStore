using OnlineStore.Core.Domain.Exceptions;
using System.Reflection.Metadata.Ecma335;

namespace OnlineStore.Core.Domain.Products.ValueObjects;

public sealed class Title
{
    public string Value { get; private set; }

    private Title() { }
    private Title(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ValueObjectInvalidStateException("Title cannot be null or white space");
        if (value.Length > 40)
            throw new ValueObjectInvalidStateException("Title cannot be more than 40 characters");

        Value = value;
    }
    public static Title Set(string value) => new Title(value);
    public bool Equals(Title? other)
    {
        if (other is null) return false;
        return Value == other.Value;
    }
    public override bool Equals(object? obj)
    {
        var other = obj as Title;
        if (other is null) return false;
        return Value == other.Value;
    }
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }


    public static explicit operator Title(string value) => new Title(value);
    public static explicit operator string(Title title) => title.Value;

    public static bool operator ==(Title left, Title right)
    {
        if (left is null && right is null) return true;
        if (left is null || right is null) return false;
        return right.Equals(left);
    }
    public static bool operator !=(Title right, Title left)
    {
        return !(right == left);
    }
}
