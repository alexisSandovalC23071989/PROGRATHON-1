using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Programacion.Service;
using Proyecto_Programacion.Models;

namespace Proyecto_Programacion.Pages.Reservas
{
    public class EliminarModel : PageModel
    {
        private readonly ReservaApiService _reservaService;

        [BindProperty]
        public ReservaModel Reserva { get; set; } = new();

        public EliminarModel(ReservaApiService reservaService)
        {
            _reservaService = reservaService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Reserva = await _reservaService.ObtenerPorId(id);
            if (Reserva == null)
                return RedirectToPage("/Reservas/Index");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _reservaService.Eliminar(id);
            return RedirectToPage("/Reservas/Index");
        }
    }
}