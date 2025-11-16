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
            
            return await _http.GetFromJsonAsync<List<ReservaModel>>(
                "api/Reservas/Listar Reservas");
        }

        public async Task Crear(ReservaModel reserva)
        {
            
            await _http.PostAsJsonAsync("api/Reservas/Agregar Reserva", reserva);
        }

        public async Task Eliminar(int id)
        {
            
            await _http.DeleteAsync($"api/Reservas/Eliminar Reserva?id={id}");
        }

        public async Task<ReservaModel> ObtenerPorId(int id)
        {
            
            return await _http.GetFromJsonAsync<ReservaModel>(
                $"api/Reservas/Listar_Reservas_por_ID?id={id}");
        }

        public async Task Actualizar(int id, ReservaModel reserva)
        {
            
            await _http.PutAsJsonAsync(
                $"api/Reservas/Editar Reserva por ID?id={id}",
                reserva);
        }
    }
}


