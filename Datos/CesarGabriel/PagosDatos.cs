using Entidad;
using Entidad.Pagos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Pagos
{
        public class PagoDatos
        {
            ConexionDatos conexionDatos = new ConexionDatos();


            /*  ----- AGREGAR ----- */
            public bool MtdAgregar(PagosEntidad ControlPagos)
            {
                try
                {
                    using (SqlConnection conn = conexionDatos.MtdConexion())
                    {
                        conn.Open();
                        string QueryAgregar = @"INSERT INTO Tbl_Pagos
                                            (
	                                            CodigoFactura,
	                                            FechaPago,
	                                            MontoFactura,
	                                            MontoPagado,
	                                            MetodoPago,
	                                            Mora,
	                                            Cambio,
	                                            TotalCancelado,
	                                            Estado,
                                                UsuarioSistema,
                                                FechaSistema,
                                                HoraSistema
    
                                            )   
                                            VALUES
                                            (
	                                            @CodigoFactura,
	                                            @FechaPago,
	                                            @MontoFactura,
	                                            @MontoPagado,
	                                            @MetodoPago,
	                                            @Mora,
	                                            @Cambio,
	                                            @TotalCancelado,
	                                            @Estado,
                                                @UsuarioSistema,
                                                @FechaSistema,
                                                @HoraSistema
                                            );";

                        using (SqlCommand cmd = new SqlCommand(QueryAgregar, conn))
                        {
                            cmd.Parameters.AddWithValue("@CodigoFactura", ControlPagos.CodigoFactura);
                            cmd.Parameters.AddWithValue("@FechaPago", ControlPagos.FechaPago);
                            cmd.Parameters.AddWithValue("@MontoFactura", ControlPagos.MontoFactura);
                            cmd.Parameters.AddWithValue("@MontoPagado", ControlPagos.MontoPagado);
                            cmd.Parameters.AddWithValue("@MetodoPago", ControlPagos.MetodoPago);
                            cmd.Parameters.AddWithValue("@Mora", ControlPagos.Mora);
                            cmd.Parameters.AddWithValue("@Cambio", ControlPagos.Cambio);
                            cmd.Parameters.AddWithValue("@TotalCancelado", ControlPagos.TotalCancelado);
                            cmd.Parameters.AddWithValue("@Estado", ControlPagos.Estado);
                            cmd.Parameters.AddWithValue("@UsuarioSistema", ControlPagos.UsuarioSistema);
                            cmd.Parameters.AddWithValue("@FechaSistema", ControlPagos.FechaSistema);
                            cmd.Parameters.AddWithValue("@HoraSistema", ControlPagos.HoraSistema);


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
            public bool MtdEditar(PagosEntidad ControlPagos)
            {
                try
                {
                    using (SqlConnection conn = conexionDatos.MtdConexion())
                    {
                        conn.Open();
                        string QueryEditar = @"UPDATE Tbl_Pagos 
                                        SET CodigoFactura = @CodigoFactura,
                                        FechaPago = @FechaPago,
                                        MontoFactura = @MontoFactura,
                                        MontoPagado = @MontoPagado,
                                        MetodoPago = @MetodoPago,
                                        Mora = @Mora,
                                        Cambio = @Cambio,
                                        TotalCancelado = @TotalCancelado,
                                        Estado = @Estado,
                                        UsuarioSistema = @UsuarioSistema,
                                        FechaSistema = @FechaSistema,
                                        HoraSistema = @HoraSistema
                                        WHERE CodigoPago = @CodigoPago;";

                        using (SqlCommand cmd = new SqlCommand(QueryEditar, conn))
                        {
                            cmd.Parameters.AddWithValue("@CodigoFactura", ControlPagos.CodigoFactura);
                            cmd.Parameters.AddWithValue("@FechaPago", ControlPagos.FechaPago);
                            cmd.Parameters.AddWithValue("@MontoFactura", ControlPagos.MontoFactura);
                            cmd.Parameters.AddWithValue("@MontoPagado", ControlPagos.MontoPagado);
                            cmd.Parameters.AddWithValue("@MetodoPago", ControlPagos.MetodoPago);
                            cmd.Parameters.AddWithValue("@Mora", ControlPagos.Mora);
                            cmd.Parameters.AddWithValue("@Cambio", ControlPagos.Cambio);
                            cmd.Parameters.AddWithValue("@TotalCancelado", ControlPagos.TotalCancelado);
                            cmd.Parameters.AddWithValue("@Estado", ControlPagos.Estado);
                            cmd.Parameters.AddWithValue("@UsuarioSistema", ControlPagos.UsuarioSistema);
                            cmd.Parameters.AddWithValue("@FechaSistema", ControlPagos.FechaSistema);
                            cmd.Parameters.AddWithValue("@HoraSistema", ControlPagos.HoraSistema);
                            return cmd.ExecuteNonQuery() > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al Editar el Doctor en la base de datos", ex);
                }
            }

            public bool MtdEliminar(int Codigofactura)
            {
                try
                {
                    using (SqlConnection conn = conexionDatos.MtdConexion())
                    {
                        conn.Open();
                        string QueryEliminar = @"DELETE Tbl_Pagos WHERE CodigoFactura = @CodigoFactura;";

                        using (SqlCommand cmd = new SqlCommand(QueryEliminar, conn))
                        {
                            cmd.Parameters.AddWithValue("@CodigoFactura", Codigofactura);

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
                                         FROM Tbl_Pagos 
                                         WHERE CodigoPago LIKE @CodigoPago;";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@CodigoPago", Codigofactura);

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            return dt;
                        }
                    }
                }
                catch (SqlException exSql)
                {
                    throw new Exception("Error al buscar el Codigo de pago: " + exSql.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error general al buscar el Codigo de pago: " + ex.Message);
                }
            }
            public List<PagosEntidad> MtdConsultarPagos()
            {
                List<PagosEntidad> ListaPagos = new List<PagosEntidad>();
                try
                {
                    using (SqlConnection conn = conexionDatos.MtdConexion())
                    {
                        conn.Open();
                        string QueryListar = "SELECT * FROM Tbl_Pagos ORDER BY CodigoPago ASC;";
                        using (SqlCommand cmd = new SqlCommand(QueryListar, conn))
                        {
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    ListaPagos.Add(new PagosEntidad()
                                    {
                                        CodigoPago = Convert.ToInt32(dr["CodigoPago"]),
                                        CodigoFactura = Convert.ToInt32(dr["CodigoFactura"]),
                                        FechaPago = Convert.ToDateTime(dr["FechaPago"]),
                                        MontoFactura = Convert.ToDecimal(dr["MontoFactura"]),
                                        MontoPagado = Convert.ToDecimal(dr["MontoPagado"]),
                                        MetodoPago = Convert.ToString(dr["MetodoPago"]),
                                        Mora = Convert.ToDecimal(dr["Mora"]),
                                        Cambio = Convert.ToDecimal(dr["Cambio"]),
                                        TotalCancelado = Convert.ToDecimal(dr["TotalCancelado"]),
                                        Estado = Convert.ToBoolean(dr["Estado"]),
                                        UsuarioSistema = Convert.ToString(dr["UsuarioSistema"]),
                                        FechaSistema = Convert.ToDateTime(dr["FechaSistema"]),
                                        HoraSistema = (TimeSpan)dr["HoraSistema"]
                                    });
                                }
                            }

                        }
                        return ListaPagos;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al mostrar la lista codigo pagos" + ex.Message);

                }
            }

        }
}



