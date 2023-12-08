using System.Net;

HttpListener listener = new HttpListener();

listener.Prefixes.Add("http://*:8080/");

listener.Start();


while (true)
{
    var context = await listener.GetContextAsync();
    using var writer = new StreamWriter(context.Response.OutputStream);


    var endpoint = context?.Request?.RawUrl?.Split("/", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);



    if (endpoint == null || endpoint.Length == 0)
    {
        var homepage = await File.ReadAllTextAsync("Views/Home.html");
        await writer.WriteLineAsync(homepage);
        context.Response.StatusCode = (int)HttpStatusCode.OK;
        context.Response.ContentType = "text/html";
        continue;
    }



    switch (endpoint[0].ToLower())
    {
        case "staff":
            break;
    }
}
