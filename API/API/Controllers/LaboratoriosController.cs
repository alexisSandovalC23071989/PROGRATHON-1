using Microsoft.AspNetCore.Mvc;
using API.Services;
using API.Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratoriosController : ControllerBase
    {
        private readonly LaboratorioService _service;

        public LaboratoriosController(LaboratorioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.ObtenerTodos());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var lab = _service.ObtenerPorId(id);
            if (lab == null)
                return NotFound();

            return Ok(lab);
        }

        [HttpPost]
        public IActionResult Post([FromBody] LaboratorioModel lab)
        {
            _service.Agregar(lab);
            return Ok(new { mensaje = "Laboratorio agregado correctamente" });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LaboratorioModel lab)
        {
            var ok = _service.Actualizar(id, lab);
            if (!ok)
                return NotFound();

            return Ok(new { mensaje = "Laboratorio actualizado correctamente" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ok = _service.Eliminar(id);
            if (!ok)
                return NotFound();

            return Ok(new { mensaje = "Laboratorio eliminado correctamente" });
        }
    }
}