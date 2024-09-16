using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capaentidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_ROL
    {
       
            private CD_ROL objCD_ROL = new CD_ROL();

            public List<ROL> Listar()

            {
                return objCD_ROL.Listar();
            }
        
    }
}
