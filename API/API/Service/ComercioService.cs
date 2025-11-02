using API.Model;
using Proyecto_Programacion.Data;


namespace API.Service
{
    public class ComercioService
    {
        private readonly AppDbcomercios _context;

        //El iniciador
        public ComercioService(AppDbcomercios context)
        {
            _context = context;
        }
        //Funcion de obtener datos
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Producto.ToListAsync());
        //}

        //GET Listar Comercios
        public List<ComerciosModel> GetComercios()
        {
            return _context.Comercios.ToList();
        }

        //POST Agrega Comercios
        public ComerciosModel PostComercio(ComerciosModel _ComercioModel)
        {
            //                 _context.Add(_comercio);
            //await _context.SaveChangesAsync();
            _context.Comercios.Add(_ComercioModel);
            _context.SaveChanges();

            return _ComercioModel;

        }
        //Put Actualizar los datos de Comercios

        public bool PutComercios(ComerciosModel _comercioModel)
        {

            var entidad = _context.Comercios.FirstOrDefault(p => p.IdComercio == _comercioModel.IdComercio);

            if (entidad == null)
            {
                return false;
            }
            
            entidad.Identificacion = _comercioModel.Identificacion;
            entidad.TipoIdentificacion = _comercioModel.TipoIdentificacion;
            entidad.Nombre = _comercioModel.Nombre;
            entidad.TipoDeComercio = _comercioModel.TipoDeComercio;
            entidad.Telefono = _comercioModel.Telefono;
            entidad.CorreoElectronico = _comercioModel.CorreoElectronico;
            entidad.Direccion = _comercioModel.Direccion;
            entidad.FechaDeRegistro = _comercioModel.FechaDeRegistro;
            entidad.FechaDeModificacion = _comercioModel.FechaDeModificacion;
            entidad.Estado = _comercioModel.Estado;


            _context.SaveChanges();

            return true;
        }

        //DELETE Elimina Comercios
        public bool DeleteComercios(int _id)
        {

            var entidad = _context.Comercios.FirstOrDefault(p => p.IdComercio == _id);

            if (entidad == null)
            {
                return false;
            }

            _context.Comercios.Remove(entidad);
            _context.SaveChanges();

            return true;
        }

    }
}
