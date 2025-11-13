using Microsoft.AspNetCore.Mvc;
using API.Services;
using API.Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly ReservaService _service;

        public ReservasController(ReservaService service)
        {
            _service = service;
        }

        [HttpGet("Listar Reservas")]
        public IActionResult Get()
        {
            return Ok(_service.ObtenerTodos());
        }

        [HttpGet("Listar_Reservas_por_ID")]
        public IActionResult Get(int id)
        {
            var reserva = _service.ObtenerPorId(id);
            if (reserva == null)
                return NotFound();

            return Ok(reserva);
        }

        [HttpPost("Agregar Reserva")]
        public IActionResult Post([FromBody] ReservaModel reserva)
        {
            _service.Agregar(reserva);
            return Ok(new { mensaje = "Reserva creada correctamente" });
        }

        [HttpPut("Editar Reserva por ID")]
        public IActionResult Put(int id, [FromBody] ReservaModel reserva)
        {
            var ok = _service.Actualizar(id, reserva);
            if (!ok)
                return NotFound();

            return Ok(new { mensaje = "Reserva actualizada correctamente" });
        }

        [HttpDelete("Eliminar Reserva")]
        public IActionResult Delete(int id)
        {
            var ok = _service.Eliminar(id);
            if (!ok)
                return NotFound();

            return Ok(new { mensaje = "Reserva cancelada correctamente" });
        }
    }
}