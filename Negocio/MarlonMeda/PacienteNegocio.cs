using Datos.MarlonMeda;
using Entidad.MarlonMeda;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.MarlonMeda
{
    public class PacientesNegocio
    {
        PacienteDatos Datos = new PacienteDatos();

        /* ----- CONSULTAR ----- */
        public List<PacientesEntidad> MtdConsultar()
        {
            return Datos.MtdConsultar();
        }

        /* ----- AGREGAR ----- */
        public bool MtdAgregar(PacientesEntidad Registro)
        {
            if (Registro == null)
                throw new Exception("Error en el modelo del paciente");
            if (string.IsNullOrEmpty(Registro.Nombre))
                throw new Exception("El nombre del paciente es obligatorio");
            if (string.IsNullOrEmpty(Registro.Apellido))
                throw new Exception("El apellido del paciente es obligatorio");
            if (Registro.Dpi <= 0)
                throw new Exception("El número de DPI ingresado no es válido");
            if (Registro.Edad < 0)
                throw new Exception("La edad no puede ser un número negativo");

            return Datos.MtdAgregar(Registro);
        }

        /* ----- EDITAR ----- */
        public bool MtdEditar(PacientesEntidad Registro)
        {
            if (Registro == null)
                throw new Exception("Error en el modelo del paciente");
            if (Registro.CodigoPaciente <= 0)
                throw new Exception("El Código del Paciente es necesario para editar");
            if (string.IsNullOrEmpty(Registro.Nombre))
                throw new Exception("El nombre del paciente es obligatorio");
            if (string.IsNullOrEmpty(Registro.Apellido))
                throw new Exception("El apellido del paciente es obligatorio");
            if (Registro.Dpi <= 0)
                throw new Exception("El número de DPI ingresado no es válido");

            return Datos.MtdEditar(Registro);
        }

        /* ----- ELIMINAR ----- */
        public bool MtdEliminar(int codigoPaciente)
        {
            if (codigoPaciente <= 0)
                throw new Exception("Código de Paciente inválido");

            return Datos.MtdEliminar(codigoPaciente);
        }


        /* ---- BUSCAR ---- */
        public List<PacientesEntidad> MtdBuscar(int CodigoPaciente)
        {
               DataTable dt = Datos.MtdBuscar(CodigoPaciente);
            List<PacientesEntidad> lista = new List<PacientesEntidad>();

            foreach (DataRow row in dt.Rows)
            {
                PacientesEntidad Registro = new PacientesEntidad
                {
                    CodigoPaciente = Convert.ToInt32(row["CodigoPaciente"]),
                    Nombre = Convert.ToString(row["Nombre"]),
                    Apellido = Convert.ToString(row["Apellido"]),
                    Dpi = Convert.ToInt64(row["Dpi"]), // El DPI en la entidad se queda como long, no pasa nada
                    FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]),
                    Genero = Convert.ToString(row["Genero"]),
                    Telefono = Convert.ToString(row["Telefono"]),
                    Direccion = Convert.ToString(row["Direccion"]),
                    Edad = Convert.ToInt32(row["Edad"]),
                    Estado = Convert.ToBoolean(row["Estado"]),
                    UsuarioSistema = Convert.ToString(row["UsuarioSistema"]),
                    FechaSistema = Convert.ToDateTime(row["FechaSistema"]),
                    HoraSistema = (TimeSpan)row["HoraSistema"]
                };

                lista.Add(Registro);
            }
            return lista;
        }


        //metodos 
        public int mtdEdadPaciente(int Nacimiento)
        {
            int Actual = DateTime.Now.Year;
            int edad = Actual - Nacimiento;

            return edad;
        }
    }
}