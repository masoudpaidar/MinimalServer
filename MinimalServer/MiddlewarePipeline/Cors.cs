using System.Net;
using MinimalServer.PipLine;

namespace MinimalServer.MiddlewarePipeline;

public class Cors: Handler,IHandler
{
    public void Build(CancellationToken cancellationToken, HttpListenerContext httpContext)
    {
        
        Console.WriteLine("Start Cors");
        base.Next(cancellationToken,httpContext);
        Console.WriteLine("Finish Cors");
    }
}