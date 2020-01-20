Install package in project

Microsoft.AspNetCore.Identity.EntityFrameworkCore
Microsoft.EntityFrameworkCore.InMemory

Install Bootstrap in ASP.NET Core.

Step 1 : Right Click then select Client Script Library.

Step 2 : In Drop Down Select unpack then type "Library@version" for example - bootstrap@4.0.0

Step 3 : Install dependent library on bootstrap 4 version with same step

# Check Dependent library version of bootstrap 4 then open bootstrap link CDN link 
# Use bootstrap library reference in either webpage.cshtm or Layout File

Step 1:
/*
<link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />
<script src="~/lib/jquery/dist/jquery.js"></script>
<script src="~/lib/bootstrap/dist/js/bootstrap.js"></script>
*/

Step 2: Use in Configure File 

app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),@"wwwroot"))
            });
