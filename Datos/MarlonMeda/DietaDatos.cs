using Entidad;
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
    public class DietaDatos
    {
        //instacia
        ConexionDatos conexionDatos = new ConexionDatos();

        //consultar
        public List<DietasEntidad> MtdConsultar()
        {
            List<DietasEntidad> ControlDietas = new List<DietasEntidad>();
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryListar = "SELECT * FROM Tbl_Dietas ORDER BY CodigoDieta ASC;";
                    using (SqlCommand cmd = new SqlCommand(QueryListar, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ControlDietas.Add(new DietasEntidad()
                                {
                                    CodigoDieta = Convert.ToInt32(dr["CodigoDieta"]),
                                    CodigoHospitalizacion = Convert.ToInt32(dr["CodigoHospitalizacion"]),
                                    TipoDieta = Convert.ToString(dr["TipoDieta"]),
                                    CostoDiario = Convert.ToDecimal(dr["CostoDiario"]),
                                    Dias = Convert.ToInt32(dr["Dias"]),
                                    Nutricionista = Convert.ToString(dr["Nutricionista"]),
                                    SubTotal = Convert.ToDecimal(dr["SubTotal"]),
                                    Impuesto = Convert.ToDecimal(dr["Impuesto"]),
                                    TotalDieta = Convert.ToDecimal(dr["TotalDieta"]),
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    UsuarioSistema = Convert.ToString(dr["UsuarioSistema"]),
                                    FechaSistema = Convert.ToDateTime(dr["FechaSistema"]),
                                    HoraSistema = (TimeSpan)dr["HoraSistema"]
                                });
                            }
                        }

                    }
                    return ControlDietas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar la lista DATOS" + ex.Message);

            }
        }



        /*  ----- AGREGAR ----- */
        public bool MtdAgregar(DietasEntidad ControlDietas)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    //no se coloca el primary key o la primera 
                    conn.Open();
                    string QueryAgregar = @"INSERT INTO Tbl_Dietas
                                            (
	                                          
                                                CodigoHospitalizacion,
                                                TipoDieta,
                                                CostoDiario,
                                                Dias,
                                                Nutricionista,
                                                SubTotal,
                                                Impuesto,
                                                TotalDieta,
                                                Estado,
                                                UsuarioSistema,
                                                FechaSistema,
                                                HoraSistema
                                            )   
                                            VALUES
                                            (
                                              
                                                @CodigoHospitalizacion,
                                                @TipoDieta,
                                                @CostoDiario,
                                                @Dias,
                                                @Nutricionista,
                                                @SubTotal,
                                                @Impuesto,
                                                @TotalDieta,
                                                @Estado,
                                                @UsuarioSistema,
                                                @FechaSistema,
                                                @HoraSistema
                                            );";

                    using (SqlCommand cmd = new SqlCommand(QueryAgregar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoHospitalizacion", ControlDietas.CodigoHospitalizacion);
                        cmd.Parameters.AddWithValue("@TipoDieta", ControlDietas.TipoDieta);
                        cmd.Parameters.AddWithValue("@CostoDiario", ControlDietas.CostoDiario);
                        cmd.Parameters.AddWithValue("@Dias", ControlDietas.Dias);
                        cmd.Parameters.AddWithValue("@Nutricionista", ControlDietas.Nutricionista);
                        cmd.Parameters.AddWithValue("@SubTotal", ControlDietas.SubTotal);
                        cmd.Parameters.AddWithValue("@Impuesto", ControlDietas.Impuesto);
                        cmd.Parameters.AddWithValue("@TotalDieta", ControlDietas.TotalDieta);
                        cmd.Parameters.AddWithValue("@Estado", ControlDietas.Estado);
                        cmd.Parameters.AddWithValue("@UsuarioSistema", ControlDietas.UsuarioSistema);
                        cmd.Parameters.AddWithValue("@FechaSistema", ControlDietas.FechaSistema);
                        cmd.Parameters.AddWithValue("@HoraSistema", ControlDietas.HoraSistema);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Agregar los Pagos en la base de datos (datos) ", ex);
            }
        }


        /*  ----- EDITAR ----- */
        public bool MtdEditar(DietasEntidad ControlDietas)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryEditar = @"UPDATE Tbl_Dietas 
                                        SET
                                        CodigoHospitalizacion = @CodigoHospitalizacion,
                                        TipoDieta = @TipoDieta,
                                        CostoDiario = @CostoDiario,
                                        Dias = @Dias,
                                        Nutricionista = @Nutricionista,
                                        SubTotal = @SubTotal,
                                        Impuesto = @Impuesto,
                                        TotalDieta = @TotalDieta,
                                        Estado = @Estado,
                                        UsuarioSistema = @UsuarioSistema,
                                        FechaSistema = @FechaSistema,
                                        HoraSistema = @HoraSistema
                                        WHERE CodigoDieta = @CodigoDieta;";

                    using (SqlCommand cmd = new SqlCommand(QueryEditar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoDieta", ControlDietas.CodigoDieta); //aqui si se coloca la primary key
                        cmd.Parameters.AddWithValue("@CodigoHospitalizacion", ControlDietas.CodigoHospitalizacion);
                        cmd.Parameters.AddWithValue("@TipoDieta", ControlDietas.TipoDieta);
                        cmd.Parameters.AddWithValue("@CostoDiario", ControlDietas.CostoDiario);
                        cmd.Parameters.AddWithValue("@Dias", ControlDietas.Dias);
                        cmd.Parameters.AddWithValue("@Nutricionista", ControlDietas.Nutricionista);
                        cmd.Parameters.AddWithValue("@SubTotal", ControlDietas.SubTotal);
                        cmd.Parameters.AddWithValue("@Impuesto", ControlDietas.Impuesto);
                        cmd.Parameters.AddWithValue("@TotalDieta", ControlDietas.TotalDieta);
                        cmd.Parameters.AddWithValue("@Estado", ControlDietas.Estado);
                        cmd.Parameters.AddWithValue("@UsuarioSistema", ControlDietas.UsuarioSistema);
                        cmd.Parameters.AddWithValue("@FechaSistema", ControlDietas.FechaSistema);
                        cmd.Parameters.AddWithValue("@HoraSistema", ControlDietas.HoraSistema);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Editar la dieta en la base de datos", ex);
            }
        }

        //buscar 
        public DataTable MtdBuscar(int CodigoHospitalizacion)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();

                    string query = @"SELECT * 
                                         FROM Tbl_Dietas 
                                         WHERE CodigoHospitalizacion = @CodigoHospitalizacion;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@CodigoHospitalizacion", CodigoHospitalizacion);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
            catch (SqlException exSql)
            {
                throw new Exception("Error al buscar el Doctor: " + exSql.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al buscar el Doctor: " + ex.Message);
            }
        }

        //eliminar
        public bool MtdEliminar(int CodigoDieta)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryEliminar = @"DELETE Tbl_Dietas  WHERE CodigoDieta = @CodigoDieta;";

                    using (SqlCommand cmd = new SqlCommand(QueryEliminar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoDieta", CodigoDieta);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar al eliminar el Doctor de la base de datos", ex);
            }
        }

    }
}
