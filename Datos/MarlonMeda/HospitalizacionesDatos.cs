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
    public class HospitalizacionDatos
    {
        // Instancia
        ConexionDatos conexionDatos = new ConexionDatos();

        /* ----- CONSULTAR ----- */
        public List<HospitalizacionesEntidad> MtdConsultar()
        {
            List<HospitalizacionesEntidad> ControlHospitalizaciones = new List<HospitalizacionesEntidad>();
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryListar = "SELECT * FROM Tbl_Hospitalizaciones ORDER BY CodigoHospitalizacion ASC;";
                    using (SqlCommand cmd = new SqlCommand(QueryListar, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ControlHospitalizaciones.Add(new HospitalizacionesEntidad()
                                {
                                    CodigoHospitalizacion = Convert.ToInt32(dr["CodigoHospitalizacion"]),
                                    CodigoAtencion = Convert.ToInt32(dr["CodigoAtencion"]),
                                    NumeroHabitacion = Convert.ToString(dr["NumeroHabitacion"]),
                                    Dias = Convert.ToInt32(dr["Dias"]),
                                    CostoDia = Convert.ToDecimal(dr["CostoDia"]),
                                    CostoMedico = Convert.ToDecimal(dr["CostoMedico"]),
                                    SubTotal = Convert.ToDecimal(dr["SubTotal"]),
                                    Descuento = Convert.ToDecimal(dr["Descuento"]),
                                    TotalHospitalizacion = Convert.ToDecimal(dr["TotalHospitalizacion"]),
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    UsuarioSistema = Convert.ToString(dr["UsuarioSistema"]),
                                    FechaSistema = Convert.ToDateTime(dr["FechaSistema"]),
                                    HoraSistema = (TimeSpan)dr["HoraSistema"]
                                });
                            }
                        }
                    }
                    return ControlHospitalizaciones;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar la lista de Hospitalizaciones: " + ex.Message);
            }
        }

        /* ----- AGREGAR ----- */
        public bool MtdAgregar(HospitalizacionesEntidad ControlHospitalizacion)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    // No se coloca el primary key (CodigoHospitalizacion) porque es autoincrementable
                    string QueryAgregar = @"INSERT INTO Tbl_Hospitalizaciones
                                         (
                                             CodigoAtencion,
                                             NumeroHabitacion,
                                             Dias,
                                             CostoDia,
                                             CostoMedico,
                                             SubTotal,
                                             Descuento,
                                             TotalHospitalizacion,
                                             Estado,
                                             UsuarioSistema,
                                             FechaSistema,
                                             HoraSistema
                                         )   
                                         VALUES
                                         (
                                             @CodigoAtencion,
                                             @NumeroHabitacion,
                                             @Dias,
                                             @CostoDia,
                                             @CostoMedico,
                                             @SubTotal,
                                             @Descuento,
                                             @TotalHospitalizacion,
                                             @Estado,
                                             @UsuarioSistema,
                                             @FechaSistema,
                                             @HoraSistema
                                         );";

                    using (SqlCommand cmd = new SqlCommand(QueryAgregar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoAtencion", ControlHospitalizacion.CodigoAtencion);
                        cmd.Parameters.AddWithValue("@NumeroHabitacion", ControlHospitalizacion.NumeroHabitacion);
                        cmd.Parameters.AddWithValue("@Dias", ControlHospitalizacion.Dias);
                        cmd.Parameters.AddWithValue("@CostoDia", ControlHospitalizacion.CostoDia);
                        cmd.Parameters.AddWithValue("@CostoMedico", ControlHospitalizacion.CostoMedico);
                        cmd.Parameters.AddWithValue("@SubTotal", ControlHospitalizacion.SubTotal);
                        cmd.Parameters.AddWithValue("@Descuento", ControlHospitalizacion.Descuento);
                        cmd.Parameters.AddWithValue("@TotalHospitalizacion", ControlHospitalizacion.TotalHospitalizacion);
                        cmd.Parameters.AddWithValue("@Estado", ControlHospitalizacion.Estado);
                        cmd.Parameters.AddWithValue("@UsuarioSistema", ControlHospitalizacion.UsuarioSistema);
                        cmd.Parameters.AddWithValue("@FechaSistema", ControlHospitalizacion.FechaSistema);
                        cmd.Parameters.AddWithValue("@HoraSistema", ControlHospitalizacion.HoraSistema);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Agregar la hospitalización en la base de datos: ", ex);
            }
        }

        /* ----- EDITAR ----- */
        public bool MtdEditar(HospitalizacionesEntidad ControlHospitalizacion)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryEditar = @"UPDATE Tbl_Hospitalizaciones 
                                     SET
                                     CodigoAtencion = @CodigoAtencion,
                                     NumeroHabitacion = @NumeroHabitacion,
                                     Dias = @Dias,
                                     CostoDia = @CostoDia,
                                     CostoMedico = @CostoMedico,
                                     SubTotal = @SubTotal,
                                     Descuento = @Descuento,
                                     TotalHospitalizacion = @TotalHospitalizacion,
                                     Estado = @Estado,
                                     UsuarioSistema = @UsuarioSistema,
                                     FechaSistema = @FechaSistema,
                                     HoraSistema = @HoraSistema
                                     WHERE CodigoHospitalizacion = @CodigoHospitalizacion;";

                    using (SqlCommand cmd = new SqlCommand(QueryEditar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoHospitalizacion", ControlHospitalizacion.CodigoHospitalizacion); // Aquí sí se coloca la primary key
                        cmd.Parameters.AddWithValue("@CodigoAtencion", ControlHospitalizacion.CodigoAtencion);
                        cmd.Parameters.AddWithValue("@NumeroHabitacion", ControlHospitalizacion.NumeroHabitacion);
                        cmd.Parameters.AddWithValue("@Dias", ControlHospitalizacion.Dias);
                        cmd.Parameters.AddWithValue("@CostoDia", ControlHospitalizacion.CostoDia);
                        cmd.Parameters.AddWithValue("@CostoMedico", ControlHospitalizacion.CostoMedico);
                        cmd.Parameters.AddWithValue("@SubTotal", ControlHospitalizacion.SubTotal);
                        cmd.Parameters.AddWithValue("@Descuento", ControlHospitalizacion.Descuento);
                        cmd.Parameters.AddWithValue("@TotalHospitalizacion", ControlHospitalizacion.TotalHospitalizacion);
                        cmd.Parameters.AddWithValue("@Estado", ControlHospitalizacion.Estado);
                        cmd.Parameters.AddWithValue("@UsuarioSistema", ControlHospitalizacion.UsuarioSistema);
                        cmd.Parameters.AddWithValue("@FechaSistema", ControlHospitalizacion.FechaSistema);
                        cmd.Parameters.AddWithValue("@HoraSistema", ControlHospitalizacion.HoraSistema);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Editar la hospitalización en la base de datos", ex);
            }
        }

        /* ----- BUSCAR ----- */
        public DataTable MtdBuscar(int CodigoAtencion)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();

                         string query = @"SELECT * FROM Tbl_Hospitalizaciones 
                                      WHERE CodigoAtencion = @CodigoAtencion;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@CodigoAtencion", CodigoAtencion);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
            catch (SqlException exSql)
            {
                throw new Exception("Error de SQL al buscar la hospitalización: " + exSql.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al buscar la hospitalización: " + ex.Message);
            }
        }

        /* ----- ELIMINAR ----- */
        public bool MtdEliminar(int CodigoHospitalizacion)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryEliminar = @"DELETE FROM Tbl_Hospitalizaciones WHERE CodigoHospitalizacion = @CodigoHospitalizacion;";

                    using (SqlCommand cmd = new SqlCommand(QueryEliminar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoHospitalizacion", CodigoHospitalizacion);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la hospitalización de la base de datos", ex);
            }
        }
    }
}
