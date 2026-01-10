/*
    Razor Views & Layouts in ASP.NET Core 9

    Description:
    Razor Views are the UI (HTML + C#) files used in MVC applications.
    They use special Razor syntax: @variable, @if, @foreach, etc.

    Layouts allow you to define a shared template (header, footer, CSS, JS)
    so pages reuse the same structure.
*/

/* ------------------------------------------
   1. Basic Razor View Example (Index.cshtml)
------------------------------------------- */

@{
    ViewData["Title"] = "Home Page";
}

<h1>@ViewData["Title"]</h1>
<p>Welcome to Razor Views!</p>

/*
    Razor Syntax Notes:
    @variable        → print variable
    @if(condition)   → conditional
    @foreach(...)    → loop
*/


/* ------------------------------------------
   2. Layout File Example (_Layout.cshtml)
------------------------------------------- */

<!DOCTYPE html>
<html>
<head>
    <title>@ViewData["Title"] - MyApp</title>
    <link rel="stylesheet" href="~/css/site.css" />
</head>
<body>
    <header>
        <h2>My Application Layout</h2>
    </header>

    <main>
        @RenderBody()  // The unique page content appears here
    </main>

    <footer>
        <p>© 2025 MyApp</p>
    </footer>
</body>
</html>

/*
    RenderBody() → Displays the main content from each page.
    RenderSection() → Displays named content sections if defined.
*/


/* ------------------------------------------------------
   3. Connecting a View to a Layout (Index.cshtml)
------------------------------------------------------- */

@{
    Layout = "_Layout";
    ViewData["Title"] = "Home";
}

<h1>Welcome!</h1>
<p>This page uses the shared layout.</p>


/* ------------------------------------------------------
   4. Optional: Using @section for custom scripts
------------------------------------------------------- */

<!-- In a View -->
@section Scripts {
    <script>
        console.log("Page-specific script loaded");
    </script>
}

<!-- In _Layout.cshtml -->
@RenderSection("Scripts", required: false)

/*
    This allows each Razor view to add extra JS or content.
*/


/* ------------------------------------------------------
   Summary
------------------------------------------------------- */
/*
    - Razor Views render UI using HTML + C#.
    - Layouts allow you to create a shared master template.
    - Use @RenderBody() for the main content area.
    - Use @RenderSection() for optional custom sections.
    - Use @ViewData or a ViewModel to send data to the View.
*/
