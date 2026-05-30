using Entidad;
using Entidad.Factura;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Facturas
{
        
            public class FacturaDatos
            {
                ConexionDatos conexionDatos = new ConexionDatos();


                /*  ----- AGREGAR ----- */
                public bool MtdAgregar(FacturasEntidad ControlFacturas)
                {
                    try
                    {
                        using (SqlConnection conn = conexionDatos.MtdConexion())
                        {
                            conn.Open();
                            string QueryAgregar = @"INSERT INTO Tbl_Facturas
                                            (
	                                            CodigoFactura,
	                                            CodigoAtencion,
	                                            CodigoSeguro,
	                                            FechaFactura,
	                                            SubTotal,
	                                            DescuentoSeguro,
	                                            Impuesto,
	                                            TotalPagar,
	                                            Estado,
                                                UsuarioSistema,
                                                FechaSistema,
                                                HoraSistema
    
                                            )   
                                            VALUES
                                            (
	                                            @CodigoFactura,
	                                            @CodigoAtencion,
	                                            @CodigoSeguro,
	                                            @FechaFactura,
	                                            @SubTotal,
	                                            @DescuentoSeguro,
	                                            @Impuesto,
	                                            @TotalPagar,
	                                            @Estado,
                                                @UsuarioSistema,
                                                @FechaSistema,
                                                @HoraSistema
                                            );";

                            using (SqlCommand cmd = new SqlCommand(QueryAgregar, conn))
                            {
                                cmd.Parameters.AddWithValue("@CodigoFactura", ControlFacturas.CodigoFactura);
                                cmd.Parameters.AddWithValue("@CodigoAtencion", ControlFacturas.CodigoAtencion);
                                cmd.Parameters.AddWithValue("@CodigoSeguro", ControlFacturas.CodigoSeguro);
                                cmd.Parameters.AddWithValue("@FechaFactura", ControlFacturas.FechaFactura);
                                cmd.Parameters.AddWithValue("@SubTotal", ControlFacturas.SubTotal);
                                cmd.Parameters.AddWithValue("@DescuentoSeguro", ControlFacturas.DescuentoSeguro);
                                cmd.Parameters.AddWithValue("@Impuesto", ControlFacturas.Impuesto);
                                cmd.Parameters.AddWithValue("@TotalPagar", ControlFacturas.TotalPagar);
                                cmd.Parameters.AddWithValue("@Estado", ControlFacturas.Estado);
                                cmd.Parameters.AddWithValue("@UsuarioSistema", ControlFacturas.UsuarioSistema);
                                cmd.Parameters.AddWithValue("@FechaSistema", ControlFacturas.FechaSistema);
                                cmd.Parameters.AddWithValue("@HoraSistema", ControlFacturas.HoraSistema);


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
                public bool MtdEditar(FacturasEntidad ControlFacturas)
                {
                    try
                    {
                        using (SqlConnection conn = conexionDatos.MtdConexion())
                        {
                            conn.Open();
                            string QueryEditar = @"UPDATE Tbl_Facturas 
                                        SET CodigoAtencion = @CodigoAtencion,
                                        CodigoSeguro = @CodigoSeguro,
                                        FechaFactura = @FechaFactura,
                                        SubTotal = @SubTotal,
                                        DescuentoSeguro = @DescuentoSeguro,
                                        Impuesto = @Impuesto,
                                        TotalPagar = @TotalPagar,
                                        Estado = @Estado,
                                        UsuarioSistema = @UsuarioSistema,
                                        FechaSistema = @FechaSistema,
                                        HoraSistema = @HoraSistema
                                        WHERE CodigoFactura = @CodigoFactura;";

                            using (SqlCommand cmd = new SqlCommand(QueryEditar, conn))
                            {
                                cmd.Parameters.AddWithValue("@CodigoAtencion", ControlFacturas.CodigoAtencion);
                                cmd.Parameters.AddWithValue("@CodigoSeguro", ControlFacturas.CodigoSeguro);
                                cmd.Parameters.AddWithValue("@FechaFactura", ControlFacturas.FechaFactura);
                                cmd.Parameters.AddWithValue("@SubTotal", ControlFacturas.SubTotal);
                                cmd.Parameters.AddWithValue("@DescuentoSeguro", ControlFacturas.DescuentoSeguro);
                                cmd.Parameters.AddWithValue("@Impuesto", ControlFacturas.Impuesto);
                                cmd.Parameters.AddWithValue("@Estado", ControlFacturas.Estado);
                                cmd.Parameters.AddWithValue("@UsuarioSistema", ControlFacturas.UsuarioSistema);
                                cmd.Parameters.AddWithValue("@FechaSistema", ControlFacturas.FechaSistema);
                                cmd.Parameters.AddWithValue("@HoraSistema", ControlFacturas.HoraSistema);
                                return cmd.ExecuteNonQuery() > 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al Editar el Doctor en la base de datos", ex);
                    }
                }

                public bool MtdEliminar(int ControlFacturas)
                {
                    try
                    {
                        using (SqlConnection conn = conexionDatos.MtdConexion())
                        {
                            conn.Open();
                            string QueryEliminar = @"DELETE Tbl_Facturas WHERE CodigoFactura = @CodigoFactura;";

                            using (SqlCommand cmd = new SqlCommand(QueryEliminar, conn))
                            {
                                cmd.Parameters.AddWithValue("@CodigoFactura", ControlFacturas);

                                return cmd.ExecuteNonQuery() > 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al eliminar al eliminar el Doctor de la base de datos", ex);
                    }
                }


                public DataTable MtdBuscar(string Codigofactura)
                {
                    try
                    {
                        using (SqlConnection conn = conexionDatos.MtdConexion())
                        {
                            conn.Open();

                            string query = @"SELECT * 
                                         FROM Tbl_Facturas 
                                         WHERE CodigoFactura LIKE @CodigoFactura;";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@CodigoFactura", Codigofactura);

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
                public List<FacturasEntidad> MtdConsultarFacturas()
                {
                    List<FacturasEntidad> ListaFacturas = new List<FacturasEntidad>();
                    try
                    {
                        using (SqlConnection conn = conexionDatos.MtdConexion())
                        {
                            conn.Open();
                            string QueryListar = "SELECT * FROM Tbl_Facturas ORDER BY CodigoFactura ASC;";
                            using (SqlCommand cmd = new SqlCommand(QueryListar, conn))
                            {
                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {
                                    while (dr.Read())
                                    {
                                    ListaFacturas.Add(new FacturasEntidad()
                                        {
                                            CodigoFactura = Convert.ToInt32(dr["CodigoFactura"]),
                                            CodigoAtencion = Convert.ToInt32(dr["CodigoAtencion"]),
                                            CodigoSeguro = Convert.ToInt32(dr["CodigoSeguro"]),
                                            FechaFactura = Convert.ToDateTime(dr["FechaFactura"]),
                                            SubTotal = Convert.ToDecimal(dr["SubTotal"]),
                                            DescuentoSeguro = Convert.ToDecimal(dr["DescuentoSeguro"]),
                                            Impuesto = Convert.ToDecimal(dr["Impuesto"]),
                                            TotalPagar = Convert.ToDecimal(dr["TotalPagar"]),
                                            Estado = Convert.ToBoolean(dr["Estado"]),
                                            UsuarioSistema = Convert.ToString(dr["UsuarioSistema"]),
                                            FechaSistema = Convert.ToDateTime(dr["FechaSistema"]),
                                            HoraSistema = (TimeSpan)dr["HoraSistema"]
                                    });
                                    }
                                }

                            }
                            return ListaFacturas;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al mostrar la lista" + ex.Message);

                    }
                }

            }
}


