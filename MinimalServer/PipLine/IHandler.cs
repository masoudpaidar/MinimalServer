using System.Net;

namespace MinimalServer.PipLine;

public interface IHandler
{
    void Build(CancellationToken cancellationToken, HttpListenerContext httpContext);
    IHandler AddMiddleware(IHandler next);
}