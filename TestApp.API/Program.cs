using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using TestApp.API.Services;
using TestApp.API.Services.Interfaces;
using TestApp.Core.Application.Login.ViewModels;
using TestApp.Repository;
using TestApp.Service.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(Program));
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //appsettingsten okuyacaðý kýsým
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddSingleton(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement, UnicodeRanges.LatinExtendedA }));
builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<MappingProfile>();
});

builder.Services.AddScoped<ITokenService, TokenService>();


builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection("TokenOptions"));

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwtbeareroptions =>
{
    //  jwtbeareroptions.SaveToken = true;
    jwtbeareroptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        IssuerSigningKey = SignHandler.GetSecurityKey(tokenOptions.SecurityKey),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
