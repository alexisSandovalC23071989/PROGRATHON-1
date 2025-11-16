using Proyecto_Programacion.Models;
using System.Net;


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
            return await _http.GetFromJsonAsync<List<UsuarioModel>>("api/usuarios/Listar Usuarios");
        }

        public async Task<UsuarioModel?> ObtenerPorId(int id)
        {
            var response = await _http.GetAsync($"api/Usuarios/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {

                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<UsuarioModel>();
        }
        public async Task Crear(UsuarioModel usuario)
        {
            await _http.PostAsJsonAsync("api/usuarios/Agregar Usuarios", usuario);
        }

        public async Task Actualizar(int id, UsuarioModel usuario)
        {
            await _http.PutAsJsonAsync($"api/usuarios/{id}", usuario);
        }

        public async Task Eliminar(int id)
        {
            var response = await _http.DeleteAsync($"api/Usuarios/{id}");
            response.EnsureSuccessStatusCode();
        }
       }
    }
