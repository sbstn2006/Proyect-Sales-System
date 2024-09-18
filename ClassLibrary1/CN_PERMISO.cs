using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capaentidad;
using CapaDatos;


namespace CapaNegocio
{
    public class CN_PERMISO
    {
        
        private CD_PERMISO objCD_PERMISO = new CD_PERMISO();
       
        public List<PERMISO> Listar(int idUSUARIO)  
        {
            return objCD_PERMISO.Listar(idUSUARIO);
        }   
    }
}
