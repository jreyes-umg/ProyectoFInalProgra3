using ClosedXML.Excel;
using Entidad.MarlonMeda;
using Negocio.MarlonMeda;
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

namespace Sanatorios.MarlonMeda
{
    public partial class HospitalizacionesForm : Form
    {
        public HospitalizacionesForm()
        {
            InitializeComponent();
        }



        HospitalizacionesNegocio Negocio = new HospitalizacionesNegocio();
        private void MtdConsultarHospitalizaciones()
        {
            try
            {
                dgvHospitalizaciones.DataSource = Negocio.MtdConsultar();
                dgvHospitalizaciones.ClearSelection();
                dgvHospitalizaciones.CurrentCell = null;
                MtdActualizarTotalRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MtdActualizarTotalRegistros()
        {
            int total = dgvHospitalizaciones.Rows.Count;
            lblTotalRegistros.Text = $"Cantidad registros: {total}";
        }

        private void MtdLimpiarControlesForm()
        {
            txtCodigoHospitalizacion.Clear();
            cbmCodigoAtencion.SelectedIndex = -1;
            txtNumeroHabitacion.Clear();
            txtDias.Clear();
            txtUsuarioSistema.Clear();

            nudCostoDia.Value = 0;
            nudCostoMedico.Value = 0;
            nudSubTotal.Value = 0;
            nudDescuento.Value = 0;
            nudTotalHospitalizacion.Value = 0;

            rdbActivo.Checked = false;
            rdbInactivo.Checked = false;

            dtmFechaSistema.Value = DateTime.Now;
            dtmHoraSistema.Value = DateTime.Now;

            if (dgvHospitalizaciones != null)
            {
                dgvHospitalizaciones.ClearSelection();
                dgvHospitalizaciones.CurrentCell = null;

                foreach (DataGridViewRow row in dgvHospitalizaciones.Rows)
                {
                    row.Cells["Seleccionar"].Value = false;
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void MtdCargarDatosFilaEnControlesForm(int filaSeleccionada)
        {
            var Hospitalizacion = (HospitalizacionesEntidad)dgvHospitalizaciones.Rows[filaSeleccionada].DataBoundItem;

            txtCodigoHospitalizacion.Text = Hospitalizacion.CodigoHospitalizacion.ToString();

            // 1. Lógica para seleccionar el ítem correcto en el ComboBox
            int CodigoAtencionSeleccionado = Hospitalizacion.CodigoAtencion;
            foreach (var item in cbmCodigoAtencion.Items)
            {
                var atencionItem = (dynamic)item;
                int CodigoItem = (int)atencionItem.GetType().GetProperty("Value").GetValue(atencionItem, null);

                if (CodigoItem == CodigoAtencionSeleccionado)
                {
                    cbmCodigoAtencion.SelectedItem = item;
                    break; // Detiene el bucle al encontrar la coincidencia
                }
            }

            txtNumeroHabitacion.Text = Hospitalizacion.NumeroHabitacion;
            txtDias.Text = Hospitalizacion.Dias.ToString();

            nudCostoDia.Value = Hospitalizacion.CostoDia;
            nudCostoMedico.Value = Hospitalizacion.CostoMedico;
            nudSubTotal.Value = Hospitalizacion.SubTotal;
            nudDescuento.Value = Hospitalizacion.Descuento;
            nudTotalHospitalizacion.Value = Hospitalizacion.TotalHospitalizacion;

            rdbActivo.Checked = Hospitalizacion.Estado;
            rdbInactivo.Checked = !Hospitalizacion.Estado;
            txtUsuarioSistema.Text = Hospitalizacion.UsuarioSistema;

            dtmFechaSistema.Value = Hospitalizacion.FechaSistema;
            dtmHoraSistema.Value = DateTime.Today.Add(Hospitalizacion.HoraSistema);
        }


      

        private int? filaActiva = null;

        private void MtdActivarFilaSeleccionada(int filaSeleccionada)
        {
            if (filaActiva.HasValue)
            {
                dgvHospitalizaciones.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvHospitalizaciones.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = filaSeleccionada;

            dgvHospitalizaciones.Rows[filaSeleccionada].Cells["Seleccionar"].Value = true;
            dgvHospitalizaciones.Rows[filaSeleccionada].DefaultCellStyle.BackColor = Color.FromArgb(220, 235, 255);

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

            txtCodigoHospitalizacion.Enabled = Estado;
            cbmCodigoAtencion.Enabled = Estado;
            txtNumeroHabitacion.Enabled = Estado;
            txtDias.Enabled = Estado;

            nudCostoDia.Enabled = Estado;
            nudCostoMedico.Enabled = Estado;
            nudSubTotal.Enabled = Estado;
            nudDescuento.Enabled = Estado;
            nudTotalHospitalizacion.Enabled = Estado;

            rdbActivo.Enabled = Estado;
            rdbInactivo.Enabled = Estado;
            txtUsuarioSistema.Enabled = Estado;

            dtmFechaSistema.Enabled = Estado;
            dtmHoraSistema.Enabled = Estado;
        }

        private void MtdtrueBotonNuevo()
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;

            txtCodigoHospitalizacion.Enabled = false;

            cbmCodigoAtencion.Enabled = true;
            txtNumeroHabitacion.Enabled = true;
            txtDias.Enabled = true;

            nudCostoDia.Enabled = true;
            nudCostoMedico.Enabled = true;
            nudSubTotal.Enabled = true;
            nudDescuento.Enabled = true;
            nudTotalHospitalizacion.Enabled = true;

            rdbActivo.Enabled = true;
            rdbInactivo.Enabled = true;
            txtUsuarioSistema.Enabled = true;

            dtmFechaSistema.Enabled = true;
            dtmHoraSistema.Enabled = true;
        }

        private void MtdDesactivaFilaSeleccionada()
        {
            if (filaActiva.HasValue)
            {
                dgvHospitalizaciones.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvHospitalizaciones.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = null;

            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
        }

        // Crear Metodo que Imprime Lista ComboBox Atenciones
        private void MtdMostrarListaAtenciones()
        {
            var Lista = Negocio.MtdListaAtenciones(); // Cambiar por tu instancia de la capa negocio
            cbmCodigoAtencion.Items.Clear();

            foreach (var Atencion in Lista)
            {
                cbmCodigoAtencion.Items.Add(Atencion);
            }
            cbmCodigoAtencion.DisplayMember = "Text";
            cbmCodigoAtencion.ValueMember = "Value";
        }
        private void HospitalizacionesForm_Load(object sender, EventArgs e)
        {
            MtdConsultarHospitalizaciones();
            MtdMostrarListaAtenciones();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MtdLimpiarControlesForm();
            MtdtrueBotonNuevo();
            cbmCodigoAtencion.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtBuscarNombre.Text.Trim(), out int codigoAtencionBusqueda))
                {
                    MessageBox.Show("Ingrese un Código de Atención numérico válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<HospitalizacionesEntidad> lista = Negocio.MtdBuscar(codigoAtencionBusqueda);

                dgvHospitalizaciones.DataSource = lista;

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
            MtdConsultarHospitalizaciones();

            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
            MtdActualizarTotalRegistros();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Extraer el valor real (ID) del ComboBox seleccionado
                var SelectedCodigoAtencion = (dynamic)cbmCodigoAtencion.SelectedItem;
                int codigoAtencionValor = (int)SelectedCodigoAtencion.GetType().GetProperty("Value").GetValue(SelectedCodigoAtencion, null);

                HospitalizacionesEntidad controlHospitalizacion = new HospitalizacionesEntidad
                {
                    CodigoAtencion = codigoAtencionValor, // 2. Usar la variable extraída aquí
                    NumeroHabitacion = txtNumeroHabitacion.Text,
                    Dias = Convert.ToInt32(txtDias.Text),
                    CostoDia = nudCostoDia.Value,
                    CostoMedico = nudCostoMedico.Value,
                    SubTotal = nudSubTotal.Value,
                    Descuento = nudDescuento.Value,
                    TotalHospitalizacion = nudTotalHospitalizacion.Value,
                    Estado = rdbActivo.Checked,
                    UsuarioSistema = txtUsuarioSistema.Text,
                    FechaSistema = dtmFechaSistema.Value.Date,
                    HoraSistema = dtmHoraSistema.Value.TimeOfDay
                };

                Negocio.MtdAgregar(controlHospitalizacion);

                MessageBox.Show("Hospitalización agregada correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultarHospitalizaciones();
                MtdtrueFilaSelecionada(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoHospitalizacion.Text))
            {
                MessageBox.Show("Seleccione una Hospitalización para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Extraer el valor real (ID) del ComboBox seleccionado
                var SelectedCodigoAtencion = (dynamic)cbmCodigoAtencion.SelectedItem;
                int codigoAtencionValor = (int)SelectedCodigoAtencion.GetType().GetProperty("Value").GetValue(SelectedCodigoAtencion, null);

                HospitalizacionesEntidad eventoHospitalizacion = new HospitalizacionesEntidad
                {
                    CodigoHospitalizacion = Convert.ToInt32(txtCodigoHospitalizacion.Text),
                    CodigoAtencion = codigoAtencionValor, // 2. Usar la variable extraída aquí
                    NumeroHabitacion = txtNumeroHabitacion.Text,
                    Dias = Convert.ToInt32(txtDias.Text),
                    CostoDia = nudCostoDia.Value,
                    CostoMedico = nudCostoMedico.Value,
                    SubTotal = nudSubTotal.Value,
                    Descuento = nudDescuento.Value,
                    TotalHospitalizacion = nudTotalHospitalizacion.Value,
                    Estado = rdbActivo.Checked,
                    UsuarioSistema = txtUsuarioSistema.Text,
                    FechaSistema = dtmFechaSistema.Value.Date,
                    HoraSistema = dtmHoraSistema.Value.TimeOfDay
                };

                Negocio.MtdEditar(eventoHospitalizacion);

                MessageBox.Show("Hospitalización editada correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultarHospitalizaciones();
                MtdtrueFilaSelecionada(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoHospitalizacion.Text))
            {
                MessageBox.Show("Seleccione una Hospitalización para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                int codigoHospitalizacion = Convert.ToInt32(txtCodigoHospitalizacion.Text);

                bool ValidaEliminacion = Negocio.MtdEliminar(codigoHospitalizacion);

                if (!ValidaEliminacion)
                {
                    MessageBox.Show("No se pudo eliminar el registro seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("Hospitalización eliminada correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdDesactivaFilaSeleccionada();
                    MtdConsultarHospitalizaciones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoHospitalizacion.Text))
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
            if (dgvHospitalizaciones.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para exportar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog saveFile = new SaveFileDialog
                {
                    Filter = "Archivo Excel (*.xlsx)|*.xlsx",
                    FileName = "Listado_Hospitalizaciones"
                };

                if (saveFile.ShowDialog() != DialogResult.OK)
                    return;

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Control Hospitalizaciones");

                    int colIndex = 1;

                    foreach (DataGridViewColumn col in dgvHospitalizaciones.Columns)
                    {
                        if (col.Visible && col.Name != "Seleccionar")
                        {
                            ws.Cell(1, colIndex).Value = col.HeaderText;
                            ws.Cell(1, colIndex).Style.Font.Bold = true;
                            colIndex++;
                        }
                    }

                    int rowIndex = 2;

                    foreach (DataGridViewRow row in dgvHospitalizaciones.Rows)
                    {
                        colIndex = 1;

                        foreach (DataGridViewColumn col in dgvHospitalizaciones.Columns)
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

            e.Graphics.DrawString("DATOS DE HOSPITALIZACIÓN", tituloFont, brush, margenizquierdo, y); y += 40;
            e.Graphics.DrawString($"Código Hospitalización: {txtCodigoHospitalizacion.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Código Atención: {cbmCodigoAtencion.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Número Habitación: {txtNumeroHabitacion.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Días: {txtDias.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Costo Día: {Convert.ToString(nudCostoDia.Value)}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Costo Médico: {Convert.ToString(nudCostoMedico.Value)}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"SubTotal: {Convert.ToString(nudSubTotal.Value)}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Descuento: {Convert.ToString(nudDescuento.Value)}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Total Hospitalización: {Convert.ToString(nudTotalHospitalizacion.Value)}", textFont, brush, margenizquierdo, y); y += 25;

            string estado = rdbActivo.Checked ? "Activo" : "Inactivo";
            e.Graphics.DrawString($"Estado: {estado}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Usuario Sistema: {txtUsuarioSistema.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Fecha Sistema: {dtmFechaSistema.Value.ToString("dd/MM/yyyy")}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Hora Sistema: {dtmHoraSistema.Value.ToString("HH:mm:ss")}", textFont, brush, margenizquierdo, y); y += 25;
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            dgvHospitalizaciones.Columns["Seleccionar"].ReadOnly = !chkSeleccionar.Checked;
            btnEditar.Enabled = chkSeleccionar.Checked;

            MtdDesactivaFilaSeleccionada();
        }

        private void dgvHospitalizaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvHospitalizaciones.Columns[e.ColumnIndex].Name != "Seleccionar")
                return;

            if (!chkSeleccionar.Checked)
                return;

            bool seleccionado = Convert.ToBoolean(
                dgvHospitalizaciones.Rows[e.RowIndex].Cells["Seleccionar"].Value ?? false);

            if (seleccionado)
                MtdDesactivaFilaSeleccionada();
            else
                MtdActivarFilaSeleccionada(e.RowIndex);
        }

        private void nudCostoMedico_ValueChanged(object sender, EventArgs e)
        {
            nudSubTotal.Value = Convert.ToDecimal(Negocio.mtdHospitalizacionesSubtotal(Convert.ToInt32("0" + txtDias.Text), nudCostoDia.Value, nudCostoMedico.Value));
        }

        private void nudSubTotal_ValueChanged(object sender, EventArgs e)
        {
            nudDescuento.Value = Convert.ToDecimal(Negocio.mtdhospitalizacionesdescuento(Convert.ToInt32("0" + txtDias.Text), nudSubTotal.Value));
            nudTotalHospitalizacion.Value = Convert.ToDecimal(Negocio.mtdhospitalizacionesTotalHospitalizaciones(nudSubTotal.Value, nudDescuento.Value));
        }

        private void nudDescuento_ValueChanged(object sender, EventArgs e)
        {
                   
        }
    }
}

