using API.Model;
using API.Services;
using Proyecto.Servicios;


var builder = WebApplication.CreateBuilder(args);

// Registrar repositorio genérico 
builder.Services.AddSingleton(typeof(IRepositorioEnMemoria<>), typeof(RepositorioEnMemoria<>));

// Registrar servicios por entidad 
builder.Services.AddSingleton<UsuarioService>();
builder.Services.AddSingleton<LaboratorioService>();
builder.Services.AddSingleton<ReservaService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Se crea los datos en memoria
using (var scope = app.Services.CreateScope())
{
    // Usa exactamente los tipos Usuario, Laboratorio, Reserva.
    var labsRepo = scope.ServiceProvider.GetRequiredService<IRepositorioEnMemoria<LaboratorioModel>>();
    var usuariosRepo = scope.ServiceProvider.GetRequiredService<IRepositorioEnMemoria<UsuarioModel>>();
    var reservasRepo = scope.ServiceProvider.GetRequiredService<IRepositorioEnMemoria<ReservaModel>>();

    // Agregar laboratorios si la lista está vacía
    if (!labsRepo.ObtenerTodos().Any())
    {
        labsRepo.Agregar(new LaboratorioModel { Nombre = "Laboratorio A", Capacidad = 30, Responsable = "Ing. Morales" });
        labsRepo.Agregar(new LaboratorioModel { Nombre = "Laboratorio B", Capacidad = 20, Responsable = "Dra. Gómez" });
    }

    // Agregar usuarios si la lista está vacía
    if (!usuariosRepo.ObtenerTodos().Any())
    {
        usuariosRepo.Agregar(new UsuarioModel { Nombre = "Carlos Pérez", Tipo = "Estudiante", Correo = "carlos@universidad.com" });
        usuariosRepo.Agregar(new UsuarioModel { Nombre = "Ana López", Tipo = "Profesor", Correo = "ana.lopez@universidad.com" });
    }

    // Agregar una reserva de ejemplo si la lista está vacía
    if (!reservasRepo.ObtenerTodos().Any())
    {
        reservasRepo.Agregar(new ReservaModel
        {
            IdUsuario = 1,
            IdLaboratorio = 1,
            Fecha = DateTime.Now.Date.AddDays(1),
            Hora = "10:00 - 12:00"
        });
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();