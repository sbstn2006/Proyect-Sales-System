using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using capaentidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_CATEGORIA
    {
        private CD_CATEGORIA objCD_CATEGORIA = new CD_CATEGORIA();
        public List<CATEGORIA> Listar()
        {
            return objCD_CATEGORIA.Listar();
        }

        public int Registrar(CATEGORIA obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesaria la descripción de la CATEGORIA\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCD_CATEGORIA.Registrar(obj, out Mensaje);
            }
        }


        public bool Editar(CATEGORIA obj, out string Mensaje)
        {

            Mensaje = string.Empty;
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesaria la descripción de la CATEGORIA\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCD_CATEGORIA.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(CATEGORIA obj, out string Mensaje)
        {
            return objCD_CATEGORIA.Eliminar(obj, out Mensaje);
        }
    }
}
