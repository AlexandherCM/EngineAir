using EngineAir.Models;
using Microsoft.EntityFrameworkCore;
using MVC.Services.DesignPatterns;
using System.Globalization;
using MVC.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Settings for Mexico Spanish - - - - - - - - - - - - - - - - - - - - - - - - - -
var culture = new CultureInfo("es-MX");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// Agregar fuentes de configuración
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// Inyección de dependencias por sesión - - - - - - - - - - - - - - - - - - - - - 
// Únidad de trabajo
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); 

// Repositorios

// Servicios intermedios entre repositorio y Unidad de trabajo
builder.Services.AddScoped<ComponentService>();

// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

// Add services to the container - - - - - - - - - - - - - - - - - - - - - - - - -
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
    pattern: "{controller=Componentes}/{action=Variante}/{id?}");

app.Run();
