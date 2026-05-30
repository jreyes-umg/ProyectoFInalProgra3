using Entidad.Factura;
using Negocio.Facturas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sanatorios
{
    public partial class FacturasForms : Form
    {
        public FacturasForms()
        {
            InitializeComponent();
        }


        private void MtdCalcularValoresFactura()
        {
            try
            {

                if (cbxAtencion.SelectedIndex != -1 && cbxCodigoSeguro.SelectedIndex != -1 &&
                    cbxAtencion.SelectedValue != null && cbxCodigoSeguro.SelectedValue != null)
                {

                    int idAtencion = Convert.ToInt32(cbxAtencion.SelectedValue);
                    int idSeguro = Convert.ToInt32(cbxCodigoSeguro.SelectedValue);


                    decimal subTotalReal = 0m;             // Temporal ya que es de Tbl_DetalleFacturas
                    decimal porcentajeCoberturaReal = 0m;  // Temporal pro que es de Tbl_SegurosMedicos


                    nudSubTotal.Value = subTotalReal;


                    FacturasNegocio negocioFacturas = new FacturasNegocio();

                    decimal descuentoCalculado = negocioFacturas.CalcularDescuentoSeguro(subTotalReal, porcentajeCoberturaReal);
                    nudDescuentoSeguro.Value = descuentoCalculado;


                    decimal impuestoCalculado = negocioFacturas.CalcularImpuesto(subTotalReal, descuentoCalculado);
                    nudImpuesto.Value = impuestoCalculado;


                    decimal totalCalculado = negocioFacturas.CalcularTotalPagar(subTotalReal, descuentoCalculado, impuestoCalculado);
                    nudTotalPagar.Value = totalCalculado;
                }

            }
            catch (Exception)
            {

            }
        }

        //----- LIMPIAR ----//
        private void MtdLimpiarCampos()
        {
            
            txtCodigoFactura.Text = "";

            
            cbxAtencion.SelectedIndex = -1;
            cbxCodigoSeguro.SelectedIndex = -1;

           
            dtpFechaFactura.Value = DateTime.Now;
            nudSubTotal.Value = 0;
            nudDescuentoSeguro.Value = 0;
            nudImpuesto.Value = 0;
            nudTotalPagar.Value = 0;

           
            rdbActivo.Checked = true;
        }
        // ---- NUEVO---//
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
        }
        // ----- CANCELAR ------ //
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
        }

        // ----- GUARDAR -----//
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                FacturasEntidad nuevaFactura = new FacturasEntidad();

                nuevaFactura.CodigoAtencion = Convert.ToInt32(cbxAtencion.SelectedValue);
                nuevaFactura.CodigoSeguro = Convert.ToInt32(cbxCodigoSeguro.SelectedValue);
                nuevaFactura.FechaFactura = dtpFechaFactura.Value;
                nuevaFactura.SubTotal = nudSubTotal.Value;
                nuevaFactura.DescuentoSeguro = nudDescuentoSeguro.Value;
                nuevaFactura.Impuesto = nudImpuesto.Value;
                nuevaFactura.TotalPagar = nudTotalPagar.Value;
                nuevaFactura.Estado = rdbActivo.Checked;

               
                nuevaFactura.UsuarioSistema = "Admin"; //Prueba, aun faltan los tipos de usuario
                nuevaFactura.FechaSistema = DateTime.Now.Date;
                nuevaFactura.HoraSistema = DateTime.Now.TimeOfDay;

                FacturasNegocio negocioFacturas = new FacturasNegocio();
                if (negocioFacturas.MtdAgregar(nuevaFactura))
                {
                    MessageBox.Show("Factura guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdCargarDatosEnTabla(); 
                    MtdLimpiarCampos();      
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //---- ELIMINAR-----//
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodigoFactura.Text))
                {
                    MessageBox.Show("Por favor seleccione una factura para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar esta factura?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    int codigoEliminar = Convert.ToInt32(txtCodigoFactura.Text);
                    FacturasNegocio negocioFacturas = new FacturasNegocio();

                    if (negocioFacturas.MtdEliminar(codigoEliminar))
                    {
                        MessageBox.Show("Factura eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MtdCargarDatosEnTabla();
                        MtdLimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---- EDITAR ----//
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (string.IsNullOrEmpty(txtCodigoFactura.Text))
                {
                    MessageBox.Show("Por favor seleccione una factura de la tabla para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FacturasEntidad facturaEditada = new FacturasEntidad();

               
                facturaEditada.CodigoFactura = Convert.ToInt32(txtCodigoFactura.Text);

                facturaEditada.CodigoAtencion = Convert.ToInt32(cbxAtencion.SelectedValue);
                facturaEditada.CodigoSeguro = Convert.ToInt32(cbxCodigoSeguro.SelectedValue);
                facturaEditada.FechaFactura = dtpFechaFactura.Value;
                facturaEditada.SubTotal = nudSubTotal.Value;
                facturaEditada.DescuentoSeguro = nudDescuentoSeguro.Value;
                facturaEditada.Impuesto = nudImpuesto.Value;
                facturaEditada.TotalPagar = nudTotalPagar.Value;
                facturaEditada.Estado = rdbActivo.Checked;

                facturaEditada.UsuarioSistema = "Admin";
                facturaEditada.FechaSistema = DateTime.Now.Date;
                facturaEditada.HoraSistema = DateTime.Now.TimeOfDay;

                FacturasNegocio negocioFacturas = new FacturasNegocio();
                if (negocioFacturas.MtdEditar(facturaEditada))
                {
                    MessageBox.Show("Factura actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdCargarDatosEnTabla();
                    MtdLimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbxAtencion_SelectedIndexChanged(object sender, EventArgs e)
        {
            MtdCalcularValoresFactura();
        }

        private void cbxCodigoSeguro_SelectedIndexChanged(object sender, EventArgs e)
        {
            MtdCalcularValoresFactura();
        }

        private void FacturasForms_Load(object sender, EventArgs e)
        {
            
            MtdCargarDatosEnTabla();

            
        }
        private void MtdCargarDatosEnTabla()
        {
            try
            {

                FacturasNegocio negocioFacturas = new FacturasNegocio();


                dgvFacturas.DataSource = negocioFacturas.MtdConsultarFacturas();


                dgvFacturas.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}

