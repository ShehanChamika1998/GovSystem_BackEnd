using GovSystem.Business.Repository.Users;
using GovSystem.Business.Services.Users;
using GovSystem.DataAccess.Common;
using GovSystem.DataAccess.Data.Users;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register Dapper context and repository
builder.Services.AddSingleton(new DapperContext(connectionString));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.TryAddScoped<IUserRepository, UserRepository>();
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
