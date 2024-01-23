namespace Clinic_App.Attributes;
using Clinic_App.Attributes.BaseAttribute;

[AttributeUsage(AttributeTargets.Method)]
public class HttpGetAttribute : HttpMethodAttribute
{
    public HttpGetAttribute(string path) : base(path, "GET") { }
}