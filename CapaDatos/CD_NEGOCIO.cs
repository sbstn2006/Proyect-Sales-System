﻿using capaentidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_NEGOCIO
    {
        public NEGOCIO ObtenerDatos()
        {
            NEGOCIO obj = new NEGOCIO();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {


                    conexion.Open();

                    string query = "select idNEGOCIO,Nombre,RUC,Direccion from NEGOCIO where idNEGOCIO = 1";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            obj = new NEGOCIO()
                            {
                                idNEGOCIO = int.Parse(dr["idNEGOCIO"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                RUC = dr["RUC"].ToString(),
                                Direccion = dr["Direccion"].ToString(),

                            };
                        }
                    }
                }
            }
            catch
            {
                obj = new NEGOCIO();
            }
            return obj;
        }


        public bool GuardarDatos(NEGOCIO objeto, out string mensaje) {
            mensaje = string.Empty;
            bool respuesta = true;


            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {


                    conexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update NEGOCIO set Nombre = @nombre,");
                    query.AppendLine("RUC = @ruc,");
                    query.AppendLine("Direccion = @direccion");
                    query.AppendLine("where idNEGOCIO = 1;");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@nombre", objeto.Nombre);
                    cmd.Parameters.AddWithValue("@ruc", objeto.RUC);
                    cmd.Parameters.AddWithValue("@direccion", objeto.Direccion);
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1) {
                        mensaje = "No se pudieron guardar los datos";
                        respuesta = false;
                    }
                }
            }
            catch(Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;

            }
            return respuesta;
        }

        public byte[] ObtenerLogo(out bool obtenido) {

            obtenido = true;
            byte[] LogoBytes = new byte[0];

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {


                    conexion.Open();
                    string query = "select Logo from NEGOCIO where idNEGOCIO = 1";
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LogoBytes = (byte[])dr["Logo"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                obtenido = false;
                LogoBytes = new byte[0];

            }
            return LogoBytes;
        }

        public bool ActualizarLogo(byte[] image, out string mensaje) {
            mensaje = string.Empty;
            bool respuesta = true;


            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {


                    conexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update NEGOCIO set Logo = @imagen");
                    query.AppendLine("where idNEGOCIO = 1");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@imagen", image);
                    cmd.CommandType = CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo actualizar el logo";
                        respuesta = false;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;

            }
            return respuesta;




        }

    }
}
