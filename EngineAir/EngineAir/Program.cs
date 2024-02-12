using EngineAir.Models;
using Microsoft.EntityFrameworkCore;
using MVC.Services.Classes.Brands;
using MVC.Services.Classes.Components;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Settings for Mexico Spanish
var culture = new CultureInfo("es-MX");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Context"),
        sqlServerOptions => sqlServerOptions.MigrationsAssembly("MVC.Models")
    );
});
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

var app = builder.Build();
using (var serviceScope = app.Services.CreateScope())
{
    var serviceProvider = serviceScope.ServiceProvider;

    // Get the context
    var context = serviceProvider.GetRequiredService<Context>();

    // Initialize the ComponentType and call the AddTypes method
    var componentType = new ComponentType(context);
    componentType.AddTypes().Wait(); // async/await en lugar de Wait
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Variantes}/{action=Alternador}/{id?}");

app.Run();
