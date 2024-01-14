

using Clinic_App.Clinic_db_ef;
using Clinic_App.Models.Persons;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;




// ClinicDbContext clinicDbContext = new();
// int[] date = new int[3] { 1993, 05, 28 };
// var staffToAdd = new Staff
// {
//     FIN = "5NL6CHR",
//     FirstName = "ZABIL",
//     LastName = "KHASAYLI",
//     Birthday = new DateTime(1993, 10, 14),
//     Contract = new StaffContract
//     {
//         StartDate = DateTime.Now,
//         Job_title = "Developer",
//         Salary = 5522.22
//     }
// };

// var staffEntry = clinicDbContext.Staff.Add(staffToAdd);
// clinicDbContext.SaveChanges();
// Console.WriteLine($"Added staff with ID: {staffEntry.Entity.Id}");


// HttpListener httpListener = new HttpListener();
// httpListener.Prefixes.Add("http://*:8080/");
// httpListener.Start();

// while (true)
// {
//     var context = await httpListener.GetContextAsync();
//     using var writer = new StreamWriter(context.Response.OutputStream);

//     var pageHtml = await File.ReadAllTextAsync("Views/HomePage.html");
//     await writer.WriteLineAsync(pageHtml);
//     context.Response.StatusCode = (int)HttpStatusCode.OK;
//     context.Response.ContentType = "text/html";

// }