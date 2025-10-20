/** Understanding Program.cs & Startup.cs (and the new minimal hosting model)
-------------------------------------------------------------


What is Program.cs?
----------------------
Program.cs is the entry point of your ASP.NET Core application.
It’s where the app starts running.


 OLD STYLE 

/**
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MyWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
**/

/**
The Startup.cs file looked like this:

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

Summary:
- Program.cs starts the app and loads Startup.cs
- Startup.cs configures services and middleware
**/


using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);  /** Create the builder **/

/** Add services to the container (like Startup.ConfigureServices) **/
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();  /** Build the app (like Startup.Configure) **/

/** Configure the HTTP request pipeline (like Startup.Configure) **/
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();  /** Map routes to controllers **/
app.Run();  /** Run the app **/

/**
Key Differences Between Old and New Models:
-------------------------------------------
1. No Startup.cs file — all logic goes inside Program.cs.
2. No explicit Main() method — handled automatically.
3. Builder pattern replaces Host.CreateDefaultBuilder().
4. Easier to read, less boilerplate code.
5. Still allows splitting files if needed for organization.
**/

/**
You Can Still Use Startup.cs with the New Model:
---------------------------------------------------
If you prefer the traditional structure:

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();
var startup = new Startup();
startup.ConfigureServices(builder.Services);
startup.Configure(app, app.Environment);

app.Run();

This lets you gradually migrate older projects.
**/

/**
Summary:
-----------
- ASP.NET Core’s startup process is now unified into Program.cs
- You can still use Startup.cs if you prefer
- Minimal hosting model = cleaner, faster, modern syntax

Tip: Use the minimal model for small APIs and microservices.
Use Startup.cs for large enterprise apps if you like separation of concerns.
**/
