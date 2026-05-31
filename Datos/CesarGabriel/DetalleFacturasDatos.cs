using Entidad;
using Entidad.Detalles;
using Entidad.Factura;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DetalleFacturas
{
             public class DetalleFacturaDatos
            {
                ConexionDatos conexionDatos = new ConexionDatos();


                /*  ----- AGREGAR ----- */
                public bool MtdAgregar(DetallesFacturasEntidad ControlDetallesFacturas)
                {
                    try
                    {
                        using (SqlConnection conn = conexionDatos.MtdConexion())
                        {
                            conn.Open();
                            string QueryAgregar = @"INSERT INTO Tbl_DetalleFacturas
                                            (
	                                            CodigoDetalle,
	                                            CodigoFactura,
	                                            TipoConcepto,
	                                            CodigoReferencia,
	                                            DescripcionReferencia,
	                                            Cantidad,
	                                            PrecioUnitario,
	                                            SubTotal,
                                                Impuesto,
                                                TotalDetalle,
	                                            Estado,
                                                UsuarioSistema,
                                                FechaSistema,
                                                HoraSistema
    
                                            )   
                                            VALUES
                                            (
	                                            @CodigoDetalle,
	                                            @CodigoFactura,
	                                            @TipoConcepto,
	                                            @CodigoReferencia,
	                                            @DescripcionReferencia,
	                                            @Cantidad,
	                                            @PrecioUnitario,
	                                            @SubTotal,
                                                @Impuesto,
                                                @TotalDetalle,
	                                            @Estado,
                                                @UsuarioSistema,
                                                @FechaSistema,
                                                @HoraSistema
                                            );";

                            using (SqlCommand cmd = new SqlCommand(QueryAgregar, conn))
                            {
                                cmd.Parameters.AddWithValue("@CodigoDetalle", ControlDetallesFacturas.CodigoDetalle);
                                cmd.Parameters.AddWithValue("@CodigoFactura", ControlDetallesFacturas.CodigoFactura);
                                cmd.Parameters.AddWithValue("@TipoConcepto", ControlDetallesFacturas.TipoConcepto);
                                cmd.Parameters.AddWithValue("@CodigoReferencia", ControlDetallesFacturas.CodigoReferencia);
                                cmd.Parameters.AddWithValue("@DescripcionReferencia", ControlDetallesFacturas.DescripcionReferencia);
                                cmd.Parameters.AddWithValue("@Cantidad", ControlDetallesFacturas.Cantidad);
                                cmd.Parameters.AddWithValue("@PrecioUnitario", ControlDetallesFacturas.PrecioUnitario);
                                cmd.Parameters.AddWithValue("@SubTotal", ControlDetallesFacturas.SubTotal);
                                cmd.Parameters.AddWithValue("@Impuesto", ControlDetallesFacturas.Impuesto);
                                cmd.Parameters.AddWithValue("@TotalDetalle", ControlDetallesFacturas.TotalDetalle);
                                cmd.Parameters.AddWithValue("@Estado", ControlDetallesFacturas.Estado);
                                cmd.Parameters.AddWithValue("@UsuarioSistema", ControlDetallesFacturas.UsuarioSistema);
                                cmd.Parameters.AddWithValue("@FechaSistema", ControlDetallesFacturas.FechaSistema);
                                cmd.Parameters.AddWithValue("@HoraSistema", ControlDetallesFacturas.HoraSistema);


                                return cmd.ExecuteNonQuery() > 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al Agregar los Detalles de Facturas en la base de datos (datos) ", ex);
                    }
                }
                /*  ----- EDITAR ----- */
                public bool MtdEditar(DetallesFacturasEntidad ControlDetallesFacturas)
                {
                    try
                    {
                        using (SqlConnection conn = conexionDatos.MtdConexion())
                        {
                            conn.Open();
                            string QueryEditar = @"UPDATE Tbl_DetalleFacturas 
                                        SET CodigoDetalle = @CodigoDetalle,
                                        TipoConcepto = @TipoConcepto,
                                        CodigoReferencia = @CodigoReferencia,
                                        DescripcionReferencia = @DescripcionReferencia,
                                        Cantidad = @Cantidad,
                                        PrecioUnitario = @PrecioUnitario,
                                        SubTotal = @SubTotal,
                                        Impuesto= @Impuesto,
                                        TotalDetalle= @TotalDetalle,
                                        Estado = @Estado,
                                        UsuarioSistema = @UsuarioSistema,
                                        FechaSistema = @FechaSistema,
                                        HoraSistema = @HoraSistema
                                        WHERE CodigoDetalle = @CodigoDetalle;";

                            using (SqlCommand cmd = new SqlCommand(QueryEditar, conn))
                            {
                                cmd.Parameters.AddWithValue("@CodigoFactura", ControlDetallesFacturas.CodigoFactura);
                                cmd.Parameters.AddWithValue("@TipoConcepto", ControlDetallesFacturas.TipoConcepto);
                                cmd.Parameters.AddWithValue("@CodigoReferencia", ControlDetallesFacturas.CodigoReferencia);
                                cmd.Parameters.AddWithValue("@DescripcionReferencia", ControlDetallesFacturas.DescripcionReferencia);
                                cmd.Parameters.AddWithValue("@Cantidad", ControlDetallesFacturas.Cantidad);
                                cmd.Parameters.AddWithValue("@PrecioUnitario", ControlDetallesFacturas.PrecioUnitario);
                                cmd.Parameters.AddWithValue("@SubTotal", ControlDetallesFacturas.SubTotal);
                                cmd.Parameters.AddWithValue("@Impuesto", ControlDetallesFacturas.Impuesto);
                                cmd.Parameters.AddWithValue("@TotalDetalle", ControlDetallesFacturas.TotalDetalle);
                                cmd.Parameters.AddWithValue("@Estado", ControlDetallesFacturas.Estado);
                                cmd.Parameters.AddWithValue("@UsuarioSistema", ControlDetallesFacturas.UsuarioSistema);
                                cmd.Parameters.AddWithValue("@FechaSistema", ControlDetallesFacturas.FechaSistema);
                                cmd.Parameters.AddWithValue("@HoraSistema", ControlDetallesFacturas.HoraSistema);
                                return cmd.ExecuteNonQuery() > 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al Editar el Detalle de Factura en la base de datos", ex);
                    }
                }

                public bool MtdEliminar(int ControlFacturas)
                {
                    try
                    {
                        using (SqlConnection conn = conexionDatos.MtdConexion())
                        {
                            conn.Open();
                            string QueryEliminar = @"DELETE Tbl_DetalleFacturas WHERE CodigoDetalle = @CodigoDetalle;";

                            using (SqlCommand cmd = new SqlCommand(QueryEliminar, conn))
                            {
                                cmd.Parameters.AddWithValue("@CodigoDetalle", ControlFacturas);

                                return cmd.ExecuteNonQuery() > 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al eliminar al eliminar el Detalle de Factura de la base de datos", ex);
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
                                         FROM Tbl_DetalleFacturas 
                                         WHERE CodigoDetalle LIKE @CodigoDetalle;";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@CodigoDetalle", Codigofactura);

                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                return dt;
                            }
                        }
                    }
                    catch (SqlException exSql)
                    {
                        throw new Exception("Error al buscar el Detalle de Factura: " + exSql.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error general al buscar el Detalle de Factura: " + ex.Message);
                    }
                }
        public List<DetallesFacturasEntidad> MtdConsultarDetalles()
        {
            List<DetallesFacturasEntidad> ListaDetallesFacturas = new List<DetallesFacturasEntidad>();
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryListar = "SELECT * FROM Tbl_DetalleFacturas ORDER BY CodigoDetalle ASC;";
                    using (SqlCommand cmd = new SqlCommand(QueryListar, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ListaDetallesFacturas.Add(new DetallesFacturasEntidad()
                                {
                                    CodigoDetalle = Convert.ToInt32(dr["CodigoDetalle"]),
                                    CodigoFactura = Convert.ToInt32(dr["CodigoFactura"]),
                                    TipoConcepto = Convert.ToString(dr["TipoConcepto"]),
                                    CodigoReferencia = Convert.ToInt32(dr["CodigoReferencia"]),
                                    DescripcionReferencia = Convert.ToString(dr["DescripcionReferencia"]),
                                    Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                    PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]),
                                    SubTotal = Convert.ToDecimal(dr["SubTotal"]),
                                    Impuesto = Convert.ToDecimal(dr["Impuesto"]),
                                    TotalDetalle = Convert.ToDecimal(dr["TotalDetalle"]),
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    UsuarioSistema = Convert.ToString(dr["UsuarioSistema"]),
                                    FechaSistema = Convert.ToDateTime(dr["FechaSistema"]),
                                    HoraSistema = (TimeSpan)(dr["HoraSistema"])
                                });
                            }
                        }
                    }
                    return ListaDetallesFacturas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar la lista: " + ex.Message);
            }
        }
        public List<dynamic> MtdListarFacturas()
                             {
            List<dynamic> ListarDatos = new List<dynamic>();

            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryListaClientes = @"
												                    select  CodigoFactura, CodigoAtencion
													                    From Tbl_Facturas;
												                    "; // Cambiar query

                    using (SqlCommand cmd = new SqlCommand(QueryListaClientes, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {


                            while (dr.Read())
                            {
                                ListarDatos.Add(new
                                {
                                    Value = dr["CodigoFactura"], // Cambiar nombre de campo codigo segun query
                                    Text = $"Factura:{dr["CodigoFactura"]} - Atencion: {dr["CodigoAtencion"]}" // Cambiar codigo y nombre, segun query
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



