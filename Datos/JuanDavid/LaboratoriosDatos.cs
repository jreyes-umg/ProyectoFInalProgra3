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
    public class LaboratoriosDatos
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
        public bool MtdAgregar(LaboratoriosEntidad ListaSanatorios)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryAgregar = @"INSERT INTO Tbl_Laboratorios (
                                                            CodigoAtencion,
                                                            TipoExamen,
                                                            CostoExamen,
                                                            Cantidad,
                                                            Urgente,
                                                            RecargoUrgente,
                                                            SubTotal,
                                                            TotalLaboratorio,
                                                            Estado,
                                                            UsuarioSistema,
                                                            FechaSistema,
                                                            HoraSistema)
                                                            VALUES (
                                                            @CodigoAtencion,
                                                            @TipoExamen,
                                                            @CostoExamen, 
                                                            @Cantidad,
                                                            @Urgente,
                                                            @RecargoUrgente,
                                                            @SubTotal,
                                                            @TotalLaboratorio,
                                                            @Estado,
                                                            @UsuarioSistema,
                                                            @FechaSistema,
                                                            @HoraSistema);";

                    using (SqlCommand cmd = new SqlCommand(QueryAgregar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoAtencion", ListaSanatorios.CodigoAtencion);
                        cmd.Parameters.AddWithValue("@TipoExamen", ListaSanatorios.TipoExamen);
                        cmd.Parameters.AddWithValue("@CostoExamen", ListaSanatorios.CostoExamen);
                        cmd.Parameters.AddWithValue("@Cantidad", ListaSanatorios.Cantidad);
                        cmd.Parameters.AddWithValue("@Urgente", ListaSanatorios.Urgente);
                        cmd.Parameters.AddWithValue("@RecargoUrgente", ListaSanatorios.RecargoUrgente);
                        cmd.Parameters.AddWithValue("@SubTotal", ListaSanatorios.SubTotal);
                        cmd.Parameters.AddWithValue("@TotalLaboratorio", ListaSanatorios.TotalLaboratorio);
                        cmd.Parameters.AddWithValue("@Estado", ListaSanatorios.Estado);
                        cmd.Parameters.AddWithValue("@UsuarioSistema", ListaSanatorios.UsuarioSistema);
                        cmd.Parameters.AddWithValue("@FechaSistema", ListaSanatorios.FechaSistema);
                        cmd.Parameters.AddWithValue("@HoraSistema", ListaSanatorios.HoraSistema);


                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Agregar el Laboratorios en la base de datos (datos) ", ex);
            }
        }
        /*  ----- EDITAR ----- */
        public bool MtdEditar(LaboratoriosEntidad ListaSanatorios)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryEditar = @"UPDATE Tbl_Laboratorios 
                                            SET CodigoAtencion = @CodigoAtencion,
                                            TipoExamen = @TipoExamen,
                                            CostoExamen = @CostoExamen,
                                            Cantidad = @Cantidad,
                                            Urgente = @Urgente,
                                            RecargoUrgente = @RecargoUrgente,
                                            SubTotal = @SubTotal,
                                            TotalLaboratorio = @TotalLaboratorio,
                                            Estado = @Estado,
                                            UsuarioSistema = @UsuarioSistema,
                                            FechaSistema = @FechaSistema,
                                            HoraSistema = @HoraSistema
                                            WHERE CodigoLaboratorio = @CodigoLaboratorio;";

                    using (SqlCommand cmd = new SqlCommand(QueryEditar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoLaboratorio", ListaSanatorios.CodigoLaboratorio);
                        cmd.Parameters.AddWithValue("@CodigoAtencion", ListaSanatorios.CodigoAtencion);
                        cmd.Parameters.AddWithValue("@TipoExamen", ListaSanatorios.TipoExamen);
                        cmd.Parameters.AddWithValue("@CostoExamen", ListaSanatorios.CostoExamen);
                        cmd.Parameters.AddWithValue("@Cantidad", ListaSanatorios.Cantidad);
                        cmd.Parameters.AddWithValue("@Urgente", ListaSanatorios.Urgente);
                        cmd.Parameters.AddWithValue("@RecargoUrgente", ListaSanatorios.RecargoUrgente);
                        cmd.Parameters.AddWithValue("@SubTotal", ListaSanatorios.SubTotal);
                        cmd.Parameters.AddWithValue("@TotalLaboratorio", ListaSanatorios.TotalLaboratorio);
                        cmd.Parameters.AddWithValue("@Estado", ListaSanatorios.Estado);
                        cmd.Parameters.AddWithValue("@UsuarioSistema", ListaSanatorios.UsuarioSistema);
                        cmd.Parameters.AddWithValue("@FechaSistema", ListaSanatorios.FechaSistema);
                        cmd.Parameters.AddWithValue("@HoraSistema", ListaSanatorios.HoraSistema);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Editar el Laboratorios en la base de datos", ex);
            }
        }

        public bool MtdEliminar(int CodigoLaboratorio)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryEliminar = @"DELETE Tbl_Laboratorios WHERE CodigoLaboratorio = @CodigoLaboratorio;";

                    using (SqlCommand cmd = new SqlCommand(QueryEliminar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoLaboratorio", CodigoLaboratorio);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Laboratorios de la base de datos", ex);
            }
        }


        public DataTable MtdBuscarLaboratoriosPorPaciente(string nombrePaciente)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();

                    string query = @"
                SELECT l.*, p.Nombre, p.Apellido 
                FROM Tbl_Laboratorios l
                INNER JOIN Tbl_AtencionesPacientes a ON l.CodigoAtencion = a.CodigoAtencion
                INNER JOIN Tbl_Pacientes p ON a.CodigoPaciente = p.CodigoPaciente
                WHERE p.Nombre LIKE '%' + @NombreBusqueda + '%' 
                   OR p.Apellido LIKE '%' + @NombreBusqueda + '%';";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        // Pasamos el parámetro ingresado por el usuario
                        cmd.Parameters.AddWithValue("@NombreBusqueda", nombrePaciente);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
            catch (SqlException exSql)
            {
                throw new Exception("Error de SQL al buscar los laboratorios del paciente: " + exSql.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al buscar los laboratorios: " + ex.Message);
            }

        }
        /*OBTENER ITEMS PARA CBX*/
        public List<dynamic> MtdListarAtenciones()
        {
            List<dynamic> ListarDatos = new List<dynamic>();

            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();


                    string QueryListaAtenciones = @"
                        SELECT a.CodigoAtencion, p.Nombre, p.Apellido
                        FROM Tbl_AtencionesPacientes a
                        INNER JOIN Tbl_Pacientes p ON a.CodigoPaciente = p.CodigoPaciente;
                    ";

                    using (SqlCommand cmd = new SqlCommand(QueryListaAtenciones, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ListarDatos.Add(new
                                {

                                    Value = dr["CodigoAtencion"],


                                    Text = $"Atención: {dr["CodigoAtencion"]} - {dr["Nombre"]} {dr["Apellido"]}"
                                });
                            }
                        }
                    }
                }
                return ListarDatos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar las atenciones: " + ex.Message);
            }
        }
    }
}
