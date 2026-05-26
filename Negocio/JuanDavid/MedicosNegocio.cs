using Datos;
using Datos.JuanDavid;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.JuanDavid
{
    public class MedicosNegocio
    {
        decimal bonoporaño = 50;
        MedicosDatos Datos = new MedicosDatos(); 
        public List<MeedicosEntidad> MtdConsultar()
        {
            return Datos.MtdConsultar();
        }
        /*  ----- Agregar -----   */
        public bool MtdAgregar(MeedicosEntidad RegistroDoctor)
        {
            if (RegistroDoctor == null)
                throw new Exception("Error en modelo template Control Eventos");
            if (RegistroDoctor.HonorarioBase < 0)
                throw new Exception("El valor del honorario base es incorrecto");
            if (string.IsNullOrEmpty(RegistroDoctor.Nombre))
                throw new Exception("El Nombre es incorrecto");
            if (string.IsNullOrEmpty(RegistroDoctor.Apellido))
                throw new Exception("El Apellido es incorrecto");
            if (string.IsNullOrEmpty(RegistroDoctor.Especialidad))
                throw new Exception("La Especialidad es incorrecto");
            return Datos.MtdAgregar(RegistroDoctor);
        }
        /*  ----- EDITAR -----   */
        public bool MtdEditar(MeedicosEntidad RegistroDoctor)
        {
            if (RegistroDoctor == null)
                throw new Exception("Error en modelo template Control Eventos");
            if (RegistroDoctor.HonorarioBase < 0)
                throw new Exception("El valor del honorario base es incorrecto");
            if (string.IsNullOrEmpty(RegistroDoctor.Nombre))
                throw new Exception("El Nombre es incorrecto");
            if (string.IsNullOrEmpty(RegistroDoctor.Apellido))
                throw new Exception("El Apellido es incorrecto");
            if (string.IsNullOrEmpty(RegistroDoctor.Especialidad))
                throw new Exception("La Especialidad es incorrecto");
            return Datos.MtdEditar(RegistroDoctor);
        }
        /*  ----- ELIMINAR ----- */

        public bool MtdEliminar(int codigodoctor)
        {
            if (codigodoctor <= 0)
                throw new Exception("Codigo del DOCTOR inválido");

            return Datos.MtdEliminar(codigodoctor);
        }

        /* ---- BUSCAR ---- */

        public List<MeedicosEntidad> MtdBuscar(string NombreDoctor)
        {
            DataTable dt = Datos.MtdBuscar(NombreDoctor);

            List<MeedicosEntidad> lista = new List<MeedicosEntidad>();

            foreach (DataRow row in dt.Rows)
            {
                MeedicosEntidad RegistroDoctor = new MeedicosEntidad
                {
                    CodigoMedico = Convert.ToInt32(row["CodigoMedico"]),
                    Nombre = Convert.ToString(row["Nombre"]),
                    Apellido = Convert.ToString(row["Apellido"]),
                    Especialidad = Convert.ToString(row["Especialidad"]),
                    Telefono = Convert.ToString(row["Telefono"]),
                    Correo = Convert.ToString(row["Correo"]),
                    HonorarioBase = Convert.ToDecimal(row["HonorarioBase"]),
                    AniosExperiencia = Convert.ToInt32(row["AniosExperiencia"]),
                    BonoExperiencia = Convert.ToDecimal(row["BonoExperiencia"]),
                    Estado = Convert.ToBoolean(row["Estado"]),
                    UsuarioSistema = Convert.ToString(row["UsuarioSistema"]),
                    FechaSistema = Convert.ToDateTime(row["FechaSistema"]),
                    HoraSistema = (TimeSpan)row["HoraSistema"]
                };

                lista.Add(RegistroDoctor);
            }
            return lista;
        }

        public decimal BonoExperiencia(decimal añosexperiencia)
        {
            return añosexperiencia * bonoporaño;
        }





    }
}
