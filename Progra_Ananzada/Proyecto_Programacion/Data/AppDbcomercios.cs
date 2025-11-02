using Microsoft.EntityFrameworkCore;
using System;
using Proyecto_Programacion.Models;
using System;
using Proyecto_Programacion.DTO;

namespace Proyecto_Programacion.Data
{
    public class AppDbcomercios : DbContext   // hereda de DbContext

    {     // Se crea el constructor que recibe las opciones de configuración
        public AppDbcomercios(DbContextOptions<AppDbcomercios> options)
            : base(options)
        {

        }
        //IdComercio – int, primary key, not null (identity) 
        //▪ Identificacion – varchar(30), not null 
        //▪ TipoIdentificacion – int, not null, (1 – Física, 2 – Jurídica) 
        //▪ Nombre – varchar(200), not null 
        //▪ TipoDeComercio – int, not null, (1 – Restaurantes, 2 - Supermercados, 3 – Ferreterías, 4 - Otros) 
        //▪ Telefono – varchar(20), not null 
        //▪ CorreoElectronico – varchar(200), not null 
        //▪ Direccion – varchar(500), not null 
        //▪ FechaDeRegistro – Datetime, not null 
        //▪ FechaDeModificacion – Datetime, null 
        //▪ Estado – bit, not null, (1 – Activo, 0 – Inactivo)
        public DbSet<ComerciosModel> Comercios { get; set; }
    }
}
