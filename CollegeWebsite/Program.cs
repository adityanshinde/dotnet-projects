/*
 Study notes - Program.cs

 What this file contains:
 - App startup for an ASP.NET Core MVC app using top-level statements (no explicit Main method).

 Key concepts & keywords used here:
 - using: import namespaces for builder, services and hosting.
 - var: C# type inference; the compiler determines the variable type from the expression.
 - WebApplication.CreateBuilder(args): bootstraps the host, configuration and dependency injection container.
 - builder.Services.AddControllersWithViews(): registers MVC services (controllers + Razor views) into DI.
 - builder.Build(): builds the WebApplication instance which is used to configure middleware and endpoints.
 - app.Use...(): middleware registration order is significant — requests pass through each middleware.
 - app.MapControllerRoute(...): sets up conventional routing for controllers and actions.
 - app.Run(): starts the application and blocks the current thread until shutdown.

 Basic startup/workflow:
 1. Create a builder that configures services and host settings.
 2. Register services via builder.Services (e.g., AddControllersWithViews, DB contexts, authentication).
 3. Build the app to obtain a pipeline object.
 4. Configure middleware in the correct order (exception handling, static files, routing, auth).
 5. Map endpoints (controller routes) and call Run() to start serving requests.

 Note on environment checks:
 - app.Environment.IsDevelopment() helps enable developer-only features (detailed errors, hot reload).

*/
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
