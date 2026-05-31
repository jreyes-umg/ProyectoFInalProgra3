using Entidad.Detalles;
using Negocio.DetalleFacturas;
using Negocio.Facturas;
using Negocio.JuanDavid;
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
    public partial class DetalleFacturasForms : Form
    {
        public DetalleFacturasForms()
        {
            InitializeComponent();
        }

        private void DetallesFacturasForms_Load(object sender, EventArgs e)
        {
           
            MtdCargarDatosEnTabla();
            MtdCargarFacturasEnCombo();

            MtdLimpiarCampos();
        }

        private void MtdCalcularValoresDetalle()
        {
            try
            {
               
                int cantidad = Convert.ToInt32(nudCantidad.Value);
                decimal precioUnitario = nudPrecioUnitario.Value;

              
                DetalleFacturasNegocio negocioDetalles = new DetalleFacturasNegocio();

                
                decimal subTotal = negocioDetalles.CalcularSubTotal(cantidad, precioUnitario);
                nudSubTotal.Value = subTotal;

               
                decimal impuesto = negocioDetalles.CalcularImpuesto(subTotal);
                nudImpuesto.Value = impuesto;

                
                decimal totalDetalle = negocioDetalles.CalcularTotalDetalle(subTotal, impuesto);
                nudTotalDetalle.Value = totalDetalle;
            }
            catch (Exception)
            {
               
            }
        }

       

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            MtdCalcularValoresDetalle();
        }

        private void nudPrecioUnitario_ValueChanged(object sender, EventArgs e)
        {
            MtdCalcularValoresDetalle();
        }

        private void MtdCargarFacturasEnCombo()
        {
            try
            {
                FacturasNegocio negocioFacturas = new FacturasNegocio();

                cbxCodigoFactura.DataSource = negocioFacturas.MtdConsultarFacturas();
                cbxCodigoFactura.DisplayMember = "CodigoFactura"; 
                cbxCodigoFactura.ValueMember = "CodigoFactura";   
                cbxCodigoFactura.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las facturas: " + ex.Message);
            }
        }
        private void MtdCargarDatosEnTabla()
        {
            try
            {
                DetalleFacturasNegocio negocioDetalles = new DetalleFacturasNegocio();
                dgvRegistroDetalles.DataSource = negocioDetalles.MtdConsultarDetalles();
                dgvRegistroDetalles.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Rastreo de Error");
            }
        }   

        // ------limpiar-----//
        private void MtdLimpiarCampos()
        {
            txtCodigoDetalle.Text = "";
            cbxCodigoFactura.SelectedIndex = -1;
            cbxTipoConcepto.SelectedIndex = -1;

            nudCodigoReferencia.Value = 0;
            txtDescripcionReferencia.Text = "";

            nudCantidad.Value = 0;
            nudPrecioUnitario.Value = 0;
            nudSubTotal.Value = 0;
            nudImpuesto.Value = 0;
            nudTotalDetalle.Value = 0;

            rdbActivo.Checked = true;
        }
        // ----NUEVO-----//
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
        }
        // ------CANCELAR-----//
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
        }

        // -----GUARDAR-----//
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DetallesFacturasEntidad nuevoDetalle = new DetallesFacturasEntidad();

                nuevoDetalle.CodigoFactura = Convert.ToInt32(cbxCodigoFactura.SelectedValue ?? 0); 
                nuevoDetalle.TipoConcepto = cbxTipoConcepto.SelectedItem?.ToString() ?? "";
                nuevoDetalle.CodigoReferencia = Convert.ToInt32(nudCodigoReferencia.Value);
                nuevoDetalle.DescripcionReferencia = txtDescripcionReferencia.Text;
                nuevoDetalle.Cantidad = Convert.ToInt32(nudCantidad.Value);
                nuevoDetalle.PrecioUnitario = nudPrecioUnitario.Value;
                nuevoDetalle.SubTotal = nudSubTotal.Value;
                nuevoDetalle.Impuesto = nudImpuesto.Value;
                nuevoDetalle.TotalDetalle = nudTotalDetalle.Value;
                nuevoDetalle.Estado = rdbActivo.Checked;

                nuevoDetalle.UsuarioSistema = "Admin";
                nuevoDetalle.FechaSistema = DateTime.Now.Date;
                nuevoDetalle.HoraSistema = DateTime.Now; 

                DetalleFacturasNegocio negocioDetalles = new DetalleFacturasNegocio();
                if (negocioDetalles.MtdAgregar(nuevoDetalle))
                {
                    MessageBox.Show("Detalle guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdCargarDatosEnTabla();
                    MtdLimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------EDITAR-----//
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodigoDetalle.Text))
                {
                    MessageBox.Show("Seleccione un detalle de la tabla para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DetallesFacturasEntidad detalleEditado = new DetallesFacturasEntidad();
                detalleEditado.CodigoDetalle = Convert.ToInt32(txtCodigoDetalle.Text);

                detalleEditado.CodigoFactura = Convert.ToInt32(cbxCodigoFactura.SelectedValue ?? 0);
                detalleEditado.TipoConcepto = cbxTipoConcepto.SelectedItem?.ToString() ?? "";
                detalleEditado.CodigoReferencia = Convert.ToInt32(nudCodigoReferencia.Value);
                detalleEditado.DescripcionReferencia = txtDescripcionReferencia.Text;
                detalleEditado.Cantidad = Convert.ToInt32(nudCantidad.Value);
                detalleEditado.PrecioUnitario = nudPrecioUnitario.Value;
                detalleEditado.SubTotal = nudSubTotal.Value;
                detalleEditado.Impuesto = nudImpuesto.Value;
                detalleEditado.TotalDetalle = nudTotalDetalle.Value;
                detalleEditado.Estado = rdbActivo.Checked;

                detalleEditado.UsuarioSistema = "Admin";
                detalleEditado.FechaSistema = DateTime.Now.Date;
                detalleEditado.HoraSistema = DateTime.Now;

                DetalleFacturasNegocio negocioDetalles = new DetalleFacturasNegocio();
                if (negocioDetalles.MtdEditar(detalleEditado))
                {
                    MessageBox.Show("Detalle actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdCargarDatosEnTabla();
                    MtdLimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ------ELIMINAR-----//
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodigoDetalle.Text))
                {
                    MessageBox.Show("Seleccione un detalle para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show("¿Desea eliminar este detalle de factura?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    int codigoEliminar = Convert.ToInt32(txtCodigoDetalle.Text);
                    DetalleFacturasNegocio negocioDetalles = new DetalleFacturasNegocio();

                    if (negocioDetalles.MtdEliminar(codigoEliminar))
                    {
                        MessageBox.Show("Detalle eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font tituloFont = new Font("Arial", 16, FontStyle.Bold);
            Font textFont = new Font("Arial", 11);
            Brush brush = Brushes.Black;
            float y = 40;
            float margenizquierdo = 50;

            e.Graphics.DrawString("DATOS DEL DETALLE DE FACTURA", tituloFont, brush, margenizquierdo, y);
            y += 40;

            e.Graphics.DrawString($"Código Detalle: {txtCodigoDetalle.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Código Factura: {cbxCodigoFactura.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Concepto: {cbxTipoConcepto.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Referencia: {nudCodigoReferencia.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Descripción: {txtDescripcionReferencia.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Cantidad: {nudCantidad.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Precio Unitario: Q{nudPrecioUnitario.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"SubTotal: Q{nudSubTotal.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Impuesto: Q{nudImpuesto.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Total Detalle: Q{nudTotalDetalle.Value}", textFont, brush, margenizquierdo, y); y += 25;

            string estado = rdbActivo.Checked ? "Activo" : "Inactivo";
            e.Graphics.DrawString($"Estado: {estado}", textFont, brush, margenizquierdo, y);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string textoBusqueda = txtBuscarNombre.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(textoBusqueda))
                {
                    MtdCargarDatosEnTabla();
                    return;
                }

                DetalleFacturasNegocio negocio = new DetalleFacturasNegocio();
                var listaCompleta = negocio.MtdConsultarDetalles();

                
                var listaFiltrada = listaCompleta.Where(s => s.TipoConcepto.ToLower().Contains(textoBusqueda) || s.DescripcionReferencia.ToLower().Contains(textoBusqueda)).ToList();
                dgvRegistroDetalles.DataSource = listaFiltrada;
            }
            catch (Exception ex) { MessageBox.Show("Error al buscar: " + ex.Message); }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarNombre.Text = "";
            MtdCargarDatosEnTabla();
        }

        private void BtnCerrarr_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try { printDocument1.Print(); }
            catch (Exception ex) { MessageBox.Show("Error al imprimir: " + ex.Message); }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRegistroDetalles.Rows.Count == 0) return;
                SaveFileDialog guardarArchivo = new SaveFileDialog { Filter = "Archivo CSV (*.csv)|*.csv", FileName = "DetallesFacturas_" + DateTime.Now.ToString("ddMMyyyy") + ".csv" };
                if (guardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(guardarArchivo.FileName, false, System.Text.Encoding.UTF8))
                    {
                        for (int i = 0; i < dgvRegistroDetalles.Columns.Count; i++)
                        {
                            sw.Write(dgvRegistroDetalles.Columns[i].HeaderText);
                            if (i < dgvRegistroDetalles.Columns.Count - 1) sw.Write(",");
                        }
                        sw.WriteLine();
                        foreach (DataGridViewRow fila in dgvRegistroDetalles.Rows)
                        {
                            for (int i = 0; i < dgvRegistroDetalles.Columns.Count; i++)
                            {
                                if (fila.Cells[i].Value != null) sw.Write(fila.Cells[i].Value.ToString().Replace(",", " "));
                                if (i < dgvRegistroDetalles.Columns.Count - 1) sw.Write(",");
                            }
                            sw.WriteLine();
                        }
                    }
                    MessageBox.Show("Exportado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
    }
}
