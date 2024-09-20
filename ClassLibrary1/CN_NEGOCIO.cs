using CapaDatos;
using capaentidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_NEGOCIO
    {

        private CD_NEGOCIO objCD_NEGOCIO = new CD_NEGOCIO();

        

        public NEGOCIO ObtenerDatos()
        {
            return objCD_NEGOCIO.ObtenerDatos();
        }

        public bool GuardarDatos(NEGOCIO obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre\n";
            }
            if (obj.RUC == "")
            {
                Mensaje += "Es necesario el número de RUC\n";
            }
            if (obj.Direccion == "")
            {
                Mensaje += "Es necesaria la dirección\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCD_NEGOCIO.GuardarDatos(obj, out Mensaje);
            }
        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            return objCD_NEGOCIO.ObtenerLogo(out obtenido);
        }

        public bool ActualizarLogo(byte[] imagen, out string mensaje)
        {
            return objCD_NEGOCIO.ActualizarLogo(imagen, out mensaje);
        }

    }
}
