using Clinic_App.Controllers.ClinicControllers.PersonControllers;
using Clinic_App.Controllers.ClinicControllers.RoomControllers;
using Clinic_App.Server;

//Type[] coll = null;
//var controllerType = Assembly.GetExecutingAssembly()
//       .GetTypes()
//       .Where(t => {
//           if(t.BaseType == typeof(BaseController))
//           {
//               coll?.Append(t.GetType());
//               return true;
//           }
//           return false;           
//       });

var server = new ClinicHttpServer(typeof(StaffController), 
    typeof(PatientController), 
    typeof(CabinetController), 
    typeof(WardController));

server.Start("http://localhost:8080/");

Console.WriteLine("Press Enter to stop the server.");
Console.ReadLine();

server.Stop();