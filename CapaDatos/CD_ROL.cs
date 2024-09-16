using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using capaentidad;

namespace CapaDatos
{
    public class CD_ROL
    {
        public List <ROL> Listar()
        {
            List<ROL> lista = new List<ROL>();

            using (SqlConnection oconnection = new SqlConnection(conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select idROL, Descripcion from ROL ");




                    SqlCommand cmd = new SqlCommand(query.ToString(), oconnection);
                    cmd.CommandType = CommandType.Text;

                    oconnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ROL()
                            {
                                idROL = Convert.ToInt32(dr["idROL"]),
                                Descripcion = dr["Descripcion"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception )
                {
                    lista = new List<ROL>();
                }
            }
            return lista;
        }
    }
}