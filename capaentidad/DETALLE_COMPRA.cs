﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class DETALLE_COMPRA
    {
        public int idDETALLE_COMPRA { get; set; }
        public PRODUCTO oPRODUCTO { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal MontoTotal { get; set; }
        public String FechaRegistro { get; set; }
    }
}
