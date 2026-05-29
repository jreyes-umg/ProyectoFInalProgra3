using Entidad;
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
    public class SanatoriosDatos
    {
        ConexionDatos conexionDatos = new ConexionDatos();
        /*  ----- CONSULTAR ----- */
        public List<EntidadSanatorios> MtdConsultar()
        {
            List<EntidadSanatorios> ListaSanatorios = new List<EntidadSanatorios>();
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryListar = "SELECT * FROM Tbl_Sanatorios ORDER BY CodigoSanatorio ASC;";
                    using (SqlCommand cmd = new SqlCommand(QueryListar, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ListaSanatorios.Add(new EntidadSanatorios()
                                {
                                    CodigoSanatorio = Convert.ToInt32(dr["CodigoSanatorio"]),
                                    Nombre = Convert.ToString(dr["Nombre"]),
                                    Ubicacion = Convert.ToString(dr["Ubicacion"]),
                                    TipoSanatorio = Convert.ToString(dr["TipoSanatorio"]),
                                    Telefono = Convert.ToString(dr["Telefono"]),
                                    Director = Convert.ToString(dr["Director"]),
                                    CostoOperacionDiario = Convert.ToDecimal(dr["CostoOperacionDiario"]),
                                    CapacidadHabitaciones = Convert.ToInt32(dr["CapacidadHabitaciones"]),
                                    NivelServicio = Convert.ToString(dr["NivelServicio"]),
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
        /*  ----- EDITAR ----- */
        public bool MtdEditar(EntidadSanatorios ControlSanatorios)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryEditar = @"UPDATE Tbl_Sanatorios 
                                                    SET Nombre = @Nombre,
                                                    Ubicacion = @Ubicacion,
                                                    CapacidadHabitaciones = @CapacidadHabitaciones,
                                                    Telefono = @Telefono,
                                                    Director = @Director,
                                                    TipoSanatorio = @TipoSanatorio,
                                                    CostoOperacionDiario = @CostoOperacionDiario,
                                                    NivelServicio = @NivelServicio,
                                                    Estado = @Estado,
                                                    UsuarioSistema = @UsuarioSistema,
                                                    FechaSistema = @FechaSistema,
                                                    HoraSistema = @HoraSistema
                                                    WHERE CodigoSanatorio = @CodigoSanatorio;";

                    using (SqlCommand cmd = new SqlCommand(QueryEditar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoSanatorio", ControlSanatorios.CodigoSanatorio);
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
                throw new Exception("Error al Editar el Sanatorio en la base de datos", ex);
            }
        }
        public bool MtdEliminar(int CodigoSanatorio)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryEliminar = @"DELETE Tbl_Sanatorios WHERE CodigoSanatorio = @CodigoSanatorio;";

                    using (SqlCommand cmd = new SqlCommand(QueryEliminar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoSanatorio", CodigoSanatorio);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Sanatorio de la base de datos", ex);
            }
        }


        public DataTable MtdBuscar(string Nombre)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();

                    string query = @"SELECT * FROM Tbl_Sanatorios WHERE Nombre LIKE @Nombre;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Nombre", Nombre);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
            catch (SqlException exSql)
            {
                throw new Exception("Error al buscar el Sanatorio: " + exSql.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al buscar el Sanatorio: " + ex.Message);
            }
        }



    }
}
