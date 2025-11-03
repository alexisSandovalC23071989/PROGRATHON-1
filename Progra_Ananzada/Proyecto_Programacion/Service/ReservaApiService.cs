using Proyecto_Programacion.Models;
namespace Proyecto_Programacion.Service
{
    public class ReservaApiService
    {
        private readonly HttpClient _http;

        public ReservaApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ReservaModel>> ObtenerTodos()
        {
            return await _http.GetFromJsonAsync<List<ReservaModel>>("api/reservas");
        }

        public async Task Crear(ReservaModel reserva)
        {
            await _http.PostAsJsonAsync("api/reservas", reserva);
        }

        public async Task Eliminar(int id)
        {
            await _http.DeleteAsync($"api/reservas/{id}");
        }
        public async Task<ReservaModel> ObtenerPorId(int id)
        {
            return await _http.GetFromJsonAsync<ReservaModel>($"api/reservas/{id}");
        }
        public async Task Actualizar(int id, ReservaModel reserva)
        {
            await _http.PutAsJsonAsync($"api/reservas/{id}", reserva);
        }
    }
}

