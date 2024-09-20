using CapaDatos;
using capaentidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_CLIENTE
    {

        private CD_CLIENTE objCD_CLIENTE = new CD_CLIENTE();
        public List<CLIENTE> Listar()
        {
            return objCD_CLIENTE.Listar();
        }

        public int Registrar(CLIENTE obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del CLIENTE\n";
            }
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre del CLIENTE\n";
            }
            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo del CLIENTE\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCD_CLIENTE.Registrar(obj, out Mensaje);
            }
        }


        public bool Editar(CLIENTE obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del CLIENTE\n";
            }
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre del CLIENTE\n";
            }
            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo del CLIENTE\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCD_CLIENTE.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(CLIENTE obj, out string Mensaje)
        {
            return objCD_CLIENTE.Eliminar(obj, out Mensaje);
        }
    }
}
