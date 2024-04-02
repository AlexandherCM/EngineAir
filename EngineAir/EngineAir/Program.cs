using EngineAir.Models;
using Microsoft.EntityFrameworkCore;
using MVC.Services.DesignPatterns;
using System.Globalization;
using MVC.Services.Services;
using MVC.Services.DesignPatterns.Repositories;
using MVC.Models.Entities;
using EngineAir.Hubs;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Settings for Mexico Spanish - - - - - - - - - - - - - - - - - - - - - - - - - -
var culture = new CultureInfo("es-MX");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// Agregar fuentes de configuración
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// Inyección de dependencias por sesión - - - - - - - - - - - - - - - - - - - - - 
// Únidad de trabajo y otros servicios
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); 
builder.Services.AddScoped<AutenticarService>();

// Servicios intermedios entre repositorio y Unidad de trabajo
builder.Services.AddScoped<ComponentService>();

// Repositorios
builder.Services.AddScoped<MarcaTipoRepository<MarcaMotor>>();
builder.Services.AddScoped<MarcaTipoRepository<MarcaHelice>>();
builder.Services.AddScoped<MarcaTipoRepository<TipoComponente>>();

// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

// Add services to the container - - - - - - - - - - - - - - - - - - - - - - - - -
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
// Configuraciones de autenticación por roles - - - - - - - - - - - - - - - - - - - - - -
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Home/Login";
        option.ExpireTimeSpan = TimeSpan.FromSeconds(10);
        option.AccessDeniedPath = "/Home/Privacy";
    });

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

// CONFIGURACIÓN DE LOS ROLES
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

// Configuración de los Sockets
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/ChatMessage");
});

app.Run();
