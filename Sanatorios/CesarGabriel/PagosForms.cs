using ClosedXML.Excel;
using Entidad;
using Entidad.Pagos;
using Negocio.Facturas;
using Negocio.Pagos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sanatorios
{
    public partial class PagosForms : Form
    {
        PagosNegocio Negocio = new PagosNegocio();
        PagosEntidad Entidad = new PagosEntidad();
        private DateTime fechaFacturaSeleccionada = DateTime.Now;

        public PagosForms()
        {
            InitializeComponent();
        }

        /*-----METODOS-----*/


        /* ----- Consultar -----*/

        private void MtdConsultarControlPagos()
        {
            try
            {
                dgvRegistroPagos.DataSource = Negocio.MtdConsultarPagos();
                dgvRegistroPagos.ClearSelection();
                dgvRegistroPagos.CurrentCell = null;
                MtdActualizarTotalRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MtdActualizarTotalRegistros()
        {
            int total = dgvRegistroPagos.Rows.Count;
            lblTotalRegistros.Text = $"Cantidad registros: {total}";
        }

        private void MtdLimpiarControlesForm()
        {
            txtCodigoPago.Clear();
            cmbCodigoFactura.SelectedIndex = -1;
            dtpFechaPago.Value = DateTime.Now;
            nudMontoFactura.Value = 0;
            nudMontoPagado.Value = 0;
            cmbMetodoPago.SelectedIndex = -1;
            nudMora.Value = 0;
            nudCambio.Value = 0;
            nudTotalCancelado.Value = 0;

            rdbActivo.Checked = false;
            rdbInactivo.Checked = false;

            dgvRegistroPagos.ClearSelection();
            dgvRegistroPagos.CurrentCell = null;

            foreach (DataGridViewRow row in dgvRegistroPagos.Rows)
            {
                row.Cells["Seleccionar"].Value = false;
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void MtdCargarDatosFilaEnControlesForm(int filaSeleccionada)
        {
            var Pago = (PagosEntidad)dgvRegistroPagos.Rows[filaSeleccionada].DataBoundItem;

            txtCodigoPago.Text = Pago.CodigoPago.ToString();
            cmbCodigoFactura.Text = Pago.CodigoFactura.ToString();
            dtpFechaPago.Value = Pago.FechaPago;
            nudMontoFactura.Value = Pago.MontoFactura;
            nudMontoPagado.Value = Pago.MontoPagado;
            cmbMetodoPago.Text = Pago.MetodoPago;
            nudMora.Value = Pago.Mora;
            nudCambio.Value = Pago.Cambio;
            nudTotalCancelado.Value = Pago.TotalCancelado;
            rdbActivo.Checked = Pago.Estado;
            rdbInactivo.Checked = !Pago.Estado;
        }

        private int? filaActiva = null;

        private void MtdActivarFilaSeleccionada(int filaSeleccionada)
        {
            if (filaActiva.HasValue)
            {
                dgvRegistroPagos.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvRegistroPagos.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = filaSeleccionada;

            dgvRegistroPagos.Rows[filaSeleccionada].Cells["Seleccionar"].Value = true;
            dgvRegistroPagos.Rows[filaSeleccionada].DefaultCellStyle.BackColor = Color.FromArgb(220, 235, 255);

            MtdCargarDatosFilaEnControlesForm(filaSeleccionada);
            MtdtrueFilaSelecionada(true);
        }

        private void MtdtrueFilaSelecionada(bool Estado)
        {
            btnEditar.Enabled = Estado;
            btnEliminar.Enabled = Estado;
            btnCancelar.Enabled = Estado;
            btnImprimir.Enabled = Estado;
            btnNuevo.Enabled = !Estado;
            btnGuardar.Enabled = false;

            txtCodigoPago.Enabled = Estado;
            cmbCodigoFactura.Enabled = Estado;
            dtpFechaPago.Enabled = Estado;
            nudMontoFactura.Enabled = Estado;
            nudMontoPagado.Enabled = Estado;
            cmbMetodoPago.Enabled = Estado;
            nudMora.Enabled = Estado;
            nudCambio.Enabled = Estado;
            nudTotalCancelado.Enabled = Estado;
            rdbActivo.Enabled = Estado;
            rdbInactivo.Enabled = Estado;
        }

        private void MtdtrueBotonNuevo()
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;

            txtCodigoPago.Enabled = false;
            cmbCodigoFactura.Enabled = true;
            dtpFechaPago.Enabled = true;
            nudMontoFactura.Enabled = true;
            nudMontoPagado.Enabled = true;
            cmbMetodoPago.Enabled = true;
            nudMora.Enabled = true;
            nudCambio.Enabled = true;
            nudTotalCancelado.Enabled = true;
            rdbActivo.Enabled = true;
            rdbInactivo.Enabled = true;
        }

        private void MtdDesactivaFilaSeleccionada()
        {
            if (filaActiva.HasValue)
            {
                dgvRegistroPagos.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvRegistroPagos.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = null;

            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
        }

        /*--- BOTONES O CAMPOS----*/
        private void PagosForms_Load(object sender, EventArgs e)
        {

            MtdConsultarControlPagos();


            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.Add("Efectivo");
            cmbMetodoPago.Items.Add("Tarjeta");
            cmbMetodoPago.Items.Add("Transferencia");
            cmbMetodoPago.Items.Add("Deposito");


            CargarFacturasEnCombo();
        }

        private void MtdCargarFacturasEnCombo()
        {
            try
            {
                FacturasNegocio negocioFacturas = new FacturasNegocio();

                cmbCodigoFactura.DataSource = negocioFacturas.MtdConsultarFacturas();
                cmbCodigoFactura.DisplayMember = "CodigoFactura"; 
                cmbCodigoFactura.ValueMember = "CodigoFactura";   
                cmbCodigoFactura.SelectedIndex = -1;              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las facturas: " + ex.Message);
            }
        }
        private void CargarFacturasEnCombo()
        {
            try
            {

                FacturasNegocio negocioFacturas = new FacturasNegocio();

                cmbCodigoFactura.DataSource = negocioFacturas.MtdConsultarFacturas();
                cmbCodigoFactura.DisplayMember = "CodigoFactura";
                cmbCodigoFactura.ValueMember = "CodigoFactura";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las facturas: " + ex.Message);
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MtdLimpiarControlesForm();
            MtdtrueBotonNuevo();
            cmbCodigoFactura.Focus();
        }

        private void dgvRegistroPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvRegistroPagos.Columns[e.ColumnIndex].Name != "Seleccionar")
                return;

            if (!chkSeleccionar.Checked)
                return;

            bool seleccionado = Convert.ToBoolean(
                dgvRegistroPagos.Rows[e.RowIndex].Cells["Seleccionar"].Value ?? false);

            if (seleccionado)
                MtdDesactivaFilaSeleccionada();
            else
                MtdActivarFilaSeleccionada(e.RowIndex);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
        }


        private void nudMontoPagado_ValueChanged(object sender, EventArgs e)
        {
            nudCambio.Value = Negocio.CalcularCambio(nudMontoPagado.Value, nudMontoFactura.Value, nudMora.Value);
            nudTotalCancelado.Value = Negocio.CalcularTotalCancelado(nudMontoFactura.Value, nudMora.Value);
        }

        private void dtpFechaPago_ValueChanged(object sender, EventArgs e)
        {

            DateTime fechaFactura = DateTime.Today;

            nudMora.Value = Negocio.CalcularMora(dtpFechaPago.Value, fechaFactura, nudMontoFactura.Value);
            nudTotalCancelado.Value = Negocio.CalcularTotalCancelado(nudMontoFactura.Value, nudMora.Value);
            nudCambio.Value = Negocio.CalcularCambio(nudMontoPagado.Value, nudMontoFactura.Value, nudMora.Value);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<PagosEntidad> lista = Negocio.MtdBuscar(txtBuscarNombre.Text.Trim());

                dgvRegistroPagos.DataSource = lista;

                MtdLimpiarControlesForm();
                MtdtrueFilaSelecionada(false);
                MtdActualizarTotalRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarNombre.Clear();
            MtdConsultarControlPagos();

            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
            MtdActualizarTotalRegistros();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                PagosEntidad controlPagos = new PagosEntidad
                {
                    CodigoFactura = Convert.ToInt32(cmbCodigoFactura.Text),
                    FechaPago = dtpFechaPago.Value,
                    MontoFactura = nudMontoFactura.Value,
                    MontoPagado = nudMontoPagado.Value,
                    MetodoPago = cmbMetodoPago.Text,
                    Mora = nudMora.Value,
                    Cambio = nudCambio.Value,
                    TotalCancelado = nudTotalCancelado.Value,
                    Estado = rdbActivo.Checked,
                    UsuarioSistema = "Consola",
                    FechaSistema = System.DateTime.Today,
                    HoraSistema = System.DateTime.Now.TimeOfDay
                };

                Negocio.MtdAgregar(controlPagos);
                MessageBox.Show("Pago agregado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultarControlPagos();
                MtdtrueFilaSelecionada(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoPago.Text))
            {
                MessageBox.Show("Seleccione un Pago para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PagosEntidad evento = new PagosEntidad
                {
                    CodigoPago = Convert.ToInt32(txtCodigoPago.Text),
                    CodigoFactura = Convert.ToInt32(cmbCodigoFactura.Text),
                    FechaPago = dtpFechaPago.Value,
                    MontoFactura = nudMontoFactura.Value,
                    MontoPagado = nudMontoPagado.Value,
                    MetodoPago = cmbMetodoPago.Text,
                    Mora = nudMora.Value,
                    Cambio = nudCambio.Value,
                    TotalCancelado = nudTotalCancelado.Value,
                    Estado = rdbActivo.Checked,
                    UsuarioSistema = "Consola",
                    FechaSistema = System.DateTime.Today,
                    HoraSistema = System.DateTime.Now.TimeOfDay,
                };
                Negocio.MtdEditar(evento);
                MessageBox.Show("Pago Editado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultarControlPagos();
                MtdtrueFilaSelecionada(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoPago.Text))
            {
                MessageBox.Show("Seleccione un Codigo de Pago para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                int CodigoRenta = Convert.ToInt32(txtCodigoPago.Text);

                bool ValidaEliminacion = Negocio.MtdEliminar(CodigoRenta);

                if (!ValidaEliminacion)
                {
                    MessageBox.Show("No se pudo eliminar el registro seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("Pago eliminado correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdDesactivaFilaSeleccionada();
                    MtdConsultarControlPagos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoPago.Text))
            {
                MessageBox.Show("Seleccione un registro a imprimir", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                printDocument1.DefaultPageSettings.Margins = new Margins(20, 20, 20, 20);

                int AltoDocumento = 350;
                int AnchoDocumento = 400;

                printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Documento", AnchoDocumento, AltoDocumento);

                PrintPreviewDialog preview = new PrintPreviewDialog
                {
                    Document = printDocument1,
                    WindowState = FormWindowState.Maximized
                };

                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al imprimir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvRegistroPagos.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para exportar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog saveFile = new SaveFileDialog
                {
                    Filter = "Archivo Excel (*.xlsx)|*.xlsx",
                    FileName = "Listado_Pagos"
                };

                if (saveFile.ShowDialog() != DialogResult.OK)
                    return;

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Control Pagos");
                    int colIndex = 1;

                    foreach (DataGridViewColumn col in dgvRegistroPagos.Columns)
                    {
                        if (col.Visible && col.Name != "Seleccionar")
                        {
                            ws.Cell(1, colIndex).Value = col.HeaderText;
                            ws.Cell(1, colIndex).Style.Font.Bold = true;
                            colIndex++;
                        }
                    }

                    int rowIndex = 2;

                    foreach (DataGridViewRow row in dgvRegistroPagos.Rows)
                    {
                        colIndex = 1;

                        foreach (DataGridViewColumn col in dgvRegistroPagos.Columns)
                        {
                            if (col.Visible && col.Name != "Seleccionar")
                            {
                                object valorCelda = row.Cells[col.Name].Value;

                                if (valorCelda is System.DateTime fecha)
                                {
                                    ws.Cell(rowIndex, colIndex).Value = fecha.ToString("dd/MM/yyyy");
                                }
                                else if (valorCelda is bool estado)
                                {
                                    ws.Cell(rowIndex, colIndex).Value = estado ? "Activo" : "Inactivo";
                                }
                                else
                                {
                                    ws.Cell(rowIndex, colIndex).Value = valorCelda?.ToString();
                                }
                                colIndex++;
                            }
                        }
                        rowIndex++;
                    }

                    ws.Columns().AdjustToContents();
                    wb.SaveAs(saveFile.FileName);
                }

                MessageBox.Show("Archivo exportado correctamente.", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font tituloFont = new Font("Arial", 16, FontStyle.Bold);
            Font textFont = new Font("Arial", 11);
            Brush brush = Brushes.Black;

            float y = 40;
            float margenizquierdo = 50;

            e.Graphics.DrawString("DATOS DEL PAGO", textFont, brush, margenizquierdo, y); y += 40;
            e.Graphics.DrawString($"Código Pago: {txtCodigoPago.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Código Factura: {cmbCodigoFactura.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Fecha Pago: {dtpFechaPago.Value.ToString("dd/MM/yyyy")}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Monto Factura: Q{nudMontoFactura.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Monto Pagado: Q{nudMontoPagado.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Método Pago: {cmbMetodoPago.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Mora: Q{nudMora.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Cambio: Q{nudCambio.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Total Cancelado: Q{nudTotalCancelado.Value}", textFont, brush, margenizquierdo, y); y += 25;

            string estado = rdbActivo.Checked ? "Activo" : "Inactivo";
            e.Graphics.DrawString($"Estado: {estado}", textFont, brush, margenizquierdo, y); y += 25;
        }

        private void MtdCalcularValoresPago()
        {
            try
            {

                decimal montoFactura = nudMontoFactura.Value;
                decimal montoPagado = nudMontoPagado.Value;
                DateTime fechaPago = dtpFechaPago.Value;

                PagosNegocio negocioPagos = new PagosNegocio();


                decimal moraCalculada = negocioPagos.CalcularMora(fechaPago, fechaFacturaSeleccionada, montoFactura);
                nudMora.Value = moraCalculada;


                decimal totalCancelado = negocioPagos.CalcularTotalCancelado(montoFactura, moraCalculada);
                nudTotalCancelado.Value = totalCancelado;


                decimal cambioCalculado = negocioPagos.CalcularCambio(montoPagado, montoFactura, moraCalculada);
                nudCambio.Value = cambioCalculado;
            }
            catch (Exception)
            {

            }
        }   
            private void cbCodigoFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                if (cmbCodigoFactura.SelectedIndex != -1 && cmbCodigoFactura.SelectedValue != null)
                {
                    int codigoSeleccionado;
                 
                    if (int.TryParse(cmbCodigoFactura.SelectedValue.ToString(), out codigoSeleccionado))
                    {
                       
                        FacturasNegocio negocioFacturas = new FacturasNegocio();

                        
                        var listaFacturas = negocioFacturas.MtdBuscar(codigoSeleccionado.ToString());

                        if (listaFacturas.Count > 0)
                        {
                      
                            var miFactura = listaFacturas[0];

                           
                            fechaFacturaSeleccionada = miFactura.FechaFactura;

                           
                            nudMontoFactura.Value = miFactura.TotalPagar;

                           
                            MtdCalcularValoresPago();
                        }
                    }
                }
            }
            catch (Exception)
            {
               
            }
        }

        private void PagosForms_Load_1(object sender, EventArgs e)
        {
            MtdConsultarControlPagos();
            MtdCargarFacturasEnCombo();
        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            Font tituloFont = new Font("Arial", 16, FontStyle.Bold);
            Font textFont = new Font("Arial", 11);
            Brush brush = Brushes.Black;
            float y = 40;
            float margenizquierdo = 50;

            e.Graphics.DrawString("COMPROBANTE DE PAGO", tituloFont, brush, margenizquierdo, y);
            y += 40;

            e.Graphics.DrawString($"Código de Pago: {txtCodigoPago.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Código de Factura: {cmbCodigoFactura.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Método de Pago: {cmbMetodoPago.Text}", textFont, brush, margenizquierdo, y); y += 25; 
            e.Graphics.DrawString($"Monto Recibido: Q{nudMontoFactura.Value}", textFont, brush, margenizquierdo, y); y += 25;

            string estado = rdbActivo.Checked ? "Procesado" : "Revertido";
            e.Graphics.DrawString($"Estado: {estado}", textFont, brush, margenizquierdo, y);
        }
    }
}

