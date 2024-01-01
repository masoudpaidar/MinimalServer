using System.Net;

namespace MinimalServer.Controller.BaseController;

public abstract  class ControllerBase
{
    public HttpListenerContext HttpListenerContext { get; set; }
    
    
    
    protected void Ok(object? value)
    {
        ResultGenerator.OK(HttpListenerContext, value);
    }
    protected void NotFound(object? value)
    {
        ResultGenerator.NotFound(HttpListenerContext, value);
    }
    protected void BadRequest(object? value)
    {
        ResultGenerator.BadRequest(HttpListenerContext, value);
    }
    protected void Unauthorized(object? value)
    {
        ResultGenerator.Unauthorized(HttpListenerContext, value);
    }
    
    
}