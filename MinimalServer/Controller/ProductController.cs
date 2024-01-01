using MinimalServer.Controller.BaseController;

namespace MinimalServer.Controller;

public class ProductController : ControllerBase
{
    public void AllProducts()
    {
        Ok("All Product");
    }
    
}