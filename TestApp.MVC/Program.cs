using Bentas.O2.WebExtensions.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using TestApp.MVC.Services;
using TestApp.MVC.Services.Interfaces;
using TestApp.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKendo();
builder.Services.AddSession();
// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<HttpClient>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUrlShortService, UrlShortService>();


builder.Services.AddSingleton(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement, UnicodeRanges.LatinExtendedA }));
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

app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name:"ShortUrl",
    pattern:"{ShortUrl}",
    new { controller = "Home", action = "Short" });
app.MapControllerRoute(
name: "default",
pattern: "{controller=Login}/{action=Index}/{id?}");




app.Run();
