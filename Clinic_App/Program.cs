using Clinic.ClinicDbContext;
using Clinic.Controllers.Base;
using Clinic.Listeners;
//using Dapper;
using System.Data.SqlClient;
using System.Net;
using System.Reflection;
using System.Text.Json;

ClinicDbContext clinicDbContext = new();
int[] date = new int[3] { 1993, 10, 14 };
var qwer = clinicDbContext.Staff.Add(
    new Staff
    {
        Id = 1005,
        FIN = "5NL6CHR",
        FirstName = "Zabil",
        LastName = "Khasayli",
        Salary = 5500.55,
        IsManagement = true,
        Job_title = "Developer",
        Birthday = new DateTime(date[0], date[1], date[2])
    });

Console.WriteLine(qwer);

//var httpListener = new HttpListenerCreator().Listener;


//while (true && httpListener != null)
//{
//    var context = await httpListener.GetContextAsync();




//}
