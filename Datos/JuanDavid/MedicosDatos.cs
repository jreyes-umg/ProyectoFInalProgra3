using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.JuanDavid
{
    public class MedicosDatos
    {

        ConexionDatos conexionDatos = new ConexionDatos();

        //Agregar
        /*  ----- AGREGAR ----- */
        public bool MtdAgregar(MeedicosEntidad ControlMedicos)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryAgregar = @"INSERT INTO Tbl_Medicos
                                            (
	                                            Nombre,
	                                            Apellido,
	                                            Especialidad,
	                                            Telefono,
	                                            Correo,
	                                            HonorarioBase,
	                                            AniosExperiencia,
	                                            BonoExperiencia,
	                                            Estado,
                                                UsuarioSistema,
                                                FechaSistema,
                                                HoraSistema
    
                                            )   
                                            VALUES
                                            (
	                                            @Nombre,
	                                            @Apellido,
	                                            @Especialidad,
	                                            @Telefono,
	                                            @Correo,
	                                            @HonorarioBase,
	                                            @AniosExperiencia,
	                                            @BonoExperiencia,
	                                            @Estado,
                                                @UsuarioSistema,
                                                @FechaSistema,
                                                @HoraSistema
                                            );";

                    using (SqlCommand cmd = new SqlCommand(QueryAgregar, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", ControlMedicos.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", ControlMedicos.Apellido);
                        cmd.Parameters.AddWithValue("@Especialidad", ControlMedicos.Especialidad);
                        cmd.Parameters.AddWithValue("@Telefono", ControlMedicos.Telefono);
                        cmd.Parameters.AddWithValue("@Correo", ControlMedicos.Correo);
                        cmd.Parameters.AddWithValue("@HonorarioBase", ControlMedicos.HonorarioBase);
                        cmd.Parameters.AddWithValue("@AniosExperiencia", ControlMedicos.AniosExperiencia);
                        cmd.Parameters.AddWithValue("@BonoExperiencia", ControlMedicos.BonoExperiencia);
                        cmd.Parameters.AddWithValue("@Estado", ControlMedicos.Estado);
                        cmd.Parameters.AddWithValue("@UsuarioSistema", ControlMedicos.UsuarioSistema);
                        cmd.Parameters.AddWithValue("@FechaSistema", ControlMedicos.FechaSistema);
                        cmd.Parameters.AddWithValue("@HoraSistema", ControlMedicos.HoraSistema);


                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Agregar el Doctor en la base de datos (datos) ", ex);
            }
        }
        /*  ----- EDITAR ----- */
        public bool MtdEditar(MeedicosEntidad ControlMedicos)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryEditar = @"UPDATE Tbl_Medicos 
                                        SET Nombre = @Nombre,
                                        Apellido = @Apellido,
                                        Especialidad = @Especialidad,
                                        Telefono = @Telefono,
                                        Correo = @Correo,
                                        HonorarioBase = @HonorarioBase,
                                        AniosExperiencia = @AniosExperiencia,
                                        BonoExperiencia = @BonoExperiencia,
                                        Estado = @Estado,
                                        UsuarioSistema = @UsuarioSistema,
                                        FechaSistema = @FechaSistema,
                                        HoraSistema = @HoraSistema
                                        WHERE CodigoMedico = @CodigoMedico;";

                    using (SqlCommand cmd = new SqlCommand(QueryEditar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoMedico", ControlMedicos.CodigoMedico);
                        cmd.Parameters.AddWithValue("@Nombre", ControlMedicos.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", ControlMedicos.Apellido);
                        cmd.Parameters.AddWithValue("@Especialidad", ControlMedicos.Especialidad);
                        cmd.Parameters.AddWithValue("@Telefono", ControlMedicos.Telefono);
                        cmd.Parameters.AddWithValue("@Correo", ControlMedicos.Correo);
                        cmd.Parameters.AddWithValue("@HonorarioBase", ControlMedicos.HonorarioBase);
                        cmd.Parameters.AddWithValue("@AniosExperiencia", ControlMedicos.AniosExperiencia);
                        cmd.Parameters.AddWithValue("@BonoExperiencia", ControlMedicos.BonoExperiencia);
                        cmd.Parameters.AddWithValue("@Estado", ControlMedicos.Estado);
                        cmd.Parameters.AddWithValue("@UsuarioSistema", ControlMedicos.UsuarioSistema);
                        cmd.Parameters.AddWithValue("@FechaSistema", ControlMedicos.FechaSistema);
                        cmd.Parameters.AddWithValue("@HoraSistema", ControlMedicos.HoraSistema);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Editar el Doctor en la base de datos", ex);
            }
        }

        public bool MtdEliminar(int CodigoMedico)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryEliminar = @"DELETE Tbl_Medicos WHERE CodigoMedico = @CodigoMedico;";

                    using (SqlCommand cmd = new SqlCommand(QueryEliminar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoMedico", CodigoMedico);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar al eliminar el Doctor de la base de datos", ex);
            }
        }


        public DataTable MtdBuscar(string Nombre)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();

                    string query = @"SELECT * 
                                         FROM Tbl_Medicos 
                                         WHERE Nombre LIKE @Nombre;";

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
                throw new Exception("Error al buscar el Doctor: " + exSql.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al buscar el Doctor: " + ex.Message);
            }
        }
        public List<MeedicosEntidad> MtdConsultar()
        {
            List<MeedicosEntidad> ListaMedicos = new List<MeedicosEntidad>();
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryListar = "SELECT * FROM Tbl_Medicos ORDER BY CodigoMedico ASC;";
                    using (SqlCommand cmd = new SqlCommand(QueryListar, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ListaMedicos.Add(new MeedicosEntidad()
                                {
                                    CodigoMedico = Convert.ToInt32(dr["CodigoMedico"]),
                                    Nombre = Convert.ToString(dr["Nombre"]),
                                    Apellido = Convert.ToString(dr["Apellido"]),
                                    Especialidad = Convert.ToString(dr["Especialidad"]),
                                    Telefono = Convert.ToString(dr["Telefono"]),
                                    Correo = Convert.ToString(dr["Correo"]),
                                    HonorarioBase = Convert.ToDecimal(dr["HonorarioBase"]),
                                    AniosExperiencia = Convert.ToInt32(dr["AniosExperiencia"]),
                                    BonoExperiencia = Convert.ToDecimal(dr["BonoExperiencia"]),
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    UsuarioSistema = Convert.ToString(dr["UsuarioSistema"]),
                                    FechaSistema = Convert.ToDateTime(dr["FechaSistema"]),
                                    HoraSistema = (TimeSpan)dr["HoraSistema"]
                                });
                            }
                        }

                    }
                    return ListaMedicos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar la lista DATOS" + ex.Message);

            }


        }
    }

}

    
