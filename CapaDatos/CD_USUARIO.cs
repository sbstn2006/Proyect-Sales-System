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
    public class CD_USUARIO
    {
        public List<USUARIO> Listar()
        {
            List<USUARIO> lista = new List<USUARIO>();
            
            using (SqlConnection oconnection = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select u.idUSUARIO, u.Documento, u.NombreCompleto, u.Correo, u.Clave, u.Estado, r.idROL, r.Descripcion from USUARIO u");
                    query.AppendLine("inner join ROL r on r.idROL = u.idROL");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconnection);
                    cmd.CommandType = CommandType.Text;
                    oconnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new USUARIO()
                            {
                                idUSUARIO = Convert.ToInt32(dr["idUSUARIO"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oROL = new ROL() { idROL = Convert.ToInt32(dr["idROL"]), Descripcion = dr["Descripcion"].ToString()}
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<USUARIO>();
                }
            }
            return lista;
        }


        public int Registrar(USUARIO obj, out string Mensaje)
        {
            int idusuariogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconnection = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("PA_RegistrarUsuario", oconnection);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("idROL", obj.oROL.idROL);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("idUSUARIOresultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconnection.Open();

                    cmd.ExecuteNonQuery();

                    idusuariogenerado = Convert.ToInt32(cmd.Parameters["idUSUARIOresultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idusuariogenerado = 0;
                Mensaje = ex.Message;
            }
            return idusuariogenerado;
        }

        
        public bool Editar(USUARIO obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconnection = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("PA_EditarUsuario", oconnection);
                    cmd.Parameters.AddWithValue("idUSUARIO", obj.idUSUARIO);
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("idROL", obj.oROL.idROL);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconnection.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }


        public bool Eliminar(USUARIO obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconnection = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("PA_EliminarUsuario", oconnection);
                    cmd.Parameters.AddWithValue("idUSUARIO", obj.idUSUARIO);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconnection.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }
    }
}