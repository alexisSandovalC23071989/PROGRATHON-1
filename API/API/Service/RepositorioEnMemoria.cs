using Proyecto.Servicios;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public class RepositorioEnMemoria<T> : IRepositorioEnMemoria<T> where T : class
    {
        private readonly List<T> _datos = new();
        private int _contadorId = 1;

        public List<T> ObtenerTodos() => _datos;

        public T ObtenerPorId(int id)
        {
            return _datos.FirstOrDefault(x => ObtenerId(x) == id);
        }

        public void Agregar(T entidad)
        {
            AsignarId(entidad);
            _datos.Add(entidad);
        }

        public bool Eliminar(int id)
        {
            var entidad = ObtenerPorId(id);
            if (entidad == null) return false;

            _datos.Remove(entidad);
            return true;
        }

        public bool Actualizar(int id, T entidad)
        {
            var existente = ObtenerPorId(id);
            if (existente == null) return false;

            var index = _datos.IndexOf(existente);
            _datos[index] = entidad;
            return true;
        }

        private void AsignarId(T entidad)
        {
            var prop = entidad.GetType().GetProperty("Id");
            prop?.SetValue(entidad, _contadorId++);
        }

        private int ObtenerId(T entidad)
        {
            var prop = entidad.GetType().GetProperty("Id");
            return (int)(prop?.GetValue(entidad) ?? 0);
        }
    }
}