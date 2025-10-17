/**
 Creating Your First ASP.NET Core 9 Web App
 --------------------------------------------------------
 it’s time to create and run your first ASP.NET Core 9 web application.

 --------------------------------------------------------
 Step 1: Create a New Project
 --------------------------------------------------------
 You can create your project using either:
 - Visual Studio
 - Visual Studio Code (or any terminal)

 --------------------------------------------------------
 Option A: Using Visual Studio
 --------------------------------------------------------
 1. Open Visual Studio.
 2. Click “Create a new project”.
 3. Search for “ASP.NET Core Web App” and select it.
 4. Click “Next” and name your project (for example: MyFirstWebApp).
 5. Choose a location and click “Next”.
 6. Under Framework, select “.NET 9.0”.
 7. Click “Create”.

 Visual Studio will automatically generate the starter files and folder structure.

 --------------------------------------------------------
 Option B: Using the .NET CLI (Command Line)
 --------------------------------------------------------
 1. Open your terminal or command prompt.
 2. Run the following commands:

    dotnet new web -n MyFirstWebApp
    cd MyFirstWebApp

 This creates a minimal ASP.NET Core 9 app inside the folder “MyFirstWebApp”.

 --------------------------------------------------------
 Step 2: Explore the Project Structure
 --------------------------------------------------------
 Let’s look at the key files created by default:

 - Program.cs → The entry point of your application.
 - appsettings.json → Configuration settings like database connections or logging.
 - Properties/ → Contains launch settings for running locally.
 - wwwroot/ → Public folder for static files like CSS, JS, and images.

 In ASP.NET Core 9, the default template uses a “Minimal API” structure.
 This means your Program.cs file handles routing, configuration, and startup.

 --------------------------------------------------------
 Step 3: Open Program.cs
 --------------------------------------------------------
 You’ll see something like this by default:

    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();

    app.MapGet("/", () => "Hello, ASP.NET Core 9!");
    app.Run();

 This is a simple web server that responds to requests on the root URL (“/”).

 --------------------------------------------------------
 Step 4: Run the App
 --------------------------------------------------------
 Run the following command inside your project folder:

    dotnet run

 You’ll see console output similar to:
    Now listening on: https://localhost:5001
    Application started. Press Ctrl+C to shut down.

 Open your browser and visit:
    https://localhost:5001

 You should see the message:
    Hello, ASP.NET Core 9!

 --------------------------------------------------------
 Step 5: Customize the Message
 --------------------------------------------------------
 Try editing the message in Program.cs to something else:

    app.MapGet("/", () => "Welcome to My First ASP.NET Core 9 App!");

 Save your changes, restart the app, and refresh your browser.
 You’ll see your new message instantly.

 --------------------------------------------------------
 Step 6: Add Another Route
 --------------------------------------------------------
 You can define more endpoints easily:

    app.MapGet("/about", () => "This is the About page.");
    app.MapGet("/contact", () => "Contact us at info@example.com");

 Each route represents a different page or API endpoint.

 --------------------------------------------------------
 Step 7: Stop the App
 --------------------------------------------------------
 When you’re done, press Ctrl + C in your terminal
 (or stop debugging in Visual Studio).

 --------------------------------------------------------
 Key Takeaways:
 --------------------------------------------------------
 - ASP.NET Core 9 makes web app creation simple and fast.
 - Minimal APIs use less code and load faster.
 - You can build and run apps from either Visual Studio or the command line.
 - The Program.cs file is where everything starts.
 - You now have a working web app running locally on .NET 9.
*/
