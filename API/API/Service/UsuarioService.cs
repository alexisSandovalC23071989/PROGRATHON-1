using API.Model;
using Proyecto.Servicios;

namespace API.Services
{
    public class UsuarioService
    {
        private readonly IRepositorioEnMemoria<UsuarioModel> _repo;

        public UsuarioService(IRepositorioEnMemoria<UsuarioModel> repo)
        {
            _repo = repo;
        }

        public List<UsuarioModel> ObtenerTodos() => _repo.ObtenerTodos();
        public UsuarioModel ObtenerPorId(int id) => _repo.ObtenerPorId(id);
        public void Agregar(UsuarioModel usuario) => _repo.Agregar(usuario);
        public bool Actualizar(int id, UsuarioModel usuario) => _repo.Actualizar(id, usuario);
        public bool Eliminar(int id) => _repo.Eliminar(id);
    }
}