using Datos.JuanDavid;
using Entidad;
using Entidad.JuanDavid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.JuanDavid
{
    public class SanatoriosNegocio
    {
        SanatoriosDatos Datos = new SanatoriosDatos();
        public List<EntidadSanatorios> MtdConsultar()
        {
            return Datos.MtdConsultar();
        }
        /*  ----- Agregar -----   */
        public bool MtdAgregar(EntidadSanatorios RegistroSanatorio)
        {
            if (RegistroSanatorio == null)
                throw new Exception("Error en modelo template Control Eventos");
            if (RegistroSanatorio.CapacidadHabitaciones < 0)
                throw new Exception("El valor de la capacidad de Habitaciones base es incorrecto");
            if (RegistroSanatorio.CostoOperacionDiario < 0)
                throw new Exception("El valor del costo Diario base es incorrecto");
            if (string.IsNullOrEmpty(RegistroSanatorio.Nombre))
                throw new Exception("El Nombre es incorrecto");
            if (string.IsNullOrEmpty(RegistroSanatorio.Ubicacion))
                throw new Exception("La Ubicacion es incorrecto");
            if (string.IsNullOrEmpty(RegistroSanatorio.Telefono))
                throw new Exception("El Telefono es incorrecto");
            if (string.IsNullOrEmpty(RegistroSanatorio.Director))
                throw new Exception("El Nombre del Director es incorrecto");
            if (string.IsNullOrEmpty(RegistroSanatorio.TipoSanatorio))
                throw new Exception("EEl Tipo de Servicio es incorrecto");
            if (string.IsNullOrEmpty(RegistroSanatorio.NivelServicio))
                throw new Exception("El Nivel de Servicio es incorrecto");
            return Datos.MtdAgregar(RegistroSanatorio);
        }
        /*  ----- EDITAR -----   */
        public bool MtdEditar(EntidadSanatorios RegistroSanatorio)
        {
            if (RegistroSanatorio == null)
                throw new Exception("Error en modelo template Control Eventos");
            if (RegistroSanatorio.CodigoSanatorio < 0)
                throw new Exception("El Codigo de Sanatorio es incorrecto");
            if (RegistroSanatorio.CapacidadHabitaciones < 0)
                throw new Exception("El valor de la capacidad de Habitaciones base es incorrecto");
            if (RegistroSanatorio.CostoOperacionDiario < 0)
                throw new Exception("El valor del costo Diario base es incorrecto");
            if (string.IsNullOrEmpty(RegistroSanatorio.Nombre))
                throw new Exception("El Nombre es incorrecto");
            if (string.IsNullOrEmpty(RegistroSanatorio.Ubicacion))
                throw new Exception("La Ubicacion es incorrecto");
            if (string.IsNullOrEmpty(RegistroSanatorio.Telefono))
                throw new Exception("El Telefono es incorrecto");
            if (string.IsNullOrEmpty(RegistroSanatorio.Director))
                throw new Exception("El Nombre del Director es incorrecto");
            if (string.IsNullOrEmpty(RegistroSanatorio.TipoSanatorio))
                throw new Exception("EEl Tipo de Servicio es incorrecto");
            if (string.IsNullOrEmpty(RegistroSanatorio.NivelServicio))
                throw new Exception("El Nivel de Servicio es incorrecto");
            return Datos.MtdEditar(RegistroSanatorio);
        }
        /*  ----- ELIMINAR ----- */

        public bool MtdEliminar(int CodigoSanatorio)
        {
            if (CodigoSanatorio <= 0)
                throw new Exception("Codigo del sanatorio inválido");

            return Datos.MtdEliminar(CodigoSanatorio);
        }

        /* ---- BUSCAR ---- */

        public List<EntidadSanatorios> MtdBuscar(string NombreSanatorios)
        {
            DataTable dt = Datos.MtdBuscar(NombreSanatorios);

            List<EntidadSanatorios> lista = new List<EntidadSanatorios>();

            foreach (DataRow row in dt.Rows)
            {
                EntidadSanatorios RegistroSanatorio = new EntidadSanatorios
                {
                    CodigoSanatorio = Convert.ToInt32(row["CodigoSanatorio"]),
                    Nombre = Convert.ToString(row["Nombre"]),
                    Ubicacion = Convert.ToString(row["Ubicacion"]),
                    TipoSanatorio = Convert.ToString(row["TipoSanatorio"]),
                    Telefono = Convert.ToString(row["Telefono"]),
                    Director = Convert.ToString(row["Director"]),
                    CostoOperacionDiario = Convert.ToDecimal(row["CostoOperacionDiario"]),
                    CapacidadHabitaciones = Convert.ToInt32(row["CapacidadHabitaciones"]),
                    NivelServicio = Convert.ToString(row["NivelServicio"]),
                    Estado = Convert.ToBoolean(row["Estado"]),
                    UsuarioSistema = Convert.ToString(row["UsuarioSistema"]),
                    FechaSistema = Convert.ToDateTime(row["FechaSistema"]),
                    HoraSistema = (TimeSpan)row["HoraSistema"]
                };

                lista.Add(RegistroSanatorio);
            }
            return lista;
        }

    }
}
