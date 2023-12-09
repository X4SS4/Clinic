using Clinic.Controllers.Base;
using Clinic.Listeners;
using Dapper;
using System.Data.SqlClient;
using System.Net;
using System.Reflection;
using System.Text.Json;


var httpListener = new HttpListenerCreator().Listener;

while (true)
{

    var context = await httpListener.GetContextAsync();


    using var writer =
        new StreamWriter(context.Response.OutputStream);


    var endpoint = context
        ?.Request
        ?.RawUrl
        ?.Split("/"
            , StringSplitOptions.RemoveEmptyEntries
            | StringSplitOptions.TrimEntries
        );



    if (endpoint == null || endpoint.Length == 0)
    {
        var homepage = await File.ReadAllTextAsync("Views/Home.html");
        await writer.WriteLineAsync(homepage);
        context.Response.StatusCode = (int)HttpStatusCode.OK;
        context.Response.ContentType = "text/html";
        continue;
    }

    var controllerType = Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Where(t => t.BaseType == typeof(BaseController))
        .FirstOrDefault(t => t.Name.ToLower().Contains($"{endpoint[0]}controller"));


    if (controllerType == null)
    {
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        continue;
    }


    var controllerObj = Activator.CreateInstance(controllerType) as BaseController;

    var controllerMethod = controllerType
        .GetMethods()
        .FirstOrDefault(m => m.Name.ToLower().Contains(context.Request.HttpMethod.ToLower()));

    if (controllerMethod == null)
    {
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        continue;
    }

    controllerMethod.Invoke(controllerObj, parameters: new[] { context });

    switch (endpoint[0].ToLower())
    {
        case "person":
            if (context?.Request.HttpMethod == HttpMethod.Get.ToString())
            {
                const string connectionString = "Data Source=localhost;Initial Catalog=Clinic;Integrated Security=True";
                using var connection = new SqlConnection(connectionString);
                var persons = await connection.QueryAsync<Person>("select * from Persons");
                var personJson = JsonSerializer.Serialize(persons);
                foreach (var person in persons)
                {
                    Console.WriteLine(person);
                }
                await writer.WriteLineAsync(personJson);
                context.Response.ContentType = "application/json";
                Console.WriteLine(context.Response.ContentType);
                context.Response.StatusCode = (int)HttpStatusCode.OK;
            }
            break;
    }
}
