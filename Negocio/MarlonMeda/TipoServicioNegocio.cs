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
    public class TipoServiciosNegocio
    {
          TipoServicioDatos Datos = new TipoServicioDatos();

        /* ----- CONSULTAR ----- */
        public List<TipoServicioEntidad> MtdConsultar()
        {
            return Datos.MtdConsultar();
        }

        /* ----- AGREGAR ----- */
        public bool MtdAgregar(TipoServicioEntidad RegistroServicio)
        {
            if (RegistroServicio == null)
                throw new Exception("Error en modelo template Control Eventos");
            if (string.IsNullOrEmpty(RegistroServicio.NombreServicio))
                throw new Exception("El nombre del servicio es requerido");
            if (RegistroServicio.TarifaBase < 0)
                throw new Exception("La tarifa base no puede ser un valor negativo");
            if (string.IsNullOrEmpty(RegistroServicio.NivelComplejidad))
                throw new Exception("El nivel de complejidad es requerido");
            if (RegistroServicio.RecargoBase < 0)
                throw new Exception("El recargo base no puede ser negativo");

            return Datos.MtdAgregar(RegistroServicio);
        }

        /* ----- EDITAR ----- */
        public bool MtdEditar(TipoServicioEntidad RegistroServicio)
        {
            if (RegistroServicio == null)
                throw new Exception("Error en modelo template Control Eventos");
            if (RegistroServicio.CodigoTipoServicio <= 0)
                throw new Exception("El Código de Servicio es incorrecto para actualizar");
            if (string.IsNullOrEmpty(RegistroServicio.NombreServicio))
                throw new Exception("El nombre del servicio es requerido");
            if (RegistroServicio.TarifaBase < 0)
                throw new Exception("La tarifa base no puede ser un valor negativo");

            return Datos.MtdEditar(RegistroServicio);
        }

        /* ----- ELIMINAR ----- */
        public bool MtdEliminar(int codigoTipoServicio)
        {
            if (codigoTipoServicio <= 0)
                throw new Exception("Código de Servicio inválido");

            return Datos.MtdEliminar(codigoTipoServicio);
        }

        /* ---- BUSCAR ---- */
         public List<TipoServicioEntidad> MtdBuscar(int CodigoTipoServicio)
        {
            DataTable dt = Datos.MtdBuscar(CodigoTipoServicio);
            List<TipoServicioEntidad> lista = new List<TipoServicioEntidad>();

            foreach (DataRow row in dt.Rows)
            {
                TipoServicioEntidad RegistroServicio = new TipoServicioEntidad
                {
                    CodigoTipoServicio = Convert.ToInt32(row["CodigoTipoServicio"]),
                    NombreServicio = Convert.ToString(row["NombreServicio"]),
                    TarifaBase = Convert.ToDecimal(row["TarifaBase"]),
                    AplicaEmergencia = Convert.ToBoolean(row["AplicaEmergencia"]),
                    AplicaHospitalizacion = Convert.ToBoolean(row["AplicaHospitalizacion"]),
                    AplicaLaboratorio = Convert.ToBoolean(row["AplicaLaboratorio"]),
                    NivelComplejidad = Convert.ToString(row["NivelComplejidad"]),
                    RecargoBase = Convert.ToDecimal(row["RecargoBase"]),
                    Estado = Convert.ToBoolean(row["Estado"]),
                    UsuarioSistema = Convert.ToString(row["UsuarioSistema"]),
                    FechaSistema = Convert.ToDateTime(row["FechaSistema"]),
                    HoraSistema = (TimeSpan)row["HoraSistema"]
                };

                lista.Add(RegistroServicio);
            }
            return lista;
        }
    }
}

