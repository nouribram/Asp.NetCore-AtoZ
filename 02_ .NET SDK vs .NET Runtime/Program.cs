/**
 .NET SDK vs .NET Runtime
 ---------------------------------------------
 Before building or running any .NET application, 
 it’s important to understand the difference between 
 the .NET SDK and the .NET Runtime.

 Both are essential parts of the .NET ecosystem, 
 but they serve different purposes.

 ---------------------------------------------
 What is the .NET Runtime?
 ---------------------------------------------
 The .NET Runtime is the environment where your .NET applications run.
 It includes the core libraries and the Common Language Runtime (CLR)
 responsible for executing compiled code.

 Think of it as the “engine” that powers your app.

 Key points:
 - Required to run .NET applications.
 - Includes the CLR and base libraries (System.*, Microsoft.*).
 - Does NOT include tools for creating new projects or compiling code.
 - Installed automatically when you deploy a .NET app.

 Example:
 If someone gives you a .NET app to run, 
 you only need the .NET Runtime installed.

 ---------------------------------------------
 What is the .NET SDK?
 ---------------------------------------------
 The .NET SDK (Software Development Kit) 
 includes everything a developer needs to build .NET apps.

 It contains:
 - The .NET Runtime
 - Developer tools (compiler, CLI tools)
 - Templates for creating projects
 - Build and publish tools

 Key points:
 - Needed for development and building new apps.
 - Allows you to create, build, run, and publish projects.
 - Developers install the SDK, not just the runtime.

 Example:
 If you want to run commands like:
    dotnet new web
    dotnet build
    dotnet run
 You need the .NET SDK installed.

 ---------------------------------------------
 Quick Comparison Summary
 ---------------------------------------------
 - .NET Runtime → Runs existing applications.
 - .NET SDK → Builds and runs applications (includes the runtime).

 In short:
 Every SDK includes a runtime, 
 but a runtime alone does not include the SDK.

 ---------------------------------------------
 How to Check What’s Installed
 ---------------------------------------------
 You can check your installed versions with these commands:

    dotnet --list-sdks
    dotnet --list-runtimes

 Or simply type:
    dotnet --info

 ---------------------------------------------
 Real Example:
 ---------------------------------------------
 Suppose you install only the .NET Runtime.
 You can run an app like this:
    dotnet MyApp.dll

 But you cannot create a new one because:
    dotnet new web
 will not work without the SDK.

 ---------------------------------------------
 Key Takeaways:
 ---------------------------------------------
 - The .NET Runtime runs apps.
 - The .NET SDK builds and runs apps.
 - Developers use the SDK.
 - End users only need the Runtime.
*/
