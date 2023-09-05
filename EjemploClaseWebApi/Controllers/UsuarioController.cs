using EjemploClaseDto;
using EjemploClaseService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjemploClaseWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService usuarioService = new UsuarioService();

        [HttpPost]
        public IActionResult CrearUsuario([FromBody] UsuarioDto usuarioDTO)
        {
            if (!usuarioDTO.IsValid().Success)
            {
                return BadRequest(usuarioDTO.IsValid().Errors);
            }

            usuarioDTO = usuarioService.CrearUsuario(usuarioDTO);

            return Ok(usuarioDTO);
        }

        [HttpGet]
        public IActionResult ObtenerTodosUsuarios()
        {
            List<UsuarioDto> usuarios = usuarioService.ObtenerTodosUsuarios();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerUsuarioPorId(int id)
        {
            UsuarioDto usuario = usuarioService.ObtenerUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarUsuario(int id, [FromBody] UsuarioDto usuarioDTO)
        {
            if (!usuarioDTO.IsValid().Success)
            {
                return BadRequest(usuarioDTO.IsValid().Errors);
            }

            UsuarioDto usuarioActualizado = usuarioService.ActualizarUsuario(usuarioDTO);
            if (usuarioActualizado == null)
            {
                return NotFound();
            }

            return Ok(usuarioDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            bool result = usuarioService.EliminarUsuario(id);

            if (!result) {
                return NotFound();
            }

            return Ok();
        }
    }
}
