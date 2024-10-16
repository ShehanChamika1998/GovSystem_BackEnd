using GovSystem.Business.Data;
using GovSystem.Business.Interfaces;
using GovSystem.Business.Services;
using GovSystem.DataAccess.Common;
using GovSystem.DataAccess.Data;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register Dapper context and repository
builder.Services.AddSingleton(new DapperContext(connectionString));
builder.Services.AddScoped<IUser, UserService>();
builder.Services.TryAddScoped<IDInitializer, DInitializer>();
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
