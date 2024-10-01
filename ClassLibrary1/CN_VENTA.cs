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
    public class CN_VENTA
    {
        private CD_VENTA objCD_VENTA = new CD_VENTA();



        public bool RestarStock(int idproducto, int cantidad)
        {
            return objCD_VENTA.RestarStock(idproducto,cantidad);
        }

        public bool SumarStock(int idproducto, int cantidad)
        {
            return objCD_VENTA.SumarStock(idproducto, cantidad);
        }


        public int ObtenerCorrelativo()
        {
            return objCD_VENTA.ObtenerCorrelativo();
        }

        public bool Registrar(VENTA obj, DataTable DetalleVenta, out string Mensaje)
        {
            return objCD_VENTA.Registrar(obj, DetalleVenta, out Mensaje);

        }
    }
}
