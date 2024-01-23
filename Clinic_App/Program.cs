using Clinic_App.Controllers.BaseControllers;
using Clinic_App.Server;
using System.Reflection;


Type[] allControllerTypes = new Type[] { };
var controllerTypes = Assembly.GetExecutingAssembly()
       .GetTypes()
       .Where(t => t.BaseType == typeof(BaseController));
allControllerTypes = controllerTypes.ToArray();
var server = new ClinicHttpServer(allControllerTypes);
server.Start("http://localhost:8080/");
Console.WriteLine("Press Enter to stop the server.");
Console.ReadLine();
server.Stop();