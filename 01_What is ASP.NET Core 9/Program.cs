/**
 What is ASP.NET Core 9?
 ---------------------------------------------
 ASP.NET Core 9 is the latest version of Microsoft's open-source,
 cross-platform web framework for building modern web applications,
 APIs, and cloud-based services using .NET 9.

 It runs on Windows, macOS, and Linux.
 It supports high performance, scalability, and modular design.
 It is built on top of .NET 9, which includes improvements in speed,
 cloud integration, AI support, and developer productivity.

 ASP.NET Core 9 helps developers create:
 - Web applications (MVC or Razor Pages)
 - RESTful APIs (using Minimal APIs or Controllers)
 - Real-time apps (using SignalR)
 - Microservices (container-friendly)
 - Serverless functions (with Azure Functions)

 Why ASP.NET Core 9 Matters:
 - Unified platform for web, mobile, desktop, cloud, and IoT.
 - Better performance than older .NET versions.
 - Simplified configuration and hosting model.
 - Improved security and identity management.
 - Deep integration with AI, Docker, and Kubernetes.
 ---------------------------------------------
 Example: ASP.NET Core 9 Minimal API
 ---------------------------------------------
 Below is an example using a Minimal API.
 This approach is simple and great for small APIs and microservices.

 To try it yourself:
 1. Install .NET 9 SDK from https://dotnet.microsoft.com/download
 2. Open your terminal and run:
    dotnet new web -n MyFirstApp
    cd MyFirstApp
    dotnet run

 Then open your browser and go to:
 https://localhost:5001
 You should see: "Hello from ASP.NET Core 9!"
 ---------------------------------------------
 Program.cs Example
 ---------------------------------------------
*/

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

/** 
 Add minimal API services 
*/
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/**
 Enable Swagger for API documentation
*/
app.UseSwagger();
app.UseSwaggerUI();

/**
 Define a simple GET endpoint
*/
app.MapGet("/", () => "Hello from ASP.NET Core 9!");

/**
 Run the application
*/
app.Run();

/**
 Key Takeaways:
 ---------------------------------------------
 ASP.NET Core 9 focuses on performance, modularity, and simplicity.
 It is ideal for APIs, cloud-native apps, and AI-driven backends.
 Minimal APIs reduce boilerplate and make development faster.
*/
