using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosDTO
{
    public class ValidationDto
    {
        public bool Success { get; set; }

        public List<Error> Errors { get; set; }
    }
}
