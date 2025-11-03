using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Programacion.Models;
using Proyecto_Programacion.Service;

namespace Proyecto_Programacion.Pages.Reservas
{
    public class CrearModel : PageModel
    {
        private readonly ReservaApiService _reservaService;

        [BindProperty]
        public ReservaModel Reserva { get; set; } = new();

        public CrearModel(ReservaApiService reservaService)
        {
            _reservaService = reservaService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _reservaService.Crear(Reserva);
            return RedirectToPage("/Reservas/Index");
        }
    }
}