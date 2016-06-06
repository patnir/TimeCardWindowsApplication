using System;

internal class clsTooManyRecordsException : ApplicationException
{
    internal clsTooManyRecordsException(string message)
        : base(message)
    {

    }
}