using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.RazorPages;

using Proyecto_Programacion.Service;

using Proyecto_Programacion.Models;

namespace Proyecto_Programacion.Pages.Reservas

{

    public class IndexModel : PageModel

    {

        private readonly ReservaApiService _reservaService;

        public List<ReservaModel> ListaReservas { get; set; } = new();

        public IndexModel(ReservaApiService reservaService)

        {

            _reservaService = reservaService;

        }

        public async Task OnGet()

        {

            ListaReservas = await _reservaService.ObtenerTodos();

        }

    }

}

