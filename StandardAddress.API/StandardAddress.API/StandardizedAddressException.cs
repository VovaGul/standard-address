namespace StandardAddress.API;

public class StandardizedAddressException : Exception
{
    public StandardizedAddressException(string message) : base(message)
    {
    }
}