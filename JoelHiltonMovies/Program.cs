// Create a new instance of the web application builder.
using JoelHiltonMovies.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add the NewMovieContext to the service container, configuring it to use SQLite.
builder.Services.AddDbContext<NewMovieContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:JoelHiltonMovieConnection"]);
});

// Build the application.
var app = builder.Build();

// Configure the HTTP request pipeline.

// Check if the application is not running in development mode.
if (!app.Environment.IsDevelopment())
{
    // Use the error handler middleware to redirect to the Error action method in HomeController.
    app.UseExceptionHandler("/Home/Error");

    // Enable HTTP Strict Transport Security (HSTS).
    app.UseHsts();
}

// Redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Serve static files (e.g., HTML, CSS, JavaScript).
app.UseStaticFiles();

// Enable routing.
app.UseRouting();

// Enable authorization.
app.UseAuthorization();

// Map the default controller route.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the application.
app.Run();