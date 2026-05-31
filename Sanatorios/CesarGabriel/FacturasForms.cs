using Entidad.Factura;
using Negocio.Facturas;
using Negocio.JuanDavid;
using Negocio.SegurosMedicos;
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
        private void MtdCargarAtencionesEnCombo()
        {
            try
            {

                AntencionNegocio negocioAtenciones = new AntencionNegocio();


                cbxAtencion.DataSource = negocioAtenciones.MtdConsultar();


                cbxAtencion.DisplayMember = "CodigoAtencion";
                cbxAtencion.ValueMember = "CodigoAtencion";
                cbxAtencion.SelectedIndex = -1; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las Atenciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MtdCargarSegurosEnCombo()
        {
            try
            {
               
                SegurosMedicosNegocio negocioSeguros = new SegurosMedicosNegocio();

                cbxCodigoSeguro.DataSource = negocioSeguros.MtdConsultarSeguros();

               
                cbxCodigoSeguro.DisplayMember = "NombreSeguro";

              
                cbxCodigoSeguro.ValueMember = "CodigoSeguro";
                cbxCodigoSeguro.SelectedIndex = -1; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los Seguros Médicos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

               
                nuevaFactura.UsuarioSistema = "Admin"; 
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
            MtdCargarAtencionesEnCombo(); 
            MtdCargarSegurosEnCombo();   

            MtdCargarDatosEnTabla();
            MtdLimpiarCampos();
          
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font tituloFont = new Font("Arial", 16, FontStyle.Bold);
            Font textFont = new Font("Arial", 11);
            Brush brush = Brushes.Black;
            float y = 40;
            float margenizquierdo = 50;

            e.Graphics.DrawString("DOCUMENTO DE FACTURACIÓN", tituloFont, brush, margenizquierdo, y);
            y += 40;

            e.Graphics.DrawString($"Código de Factura: {txtCodigoFactura.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Paciente: {cbxAtencion.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Seguro Médico: {cbxCodigoSeguro.Text}", textFont, brush, margenizquierdo, y); y += 25; 
            e.Graphics.DrawString($"SubTotal: Q{nudSubTotal.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Descuento/Cobertura: Q{nudDescuentoSeguro.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Impuesto: Q{nudImpuesto.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Total a Pagar: Q{nudTotalPagar.Value}", textFont, brush, margenizquierdo, y); y += 25;

            string estado = rdbActivo.Checked ? "Activa" : "Anulada";
            e.Graphics.DrawString($"Estado: {estado}", textFont, brush, margenizquierdo, y);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string textoBusqueda = txtBuscarNombre.Text.Trim().ToLower(); 
                    if (string.IsNullOrEmpty(textoBusqueda))
                    {
                        MtdCargarDatosEnTabla();
                        return;
                    }

                    FacturasNegocio negocio = new FacturasNegocio();
                    var listaCompleta = negocio.MtdConsultarFacturas();

                    var listaFiltrada = listaCompleta.Where(s => s.CodigoFactura.ToString().Contains(textoBusqueda)).ToList();
                    dgvFacturas.DataSource = listaFiltrada;
                }
                catch (Exception ex) { MessageBox.Show("Error al buscar: " + ex.Message); }
            }
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
                if (dgvFacturas.Rows.Count == 0) return;
                SaveFileDialog guardarArchivo = new SaveFileDialog { Filter = "Archivo CSV (*.csv)|*.csv", FileName = "Facturas_" + DateTime.Now.ToString("ddMMyyyy") + ".csv" };
                if (guardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(guardarArchivo.FileName, false, System.Text.Encoding.UTF8))
                    {
                        for (int i = 0; i < dgvFacturas.Columns.Count; i++)
                        {
                            sw.Write(dgvFacturas.Columns[i].HeaderText);
                            if (i < dgvFacturas.Columns.Count - 1) sw.Write(",");
                        }
                        sw.WriteLine();
                        foreach (DataGridViewRow fila in dgvFacturas.Rows)
                        {
                            for (int i = 0; i < dgvFacturas.Columns.Count; i++)
                            {
                                if (fila.Cells[i].Value != null) sw.Write(fila.Cells[i].Value.ToString().Replace(",", " "));
                                if (i < dgvFacturas.Columns.Count - 1) sw.Write(",");
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

