using API;
using API.Service;
using Microsoft.EntityFrameworkCore;
using Proyecto_Programacion.Data;


var builder = WebApplication.CreateBuilder(args);


//Establecer mi conexion de mysql
//Contexto maneja la informacion de la conexion
//public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)

builder.Services.AddDbContext<AppDbcomercios>(

    options =>
           options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection"))

    );

//Incluir el service
builder.Services.AddScoped<ComercioService>();

// Add services to the container.

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
