﻿namespace OnlineStore.Core.Domain.Common.Exceptions;

public sealed class ApplicationException : Exception
{
    public ApplicationException(string message) : base(message) { }

}
