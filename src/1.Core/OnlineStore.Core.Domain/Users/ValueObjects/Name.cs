namespace OnlineStore.Core.Domain.Users.ValueObjects;

public sealed class Name
{
    public string Value { get; private set; }

    private Name() { }
    private Name(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ApplicationException("Name cannot be null or white space");
        if (value.Length > 50)
            throw new ApplicationException("Name cannot be more than 50 characters");

        Value = value;
    }
    public static Name Set(string value) => new Name(value);
    public bool Equals(Name? other)
    {
        if (other is null) return false;
        return Value == other.Value;
    }
    public override bool Equals(object? obj)
    {
        var other = obj as Name;
        if (other is null) return false;
        return Value == other.Value;
    }
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }


    public static explicit operator Name(string value) => new Name(value);
    public static explicit operator string(Name title) => title.Value;

    public static bool operator ==(Name left, Name right)
    {
        if (left is null && right is null) return true;
        if (left is null || right is null) return false;
        return right.Equals(left);
    }
    public static bool operator !=(Name right, Name left)
    {
        return !(right == left);
    }
}
