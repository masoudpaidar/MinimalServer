namespace MinimalServer;

public class HttpContext
{
    public required string RequestIpAddress { get; set; }
    public required string Country { get; set; }
    public required string Url { get; set; }
}