using System.Net;
using System.Text;
using System.Text.Json;

HttpListener httpListener = new HttpListener();
httpListener.Prefixes.Add("http://*:8080/");
httpListener.Start();

while (true)
{
    var context = await httpListener.GetContextAsync();
    using var writer = new StreamWriter(context.Response.OutputStream);

    var pageHtml = await File.ReadAllTextAsync("Views/HomePage.html");
    await writer.WriteLineAsync(pageHtml);
    context.Response.StatusCode = (int)HttpStatusCode.OK;
    context.Response.ContentType = "text/html";

}