using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Programacion.Service;
using Proyecto_Programacion.Models;

namespace Proyecto_Programacion.Pages.Usuarios
{
    public class EditarModel : PageModel
    {
        private readonly UsuarioApiService _usuarioService;

        [BindProperty]
        public UsuarioModel Usuario { get; set; } = new();

        public EditarModel(UsuarioApiService usuarioService)
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
            await _usuarioService.Actualizar(id, Usuario);
            return RedirectToPage("/Usuarios/Index");
        }
    }
}