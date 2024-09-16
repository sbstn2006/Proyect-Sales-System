using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class COMPRA
    {

        public int idCOMPRA { get; set; }
        public USUARIO oUSUARIO  { get; set; }
        public PROVEEDOR oPROVEEDOR { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public decimal MontoTotal { get; set; }
        public List<DETALLE_COMPRA> oDETALLE_COMPRA { get; set; }
        public String FechaRegistro { get; set; }
    }
}
