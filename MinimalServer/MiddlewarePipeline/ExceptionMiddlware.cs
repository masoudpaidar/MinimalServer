
using System.Net;
using MinimalServer.Controller.BaseController;
using MinimalServer.CustomException;
using MinimalServer.PipLine;

namespace MinimalServer.MiddlewarePipeline;

public class ExceptionMiddleware : Handler , IHandler
{
    public void Build(CancellationToken cancellationToken , HttpListenerContext httpContext)
    {
        try
        {   
            Console.WriteLine("Exception Middleware Start......");
            
            base.Next(cancellationToken,httpContext);
        }
        catch (AppException e )
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" exception message is : {e.Message} The statusCode is {e.ApiStatusCode} ");
            ResultGenerator.Exception(httpContext,$" exception message is : {e.Message} The statusCode is {e.ApiStatusCode} "
                ,(int)e.HttpStatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
}