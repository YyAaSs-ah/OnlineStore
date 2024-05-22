namespace OnlineStore.Core.Domain.Exceptions;

public sealed class ValueObjectInvalidStateException : Exception
{
    public ValueObjectInvalidStateException(string message) : base(message) { }
   
}
