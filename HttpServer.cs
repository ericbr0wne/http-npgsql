using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;


namespace http_npgsql;

public class HttpServer
{
    public int Port = 3000;


    public HttpListener? _listener;

    public void Start(string dbUri)
    {
        _listener = new HttpListener();
        _listener.Prefixes.Add("htt://*:" + Port.ToString() + "/");
        _listener.Start();
        Receive();
    }

    public void Stop()
    {
        _listener.Stop();
    }

    public void Receive()
    {
        _listener.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
    }

    public void ListenerCallback(IAsyncResult result)
    {
        if (_listener.IsListening)
        {
            var context = _listener.EndGetContext(result);
            var request = context.Request;

            //do something with the request
            Console.WriteLine($"{request.Url}, + {request.UserHostName}, {request.HttpMethod}, {request.Headers}");

            Receive();
        }
    }
}
