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
            return await _http.GetFromJsonAsync<List<LaboratorioModel>>("api/laboratorios");
        }

        public async Task Crear(LaboratorioModel laboratorio)
        {
            await _http.PostAsJsonAsync("api/laboratorios", laboratorio);
        }

        public async Task Eliminar(int id)
        {
            await _http.DeleteAsync($"api/laboratorios/{id}");
        }
        public async Task<LaboratorioModel> ObtenerPorId(int id)
        {
            return await _http.GetFromJsonAsync<LaboratorioModel>($"api/laboratorios/{id}");
        }
      
        public async Task Actualizar(int id, LaboratorioModel laboratorio)
        {
            await _http.PutAsJsonAsync($"api/laboratorios/{id}", laboratorio);
        }
    }
}

