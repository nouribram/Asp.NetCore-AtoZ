/** 
 Introduction to ASP.NET Core
================================
ASP.NET Core is a free, open-source, cross-platform framework for
 building modern web applications, APIs, and microservices.
It supports Windows, Linux, and macOS.

Key Features:
- High performance and scalability
- Built-in dependency injection
- Unified platform for web, API, and real-time apps
- Modular and lightweight architecture
- Cloud-ready and container-friendly
**/

// Create a new project
// dotnet new webapp -n MyApp
// cd MyApp
// dotnet run


/** 
Project Structure and Startup
========================================
A typical ASP.NET Core project includes:
- Program.cs – Application entry point
- appsettings.json – Configuration and environment settings
- Controllers/ – Handles HTTP requests
- Models/ – Contains data and business logic
- Views/ – Razor templates for UI
- wwwroot/ – Static assets (CSS, JS, images)
**/

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.MapDefaultControllerRoute();
app.Run();


/** 
Middleware and the Request Pipeline
=====================================
Middleware components process HTTP requests and responses in order.
Each request passes through the middleware pipeline.
Common middleware:
- UseRouting()
- UseStaticFiles()
- UseAuthentication()
- UseAuthorization()
- UseExceptionHandler()
**/

var app2 = builder.Build();
app2.UseRouting();
app2.UseAuthentication();
app2.UseAuthorization();
app2.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app2.Run();


/** 
Dependency Injection (DI)
======================================
ASP.NET Core includes built-in dependency injection for managing services and objects.

Service lifetimes:
- Transient – New instance every time
- Scoped – One instance per request
- Singleton – One instance for the entire app
**/

builder.Services.AddScoped<IMyService, MyService>();
builder.Services.AddSingleton<ILogger, Logger>();
builder.Services.AddTransient<IEmailService, EmailService>();

public class HomeController : Controller
{
    private readonly IMyService _service;
    public HomeController(IMyService service)
    {
        _service = service;
    }
}


/** 
 MVC Pattern and Razor Pages
============================================
ASP.NET Core uses the Model-View-Controller (MVC) pattern.

Model – Represents data and logic
View – Displays data (Razor templates)
Controller – Handles HTTP requests and responses
**/

public class HomeController2 : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

/** Razor View (Index.cshtml)
@model MyApp.Models.User
<h2>Welcome @Model.Name</h2>
**/


/** 
 Routing, Endpoints, and APIs
=========================================
Routing defines how URLs map to controllers and actions.

Conventional Routing:
**/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

/** Attribute Routing **/
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetUser(int id) => Ok();
}

/** Example REST API **/
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;
    public ProductsController(AppDbContext context) => _context = context;

    [HttpGet]
    public IEnumerable<Product> GetAll() => _context.Products.ToList();
}


/** 
 Data Access with Entity Framework Core
============================================
Entity Framework Core (EF Core) is the ORM used to interact with databases.
**/

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// dotnet ef migrations add InitialCreate
// dotnet ef database update


/** 
 Authentication, Authorization, and Security
==================================================
ASP.NET Core supports multiple authentication methods:
- Cookie-based
- JWT Bearer tokens
- OAuth & OpenID Connect
- ASP.NET Core Identity

Other security features:
- HTTPS enforcement
- Data protection
- CORS policies
**/

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
            ValidateIssuer = true,
            ValidateAudience = true
        };
    });

[Authorize]
[HttpGet("profile")]
public IActionResult Profile() => Ok("Private Data");


/** 
 Advanced Topics and Deployment
===========================================
Advanced Concepts:
- SignalR for real-time communication
- gRPC for high-performance RPC
- Background Services (HostedService)
- Caching (In-memory or distributed)
- Localization and Globalization
- Configuration Providers (JSON, Environment, Azure Key Vault)

Deployment:
dotnet publish -c Release -o out

Hosting Options:
- Kestrel
- IIS / Nginx
- Azure App Service
- Docker containers

Monitoring and Scaling:
- Application Insights
- Health Checks
- Serilog, NLog, Seq for logging
**/
