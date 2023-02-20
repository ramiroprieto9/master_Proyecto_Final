using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final.Models;
using Proyecto_Final.Repository;

namespace Proyecto_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("{usuario}/{contrasena}")]
        public Usuario InicioSesion(string usuario, string contrasena)
        {
            return UsuarioHandler.InicioSesion(usuario, contrasena);
        }

        [HttpPost]
        public Usuario CrearUsuario(Usuario usuario)
        {
            UsuarioHandler.CrearUsuario(usuario);
            return usuario;
        }

        [HttpPut]
        public int ModificarUsuario(Usuario usuario)
        {
            return UsuarioHandler.ModificarUsuario(usuario);

        }

        [HttpGet("{usuario}")]
        public Usuario TraerUsuario(string usuario)
        {
            return UsuarioHandler.TraerUsuario(usuario);
        }

        [HttpDelete("{id}")]
        public int EliminarUsuario(long id)
        {
            return UsuarioHandler.EliminarUsuario(id);
        }
    }
}
