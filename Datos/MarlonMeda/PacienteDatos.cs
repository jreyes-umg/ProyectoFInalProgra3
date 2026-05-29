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
    public class PacienteDatos
    {
        // Instancia
        ConexionDatos conexionDatos = new ConexionDatos();

        /* ----- CONSULTAR ----- */
        public List<PacientesEntidad> MtdConsultar()
        {
            List<PacientesEntidad> ControlPacientes = new List<PacientesEntidad>();
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryListar = "SELECT * FROM Tbl_Pacientes ORDER BY CodigoPaciente ASC;";
                    using (SqlCommand cmd = new SqlCommand(QueryListar, conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ControlPacientes.Add(new PacientesEntidad()
                                {
                                    CodigoPaciente = Convert.ToInt32(dr["CodigoPaciente"]),
                                    Nombre = Convert.ToString(dr["Nombre"]),
                                    Apellido = Convert.ToString(dr["Apellido"]),
                                    Dpi = Convert.ToInt64(dr["Dpi"]), // BIGINT se mapea a Int64 (long)
                                    FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                                    Genero = Convert.ToString(dr["Genero"]),
                                    Telefono = Convert.ToString(dr["Telefono"]),
                                    Direccion = Convert.ToString(dr["Direccion"]),
                                    Edad = Convert.ToInt32(dr["Edad"]),
                                    Estado = Convert.ToBoolean(dr["Estado"]),
                                    UsuarioSistema = Convert.ToString(dr["UsuarioSistema"]),
                                    FechaSistema = Convert.ToDateTime(dr["FechaSistema"]),
                                    HoraSistema = (TimeSpan)dr["HoraSistema"]
                                });
                            }
                        }
                    }
                    return ControlPacientes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al mostrar la lista de Pacientes: " + ex.Message);
            }
        }

        /* ----- AGREGAR ----- */
        public bool MtdAgregar(PacientesEntidad ControlPacientes)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryAgregar = @"INSERT INTO Tbl_Pacientes
                                     (
                                         Nombre,
                                         Apellido,
                                         Dpi,
                                         FechaNacimiento,
                                         Genero,
                                         Telefono,
                                         Direccion,
                                         Edad,
                                         Estado,
                                         UsuarioSistema,
                                         FechaSistema,
                                         HoraSistema
                                     )   
                                     VALUES
                                     (
                                         @Nombre,
                                         @Apellido,
                                         @Dpi,
                                         @FechaNacimiento,
                                         @Genero,
                                         @Telefono,
                                         @Direccion,
                                         @Edad,
                                         @Estado,
                                         @UsuarioSistema,
                                         @FechaSistema,
                                         @HoraSistema
                                     );";

                    using (SqlCommand cmd = new SqlCommand(QueryAgregar, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", ControlPacientes.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", ControlPacientes.Apellido);
                        cmd.Parameters.AddWithValue("@Dpi", ControlPacientes.Dpi);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", ControlPacientes.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Genero", ControlPacientes.Genero);
                        cmd.Parameters.AddWithValue("@Telefono", ControlPacientes.Telefono);
                        cmd.Parameters.AddWithValue("@Direccion", ControlPacientes.Direccion);
                        cmd.Parameters.AddWithValue("@Edad", ControlPacientes.Edad);
                        cmd.Parameters.AddWithValue("@Estado", ControlPacientes.Estado);
                        cmd.Parameters.AddWithValue("@UsuarioSistema", ControlPacientes.UsuarioSistema);
                        cmd.Parameters.AddWithValue("@FechaSistema", ControlPacientes.FechaSistema);
                        cmd.Parameters.AddWithValue("@HoraSistema", ControlPacientes.HoraSistema);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Agregar el Paciente en la base de datos: ", ex);
            }
        }

        /* ----- EDITAR ----- */
        public bool MtdEditar(PacientesEntidad ControlPacientes)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryEditar = @"UPDATE Tbl_Pacientes 
                                     SET
                                     Nombre = @Nombre,
                                     Apellido = @Apellido,
                                     Dpi = @Dpi,
                                     FechaNacimiento = @FechaNacimiento,
                                     Genero = @Genero,
                                     Telefono = @Telefono,
                                     Direccion = @Direccion,
                                     Edad = @Edad,
                                     Estado = @Estado,
                                     UsuarioSistema = @UsuarioSistema,
                                     FechaSistema = @FechaSistema,
                                     HoraSistema = @HoraSistema
                                     WHERE CodigoPaciente = @CodigoPaciente;";

                    using (SqlCommand cmd = new SqlCommand(QueryEditar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoPaciente", ControlPacientes.CodigoPaciente);
                        cmd.Parameters.AddWithValue("@Nombre", ControlPacientes.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", ControlPacientes.Apellido);
                        cmd.Parameters.AddWithValue("@Dpi", ControlPacientes.Dpi);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", ControlPacientes.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Genero", ControlPacientes.Genero);
                        cmd.Parameters.AddWithValue("@Telefono", ControlPacientes.Telefono);
                        cmd.Parameters.AddWithValue("@Direccion", ControlPacientes.Direccion);
                        cmd.Parameters.AddWithValue("@Edad", ControlPacientes.Edad);
                        cmd.Parameters.AddWithValue("@Estado", ControlPacientes.Estado);
                        cmd.Parameters.AddWithValue("@UsuarioSistema", ControlPacientes.UsuarioSistema);
                        cmd.Parameters.AddWithValue("@FechaSistema", ControlPacientes.FechaSistema);
                        cmd.Parameters.AddWithValue("@HoraSistema", ControlPacientes.HoraSistema);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Editar el Paciente en la base de datos", ex);
            }
        }

        /* ----- BUSCAR ----- */
        public DataTable MtdBuscar(int CodigoPaciente)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string query = @"SELECT * FROM Tbl_Pacientes WHERE CodigoPaciente = @CodigoPaciente;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@CodigoPaciente", CodigoPaciente);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el Paciente: " + ex.Message);
            }
        }

        /* ----- ELIMINAR ----- */
        public bool MtdEliminar(int CodigoPaciente)
        {
            try
            {
                using (SqlConnection conn = conexionDatos.MtdConexion())
                {
                    conn.Open();
                    string QueryEliminar = @"DELETE FROM Tbl_Pacientes WHERE CodigoPaciente = @CodigoPaciente;";

                    using (SqlCommand cmd = new SqlCommand(QueryEliminar, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodigoPaciente", CodigoPaciente);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Paciente de la base de datos", ex);
            }
        }
    }
}
