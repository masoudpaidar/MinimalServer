using System.Net;
using MinimalServer.PipLine;

namespace MinimalServer.MiddlewarePipeline;

public class RouteMiddleware : Handler,IHandler
{
    public void Build(CancellationToken cancellationToken , HttpListenerContext httpContext)
    {
       
        Console.WriteLine("Start Route");
        Console.WriteLine("Finish Route");
        
        
        base.Next(cancellationToken,httpContext);
    }
}