using EjemploClaseData;
using EjemploClaseDto;

namespace EjemploClaseService
{
    public class UsuarioService
    {
        public List<UsuarioDto> ObtenerTodosUsuarios()
        {
            return Archivos.LeerDesdeArchivoJson()
                .Where(x => x.FechaEliminacion == null)
                .Select(x => new UsuarioDto()
                {
                    NombreCompleto = x.NombreCompleto,
                    CorreoElectronico = x.CorreoElectronico,
                    Id = x.Id,
                }).ToList();
        }

        public UsuarioDto ObtenerUsuarioPorId(int id)
        {
            Usuario usuarioDb = new Usuario();
            UsuarioDto usuarioDto = new UsuarioDto();

            usuarioDb = Archivos.LeerDesdeArchivoJson().Where(x => x.Id == id).FirstOrDefault();

            if (usuarioDb != null)
            {
                usuarioDto.Id = usuarioDb.Id;
                usuarioDto.CorreoElectronico = usuarioDb.CorreoElectronico;
                usuarioDto.NombreCompleto = usuarioDb.NombreCompleto;

                return usuarioDto;
            }

            return null;
        }

        public UsuarioDto CrearUsuario(UsuarioDto usuarioDto)
        {
            Usuario usuarioDb = new Usuario();

            usuarioDb.CorreoElectronico = usuarioDto.CorreoElectronico;
            usuarioDb.NombreCompleto = usuarioDto.NombreCompleto;

            usuarioDb = Archivos.GuardarEnArchivoJson(usuarioDb);

            usuarioDto.Id = usuarioDb.Id;

            return usuarioDto;
        }

        public UsuarioDto ActualizarUsuario(UsuarioDto usuarioDto)
        {
            Usuario usuarioDb = Archivos.LeerDesdeArchivoJson().FirstOrDefault(x => x.Id == usuarioDto.Id);

            if (usuarioDb != null)
            {
                usuarioDb.NombreCompleto = usuarioDto.NombreCompleto;
                usuarioDb.CorreoElectronico = usuarioDto.CorreoElectronico;

                Archivos.GuardarEnArchivoJson(usuarioDb);

                return usuarioDto;
            }

            return null;
        }

        public bool EliminarUsuario(int id)
        {
            Usuario usuarioDb = Archivos.LeerDesdeArchivoJson().FirstOrDefault(x => x.Id == id);

            if (usuarioDb != null)
            {
                usuarioDb.FechaEliminacion = DateTime.Now;

                Archivos.GuardarEnArchivoJson(usuarioDb);

                return true;
            }

            return false;
        }
    }
}