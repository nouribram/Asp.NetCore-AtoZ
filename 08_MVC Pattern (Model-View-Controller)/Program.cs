/*
 MVC Pattern (Model-View-Controller) in ASP.NET Core 9

  Description:
  The MVC pattern in ASP.NET Core 9 separates an application into three main components:
  - Model: Manages data and business logic
  - View: Handles UI and presentation
  - Controller: Manages user requests and interactions between Model and View

  This structure promotes clean architecture, testability, and scalability.
*/

/*
  PROJECT STRUCTURE (Example)
  ├── Controllers/
  │    └── ProductsController.cs
  ├── Models/
  │    └── Product.cs
  ├── Views/
  │    └── Products/
  │         ├── Index.cshtml
  │         └── Details.cshtml
  ├── wwwroot/        → Static files (CSS, JS, images)
  ├── Program.cs
  └── appsettings.json
*/

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MVCTutorial.Controllers
{
    /*
      MODEL
      Defines the data structure and business logic.
      In real applications, Models often represent database entities.
    */
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    /*
      CONTROLLER
      - Handles HTTP requests (GET, POST, etc.).
      - Interacts with the Model to get or modify data.
      - Chooses the appropriate View to return.
    */
    public class ProductsController : Controller
    {
        // Sample in-memory data
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 899.99 },
            new Product { Id = 2, Name = "Smartphone", Price = 499.50 },
            new Product { Id = 3, Name = "Headphones", Price = 99.99 }
        };

        // GET: /Products
        public IActionResult Index()
        {
            // Pass data to the View
            return View(_products);
        }

        // GET: /Products/Details/1
        public IActionResult Details(int id)
        {
            var product = _products.Find(p => p.Id == id);
            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}

/*
  VIEW (Example: Views/Products/Index.cshtml)

  @model IEnumerable<MVCTutorial.Controllers.Product>

  <h2>Product List</h2>
  <ul>
    @foreach (var product in Model)
    {
        <li>
            <a href="/Products/Details/@product.Id">@product.Name</a> - $@product.Price
        </li>
    }
  </ul>

  ----------------------------------------------

  VIEW (Example: Views/Products/Details.cshtml)

  @model MVCTutorial.Controllers.Product

  <h2>@Model.Name</h2>
  <p>Price: $@Model.Price</p>
  <a href="/Products">Back to List</a>
*/

/*
  PROGRAM.CS (ASP.NET Core 9 minimal setup for MVC)

  var builder = WebApplication.CreateBuilder(args);

  // Add services for controllers and views
  builder.Services.AddControllersWithViews();

  var app = builder.Build();

  // Enable static files and MVC routing
  app.UseStaticFiles();
  app.UseRouting();

  app.MapControllerRoute(
      name: "default",
      pattern: "{controller=Products}/{action=Index}/{id?}");

  app.Run();
*/

/*
  SUMMARY:
  - Model: Handles data and logic
  - View: Displays the UI
  - Controller: Connects user input to data and views
  - Together, they make a clean, organized, and testable web application.
*/
