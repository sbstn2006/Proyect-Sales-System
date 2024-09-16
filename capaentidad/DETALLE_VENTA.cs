using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class DETALLE_VENTA
    {
        public int idDETALLE_VENTA { get; set; }
        public PRODUCTO oPRODUCTO { get; set; }
        
        public decimal PrecioVenta { get; set; }
        public string Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public String FechaRegistro { get; set; }
    }
}
