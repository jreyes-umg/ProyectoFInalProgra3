using Entidad.JuanDavid;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.JuanDavid
{
    internal class LaboratoriosDatos
    {
        ConexionDatos conexionDatos = new ConexionDatos();
        /*  ----- CONSULTAR ----- */
        public List<LaboratoriosEntidad> MtdConsultar()
        {
            List<LaboratoriosEntidad> ListaSanatorios = new List<LaboratoriosEntidad>();
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryListar = "SELECT * FROM Tbl_Laboratorios ORDER BY CodigoLaboratorio ASC;";
                    using (SqlCommand cmd = new SqlCommand(QueryListar, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ListaSanatorios.Add(new LaboratoriosEntidad()
                                {
                                    CodigoLaboratorio = Convert.ToInt32(dr["CodigoLaboratorio"]),
                                    CodigoAtencion = Convert.ToInt32(dr["CodigoAtencion"]),
                                    TipoExamen = Convert.ToString(dr["TipoExamen"]),
                                    CostoExamen = Convert.ToDecimal(dr["CostoExamen"]),
                                    Cantidad = Convert.ToInt32(dr["CodigoAtencion"]),
                                    Urgente = Convert.ToBoolean(dr["Urgente"]),
                                    RecargoUrgente = Convert.ToDecimal(dr["RecargoUrgente"]),
                                    SubTotal = Convert.ToDecimal(dr["SubTotal"]),
                                    TotalLaboratorio = Convert.ToDecimal(dr["TotalLaboratorio"]),
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
        public bool MtdAgregar(EntidadSanatorios ControlSanatorios)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryAgregar = @"INSERT INTO Tbl_Sanatorios (
                                                        Nombre,
                                                        Ubicacion,
                                                        CapacidadHabitaciones,
                                                        Telefono,
                                                        Director,
                                                        TipoSanatorio,
                                                        CostoOperacionDiario,
                                                        NivelServicio,
                                                        Estado,
                                                        UsuarioSistema,
                                                        FechaSistema,
                                                        HoraSistema)
                                                    VALUES (
                                                        @Nombre,
                                                        @Ubicacion,
                                                        @CapacidadHabitaciones,
                                                        @Telefono,
                                                        @Director,
                                                        @TipoSanatorio,
                                                        @CostoOperacionDiario,
                                                        @NivelServicio,
                                                        @Estado,
                                                        @UsuarioSistema,
                                                        @FechaSistema,
                                                        @HoraSistema);";

                    using (SqlCommand cmd = new SqlCommand(QueryAgregar, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", ControlSanatorios.Nombre);
                        cmd.Parameters.AddWithValue("@Ubicacion", ControlSanatorios.Ubicacion);
                        cmd.Parameters.AddWithValue("@CapacidadHabitaciones", ControlSanatorios.CapacidadHabitaciones);
                        cmd.Parameters.AddWithValue("@Telefono", ControlSanatorios.Telefono);
                        cmd.Parameters.AddWithValue("@Director", ControlSanatorios.Director);
                        cmd.Parameters.AddWithValue("@TipoSanatorio", ControlSanatorios.TipoSanatorio);
                        cmd.Parameters.AddWithValue("@CostoOperacionDiario", ControlSanatorios.CostoOperacionDiario);
                        cmd.Parameters.AddWithValue("@NivelServicio", ControlSanatorios.NivelServicio);
                        cmd.Parameters.AddWithValue("@Estado", ControlSanatorios.Estado);
                        cmd.Parameters.AddWithValue("@UsuarioSistema", ControlSanatorios.UsuarioSistema);
                        cmd.Parameters.AddWithValue("@FechaSistema", ControlSanatorios.FechaSistema);
                        cmd.Parameters.AddWithValue("@HoraSistema", ControlSanatorios.HoraSistema);


                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Agregar el Sanatorio en la base de datos (datos) ", ex);
            }
        }
    }
}
