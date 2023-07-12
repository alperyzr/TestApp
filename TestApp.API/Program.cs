using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TestApp.Repository;
using TestApp.Service.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(Program));
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(x =>
{
    //appsettingsten okuyacaðý kýsým
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});


builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<MappingProfile>();
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
