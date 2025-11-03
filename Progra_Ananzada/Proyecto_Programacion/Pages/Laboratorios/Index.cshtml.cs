using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Programacion.Service;
using Proyecto_Programacion.Models;

namespace Proyecto_Programacion.Pages.Laboratorios
{
    public class IndexModel : PageModel
    {
        private readonly LaboratorioApiService _laboratorioService;

        public List<LaboratorioModel> ListaLaboratorios { get; set; } = new();

        public IndexModel(LaboratorioApiService laboratorioService)
        {
            _laboratorioService = laboratorioService;
        }

        public async Task OnGet()
        {
            ListaLaboratorios = await _laboratorioService.ObtenerTodos();
        }
    }
}