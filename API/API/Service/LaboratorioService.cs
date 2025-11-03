using API.Model;
using Proyecto.Servicios;

namespace API.Services
{
    public class LaboratorioService
    {
        private readonly IRepositorioEnMemoria<LaboratorioModel> _repo;

        public LaboratorioService(IRepositorioEnMemoria<LaboratorioModel> repo)
        {
            _repo = repo;
        }

        public List<LaboratorioModel> ObtenerTodos() => _repo.ObtenerTodos();
        public LaboratorioModel ObtenerPorId(int id) => _repo.ObtenerPorId(id);
        public void Agregar(LaboratorioModel lab) => _repo.Agregar(lab);
        public bool Actualizar(int id, LaboratorioModel lab) => _repo.Actualizar(id, lab);
        public bool Eliminar(int id) => _repo.Eliminar(id);
    }
}