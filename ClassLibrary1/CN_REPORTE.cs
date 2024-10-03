using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using capaentidad;

namespace CapaNegocio
{
    public class CN_REPORTE
    {
        private CD_REPORTE objcd_reporte = new CD_REPORTE();

        public List<REPORTE_COMPRA> Compra(string fechainicio, string fechafin, int idproveedor)
        {
            return objcd_reporte.Compra(fechainicio, fechafin,idproveedor);
        }

        public List<REPORTE_VENTA> Venta(string fechainicio, string fechafin)
        {
            return objcd_reporte.Venta(fechainicio, fechafin);
        }




    }
}
