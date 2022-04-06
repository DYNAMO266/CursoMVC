using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
  public  class Usuario
    {

        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public bool Reestablecer { get; set; }
        public bool Activo { get; set; }

    }
}
