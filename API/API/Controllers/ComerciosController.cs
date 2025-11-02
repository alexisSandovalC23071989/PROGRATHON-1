using API.Model;
using API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComerciosController : Controller
        //hola
    {
        private readonly ComercioService _ComerciosService;


        public ComerciosController(ComercioService ComercioSerice)
        {
            _ComerciosService = ComercioSerice;
        }

        //El controller de la vista con la logica 

        //CRUD POST/GET/PUT/DELETE

        //GetProducto()
        // GET: api/<ComerciosController> Lista los comercios de la BD

        [HttpGet("Lista Comercios")]
        public ActionResult<IEnumerable<ComerciosModel>> GetComercios()
        {
            return _ComerciosService.GetComercios();
        }


        // POST api/<ComerciosController> Agregar Comercios
        [HttpPost("Agregar Comercios")]
        public ActionResult PostComercios(ComerciosModel _comerciosModel)
        {
            ComerciosModel newComercios = _ComerciosService.PostComercio(_comerciosModel);

            return CreatedAtAction(nameof(GetComercios), new { id = newComercios.IdComercio }, newComercios);
        }
        
       
        // PUT api/<ComerciosController>Actualiza los datos de comercios.
        [HttpPut("Actualizar Comercios")]
        public ActionResult PutComercios(ComerciosModel _comerciosModel)
        {
            if (!_ComerciosService.PutComercios(_comerciosModel))
            {
                return NotFound(
                     new
                     {
                         Mensaje = "No se encontro el registro"
                     }
                    );
            }

            return NoContent();
        }


        // DELETE api/<ComerciosController>/5
        [HttpDelete("Eliminar Comercios")]
        public ActionResult DeleteProducto(int _id)
        {
            if (!_ComerciosService.DeleteComercios(_id))
            {
                return NotFound(
                     new
                     {
                         Mensaje = "No se encontro el registro"
                     }
                    );
            }

            return NoContent();

        }
    }
}
