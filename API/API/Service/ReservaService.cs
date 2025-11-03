using API.Model;
using Proyecto.Servicios;

namespace API.Services
{
    public class ReservaService
    {
        private readonly IRepositorioEnMemoria<ReservaModel> _repo;

        public ReservaService(IRepositorioEnMemoria<ReservaModel> repo)
        {
            _repo = repo;
        }

        public List<ReservaModel> ObtenerTodos() => _repo.ObtenerTodos();
        public ReservaModel ObtenerPorId(int id) => _repo.ObtenerPorId(id);
        public void Agregar(ReservaModel reserva) => _repo.Agregar(reserva);
        public bool Actualizar(int id, ReservaModel reserva) => _repo.Actualizar(id, reserva);
        public bool Eliminar(int id) => _repo.Eliminar(id);
    }
}