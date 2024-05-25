namespace MUSbooking.Exceptions.Common.Exceptions;

public class BadRequestException : BaseException
{
    public BadRequestException(string errorCode, string message) : base(errorCode, message)
    {
    }
    
    public BadRequestException(string message) : this(ErrorCodes.Common.BadRequest, message)
    {
    }
}