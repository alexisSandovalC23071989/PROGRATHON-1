using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Programacion.Service;
using Proyecto_Programacion.Models;

namespace Proyecto_Programacion.Pages.Laboratorios
{
    public class CrearModel : PageModel
    {
        private readonly LaboratorioApiService _laboratorioService;

        [BindProperty]
        public LaboratorioModel Laboratorio { get; set; } = new();

        public CrearModel(LaboratorioApiService laboratorioService)
        {
            _laboratorioService = laboratorioService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _laboratorioService.Crear(Laboratorio);
            return RedirectToPage("/Laboratorios/Index");
        }
    }
}