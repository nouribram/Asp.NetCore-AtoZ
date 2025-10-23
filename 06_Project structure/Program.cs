/**
ASP.NET Core Project Structure
 Understanding wwwroot, Controllers, Views, Models, etc.

*/

/**
 When you create a new ASP.NET Core MVC project,
 it follows a well-organized folder structure.
 Each folder serves a specific purpose in the MVC pattern:

 M → Models
 V → Views
 C → Controllers
*/

/**
 1. wwwroot Folder

 - This is the "web root" folder of your app.
 - It contains all static files accessible by the browser.
   Examples: CSS, JavaScript, images, fonts, etc.

 Example structure:
 wwwroot/
 ├── css/
 │   └── site.css
 ├── js/
 │   └── site.js
 ├── images/
 │   └── logo.png

 Any file placed here is served directly to clients.
 Static files outside wwwroot are not accessible by default.
*/

/**
 2. Controllers Folder

 - Controllers handle user input and app logic.
 - They process incoming requests and return responses (HTML, JSON, etc.).

 Example: HomeController.cs

 using Microsoft.AspNetCore.Mvc;

 namespace MyApp.Controllers
 {
     public class HomeController : Controller
     {
         public IActionResult Index()
         {
             return View(); // returns a View (Index.cshtml)
         }
     }
 }

 Each public method (like Index) is called an Action.
*/

/**
 3. Views Folder

 - Views are responsible for the UI.
 - They use Razor syntax (.cshtml) to combine HTML + C#.

 Example structure:
 Views/
 ├── Home/
 │   ├── Index.cshtml
 │   └── About.cshtml
 ├── Shared/
 │   └── _Layout.cshtml

 The Shared folder holds layout and partial views used across pages.
 Each controller has a folder under Views with its name.
*/

/**
 4. Models Folder

 - Models represent the application's data and business logic.
 - They define the shape of data passed between Views and Controllers.

 Example: Models/User.cs

 namespace MyApp.Models
 {
     public class User
     {
         public int Id { get; set; }
         public string Name { get; set; }
         public string Email { get; set; }
     }
 }

 Models are often linked to a database via Entity Framework.
*/

/**
 5. Program.cs and Startup.cs (or Minimal Hosting)

 - Program.cs is the entry point of your app.
 - It configures the web server and registers middleware.

 Example (Minimal hosting model):

 var builder = WebApplication.CreateBuilder(args);
 builder.Services.AddControllersWithViews();
 var app = builder.Build();

 app.UseStaticFiles();
 app.MapDefaultControllerRoute();

 app.Run();

 Startup.cs was used in older versions to separate configuration logic.
*/

/**
 6. appsettings.json

 - This file stores configuration settings (connection strings, app keys, etc.)
 - Supports multiple environments (appsettings.Development.json).

 Example:
 {
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=MyDB;Trusted_Connection=True;"
   },
   "Logging": {
     "LogLevel": {
       "Default": "Information",
       "Microsoft.AspNetCore": "Warning"
     }
   }
 }
*/

/**
 7. Summary
 
 ASP.NET Core MVC structure helps separate responsibilities:
 - Models → Data & Business Logic
 - Views → Presentation/UI
 - Controllers → Application Flow & Logic

 The wwwroot folder serves static files,
 while appsettings.json manages configuration.

 This clear separation makes ASP.NET Core projects
 maintainable, scalable, and easy to test.
*/
