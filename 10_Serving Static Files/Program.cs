/* =============================================
    Serving Static Files in ASP.NET Core 9
   =============================================
   ASP.NET Core can serve static files such as:
   - HTML
   - CSS
   - JavaScript
   - Images (PNG, JPG, SVG)
   - PDFs and other assets

   Static files are served from the *wwwroot* folder
   by default. You only need to enable it in the
   middleware pipeline.
   ============================================= */
public class ServingStaticFiles
{
    /* -----------------------------------------
       1. Enable Static Files in Program.cs
       -----------------------------------------
       In ASP.NET Core 9, add this to Program.cs:

       var builder = WebApplication.CreateBuilder(args);
       var app = builder.Build();

       // Enable serving static files
       app.UseStaticFiles();

       app.Run();

       Without UseStaticFiles(), ASP.NET Core will
       NOT serve any static content.
       ----------------------------------------- */



    /* -----------------------------------------
        2. wwwroot Folder
       -----------------------------------------
       Static files MUST be placed inside:
         wwwroot/

       Example folder structure:

       wwwroot/
         css/
           site.css
         js/
           app.js
         images/
           logo.png

       To access a file:
       /css/site.css
       /images/logo.png

       The wwwroot folder becomes the web server’s
       public root directory.
       ----------------------------------------- */



    /* -----------------------------------------
        3. Accessing Static Files
       -----------------------------------------
       Example:

       <link rel="stylesheet" href="/css/site.css" />
       <script src="/js/app.js"></script>
       <img src="/images/logo.png" />

       The path is relative to wwwroot.
       ----------------------------------------- */



    /* -----------------------------------------
        4. Serving Static Files from a Custom Folder
       -----------------------------------------
       Example: serve files from "Static" folder.

       app.UseStaticFiles(new StaticFileOptions
       {
           FileProvider = new PhysicalFileProvider(
               Path.Combine(builder.Environment.ContentRootPath, "Static")),
           RequestPath = "/static"
       });

       Now anything inside /Static can be accessed at:

       /static/fileName.ext

       Useful for downloads, uploads, documentation, etc.
       ----------------------------------------- */



    /* -----------------------------------------
        5. Enable Directory Browsing (Optional)
       -----------------------------------------
       WARNING: Not recommended in production.

       builder.Services.AddDirectoryBrowser();

       app.UseDirectoryBrowser(new DirectoryBrowserOptions
       {
           FileProvider = new PhysicalFileProvider(
               Path.Combine(builder.Environment.ContentRootPath, "wwwroot")),
           RequestPath = "/files"
       });

       Now visiting:
         /files

       will list all files in wwwroot.
       ----------------------------------------- */



    /* -----------------------------------------
        6. MIME Types Support
       -----------------------------------------
       ASP.NET Core automatically identifies file types:
       - .css → text/css
       - .js → application/javascript
       - .png → image/png
       - .jpg → image/jpeg
       - .pdf → application/pdf

       Custom MIME types can be added if needed.
       ----------------------------------------- */



    /* -----------------------------------------
        7. Security Notes
       -----------------------------------------
       Static files:
       - Are NOT secure
       - Skip authorization
       - Must not contain sensitive data

       Anything in wwwroot is public.
       ----------------------------------------- */
}
