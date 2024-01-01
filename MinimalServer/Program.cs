// See https://aka.ms/new-console-template for more information

using System.Net;
using MinimalServer.MiddlewarePipeline;
using MinimalServer.MiddlewarePipeline;
using EndPoint = MinimalServer.MiddlewarePipeline.EndPoint;

HttpListener _listener = new();
_listener.Prefixes.Add("http://localhost:8000/");
_listener.Start();
Console.WriteLine("Starting HTTP listener to localhost:8000/ ...");
try
{
    while (true)
    {
        var ctx = await _listener.GetContextAsync();
    
    
        var cancellationToken = new CancellationToken();
        var exceptionMiddleware = new ExceptionMiddleware();
        var authorizedMiddleware = new AuthorizedMiddleware();
        var cors = new Cors();
        var routeMiddleware = new RouteMiddleware();
        var endPoint = new EndPoint();

        exceptionMiddleware
            .AddMiddleware(authorizedMiddleware)
            .AddMiddleware(cors)
            .AddMiddleware(routeMiddleware)
            .AddMiddleware(endPoint);

        exceptionMiddleware.Build(cancellationToken,ctx);
    }

}catch (Exception e)
{
    Console.WriteLine(e.Message);
    _listener.Stop();
    _listener.Close();
}


