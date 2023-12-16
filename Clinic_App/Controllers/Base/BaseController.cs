using System.Net;
using System.Runtime.CompilerServices;

namespace Clinic.Controllers.Base;

public class BaseController
{
    public HttpListenerContext? Httpcontext;
    public string View([CallerMemberName] string MethodName = "")
    {
        var controllerName = this.GetType().Name[..(this.GetType().Name.LastIndexOf("Controller"))];
        return File.ReadAllText($"{controllerName}/{MethodName}.html");
    }
}
