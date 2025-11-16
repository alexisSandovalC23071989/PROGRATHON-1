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

        // GET api/Laboratorios
        [HttpGet]
        public IActionResult Get()
        {
            var lista = _service.ObtenerTodos();
            return Ok(lista);
        }

        // GET api/Laboratorios/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var lab = _service.ObtenerPorId(id);
            if (lab == null)
                return NotFound();

            return Ok(lab);
        }

        // POST api/Laboratorios
        [HttpPost]
        public IActionResult Post([FromBody] LaboratorioModel lab)
        {
            _service.Agregar(lab);
            return Ok(new { mensaje = "Laboratorio agregado correctamente" });
        }

        // PUT api/Laboratorios/5
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] LaboratorioModel lab)
        {
            var ok = _service.Actualizar(id, lab);
            if (!ok)
                return NotFound();

            return Ok(new { mensaje = "Laboratorio actualizado correctamente" });
        }

        // DELETE api/Laboratorios/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var ok = _service.Eliminar(id);
            if (!ok)
                return NotFound();

            return Ok(new { mensaje = "Laboratorio eliminado correctamente" });
        }
    }
}
