using System.Net.Http.Json;
using Proyecto_Programacion.Models;

namespace Proyecto_Programacion.Service
{
    public class LaboratorioApiService
    {
        private readonly HttpClient _http;

        public LaboratorioApiService(HttpClient http)
        {
            _http = http;
        }

       
        public async Task<List<LaboratorioModel>> ObtenerTodos()
        {
            return await _http.GetFromJsonAsync<List<LaboratorioModel>>("api/Laboratorios");
        }

        
        public async Task<LaboratorioModel?> ObtenerPorId(int id)
        {
            return await _http.GetFromJsonAsync<LaboratorioModel>($"api/Laboratorios/{id}");
        }

       
        public async Task Crear(LaboratorioModel laboratorio)
        {
            var response = await _http.PostAsJsonAsync("api/Laboratorios", laboratorio);
            response.EnsureSuccessStatusCode();
        }

        
        public async Task Actualizar(LaboratorioModel lab)
        {
            var response = await _http.PutAsJsonAsync($"api/Laboratorios/{lab.Id}", lab);
            response.EnsureSuccessStatusCode();
        }

        
        public async Task Eliminar(int id)
        {
            var response = await _http.DeleteAsync($"api/Laboratorios/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
