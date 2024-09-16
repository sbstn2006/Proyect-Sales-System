using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capaentidad;
using CapaDatos;


namespace CapaNegocio
{
    public class CN_USUARIO
    {
        private CD_USUARIO objCD_USUARIO = new CD_USUARIO();
        public List<USUARIO> Listar()
        {
            return objCD_USUARIO.Listar();
        }

    }
}
