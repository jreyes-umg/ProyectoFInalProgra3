using Entidad.JuanDavid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.JuanDavid
{
    internal class AtencionesDatos
    {
        ConexionDatos conexionDatos = new ConexionDatos();
        /*  ----- CONSULTAR ----- */
        public List<AntencionPacientesEntidad> MtdConsultar()
        {
            List<AntencionPacientesEntidad> ListaSanatorios = new List<AntencionPacientesEntidad>();
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryListar = "SELECT * FROM Tbl_AtencionesPacientes ORDER BY CodigoAtencion ASC;";
                    using (SqlCommand cmd = new SqlCommand(QueryListar, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ListaSanatorios.Add(new AntencionPacientesEntidad()
                                {
                                    CodigoAtencion = Convert.ToInt32(dr["CodigoAtencion"]),
                                    CodigoPaciente = Convert.ToInt32(dr["CodigoPaciente"]),
                                    CodigoMedico = Convert.ToInt32(dr["CodigoMedico"]),
                                    CodigoTipoServicio = Convert.ToInt32(dr["TipoSanatorio"]),
                                    CodigoSanatorio = Convert.ToInt32(dr["CodigoMedico"]),
                                    FechaAtencion = Convert.ToDateTime(dr["FechaAtencion"]),
                                    CostoBase = Convert.ToDecimal(dr["CostoBase"]),
                                    RecargoEmergencia = Convert.ToDecimal(dr["RecargoEmergencia"]),
                                    TotalAtencion = Convert.ToDecimal(dr["TotalAtencion"]),
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    UsuarioSistema = Convert.ToString(dr["UsuarioSistema"]),
                                    FechaSistema = Convert.ToDateTime(dr["FechaSistema"]),
                                    HoraSistema = (TimeSpan)dr["HoraSistema"]
                                });
                            }
                        }

                    }
                    return ListaSanatorios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar la lista " + ex.Message);

            }
        }
            /*  ----- AGREGAR ----- */
        public bool MtdAgregar(AntencionPacientesEntidad ControlAtencion)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryAgregar = @"INSERT INTO Tbl_AtencionesPacientes (
                                                        CodigoPaciente,
                                                        CodigoMedico,
                                                        CodigoTipoServicio,
                                                        CodigoSanatorio,
                                                        FechaAtencion,
                                                        CostoBase,
                                                        RecargoEmergencia,
                                                        TotalAtencion,
                                                        Estado,
                                                        UsuarioSistema,
                                                        FechaSistema,
                                                        HoraSistema)
                                                        VALUES (
                                                        @CodigoPaciente,
                                                        @CodigoMedico,
                                                        @CodigoTipoServicio,
                                                        @CodigoSanatorio,
                                                        @FechaAtencion,
                                                        @CostoBase,
                                                        @RecargoEmergencia,
                                                        @TotalAtencion,
                                                        @Estado,
                                                        @UsuarioSistema,
                                                        @FechaSistema,
                                                        @HoraSistema);
                                                        ";

                    using (SqlCommand cmd = new SqlCommand(QueryAgregar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoPaciente", ControlAtencion.CodigoPaciente);
                        cmd.Parameters.AddWithValue("@CodigoMedico", ControlAtencion.CodigoMedico);
                        cmd.Parameters.AddWithValue("@CodigoTipoServicio", ControlAtencion.CodigoTipoServicio);
                        cmd.Parameters.AddWithValue("@CodigoSanatorio", ControlAtencion.CodigoSanatorio);
                        cmd.Parameters.AddWithValue("@FechaAtencion", ControlAtencion.FechaAtencion);
                        cmd.Parameters.AddWithValue("@CostoBase", ControlAtencion.CostoBase);
                        cmd.Parameters.AddWithValue("@RecargoEmergencia", ControlAtencion.RecargoEmergencia);
                        cmd.Parameters.AddWithValue("@TotalAtencion", ControlAtencion.TotalAtencion);
                        cmd.Parameters.AddWithValue("@Estado", ControlAtencion.Estado);
                        cmd.Parameters.AddWithValue("@UsuarioSistema", ControlAtencion.UsuarioSistema);
                        cmd.Parameters.AddWithValue("@FechaSistema", ControlAtencion.FechaSistema);
                        cmd.Parameters.AddWithValue("@HoraSistema", ControlAtencion.HoraSistema);


                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Agregar la Atencion en la base de datos (datos) ", ex);
            }
        }
        /*  ----- EDITAR ----- */
        public bool MtdEditar(AntencionPacientesEntidad ControlAtencion)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryEditar = @"UPDATE Tbl_AtencionesPacientes 
                                                    SET CodigoPaciente = @CodigoPaciente,
                                                    CodigoMedico = @CodigoMedico,
                                                    CodigoTipoServicio = @CodigoTipoServicio,
                                                    CodigoSanatorio = @CodigoSanatorio,
                                                    FechaAtencion = @FechaAtencion,
                                                    CostoBase = @CostoBase,
                                                    RecargoEmergencia = @RecargoEmergencia,
                                                    TotalAtencion = @TotalAtencion,
                                                    Estado = @Estado,
                                                    UsuarioSistema = @UsuarioSistema,
                                                    FechaSistema = @FechaSistema,
                                                    HoraSistema = @HoraSistema
                                                    WHERE CodigoAtencion = @CodigoAtencion;;";

                    using (SqlCommand cmd = new SqlCommand(QueryEditar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoAtencion", ControlAtencion.CodigoAtencion);
                        cmd.Parameters.AddWithValue("@CodigoPaciente", ControlAtencion.CodigoPaciente);
                        cmd.Parameters.AddWithValue("@CodigoMedico", ControlAtencion.CodigoMedico);
                        cmd.Parameters.AddWithValue("@CodigoTipoServicio", ControlAtencion.CodigoTipoServicio);
                        cmd.Parameters.AddWithValue("@CodigoSanatorio", ControlAtencion.CodigoSanatorio);
                        cmd.Parameters.AddWithValue("@FechaAtencion", ControlAtencion.FechaAtencion);
                        cmd.Parameters.AddWithValue("@CostoBase", ControlAtencion.CostoBase);
                        cmd.Parameters.AddWithValue("@RecargoEmergencia", ControlAtencion.RecargoEmergencia);
                        cmd.Parameters.AddWithValue("@TotalAtencion", ControlAtencion.TotalAtencion);
                        cmd.Parameters.AddWithValue("@Estado", ControlAtencion.Estado);
                        cmd.Parameters.AddWithValue("@UsuarioSistema", ControlAtencion.UsuarioSistema);
                        cmd.Parameters.AddWithValue("@FechaSistema", ControlAtencion.FechaSistema);
                        cmd.Parameters.AddWithValue("@HoraSistema", ControlAtencion.HoraSistema);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Editar la Atencion en la base de datos", ex);
            }
        }
        public bool MtdEliminar(int CodigoAtencion)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryEliminar = @"DELETE Tbl_AtencionesPacientes WHERE CodigoAtencion = @CodigoAtencion;";

                    using (SqlCommand cmd = new SqlCommand(QueryEliminar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoAtencion", CodigoAtencion);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la Atencioin de la base de datos", ex);
            }
        }


        public DataTable MtdBuscar(int UsuarioSistema)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();

                    string query = @"SELECT * FROM Tbl_AtencionesPacientes WHERE UsuarioSistema LIKE @UsuarioSistema;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
            catch (SqlException exSql)
            {
                throw new Exception("Error al buscar la Atencion: " + exSql.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al buscar la Atencion: " + ex.Message);
            }
        }

        /*OBTENER ITEMS PARA CBX*/
        public List<dynamic> MtdListarPacientes()
        {
            List<dynamic> ListarDatos = new List<dynamic>();

            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryListaClientes = @"
												select  CodigoPaciente, Nombre
													From Tbl_Pacientes;
												"; // Cambiar query

                    using (SqlCommand cmd = new SqlCommand(QueryListaClientes, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {


                            while (dr.Read())
                            {
                                ListarDatos.Add(new
                                {
                                    Value = dr["CodigoPaciente"], // Cambiar nombre de campo codigo segun query
                                    Text = $"{dr["CodigoPaciente"]} - {dr["Nombre"]}" // Cambiar codigo y nombre, segun query
                                });
                            }
                        }
                    }

                }
                return ListarDatos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar los datos : " + ex.Message);
            }
        }
   
        public List<dynamic> MtdListarDoctores()
        {
            List<dynamic> ListarDatos = new List<dynamic>();

            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryListaClientes = @"
												select  CodigoMedico, Nombre
													From Tbl_Medicos;
												"; // Cambiar query

                    using (SqlCommand cmd = new SqlCommand(QueryListaClientes, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {


                            while (dr.Read())
                            {
                                ListarDatos.Add(new
                                {
                                    Value = dr["CodigoMedico"], // Cambiar nombre de campo codigo segun query
                                    Text = $"{dr["CodigoMedico"]} - {dr["Nombre"]}" // Cambiar codigo y nombre, segun query
                                });
                            }
                        }
                    }

                }
                return ListarDatos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar los datos : " + ex.Message);
            }
        }
        public List<dynamic> MtdListarTiposdeServicio()
        {
            List<dynamic> ListarDatos = new List<dynamic>();

            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryListaClientes = @"
												select  CodigoTipoServicio, Nombre
													From Tbl_TiposServicios;
												"; // Cambiar query

                    using (SqlCommand cmd = new SqlCommand(QueryListaClientes, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {


                            while (dr.Read())
                            {
                                ListarDatos.Add(new
                                {
                                    Value = dr["CodigoTipoServicio"], // Cambiar nombre de campo codigo segun query
                                    Text = $"{dr["CodigoTipoServicio"]} - {dr["Nombre"]}" // Cambiar codigo y nombre, segun query
                                });
                            }
                        }
                    }

                }
                return ListarDatos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar los datos : " + ex.Message);
            }
        }
        public List<dynamic> MtdListarSanatorios()
        {
            List<dynamic> ListarDatos = new List<dynamic>();

            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryListaClientes = @"
												select  CodigoSanatorio, Nombre
													From Tbl_Sanatorios;
												"; // Cambiar query

                    using (SqlCommand cmd = new SqlCommand(QueryListaClientes, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {


                            while (dr.Read())
                            {
                                ListarDatos.Add(new
                                {
                                    Value = dr["CodigoSanatorio"], // Cambiar nombre de campo codigo segun query
                                    Text = $"{dr["CodigoSanatorio"]} - {dr["Nombre"]}" // Cambiar codigo y nombre, segun query
                                });
                            }
                        }
                    }

                }
                return ListarDatos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar los datos : " + ex.Message);
            }
        }
    }
}
