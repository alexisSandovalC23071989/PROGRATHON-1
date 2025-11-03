using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Programacion.Service;
using Proyecto_Programacion.Models; 

namespace Proyecto_Programacion.Pages.Laboratorios
{
    public class EliminarModel : PageModel
    {
        private readonly LaboratorioApiService _laboratorioService;

        [BindProperty]
        public LaboratorioModel Laboratorio { get; set; } = new();

        public EliminarModel(LaboratorioApiService laboratorioService)
        {
            _laboratorioService = laboratorioService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Laboratorio = await _laboratorioService.ObtenerPorId(id);
            if (Laboratorio == null)
                return RedirectToPage("/Laboratorios/Index");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _laboratorioService.Eliminar(id);
            return RedirectToPage("/Laboratorios/Index");
        }
    }
}