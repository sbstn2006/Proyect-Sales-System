using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capaentidad;
using CapaDatos;


namespace CapaNegocio
{
    public class CN_USUARIO
    {
        private CD_USUARIO objCD_USUARIO = new CD_USUARIO();
        public List<USUARIO> Listar()
        {
            return objCD_USUARIO.Listar();
        }

        public int Registrar(USUARIO obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Documento == "") {
                Mensaje += "Es necesario el documento del usuario\n";

            }
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre del usuario del usuario\n";

            }

            if (obj.Clave == "")
            {
                Mensaje += "Es necesaria la clave del usuario\n";

            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else {
                return objCD_USUARIO.Registrar(obj, out Mensaje);
            }  
        }



        public bool Editar(USUARIO obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el documento del usuario\n";

            }
            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre del usuario del usuario\n";

            }
            if (obj.Clave == "")
            {
                Mensaje += "Es necesaria la Clave del usuario\n";

            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCD_USUARIO.Editar(obj, out Mensaje);
            }


           
        }

        public bool Eliminar(USUARIO obj, out string Mensaje)
        {
            return objCD_USUARIO.Eliminar(obj, out Mensaje);
        }


    }
}
