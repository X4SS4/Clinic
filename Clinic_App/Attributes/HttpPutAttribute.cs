namespace Clinic_App.Attributes;
using Clinic_App.Attributes.BaseAttribute;

[AttributeUsage(AttributeTargets.Method)]
public class HttpPutAttribute : HttpMethodAttribute
{
    public HttpPutAttribute(string path) : base(path, "PUT") { }
}