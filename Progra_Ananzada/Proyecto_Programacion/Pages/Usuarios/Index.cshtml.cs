using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto_Programacion.Service;
using Proyecto_Programacion.Models;

namespace Proyecto_Programacion.Pages.Usuarios
{
  
        public class IndexModel : PageModel
        {
            private readonly UsuarioApiService _usuarioService;

            public List<UsuarioModel> ListaUsuarios { get; set; } = new();

            public IndexModel(UsuarioApiService usuarioService)
            {
                _usuarioService = usuarioService;
            }

            public async Task OnGet()
            {
            ListaUsuarios = await _usuarioService.ObtenerTodos();
        }
        }
    }
