using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Programacion.Models;
using Proyecto_Programacion.Service;

namespace Proyecto_Programacion.Pages.Usuarios
{
    public class CrearModel : PageModel
    {
        private readonly UsuarioApiService _usuarioService;

        [BindProperty]
        public UsuarioModel Usuario { get; set; } = new();

        public CrearModel(UsuarioApiService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _usuarioService.Crear(Usuario);
            return RedirectToPage("/Usuarios/Index");
        }
    }
}