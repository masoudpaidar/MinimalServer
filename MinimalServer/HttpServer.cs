using System.Net;

namespace MinimalServer;

public class HttpServer
{
    public int Port = 8080;
    private HttpListener _listener;

    public void Start()
    {
        _listener = new HttpListener();
        _listener.Prefixes.Add("http://localhost:8000/");
        _listener.Start();
        Receive();
    }

    public void Stop()
    {
        _listener.Stop();
    }

    private void Receive()
    {
        _listener.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
    }

    private void ListenerCallback(IAsyncResult result)
    {
        if (!_listener.IsListening) return;
        var context = _listener.EndGetContext(result);
        var request = context.Request;

        Console.WriteLine($"{request.HttpMethod} {request.Url}");

        if (request.HasEntityBody)
        {
            var body = request.InputStream;
            var encoding = request.ContentEncoding;
            var reader = new StreamReader(body, encoding);
            if (request.ContentType != null)
            {
                Console.WriteLine("Client data content type {0}", request.ContentType);
            }
            Console.WriteLine("Client data content length {0}", request.ContentLength64);

            Console.WriteLine("Start of data:");
            string s = reader.ReadToEnd();
            Console.WriteLine(s);
            Console.WriteLine("End of data:");
            reader.Close();
            body.Close();
        }
        Console.WriteLine($"{request.Url}");

        Receive();
    }
}