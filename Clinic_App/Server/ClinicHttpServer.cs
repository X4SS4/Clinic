namespace Clinic_App.Server;
using Clinic_App.Attributes.BaseAttribute;
using System.Net;
using System.Text;

public class ClinicHttpServer
{
    private readonly HttpListener listener;
    private readonly List<Type> controllers;

    public ClinicHttpServer(params Type[] controllers)
    {
        this.controllers = new List<Type>(controllers);
        listener = new HttpListener();
    }

    public void Start(string prefix)
    {
        listener.Prefixes.Add(prefix);
        listener.Start();

        Console.WriteLine($"Server started. Listening on {prefix}");

        ThreadPool.QueueUserWorkItem((state) =>
        {
            while (listener.IsListening)
            {
                var context = listener.GetContext();
                ProcessRequest(context);
            }
        });
    }

    private void ProcessRequest(HttpListenerContext context)
    {
        var request = context.Request;
        var response = context.Response;

        foreach (var controllerType in controllers)
        {
            var methods = controllerType.GetMethods();

            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes(typeof(HttpMethodAttribute), true);

                foreach (var attribute in attributes)
                {
                    var httpAttribute = attribute as HttpMethodAttribute;

                    if (httpAttribute?.Method == request.HttpMethod && httpAttribute.Path == request.Url?.AbsolutePath)
                    {
                        var controllerInstance = Activator.CreateInstance(controllerType);
                        var parameters = method.GetParameters();
                        object[]? methodParameters = parameters.Length > 0 
                                                               ? new object[] { context } 
                                                               : null;
                        var result = method.Invoke(controllerInstance, methodParameters);

                        var responseBytes = Encoding.UTF8.GetBytes(result.ToString());
                        response.OutputStream.Write(responseBytes, 0, responseBytes.Length);
                        response.Close();
                        return;
                    }
                }
            }
        }

        response.StatusCode = (int)HttpStatusCode.NotFound;
        response.Close();
    }

    public void Stop()
    {
        listener.Stop();
        listener.Close();
    }
}