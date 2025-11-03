using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Programacion.Models;
using Proyecto_Programacion.Service;

namespace Proyecto_Programacion.Pages.Usuarios
{
    public class EliminarModel : PageModel
    {
        private readonly UsuarioApiService _usuarioService;

        [BindProperty]
        public UsuarioModel Usuario { get; set; } = new();

        public EliminarModel(UsuarioApiService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Usuario = await _usuarioService.ObtenerPorId(id);
            if (Usuario == null)
                return RedirectToPage("/Usuarios/Index");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _usuarioService.Eliminar(id);
            return RedirectToPage("/Usuarios/Index");
        }
    }
}