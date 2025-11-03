using Microsoft.EntityFrameworkCore;
using Proyecto_Programacion.Models;
using Proyecto_Programacion.Service;
using System;

var builder = WebApplication.CreateBuilder(args);

// Habilitar Razor Pages
builder.Services.AddRazorPages();

// Registrar HttpClient para servicios del API
builder.Services.AddHttpClient<UsuarioApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7035/"); 
});

builder.Services.AddHttpClient<LaboratorioApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7035/");
});

builder.Services.AddHttpClient<ReservaApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7035/"); 
});

var app = builder.Build();

// Configuración de entorno
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();