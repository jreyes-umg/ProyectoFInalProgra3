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
    public class AntencionNegocio
    {
        decimal ProcentajeRecargoUrgencia = 0.25m;
        AtencionesDatos Datos = new AtencionesDatos();
        public List<AntencionPacientesEntidad> MtdConsultar()
        {
            return Datos.MtdConsultar();
        }
        /*  ----- Agregar -----   */
        public bool MtdAgregar(AntencionPacientesEntidad Registroatencion)
        {
            if (Registroatencion == null)
                throw new Exception("Error en modelo template Control Eventos");
            if (Registroatencion.CodigoPaciente == 0)
                throw new Exception("El valor del codigo de paciente es incorrecto");
            if (Registroatencion.CodigoMedico == 0)
                throw new Exception("El valor del codigo de Medico es incorrecto");
            if (Registroatencion.CodigoTipoServicio == 0)
                throw new Exception("El valor del codigo del Tipo de servicio es incorrecto");
            if (Registroatencion.CodigoSanatorio == 0)
                throw new Exception("El valor del codigo de Sanatorio base es incorrecto");
            if (Registroatencion.FechaAtencion < DateTime.Today)
                throw new Exception("La fecha debe ser mayor o igual que Hoy");
            if (Registroatencion.CostoBase == 0)
                throw new Exception("El valor del  Costo base es incorrecto");
            if (Registroatencion.TotalAtencion == 0)
                throw new Exception("El valor del Total de Atencion es incorrecto");
            return Datos.MtdAgregar(Registroatencion);
        }
        /*  ----- EDITAR -----   */
        public bool MtdEditar(AntencionPacientesEntidad Registroatencion)
        {
            if (Registroatencion == null)
                throw new Exception("Error en modelo template Control Eventos");
            if (Registroatencion.CodigoPaciente == 0)
                throw new Exception("El valor del codigo de paciente es incorrecto");
            if (Registroatencion.CodigoMedico == 0)
                throw new Exception("El valor del codigo de Medico es incorrecto");
            if (Registroatencion.CodigoTipoServicio == 0)
                throw new Exception("El valor del codigo del Tipo de servicio es incorrecto");
            if (Registroatencion.CodigoSanatorio == 0)
                throw new Exception("El valor del codigo de Sanatorio base es incorrecto");
            if (Registroatencion.FechaAtencion < DateTime.Today)
                throw new Exception("La fecha debe ser mayor o igual que Hoy");
            if (Registroatencion.CostoBase == 0)
                throw new Exception("El valor del  Costo base es incorrecto");
            if (Registroatencion.TotalAtencion == 0)
                throw new Exception("El valor del Total de Atencion es incorrecto");
            return Datos.MtdEditar(Registroatencion);
        }
        /*  ----- ELIMINAR ----- */

        public bool MtdEliminar(int CodigoAtencion)
        {
            if (CodigoAtencion <= 0)
                throw new Exception("Codigo del Atencion inválido");

            return Datos.MtdEliminar(CodigoAtencion);
        }

        /* ---- BUSCAR ---- */

        public List<AntencionPacientesEntidad> MtdBuscar(string NombrePaciente)
        {


            DataTable dt = Datos.MtdBuscar(NombrePaciente);

            List<AntencionPacientesEntidad> lista = new List<AntencionPacientesEntidad>();

            foreach (DataRow row in dt.Rows)
            {
                AntencionPacientesEntidad RegistroDoctor = new AntencionPacientesEntidad
                {
                    CodigoAtencion = Convert.ToInt32(row["CodigoAtencion"]),
                    CodigoPaciente = Convert.ToInt32(row["CodigoPaciente"]),
                    CodigoMedico = Convert.ToInt32(row["CodigoMedico"]),
                    CodigoTipoServicio = Convert.ToInt32(row["CodigoTipoServicio"]),
                    CodigoSanatorio = Convert.ToInt32(row["CodigoSanatorio"]),
                    FechaAtencion = Convert.ToDateTime(row["FechaAtencion"]),
                    CostoBase = Convert.ToDecimal(row["CostoBase"]),
                    RecargoEmergencia = Convert.ToDecimal(row["RecargoEmergencia"]),
                    TotalAtencion = Convert.ToDecimal(row["TotalAtencion"]),
                    Estado = Convert.ToBoolean(row["Estado"]),
                    UsuarioSistema = Convert.ToString(row["UsuarioSistema"]),
                    FechaSistema = Convert.ToDateTime(row["FechaSistema"]),
                    HoraSistema = (TimeSpan)row["HoraSistema"]
                };

                lista.Add(RegistroDoctor);
            }
            return lista;
        }
        /* ---------- METODOS DE LOS COMBOBOX ---------- */

        // Crear Metodo Envia clientes de la Base de Datos a Capa Presentación

        public List<dynamic> MtdListaPacientes()
        {
            return Datos.MtdListarPacientes();
        }
        public List<dynamic> MtdListaMedicos()
        {
            return Datos.MtdListarDoctores();
        }
        public List<dynamic> MtdListaTiposdeServicios()
        {
            return Datos.MtdListarTiposdeServicio();
        }
        public List<dynamic> MtdListaSanatorios()
        {
            return Datos.MtdListarSanatorios();
        }
        public decimal MtdCostoBase(int codigoTipoPaquete)
        {
            return Datos.MtdCostoTipoServicos(codigoTipoPaquete);
        }
        public decimal MtdRecargoemergencia(decimal cosotbase)
        {
            return cosotbase * ProcentajeRecargoUrgencia;
        }
        public decimal MtdTotal(decimal cosotbase, decimal RecargoEmergencia)
        {
            return cosotbase + RecargoEmergencia;
        }
    }
}
