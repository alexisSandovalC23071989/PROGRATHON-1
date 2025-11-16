using Microsoft.AspNetCore.Mvc;

using API.Services;

using API.Model;

namespace API.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class UsuariosController : ControllerBase

    {

        private readonly UsuarioService _service;

        public UsuariosController(UsuarioService service)

        {

            _service = service;

        }

        [HttpGet("Listar Usuarios")]

        public IActionResult Get()

        {

            return Ok(_service.ObtenerTodos());

        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)

        {

            var usuario = _service.ObtenerPorId(id);

            if (usuario == null)

                return NotFound();

            return Ok(usuario);

        }

        [HttpPost("Agregar Usuarios")]

        public IActionResult Post([FromBody] UsuarioModel usuario)

        {

            _service.Agregar(usuario);

            return Ok(new { mensaje = "Usuario agregado correctamente" });

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UsuarioModel usuario)
        {
            var ok = _service.Actualizar(id, usuario);
            if (!ok)
                return NotFound();

            return Ok(new { mensaje = "Usuario actualizado correctamente" });
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var ok = _service.Eliminar(id);
            if (!ok)
                return NotFound();

            return Ok(new { mensaje = "Usuario eliminado correctamente" });
        }


    }

}

