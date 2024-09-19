using CapaDatos;
using capaentidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_PRODUCTO
    {
        private CD_PRODUCTO objCD_PRODUCTO = new CD_PRODUCTO();
        public List<PRODUCTO> Listar()
        {
            return objCD_PRODUCTO.Listar();
        }

        public int Registrar(PRODUCTO obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Codigo == "")
            {
                Mensaje += "Es necesario el codigo del PRODUCTO\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del PRODUCTO\n";
            }
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesaria la Descripcion del PRODUCTO\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCD_PRODUCTO.Registrar(obj, out Mensaje);
            }
        }


        public bool Editar(PRODUCTO obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.Codigo == "")
            {
                Mensaje += "Es necesario el codigo del PRODUCTO\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del PRODUCTO\n";
            }
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesaria la Descripcion del PRODUCTO\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCD_PRODUCTO.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(PRODUCTO obj, out string Mensaje)
        {
            return objCD_PRODUCTO.Eliminar(obj, out Mensaje);
        }
    }
}
