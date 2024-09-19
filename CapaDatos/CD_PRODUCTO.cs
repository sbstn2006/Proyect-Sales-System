using capaentidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_PRODUCTO
    {

        public List<PRODUCTO> Listar()
        {
            List<PRODUCTO> lista = new List<PRODUCTO>();

            using (SqlConnection oconnection = new SqlConnection(conexion.cadena))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT idPRODUCTO, Codigo, Nombre, p.Descripcion, c.idCATEGORIA,c.Descripcion[DescripcionCategoria], Stock, PrecioCompra, PrecioVenta, p.Estado FROM PRODUCTO p");
                    query.AppendLine("inner join CATEGORIA c on c.idCATEGORIA = p.idCATEGORIA");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconnection);
                    cmd.CommandType = CommandType.Text;
                    oconnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new PRODUCTO()
                            {
                                idPRODUCTO = Convert.ToInt32(dr["idPRODUCTO"]),
                                Codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                oCATEGORIA = new CATEGORIA() {idCATEGORIA = Convert.ToInt32(dr["IDcategoria"]), Descripcion = dr["DescripcionCategoria"].ToString() },
                                Stock = Convert.ToInt32(dr["Stock"].ToString()),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    lista = new List<PRODUCTO>();
                }
            }
            return lista;
        }


        public int Registrar(PRODUCTO obj, out string Mensaje)
        {
            int idPRODUCTOgenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconnection = new SqlConnection(conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("PA_RegistrarProducto", oconnection);
                    cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCATEGORIA.idCATEGORIA);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconnection.Open();

                    cmd.ExecuteNonQuery();

                    idPRODUCTOgenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idPRODUCTOgenerado = 0;
                Mensaje = ex.Message;
            }
            return idPRODUCTOgenerado;
        }


        public bool Editar(PRODUCTO obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconnection = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("PA_EditarProducto", oconnection);
                    cmd.Parameters.AddWithValue("idProducto", obj.idPRODUCTO);
                    cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCATEGORIA.idCATEGORIA);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconnection.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
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


        public bool Eliminar(PRODUCTO obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconnection = new SqlConnection(conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("PA_EliminarProducto", oconnection);
                    cmd.Parameters.AddWithValue("idProducto", obj.idPRODUCTO);
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
