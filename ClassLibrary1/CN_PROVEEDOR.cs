using CapaDatos;
using capaentidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_PROVEEDOR
    {

        private CD_PROVEEDOR objCD_PROVEEDOR = new CD_PROVEEDOR();
        public List<PROVEEDOR> Listar()
        {
            return objCD_PROVEEDOR.Listar();
        }

        public int Registrar(PROVEEDOR obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del PROVEEDOR\n";
            }
            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesaria la Razon Social del PROVEEDOR\n";
            }
            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo del PROVEEDOR\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCD_PROVEEDOR.Registrar(obj, out Mensaje);
            }
        }


        public bool Editar(PROVEEDOR obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del PROVEEDOR\n";
            }
            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesaria la Razon Social del PROVEEDOR\n";
            }
            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo del PROVEEDOR\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCD_PROVEEDOR.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(PROVEEDOR obj, out string Mensaje)
        {
            return objCD_PROVEEDOR.Eliminar(obj, out Mensaje);
        }

    }
}
