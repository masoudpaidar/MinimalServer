using System.Net;
using System.Reflection;
using MinimalServer.CustomException;
using MinimalServer.PipLine;

namespace MinimalServer.MiddlewarePipeline;

public class EndPoint : Handler,IHandler
{
    public void Build(CancellationToken cancellationToken, HttpListenerContext httpContext)
    {
        var request = httpContext.Request;
        var rawUrl=  request.RawUrl.Split("/");
        var controllerName = $"MinimalServer.Controller.{rawUrl[1]}Controller";
        var controllerType = Type.GetType(controllerName, throwOnError: false, ignoreCase: true)!;
        
        var method = controllerType.GetMethod(rawUrl[2]!, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        
        var controllerInstance = Activator.CreateInstance(controllerType);

        if (controllerInstance is null || method is null) throw new NotFoundException();
        
        var property = controllerType?.GetProperty("HttpListenerContext")!;
        var parameters = method.GetParameters();
        if (property is not null && property.CanWrite)
        {
            property.SetValue(controllerInstance, httpContext);
        }
        method?.Invoke(controllerInstance, parameters.Length > 0 ?
            new[] { Convert.ChangeType(rawUrl?[2], parameters[0].ParameterType) } :
            null);
    }
}
