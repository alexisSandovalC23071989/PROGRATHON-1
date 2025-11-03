using System.Collections.Generic;

namespace Proyecto.Servicios
{
    public interface IRepositorioEnMemoria<T>
    {
        List<T> ObtenerTodos();
        T ObtenerPorId(int id);
        void Agregar(T entidad);
        bool Eliminar(int id);
        bool Actualizar(int id, T entidad);
    }
}