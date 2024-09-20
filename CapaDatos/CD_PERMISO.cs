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
    public class CD_PERMISO
    {
        public List<PERMISO> Listar(int idUSUARIO)
        {
            List<PERMISO> lista = new List<PERMISO>();


            using (SqlConnection oconnection = new SqlConnection(Conexion.cadena))
            {

                try
                {
                
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.idROL,p.NombreMenu from PERMISO p");
                    query.AppendLine("inner join ROL r on r.idROL = p.idROL");
                    query.AppendLine("inner join USUARIO u on u.idROL = r.idROL");
                    query.AppendLine("WHERE u.idUSUARIO = @idUSUARIO"); //@idUSUARIO






                     SqlCommand cmd = new SqlCommand(query.ToString(), oconnection);
                    cmd.Parameters.AddWithValue("@idUSUARIO", idUSUARIO);//@idUSUARIO
                    cmd.CommandType = CommandType.Text;

                    oconnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {


                        while (dr.Read())
                        {
                            lista.Add(new PERMISO()
                            {

                                oROL = new ROL() { idROL = Convert.ToInt32(dr["idRol"]) } ,
                                NombreMenu = dr["NombreMenu"].ToString(),
                                



                            });


                        }

                    }

                }
                catch (Exception)
                {

                    lista = new List<PERMISO>();

                }


            }
            return lista;

        }
    }


}
