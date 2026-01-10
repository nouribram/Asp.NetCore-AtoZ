/*
    Topic: Tag Helpers & View Components in ASP.NET Core 9

    Tag Helpers and View Components are used to build clean,
    reusable, and maintainable UI components in Razor Views.
*/

/* ------------------------------------------
   1. TAG HELPERS — INTRODUCTION
------------------------------------------- */
/*
    Tag Helpers:
    - Are server-side helpers
    - Look like normal HTML tags or attributes
    - Are processed on the server
    - Generate dynamic HTML

    Example:
    <a asp-controller="Home" asp-action="Index">Home</a>
*/


/* ------------------------------------------
   2. COMMON BUILT-IN TAG HELPERS
------------------------------------------- */

/*
    Anchor Tag Helper
*/
<a asp-controller="Home" asp-action="Index">Go Home</a>

/*
    Form Tag Helper
*/
<form asp-controller="Account" asp-action="Login" method="post">
    <input asp-for="Email" />
    <input asp-for="Password" type="password" />
    <button type="submit">Login</button>
</form>

/*
    Input & Label Tag Helpers
*/
<label asp-for="Email"></label>
<input asp-for="Email" />
<span asp-validation-for="Email"></span>


/* ------------------------------------------
   3. ENABLE TAG HELPERS (_ViewImports.cshtml)
------------------------------------------- */
/*
    File: /Views/_ViewImports.cshtml

    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
*/


/* ------------------------------------------
   4. WHAT IS A VIEW COMPONENT?
------------------------------------------- */
/*
    View Components:
    - Similar to partial views but more powerful
    - Contain C# logic
    - Do NOT use HTTP requests
    - Are reusable UI blocks

    Examples:
    - Navbar
    - Sidebar
    - User profile card
    - Notifications panel
*/


/* ------------------------------------------
   5. CREATING A VIEW COMPONENT
------------------------------------------- */

/*
    File: /ViewComponents/UserProfileViewComponent.cs
*/
using Microsoft.AspNetCore.Mvc;

public class UserProfileViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var userName = "Nour";
        return View("Default", userName);
    }
}


/* ------------------------------------------
   6. VIEW COMPONENT VIEW FILE
------------------------------------------- */
/*
    File location:
    /Views/Shared/Components/UserProfile/Default.cshtml
*/

@model string

<div class="user-profile">
    <strong>User:</strong> @Model
</div>


/* ------------------------------------------
   7. USING VIEW COMPONENT IN A RAZOR VIEW
------------------------------------------- */

/*
    Method 1 — Razor syntax
*/
@await Component.InvokeAsync("UserProfile")

/*
    Method 2 — Tag Helper syntax
*/
<vc:user-profile></vc:user-profile>


/* ------------------------------------------
   8. DIFFERENCE: PARTIAL VIEW vs VIEW COMPONENT
------------------------------------------- */
/*
    Partial View:
    - UI only
    - No logic

    View Component:
    - UI + C# logic
    - Better for dynamic data
*/


/* ------------------------------------------
   SUMMARY
------------------------------------------- */
/*
    - Tag Helpers simplify Razor HTML syntax
    - They bind HTML to controllers, models, and routes
    - View Components create reusable dynamic UI blocks
    - Use View Components instead of partial views when logic is required
*/
