using CapaDatos;
using capaentidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_COMPRA
    {
        private CD_COMPRA objCD_COMPRA = new CD_COMPRA();


        public int ObtenerCorrelativo()
        {
            return objCD_COMPRA.ObtenerCorrelativo();
        }

        public bool Registrar(COMPRA obj,DataTable DetalleCompra, out string Mensaje)
        {
            return objCD_COMPRA.Registrar(obj,DetalleCompra ,out Mensaje);
            
        }
    }
}
