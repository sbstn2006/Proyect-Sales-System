using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class USUARIO
    {
        public int idUSUARIO { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public ROL oROL { get; set; }
        public bool Estado { get; set; }
        public String FechaRegistro { get; set; }
    }
}
