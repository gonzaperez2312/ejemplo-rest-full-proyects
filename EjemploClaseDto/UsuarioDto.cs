using UsuariosDTO;

namespace EjemploClaseDto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }

        public ValidationDto IsValid()
        {
            ValidationDto validation = new ValidationDto()
            {
                Errors = new List<Error>()
            };

            if (string.IsNullOrEmpty(NombreCompleto) || NombreCompleto.Length < 10)
            {
                validation.Errors.Add(new Error() { ErrorDetail = "Faltar cargar el nombre o es muy corto" });
            }

            if (string.IsNullOrEmpty(CorreoElectronico))
            {
                validation.Errors.Add(new Error() { ErrorDetail = "Faltar cargar el correo electronico" });
            }

            if (validation.Errors.Count == 0)
            {
                validation.Success = true;
            }

            return validation;
        }
    }
}