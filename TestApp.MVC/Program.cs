using Bentas.O2.Core;
using Bentas.O2.Core.Interfaces;
using Bentas.O2.TagHelpers;
using Bentas.O2.WebExtensions.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using TestApp.MVC.Services;
using TestApp.MVC.Services.Interfaces;
using TestApp.Repository;
using TestApp.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSession();

//Kendo için Json Formatýnýn AddNewtonJson olduðu belirtilir
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());
builder.Services.AddKendo();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    //appsettingsten okuyacaðý kýsým
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

//Default Validation mesajlarýný engellemke için Kullanýlýr
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddScoped<HttpClient>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUrlShortService, UrlShortService>();
builder.Services.AddSingleton<IJsonHelper, JsonNetHelper>();


//Türkçe desteði için kullanýlýr
builder.Services.AddSingleton(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement, UnicodeRanges.LatinExtendedA }));
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

//Controller ve Action adý belirtmeden direkt parametre alabilmesini saðlar
app.MapControllerRoute(
    name:"ShortUrl",
    pattern:"{ShortUrl}",
    new { controller = "Home", action = "Short" });
app.MapControllerRoute(
name: "default",
pattern: "{controller=Login}/{action=Index}/{id?}");




app.Run();
