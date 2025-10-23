/**
 =========================================================
 Understanding how Middleware works in ASP.NET Core
 ==========================================================

*/

/**
 Middleware are components that handle requests and responses
 as they pass through the ASP.NET Core request pipeline.

 Every incoming HTTP request travels through a series of middleware
 before reaching the endpoint (Controller, Razor Page, etc.),
 and every response travels back through the same pipeline.
*/

/**
 1. What is Middleware?

 Middleware are small building blocks that:
 - Inspect, modify, or handle requests and responses.
 - Decide whether to pass the request to the next middleware or stop it.

 They are executed in the order they are added in Program.cs.
*/

/**
 Example of a simple custom middleware:
 
 app.Use(async (context, next) =>
 {
     // Before next middleware
     Console.WriteLine("Request incoming: " + context.Request.Path);

     await next.Invoke(); // Pass to next middleware

     // After next middleware
     Console.WriteLine("Response outgoing: " + context.Response.StatusCode);
 });
*/

/**
 2. Built-in Middleware in ASP.NET Core

 ASP.NET Core provides several built-in middleware components:
 
 - UseRouting() → Finds the correct endpoint (Controller, Razor Page, etc.)
 - UseAuthentication() → Validates user identity
 - UseAuthorization() → Checks user permissions
 - UseStaticFiles() → Serves static files from wwwroot
 - UseEndpoints() → Executes the matched endpoint
 - UseCors() → Manages Cross-Origin Resource Sharing (CORS)
 - UseExceptionHandler() → Handles global errors
 - UseHttpsRedirection() → Redirects HTTP to HTTPS
*/

/**
 3. Middleware Execution Order

 The order of middleware is very important.
 For example:
 
 var builder = WebApplication.CreateBuilder(args);
 var app = builder.Build();

 app.UseHttpsRedirection();
 app.UseStaticFiles();
 app.UseRouting();
 app.UseAuthentication();
 app.UseAuthorization();

 app.MapDefaultControllerRoute();

 app.Run();
 
 The pipeline executes in the order defined above.
 If UseRouting() came after UseAuthorization(), routes might not be found.
*/

/**
 4. Creating a Custom Middleware Class

 You can define your own middleware as a class:

 public class LoggingMiddleware
 {
     private readonly RequestDelegate _next;

     public LoggingMiddleware(RequestDelegate next)
     {
         _next = next;
     }

     public async Task InvokeAsync(HttpContext context)
     {
         Console.WriteLine($"Request Path: {context.Request.Path}");
         await _next(context);
         Console.WriteLine($"Response Code: {context.Response.StatusCode}");
     }
 }

 Then register it in Program.cs:
 
 app.UseMiddleware<LoggingMiddleware>();
*/

/**
 5. The Request Pipeline Flow

 1. Request enters the pipeline.
 2. Each middleware can:
    - Process the request
    - Call the next middleware (next())
    - Or short-circuit and generate a response
 3. The final middleware (e.g., endpoints) returns a response.
 4. Response flows back through all middleware in reverse order.
*/

/**
 Example Request Flow:
 
 [Client Request]
   ↓
 UseExceptionHandler
   ↓
 UseHttpsRedirection
   ↓
 UseRouting
   ↓
 UseAuthentication → UseAuthorization
   ↓
 UseEndpoints (Controller executes)
   ↓
 [Response travels back up]
*/

/**
 Summary

 Middleware are the core of ASP.NET Core.
 They define how your app handles HTTP requests and responses.


 - Middleware executes in order.
 - Each component can inspect, modify, or short-circuit a request.
 - You can combine built-in and custom middleware.
 - The pipeline gives you full control over request handling.
*/
