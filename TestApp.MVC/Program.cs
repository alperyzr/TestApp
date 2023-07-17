using Bentas.O2.WebExtensions.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TestApp.MVC.Services;
using TestApp.MVC.Services.Interfaces;
using TestApp.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKendo();

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<HttpClient>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ILoginService, LoginService>();  
builder.Services.AddScoped<IUserService, UserService>();  
builder.Services.AddScoped<IUserRoleService, UserRoleService>();  
builder.Services.AddScoped<IRoleService, RoleService>();  
builder.Services.AddScoped<IUrlShortService, UrlShortService>();  

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
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
