using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.SegurosMedicos
{

            public class SegurosMedicoDatos
            {
                ConexionDatos conexionDatos = new ConexionDatos();


                /*  ----- AGREGAR ----- */
                public bool MtdAgregar(SegurosMedicosEntidad ControlSegurosMedicos)
                {
                    try
                    {
                        using (SqlConnection conn = conexionDatos.MtdConexion())
                        {
                            conn.Open();
                            string QueryAgregar = @"INSERT INTO Tbl_SegurosMedicos
                                            (
	                                            NombreSeguro,
	                                            TipoSeguro,
	                                            PorcentajeCobertura,
	                                            Telefono,
	                                            Direccion,
	                                            MontoMaximo,
	                                            Estado,
                                                UsuarioSistema,
                                                FechaSistema,
                                                HoraSistema
    
                                            )   
                                            VALUES
                                            (
	                                            @NombreSeguro,
	                                            @TipoSeguro,
	                                            @PorcentajeCobertura,
	                                            @Telefono,
	                                            @Direccion,
	                                            @MontoMaximo, 
	                                            @Estado,
                                                @UsuarioSistema,
                                                @FechaSistema,
                                                @HoraSistema
                                            );";

                            using (SqlCommand cmd = new SqlCommand(QueryAgregar, conn))
                            {
                                cmd.Parameters.AddWithValue("@NombreSeguro", ControlSegurosMedicos.NombreSeguro);
                                cmd.Parameters.AddWithValue("@TipoSeguro", ControlSegurosMedicos.TipoSeguro);
                                cmd.Parameters.AddWithValue("@PorcentajeCobertura", ControlSegurosMedicos.PorcentajeCobertura);
                                cmd.Parameters.AddWithValue("@Telefono", ControlSegurosMedicos.Telefono);
                                cmd.Parameters.AddWithValue("@Direccion", ControlSegurosMedicos.Direccion);
                                cmd.Parameters.AddWithValue("@MontoMaximo", ControlSegurosMedicos.MontoMaximo);
                                cmd.Parameters.AddWithValue("@Estado", ControlSegurosMedicos.Estado);
                                cmd.Parameters.AddWithValue("@UsuarioSistema", ControlSegurosMedicos.UsuarioSistema);
                                cmd.Parameters.AddWithValue("@FechaSistema", ControlSegurosMedicos.FechaSistema);
                                cmd.Parameters.AddWithValue("@HoraSistema", ControlSegurosMedicos.HoraSistema);


                                return cmd.ExecuteNonQuery() > 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al Agregar el seguro medico en la base de datos (datos) ", ex);
                    }
                }
                /*  ----- EDITAR ----- */
                public bool MtdEditar(SegurosMedicosEntidad ControlSegurosMedicos)
                {
                    try
                    {
                        using (SqlConnection conn = conexionDatos.MtdConexion())
                        {
                            conn.Open();
                            string QueryEditar = @"UPDATE Tbl_SegurosMedicos 
                                        SET NombreSeguro = @NombreSeguro,
                                        TipoSeguro = @TipoSeguro,
                                        PorcentajeCobertura = @PorcentajeCobertura,
                                        Telefono = @Telefono,
                                        Direccion = @Direccion,
                                        MontoMaximo = @MontoMaximo,
                                        Estado = @Estado,
                                        UsuarioSistema = @UsuarioSistema,
                                        FechaSistema = @FechaSistema,
                                        HoraSistema = @HoraSistema
                                        WHERE CodigoSeguro = @CodigoSeguro;";

                            using (SqlCommand cmd = new SqlCommand(QueryEditar, conn))
                            {
                                cmd.Parameters.AddWithValue("@NombreSeguro", ControlSegurosMedicos.NombreSeguro);
                                cmd.Parameters.AddWithValue("@TipoSeguro", ControlSegurosMedicos.TipoSeguro);
                                cmd.Parameters.AddWithValue("@PorcentajeCobertura", ControlSegurosMedicos.PorcentajeCobertura);
                                cmd.Parameters.AddWithValue("@Telefono", ControlSegurosMedicos.Telefono);
                                cmd.Parameters.AddWithValue("@Direccion", ControlSegurosMedicos.Direccion);
                                cmd.Parameters.AddWithValue("@MontoMaximo", ControlSegurosMedicos.MontoMaximo);                        
                                cmd.Parameters.AddWithValue("@Estado", ControlSegurosMedicos.Estado);
                                cmd.Parameters.AddWithValue("@UsuarioSistema", ControlSegurosMedicos.UsuarioSistema);
                                cmd.Parameters.AddWithValue("@FechaSistema", ControlSegurosMedicos.FechaSistema);
                                cmd.Parameters.AddWithValue("@HoraSistema", ControlSegurosMedicos.HoraSistema);
                                return cmd.ExecuteNonQuery() > 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al Editar el seguro medico en la base de datos", ex);
                    }
                }

                public bool MtdEliminar(int CodigoSegurosMedicos)
                {
                    try
                    {
                        using (SqlConnection conn = conexionDatos.MtdConexion())
                        {
                            conn.Open();
                            string QueryEliminar = @"DELETE Tbl_SegurosMedicos WHERE CodigoSeguro = @CodigoSeguro;";

                            using (SqlCommand cmd = new SqlCommand(QueryEliminar, conn))
                            {
                                cmd.Parameters.AddWithValue("@CodigoSeguro", CodigoSegurosMedicos);

                                return cmd.ExecuteNonQuery() > 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al eliminar al eliminar el seguro medico de la base de datos", ex);
                    }
                }


                public DataTable MtdBuscar(string CodigoSegurosMedicos)
                {
                    try
                    {
                        using (SqlConnection conn = conexionDatos.MtdConexion())
                        {
                            conn.Open();

                            string query = @"SELECT * 
                                         FROM Tbl_SegurosMedicos 
                                         WHERE CodigoSeguro LIKE @CodigoSeguro;";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@CodigoSeguro", CodigoSegurosMedicos);

                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                return dt;
                            }
                        }
                    }
                    catch (SqlException exSql)
                    {
                        throw new Exception("Error al buscar el seguro medico: " + exSql.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error general al buscar el seguro medico: " + ex.Message);
                    }
                }
                public List<SegurosMedicosEntidad> MtdConsultarSeguros()
                {
                    List<SegurosMedicosEntidad> ListaSegurosMedicos = new List<SegurosMedicosEntidad>();
                    try
                    {
                        using (SqlConnection conn = conexionDatos.MtdConexion())
                        {
                            conn.Open();
                            string QueryListar = "SELECT * FROM Tbl_SegurosMedicos ORDER BY CodigoSeguro ASC;";
                            using (SqlCommand cmd = new SqlCommand(QueryListar, conn))
                            {
                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {
                                    while (dr.Read())
                                    {
                                    ListaSegurosMedicos.Add(new SegurosMedicosEntidad()
                                        {
                                            CodigoSeguro = Convert.ToInt32(dr["CodigoSeguro"]),
                                            NombreSeguro = Convert.ToString(dr["NombreSeguro"]),
                                            TipoSeguro = Convert.ToString(dr["TipoSeguro"]),
                                            PorcentajeCobertura = Convert.ToDecimal(dr["PorcentajeCobertura"]),
                                            Telefono = Convert.ToString(dr["Telefono"]),
                                            Direccion = Convert.ToString(dr["Direccion"]),
                                            MontoMaximo = Convert.ToDecimal(dr["MontoMaximo"]),
                                            Estado = Convert.ToBoolean(dr["Estado"]),
                                            UsuarioSistema = Convert.ToString(dr["UsuarioSistema"]),
                                            FechaSistema = Convert.ToDateTime(dr["FechaSistema"]),
                                            HoraSistema = Convert.ToDateTime(dr["HoraSistema"])
                                        });
                                    }
                                }

                            }
                            return ListaSegurosMedicos;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al mostrar la los seguros medicos" + ex.Message);

                    }
                }

            }

}

