namespace Clinic_App.Attributes.BaseAttribute;

public class HttpMethodAttribute : Attribute
{
    public string Path { get; }
    public string Method { get; }

    public HttpMethodAttribute(string path, string method)
    {
        Path = path;
        Method = method;
    }
}