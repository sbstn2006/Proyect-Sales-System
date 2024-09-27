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
    public class CD_COMPRA
    {
        public int ObtenerCorrelativo()
        {
            int idCorrelativo = 0;

            using (SqlConnection oconnection = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) + 1 from COMPRA");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconnection);
                    cmd.CommandType = CommandType.Text;

                    oconnection.Open();

                    idCorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    idCorrelativo = 0;
                }
            }
            return idCorrelativo ;
        }

        public bool Registrar(COMPRA obj, DataTable DetalleCompra, out string Mensaje) {

            bool respuesta = false;
            Mensaje = string.Empty;


            using (SqlConnection oconnection = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("PA_RegistrarCompra", oconnection);
                    cmd.Parameters.AddWithValue("idUSUARIO", obj.oUSUARIO.idUSUARIO);
                    cmd.Parameters.AddWithValue("idPROVEEDOR", obj.oPROVEEDOR.idPROVEEDOR);
                    cmd.Parameters.AddWithValue("TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal); 
                    cmd.Parameters.AddWithValue("DetalleCompra", DetalleCompra);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconnection.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
                catch (Exception ex)
                {
                    respuesta = false;
                    Mensaje = ex.Message;
                }
            }
            return respuesta;
        }

        public COMPRA ObtenerCompra(string numero)
        {
            COMPRA obj = new COMPRA();


            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();


                    query.AppendLine("select c.idCOMPRA,");
                    query.AppendLine("u.NombreCompleto, ");
                    query.AppendLine("pr.Documento, pr.RazonSocial,");
                    query.AppendLine("c.TipoDocumento, c.NumeroDocumento,c.MontoTotal, convert(char(10), c.FechaRegistro, 103)[FechaRegistro]");
                    query.AppendLine("from COMPRA c");
                    query.AppendLine("inner join USUARIO u on u.idUSUARIO = c.idUSUARIO");
                    query.AppendLine("inner join PROVEEDOR pr on pr.idPROVEEDOR = c.idPROVEEDOR");
                    query.AppendLine("where c.NumeroDocumento = @numero");


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new COMPRA()
                            {
                                idCOMPRA = Convert.ToInt32(dr["idCOMPRA"]),
                                oUSUARIO = new USUARIO() { NombreCompleto = dr["NombreCompleto"].ToString() },
                                oPROVEEDOR = new PROVEEDOR { Documento = dr["Documento"].ToString(), RazonSocial = dr["RazonSocial"].ToString() },
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr ["NumeroDocumento"].ToString(),
                                MontoTotal = Convert.ToDecimal (dr["MontoTotal"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    obj = new COMPRA();
                    
                }
            }
            return obj;
        }

        public List<DETALLE_COMPRA> ObtenerDetalleCompra(int idcompra)
        {
            List<DETALLE_COMPRA> oLista = new List<DETALLE_COMPRA>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {

                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select p.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal from DETALLE_COMPRA dc");
                    query.AppendLine("inner join PRODUCTO p on p.idPRODUCTO = dc.idPRODUCTO");
                    query.AppendLine("where dc.idCOMPRA = @idCOMPRA");


                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@idCOMPRA", idcompra);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new DETALLE_COMPRA()
                            {
                                oPRODUCTO = new PRODUCTO() { Nombre = dr["Nombre"].ToString() },
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),


                            });
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                oLista = new List<DETALLE_COMPRA>();
            }
            return oLista;


        }
    }
}
