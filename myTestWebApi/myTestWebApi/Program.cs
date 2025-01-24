using Microsoft.EntityFrameworkCore;
using myTestWebApi.Middleware;
using myTestWebApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var CSting = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddDbContext<DBTmycontext>(options => options.UseSqlServer(CSting));



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
app.UseMiddleware<AuthMiddleware>();

app.MapGet("/", () => "Welcome to the API!"); // Public endpoint

app.MapGet("/secure", () => "You are authorized!")
   .RequireAuthorization(); // Secure endpoint
app.Run();



//https://localhost:44380/secure


//https://localhost:44380/api/Employee


//Add hearders

//"Authorization: Basic YWRtaW46cGFzc3dvcmQ="