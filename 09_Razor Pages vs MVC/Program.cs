/*
   Razor Pages vs MVC — What’s the Difference? (ASP.NET Core 9)

  Description:
  ASP.NET Core supports two main ways to build web applications:
  1. MVC (Model-View-Controller)
  2. Razor Pages

  Both use Razor syntax (.cshtml files) but differ in architecture and complexity.
*/

/*
  OVERVIEW:
  ------------------------------------------------------------
  | FEATURE              | MVC                          | Razor Pages                 |
  |----------------------|-------------------------------|-----------------------------|
  | Structure            | Controller + View + Model     | Page + PageModel (code-behind) |
  | Complexity           | More structured, suited for large apps | Simpler, ideal for small apps |
  | Routing              | Controller/action-based       | Folder & file-based routing |
  | Separation of Logic  | Logic in Controllers          | Logic in PageModel files    |
  | Testability          | Highly testable architecture  | Easier to start, still testable |
  | File Example         | /Controllers/HomeController.cs| /Pages/Index.cshtml.cs      |
  ------------------------------------------------------------
*/

/*
  EXAMPLE 1: MVC APPROACH
  -------------------------
  Folders:
  ├── Controllers/
  │    └── HomeController.cs
  ├── Views/
  │    └── Home/
  │         └── Index.cshtml
  ├── Models/
  └── Program.cs
*/

using Microsoft.AspNetCore.Mvc;

namespace MVCTutorial.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome to the MVC example!";
            return View();
        }
    }
}

/*
  MVC View: Views/Home/Index.cshtml

  <h2>@ViewData["Message"]</h2>
*/

/*
  EXAMPLE 2: RAZOR PAGES APPROACH
  -------------------------
  Folders:
  ├── Pages/
  │    ├── Index.cshtml
  │    └── Index.cshtml.cs
  ├── Program.cs
*/

/*
  Index.cshtml
  -----------------------------------
  @page
  @model RazorPagesExample.Pages.IndexModel

  <h2>@Model.Message</h2>
*/

/*
  Index.cshtml.cs
  -----------------------------------
*/

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesExample.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Welcome to the Razor Pages example!";
        }
    }
}

/*
  PROGRAM.CS CONFIGURATION (for both MVC and Razor Pages)
  -------------------------------------------------------
  var builder = WebApplication.CreateBuilder(args);

  // Add both MVC and Razor Pages services
  builder.Services.AddControllersWithViews();
  builder.Services.AddRazorPages();

  var app = builder.Build();

  app.UseStaticFiles();
  app.UseRouting();

  // Map both frameworks
  app.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}");

  app.MapRazorPages();

  app.Run();
*/

/*
  SUMMARY:
  ----------
 Use MVC when:
     - Building large or enterprise-level applications
     - You need clear separation of concerns (Model, View, Controller)
     - You plan to manage multiple views and complex routing

  Use Razor Pages when:
     - You’re building smaller or page-focused applications
     - You prefer a simpler, file-based structure
     - You want minimal setup and faster development

  Both are first-class citizens in ASP.NET Core 9 and can even coexist in the same project.
*/
