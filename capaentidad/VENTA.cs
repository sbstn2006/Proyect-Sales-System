﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class VENTA
    {
        public int idVENTA { get; set; }
        public USUARIO oUSUARIO { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }     
        public decimal MontoPago { get; set; }
        public decimal MontoCambio { get; set; }
        public decimal MontoTotal { get; set; }
        public List<DETALLE_VENTA> oDETALLE_VENTA { get; set; }
        public String FechaRegistro { get; set; }
    }
}
