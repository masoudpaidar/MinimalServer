using System.Net;
using MinimalServer.PipLine;

namespace MinimalServer.MiddlewarePipeline;

public class AuthorizedMiddleware : Handler,IHandler
{
    public void Build(CancellationToken cancellationToken, HttpListenerContext httpContext)
    {
       
        Console.WriteLine("Starting auth");
        // Validate
        base.Next(cancellationToken,httpContext);
        Console.WriteLine("Finish auth");
    }
}