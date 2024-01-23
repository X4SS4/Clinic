namespace Clinic_App.Attributes;
using Clinic_App.Attributes.BaseAttribute;

[AttributeUsage(AttributeTargets.Method)]
public class HttpDeleteAttribute : HttpMethodAttribute
{
    public HttpDeleteAttribute(string path) : base(path, "DELETE") { }
}