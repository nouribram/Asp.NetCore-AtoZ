/* =============================================
   Using appsettings.json for Configuration
   ASP.NET Core 9
   =============================================
   appsettings.json is the main configuration file
   in ASP.NET Core applications.

   It stores key-value settings such as:
   - Database connection strings
   - API keys
   - Environment settings
   - Logging configuration
   - Custom application settings

   Configuration is loaded automatically at startup.
   ============================================= */
public class AppSettingsConfiguration
{
    /* -----------------------------------------
        1. Default appsettings.json Structure
       -----------------------------------------
       Example appsettings.json:

       {
         "AppSettings": {
           "ApplicationName": "MyApp",
           "Version": "1.0"
         },
         "ConnectionStrings": {
           "DefaultConnection": "Server=.;Database=TestDB;Trusted_Connection=True;"
         },
         "Logging": {
           "LogLevel": {
             "Default": "Information"
           }
         }
       }
       ----------------------------------------- */



    /* -----------------------------------------
        2. Reading Configuration in Program.cs
       -----------------------------------------
       var builder = WebApplication.CreateBuilder(args);

       // Access values
       string? appName = builder.Configuration["AppSettings:ApplicationName"];
       string? version = builder.Configuration["AppSettings:Version"];

       string? connectionString =
           builder.Configuration.GetConnectionString("DefaultConnection");

       var app = builder.Build();
       app.Run();

       - builder.Configuration reads values from appsettings.json
       - Use ":" to access nested values
       ----------------------------------------- */



    /* -----------------------------------------
        3. Using GetSection()
       -----------------------------------------
       IConfigurationSection section =
           builder.Configuration.GetSection("AppSettings");

       string? appName = section["ApplicationName"];
       string? version = section["Version"];
       ----------------------------------------- */



    /* -----------------------------------------
        4. Strongly Typed Settings Class
       -----------------------------------------
       Define a C# model:

       public class AppSettings
       {
         public string ApplicationName { get; set; }
         public string Version { get; set; }
       }

       Bind to appsettings.json:

       builder.Services.Configure<AppSettings>(
           builder.Configuration.GetSection("AppSettings"));

       Use in a controller:

       public class HomeController : Controller
       {
         private readonly AppSettings _settings;

         public HomeController(
             IOptions<AppSettings> settings)
         {
           _settings = settings.Value;
         }

         public IActionResult Index()
         {
           var name = _settings.ApplicationName;
           return Content("App: " + name);
         }
       }
       ----------------------------------------- */



    /* -----------------------------------------
        5. Using Environment-Specific Settings
       -----------------------------------------
       Recommended additional files:

       appsettings.Development.json
       appsettings.Production.json
       appsettings.Staging.json

       ASP.NET Core loads automatically based on:

       ASPNETCORE_ENVIRONMENT

       Example:

       setx ASPNETCORE_ENVIRONMENT "Development"
       ----------------------------------------- */



    /* -----------------------------------------
        6. Secret & Sensitive Data Best Practice
       -----------------------------------------
       DO NOT store:
       - Passwords
       - API keys
       - JWT secrets
       - Connection strings (in production)

       Use instead:
       - User secrets (development)
       - Azure Key Vault
       - Environment variables
       ----------------------------------------- */



    /* -----------------------------------------
        7. Reload on Change (Optional)
       -----------------------------------------
       Enable automatic reload when file changes:

       var builder = WebApplication.CreateBuilder(
         new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build()
       );

       Useful for development hot reload.
       ----------------------------------------- */



    /* -----------------------------------------
        8. Summary
       -----------------------------------------
       appsettings.json is the core configuration
       system in ASP.NET Core 9.

       Key concepts:
       - builder.Configuration[] for direct access
       - GetSection() for structured data
       - Strongly typed settings with IOptions<T>
       - Environment-specific JSON files
       - Never store secrets in plain text
       ----------------------------------------- */
}
