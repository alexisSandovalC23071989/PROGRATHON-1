using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Programacion.Models;
using Proyecto_Programacion.Service;

namespace Proyecto_Programacion.Pages.Reservas
{
    public class EditarModel : PageModel
    {
        private readonly ReservaApiService _reservaService;

        [BindProperty]
        public ReservaModel Reserva { get; set; } = new();

        public EditarModel(ReservaApiService reservaService)
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
            if (!ModelState.IsValid)
                return Page();

            await _reservaService.Actualizar(id, Reserva);
            return RedirectToPage("/Reservas/Index");
        }
    }
}