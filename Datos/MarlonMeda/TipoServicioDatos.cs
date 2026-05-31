using Entidad.MarlonMeda;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.MarlonMeda
{
    public class TipoServicioDatos
    {
        // Instancia
        ConexionDatos conexionDatos = new ConexionDatos();

        // Consultar
        public List<TipoServicioEntidad> MtdConsultar()
        {
            List<TipoServicioEntidad> ControlServicios = new List<TipoServicioEntidad>();
            
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryListar = "SELECT * FROM Tbl_TiposServicios ORDER BY CodigoTipoServicio ASC;";
                    using (SqlCommand cmd = new SqlCommand(QueryListar, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ControlServicios.Add(new TipoServicioEntidad()
                                {
                                    CodigoTipoServicio = Convert.ToInt32(dr["CodigoTipoServicio"]),
                                    NombreServicio = Convert.ToString(dr["NombreServicio"]),
                                    TarifaBase = Convert.ToDecimal(dr["TarifaBase"]),
                                    AplicaEmergencia = Convert.ToBoolean(dr["AplicaEmergencia"]),
                                    AplicaHospitalizacion = Convert.ToBoolean(dr["AplicaHospitalizacion"]),
                                    AplicaLaboratorio = Convert.ToBoolean(dr["AplicaLaboratorio"]),
                                    NivelComplejidad = Convert.ToString(dr["NivelComplejidad"]),
                                    RecargoBase = Convert.ToDecimal(dr["RecargoBase"]),
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    UsuarioSistema = Convert.ToString(dr["UsuarioSistema"]),
                                    FechaSistema = Convert.ToDateTime(dr["FechaSistema"]),
                                    HoraSistema = (TimeSpan)dr["HoraSistema"]
                                });
                            }
                        }
                    }
                    return ControlServicios;
                }
            }
            

        // Agregar
        public bool MtdAgregar(TipoServicioEntidad ControlServicios)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryAgregar = @"INSERT INTO Tbl_TiposServicios
                                     (
                                            NombreServicio,
                                            TarifaBase,
                                            AplicaEmergencia,
                                            AplicaHospitalizacion,
                                            AplicaLaboratorio,
                                            NivelComplejidad,
                                            RecargoBase,
                                            Estado,
                                            UsuarioSistema,
                                            FechaSistema,
                                            HoraSistema
                                     )   
                                     VALUES
                                     (
                                            @NombreServicio,
                                            @TarifaBase,
                                            @AplicaEmergencia,
                                            @AplicaHospitalizacion,
                                            @AplicaLaboratorio,
                                            @NivelComplejidad,
                                            @RecargoBase,
                                            @Estado,
                                            @UsuarioSistema,
                                            @FechaSistema,
                                            @HoraSistema
                                     );";

                    using (SqlCommand cmd = new SqlCommand(QueryAgregar, conn))
                    {
                        cmd.Parameters.AddWithValue("@NombreServicio", ControlServicios.NombreServicio);
                        cmd.Parameters.AddWithValue("@TarifaBase", ControlServicios.TarifaBase);
                        cmd.Parameters.AddWithValue("@AplicaEmergencia", ControlServicios.AplicaEmergencia);
                        cmd.Parameters.AddWithValue("@AplicaHospitalizacion", ControlServicios.AplicaHospitalizacion);
                        cmd.Parameters.AddWithValue("@AplicaLaboratorio", ControlServicios.AplicaLaboratorio);
                        cmd.Parameters.AddWithValue("@NivelComplejidad", ControlServicios.NivelComplejidad);
                        cmd.Parameters.AddWithValue("@RecargoBase", ControlServicios.RecargoBase);
                        cmd.Parameters.AddWithValue("@Estado", ControlServicios.Estado);
                        cmd.Parameters.AddWithValue("@UsuarioSistema", ControlServicios.UsuarioSistema);
                        cmd.Parameters.AddWithValue("@FechaSistema", ControlServicios.FechaSistema);
                        cmd.Parameters.AddWithValue("@HoraSistema", ControlServicios.HoraSistema);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Agregar el Tipo de Servicio en la base de datos: ", ex);
            }
        }

        // Editar
        public bool MtdEditar(TipoServicioEntidad ControlServicios)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryEditar = @"UPDATE Tbl_TiposServicios 
                                     SET
                                     NombreServicio = @NombreServicio,
                                     TarifaBase = @TarifaBase,
                                     AplicaEmergencia = @AplicaEmergencia,
                                     AplicaHospitalizacion = @AplicaHospitalizacion,
                                     AplicaLaboratorio = @AplicaLaboratorio,
                                     NivelComplejidad = @NivelComplejidad,
                                     RecargoBase = @RecargoBase,
                                     Estado = @Estado,
                                     UsuarioSistema = @UsuarioSistema,
                                     FechaSistema = @FechaSistema,
                                     HoraSistema = @HoraSistema
                                     WHERE CodigoTipoServicio = @CodigoTipoServicio;";

                    using (SqlCommand cmd = new SqlCommand(QueryEditar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoTipoServicio", ControlServicios.CodigoTipoServicio);
                        cmd.Parameters.AddWithValue("@NombreServicio", ControlServicios.NombreServicio);
                        cmd.Parameters.AddWithValue("@TarifaBase", ControlServicios.TarifaBase);
                        cmd.Parameters.AddWithValue("@AplicaEmergencia", ControlServicios.AplicaEmergencia);
                        cmd.Parameters.AddWithValue("@AplicaHospitalizacion", ControlServicios.AplicaHospitalizacion);
                        cmd.Parameters.AddWithValue("@AplicaLaboratorio", ControlServicios.AplicaLaboratorio);
                        cmd.Parameters.AddWithValue("@NivelComplejidad", ControlServicios.NivelComplejidad);
                        cmd.Parameters.AddWithValue("@RecargoBase", ControlServicios.RecargoBase);
                        cmd.Parameters.AddWithValue("@Estado", ControlServicios.Estado);
                        cmd.Parameters.AddWithValue("@UsuarioSistema", ControlServicios.UsuarioSistema);
                        cmd.Parameters.AddWithValue("@FechaSistema", ControlServicios.FechaSistema);
                        cmd.Parameters.AddWithValue("@HoraSistema", ControlServicios.HoraSistema);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Editar el Tipo de Servicio en la base de datos", ex);
            }
        }

        // Buscar (Por ID de tipo de servicio específico)
        public DataTable MtdBuscar(int CodigoTipoServicio)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string query = @"SELECT * FROM Tbl_TiposServicios 
                                    WHERE CodigoTipoServicio = @CodigoTipoServicio;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoTipoServicio", CodigoTipoServicio);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el Tipo de Servicio: " + ex.Message);
            }
        }

        // Eliminar
        public bool MtdEliminar(int CodigoTipoServicio)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryEliminar = @"DELETE FROM Tbl_TiposServicios 
                                                WHERE CodigoTipoServicio = @CodigoTipoServicio;";
                    using (SqlCommand cmd = new SqlCommand(QueryEliminar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoTipoServicio", CodigoTipoServicio);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Tipo de Servicio de la base de datos", ex);
            }
        }
    }
}
