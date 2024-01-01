using MinimalServer.Comman.Enum;

namespace MinimalServer.CustomException;

public class ForbiddenException : AppException
{
    public ForbiddenException()
        : base(ApiResultStatusCode.Forbidden, System.Net.HttpStatusCode.Forbidden)
    {
    }

    public ForbiddenException(string message)
        : base(ApiResultStatusCode.Forbidden, message, System.Net.HttpStatusCode.Forbidden)
    {
    }

    public ForbiddenException(object additionalData)
        : base(ApiResultStatusCode.Forbidden, null, System.Net.HttpStatusCode.Forbidden, additionalData)
    {
    }

    public ForbiddenException(string message, object additionalData)
        : base(ApiResultStatusCode.Forbidden, message, System.Net.HttpStatusCode.Forbidden, additionalData)
    {
    }

    public ForbiddenException(string message, Exception exception)
        : base(ApiResultStatusCode.Forbidden, message, exception, System.Net.HttpStatusCode.Forbidden)
    {
    }

    public ForbiddenException(string message, Exception exception, object additionalData)
        : base(ApiResultStatusCode.Forbidden, message, System.Net.HttpStatusCode.Forbidden, exception, additionalData)
    {
    }
}