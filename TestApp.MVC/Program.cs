using Bentas.O2.WebExtensions.Services;
using TestApp.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKendo();

//var DefaultApi = builder.Configuration.GetValue<string>("ApiUrl:DefaultApi");

//builder.Services.AddScoped(sp =>
//	new HttpClient { BaseAddress = new Uri(DefaultApi) });

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddScoped(p => BentasRestService.For<IApiClient>());

builder.Services.AddScoped<HttpClient>();
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
