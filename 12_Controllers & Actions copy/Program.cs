/* =============================================
   Controllers & Actions
   ASP.NET Core 9
   =============================================
   MVC in ASP.NET Core uses:
   - Controllers (C)
   - Views (V)
   - Models (M)

   A Controller:
   - Accepts HTTP requests
   - Executes logic
   - Returns a response

   An Action:
   - A public method inside a controller
   - Handles one specific request
   ============================================= */
public class ControllersAndActions
{
    /* -----------------------------------------
       1. Creating a Controller
       -----------------------------------------
       File location:
       /Controllers/HomeController.cs

       Example:

       using Microsoft.AspNetCore.Mvc;

       public class HomeController : Controller
       {
         public IActionResult Index()
         {
           return Content("Hello from HomeController");
         }
       }

       - Controller inherits from Controller class
       - Index() is an Action method
       ----------------------------------------- */



    /* -----------------------------------------
       2. Default Routing Convention
       -----------------------------------------
       Default route format:

       /{controller}/{action}/{id?}

       Example request:
       /Home/Index

       Calls:
       HomeController.Index()

       Optional "id" parameter is used often for CRUD.
       ----------------------------------------- */



    /* -----------------------------------------
        3. Returning Different Action Results
       -----------------------------------------
       Common ActionResult types:

       return View();         // Returns a View (HTML)
       return Json(data);     // Returns JSON
       return Content("Hi");  // Returns plain text
       return File(...);      // Returns a file
       return Redirect("/");  // Redirects the browser

       Actions can return:
       - IActionResult
       - ActionResult<T>
       ----------------------------------------- */



    /* -----------------------------------------
       4. Parameters in Actions
       -----------------------------------------
       public IActionResult Details(int id)
       {
         return Content("Item ID = " + id);
       }

       Request:
       /Home/Details/15

       Output:
       Item ID = 15
       ----------------------------------------- */



    /* -----------------------------------------
       5. GET and POST Actions
       -----------------------------------------
       [HttpGet]
       public IActionResult Create()
       {
         return View();
       }

       [HttpPost]
       public IActionResult Create(User user)
       {
         // Save to database
         return RedirectToAction("Index");
       }

       - Used for forms and CRUD operations
       ----------------------------------------- */



    /* -----------------------------------------
       6. Attribute Routing
       -----------------------------------------
       [Route("products")]
       public class ProductsController : Controller
       {
         [Route("")]
         [Route("list")]
         public IActionResult List()
         {
           return Content("Product List");
         }

         [Route("details/{id}")]
         public IActionResult Details(int id)
         {
           return Content("Product ID: " + id);
         }
       }

       Request examples:
       /products
       /products/list
       /products/details/7
       ----------------------------------------- */



    /* -----------------------------------------
       7. Model Binding
       -----------------------------------------
       ASP.NET Core automatically maps:
       - Query strings
       - Form data
       - Route data
       - JSON body

       Example:

       public IActionResult Save(User user)
       {
         return Json(user);
       }

       Sends JSON → receives C# object automatically
       ----------------------------------------- */



    /* -----------------------------------------
        8. Dependency Injection in Controllers
       -----------------------------------------
       public class AccountController : Controller
       {
         private readonly ILogger<AccountController> _logger;

         public AccountController(
           ILogger<AccountController> logger)
         {
           _logger = logger;
         }

         public IActionResult Login()
         {
           _logger.LogInformation("Login accessed");
           return View();
         }
       }

       Controllers support DI by default.
       ----------------------------------------- */



    /* -----------------------------------------
       9. Summary
       -----------------------------------------
       Controllers:
       - Handle requests
       - Contain public action methods

       Actions:
       - Return different response types
       - Support parameters
       - Can use routing attributes
       - Use dependency injection

       Mastering controllers & actions is essential
       for MVC applications in ASP.NET Core 9.
       ----------------------------------------- */
}
