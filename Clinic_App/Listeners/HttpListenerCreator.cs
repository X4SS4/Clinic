using System.Net;

namespace Clinic.Listeners;

public class HttpListenerCreator {
    private int port = 8512;
    public HttpListener? Listener {  get; set; }
    public HttpListenerCreator() {
        this.Listener = new();
        Listener.Prefixes.Add($"http://*:{this.port}/");
        Listener.Start();
    }
}

