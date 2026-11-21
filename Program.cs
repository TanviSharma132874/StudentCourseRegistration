var builder = WebApplication.CreateBuilder(args);

// Register MVC (controllers + Razor views) in the dependency injection container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();   // serves files from wwwroot
app.UseRouting();

// Default route: /Controller/Action/Id  (for example /Student/Details/1)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
