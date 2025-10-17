/**
 Installing .NET 9 and Setting Up Visual Studio / VS Code
 --------------------------------------------------------
 Before building your first ASP.NET Core 9 application,
 you need to install the .NET 9 SDK and set up your development environment.

 This guide walks you through:
 - Installing the .NET 9 SDK
 - Setting up Visual Studio or Visual Studio Code
 - Verifying the installation
 - Creating your first project
 --------------------------------------------------------
 Step 1: Install the .NET 9 SDK
 --------------------------------------------------------
 The .NET SDK includes the tools required to build, run, and publish .NET apps.

 1. Go to the official download page:
    https://dotnet.microsoft.com/download

 2. Choose your operating system:
    - Windows
    - macOS
    - Linux

 3. Download and install the latest version of the .NET 9 SDK.

 After installation, open a terminal or command prompt and verify:
    dotnet --version

 If it shows something like:
    9.0.x
 Then the SDK is successfully installed.
 --------------------------------------------------------
 Step 2: Install an IDE (Development Environment)
 --------------------------------------------------------
 You can use either:
 - Visual Studio 2022 (or later)
 - Visual Studio Code

 Both are official Microsoft tools that support .NET 9.

 --------------------------------------------------------
 Option A: Visual Studio
 --------------------------------------------------------
 1. Download from: https://visualstudio.microsoft.com
 2. During installation, select:
    “ASP.NET and web development” workload.
 3. After setup, open Visual Studio.
 4. Create a new project → choose “ASP.NET Core Web App”.
 5. Make sure the target framework is set to “.NET 9.0”.

 Visual Studio provides:
 - Built-in templates
 - Debugging tools
 - IntelliSense (smart code completion)
 - GUI project management

 --------------------------------------------------------
 Option B: Visual Studio Code
 --------------------------------------------------------
 1. Download from: https://code.visualstudio.com
 2. Install the following extensions:
    - C# Dev Kit
    - .NET Install Tool
    - IntelliCode (optional but helpful)
 3. Open a new folder for your project.
 4. Create a new .NET app using the terminal:
    dotnet new web -n MyWebApp
 5. Open the folder “MyWebApp” in VS Code.

 VS Code provides:
 - Lightweight and fast environment
 - Integrated terminal
 - Cross-platform compatibility
 - Perfect for developers who prefer simplicity

 --------------------------------------------------------
 Step 3: Verify the Setup
 --------------------------------------------------------
 Run this command inside your project folder:
    dotnet run

 Then open your browser and go to:
    https://localhost:5001

 You should see the default ASP.NET Core 9 welcome page.

 --------------------------------------------------------
 Step 4: (Optional) Install Git and GitHub CLI
 --------------------------------------------------------
 Version control is essential for modern development.
 You can install:
    https://git-scm.com
 and optionally:
    https://cli.github.com

 This lets you initialize repositories and push code to GitHub.

 --------------------------------------------------------
 Key Takeaways:
 --------------------------------------------------------
 - Install the .NET 9 SDK (includes compiler and runtime).
 - Choose an IDE: Visual Studio (full) or VS Code (lightweight).
 - Verify installation with “dotnet --version”.
 - Create and run a sample project to confirm setup.
 - You are now ready to start developing with ASP.NET Core 9.
*/
