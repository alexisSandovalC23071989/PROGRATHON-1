using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Programacion.Models;
using Proyecto_Programacion.Service;

namespace Proyecto_Programacion.Pages.Laboratorios
{
    public class EditarModel : PageModel
    {
        private readonly LaboratorioApiService _laboratorioService;

        [BindProperty]
        public LaboratorioModel Laboratorio { get; set; } = new();

        public EditarModel(LaboratorioApiService laboratorioService)
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
            await _laboratorioService.Actualizar(id, Laboratorio);
            return RedirectToPage("/Laboratorios/Index");
        }
    }
}