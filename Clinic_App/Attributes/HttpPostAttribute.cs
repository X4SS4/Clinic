namespace Clinic_App.Attributes;
using Clinic_App.Attributes.BaseAttribute;

[AttributeUsage(AttributeTargets.Method)]
public class HttpPostAttribute : HttpMethodAttribute
{
    public HttpPostAttribute(string path) : base(path, "POST") { }
}