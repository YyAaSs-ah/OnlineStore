namespace OnlineStore.Core.Domain.Products.ValueObjects;

public sealed class Discount
{
    public int Value { get; private set; }
    private Discount() { }
    public Discount(int discount)
    {
        if (discount < 0 || discount > 100)
            throw new ApplicationException("Discount percentage is a number between 0 to 100");
        Value = discount;
    }

    public static Discount Set(int discount) => new Discount(discount);

    public bool Equals(Discount? other)
    {
        if (other is null) return false;
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        var other = obj as Discount;
        if (other is null) return false;
        return Value == other.Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
    public static explicit operator int(Discount count) => count.Value;
    public static explicit operator Discount(int count) => new Discount(count);

    public static bool operator ==(Discount left, Discount right)
    {
        if (left is null && right is null) return true;
        if (left is null || right is null) return false;

        return right.Equals(left);
    }
    public static bool operator !=(Discount right, Discount left)
    {
        return !(right == left);
    }
}
