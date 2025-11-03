using Proyecto_Programacion.Models;


namespace Proyecto_Programacion.Service
{
    public class UsuarioApiService
    {
        private readonly HttpClient _http;

        public UsuarioApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<UsuarioModel>> ObtenerTodos()
        {
            return await _http.GetFromJsonAsync<List<UsuarioModel>>("api/usuarios");
        }

        public async Task<UsuarioModel> ObtenerPorId(int id)
        {
            return await _http.GetFromJsonAsync<UsuarioModel>($"api/usuarios/{id}");
        }

        public async Task Crear(UsuarioModel usuario)
        {
            await _http.PostAsJsonAsync("api/usuarios", usuario);
        }

        public async Task Actualizar(int id, UsuarioModel usuario)
        {
            await _http.PutAsJsonAsync($"api/usuarios/{id}", usuario);
        }

        public async Task Eliminar(int id)
        {
            await _http.DeleteAsync($"api/usuarios/{id}");
        }
    }
}
