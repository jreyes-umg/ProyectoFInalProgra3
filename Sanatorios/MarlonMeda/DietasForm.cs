using ClosedXML.Excel;
using Entidad;
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
    public partial class DietasForm : Form
    {
        DietasNegocio Negocio = new DietasNegocio();
        public DietasForm()
        {
            InitializeComponent();
        }
        private void MtdConsultardietas()
        {
            try
            {
                dgvDietas.DataSource = Negocio.MtdConsultar();
                dgvDietas.ClearSelection();
                dgvDietas.CurrentCell = null;
                MtdActualizarTotalRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MtdActualizarTotalRegistros()
        {
            int total = dgvDietas.Rows.Count;

            lblTotalRegistros.Text = $"Cantidad registros: {total}";
        }

      

        private void MtdLimpiarControlesForm()
        {
            // ---> CAMBIAR: Controles forms de Dietas

            // Campos de texto y ComboBox
            txtCodigoDietas.Clear();
            cbxCodigoHospitalizacion.SelectedIndex = -1; 
            txtTipoConcepto.Clear();
            txtDias.Clear();
            txtNutricionista.Clear();
            txtUsuarioSistema.Clear();
            nudCostoDiario.Value = 0;
            nudSubTotal.Value = 0;
            nudImpuesto.Value = 0;
            nudTotalDetalle.Value = 0;
            rdbActivo.Checked = false;
            rdbInactivo.Checked = false;
            
            dtmFechaSistema.Value = DateTime.Now;
            dtmHoraSistema.Value = DateTime.Now;

            // ---> CAMBIAR: Nombre del DataGridView
            
            if (dgvDietas != null)
            {
                dgvDietas.ClearSelection();
                dgvDietas.CurrentCell = null;

                foreach (DataGridViewRow row in dgvDietas.Rows)
                {
                    row.Cells["Seleccionar"].Value = false;
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }


        private void MtdCargarDatosFilaEnControlesForm(int filaSeleccionada)
        {
            var Dieta = (DietasEntidad)dgvDietas.Rows[filaSeleccionada].DataBoundItem;

            txtCodigoDietas.Text = Dieta.CodigoDieta.ToString();

            // Lógica para seleccionar el ítem correcto en el ComboBox de Hospitalizaciones
            int CodigoHospSeleccionado = Dieta.CodigoHospitalizacion;
            foreach (var item in cbxCodigoHospitalizacion.Items)
            {
                var hospItem = (dynamic)item;
                int CodigoItem = (int)hospItem.GetType().GetProperty("Value").GetValue(hospItem, null);

                if (CodigoItem == CodigoHospSeleccionado)
                {
                    cbxCodigoHospitalizacion.SelectedItem = item;
                    break;
                }
            }

            txtTipoConcepto.Text = Dieta.TipoDieta;
            txtDias.Text = Dieta.Dias.ToString();
            txtNutricionista.Text = Dieta.Nutricionista;
            txtUsuarioSistema.Text = Dieta.UsuarioSistema;
            nudCostoDiario.Value = Dieta.CostoDiario;
            nudSubTotal.Value = Dieta.SubTotal;
            nudImpuesto.Value = Dieta.Impuesto;
            nudTotalDetalle.Value = Dieta.TotalDieta;
            rdbActivo.Checked = Dieta.Estado;
            rdbInactivo.Checked = !Dieta.Estado;

            dtmFechaSistema.Value = Dieta.FechaSistema;
            dtmHoraSistema.Value = DateTime.Today.Add(Dieta.HoraSistema);
        }


        private int? filaActiva = null;
        private void MtdActivarFilaSeleccionada(int filaSeleccionada)
        {
            // ---> CAMBIAR: Nombre del DataGridView <----- //
            if (filaActiva.HasValue)
            {
                dgvDietas.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvDietas.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = filaSeleccionada;

            dgvDietas.Rows[filaSeleccionada].Cells["Seleccionar"].Value = true;
            dgvDietas.Rows[filaSeleccionada].DefaultCellStyle.BackColor = Color.FromArgb(220, 235, 255);

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

            txtCodigoDietas.Enabled = Estado;
            cbxCodigoHospitalizacion.Enabled = Estado;
            txtTipoConcepto.Enabled = Estado;
            txtDias.Enabled = Estado;
            txtNutricionista.Enabled = Estado;
            txtUsuarioSistema.Enabled = Estado;

            nudCostoDiario.Enabled = Estado;
            nudSubTotal.Enabled = Estado;
            nudImpuesto.Enabled = Estado;
            nudTotalDetalle.Enabled = Estado;

            rdbActivo.Enabled = Estado;
            rdbInactivo.Enabled = Estado;

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

            // ---> CAMBIAR: Controles forms de Dietas
            txtCodigoDietas.Enabled = false; // Bloqueado porque suele ser autogenerado (Identity)

            cbxCodigoHospitalizacion.Enabled = true;
            txtTipoConcepto.Enabled = true;
            txtDias.Enabled = true;
            txtNutricionista.Enabled = true;
            txtUsuarioSistema.Enabled = true;

            nudCostoDiario.Enabled = true;
            nudSubTotal.Enabled = true;
            nudImpuesto.Enabled = true;
            nudTotalDetalle.Enabled = true;

            rdbActivo.Enabled = true;
            rdbInactivo.Enabled = true;

            dtmFechaSistema.Enabled = true;
            dtmHoraSistema.Enabled = true;
        }

        private void MtdDesactivaFilaSeleccionada()
        {
            // ---> CAMBIAR: Nombre del DataGridView <----- //
            if (filaActiva.HasValue)
            {
                dgvDietas.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvDietas.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = null;

            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
        }


        private void rdbInactivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }


        private void MtdMostrarListaHospitalizaciones()
        {
            // Asegúrate de usar el nombre correcto de tu capa de negocio
            var Lista = Negocio.MtdListaHospitalizaciones();
            cbxCodigoHospitalizacion.Items.Clear();

            foreach (var hosp in Lista)
            {
                cbxCodigoHospitalizacion.Items.Add(hosp);
            }

            // Esto es crucial para que sepa qué mostrar y qué valor oculto guardar
            cbxCodigoHospitalizacion.DisplayMember = "Text";
            cbxCodigoHospitalizacion.ValueMember = "Value";
        }

        private void DietasForm_Load(object sender, EventArgs e)
        {
            MtdConsultardietas();
            MtdMostrarListaHospitalizaciones();
        }

        private void dgvDietas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvDietas.Columns[e.ColumnIndex].Name != "Seleccionar")
                return;

            if (!chkSeleccionar.Checked)
                return;

            bool seleccionado = Convert.ToBoolean(
                dgvDietas.Rows[e.RowIndex].Cells["Seleccionar"].Value ?? false);

            if (seleccionado)
                MtdDesactivaFilaSeleccionada();
            else
                MtdActivarFilaSeleccionada(e.RowIndex);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MtdLimpiarControlesForm();
            MtdtrueBotonNuevo();

            // ---> CAMBIAR: Nombre Control del forms
            txtCodigoDietas.Focus();
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
                List<DietasEntidad> lista = Negocio.MtdBuscar(txtBuscarNombre.Text.Trim());

                dgvDietas.DataSource = lista;

                MtdLimpiarControlesForm();
                MtdtrueFilaSelecionada(false);
                MtdActualizarTotalRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarNombre.Clear();
            MtdConsultardietas();

            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
            MtdActualizarTotalRegistros();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Extraer el valor real (ID) del ComboBox
                var SelectedCodigoHosp = (dynamic)cbxCodigoHospitalizacion.SelectedItem;
                int codigoHospitalizacionValor = (int)SelectedCodigoHosp.GetType().GetProperty("Value").GetValue(SelectedCodigoHosp, null);

                DietasEntidad controlDietas = new DietasEntidad
                {
                    CodigoHospitalizacion = codigoHospitalizacionValor, // 2. Usar la variable extraída
                    TipoDieta = txtTipoConcepto.Text,
                    CostoDiario = nudCostoDiario.Value,
                    Dias = Convert.ToInt32(txtDias.Text),
                    Nutricionista = txtNutricionista.Text,
                    SubTotal = nudSubTotal.Value,
                    Impuesto = nudImpuesto.Value,
                    TotalDieta = nudTotalDetalle.Value,
                    Estado = rdbActivo.Checked,
                    FechaSistema = dtmFechaSistema.Value.Date,
                    UsuarioSistema = txtUsuarioSistema.Text,
                    HoraSistema = dtmHoraSistema.Value.TimeOfDay
                };

                Negocio.MtdAgregar(controlDietas);

                MessageBox.Show("Dieta agregada correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultardietas();
                MtdtrueFilaSelecionada(false);
            }
            catch (Exception ex)
            {
                string errorReal = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show("El error oculto de SQL es: \n\n" + errorReal, "Investigando el Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoDietas.Text))
            {
                MessageBox.Show("Seleccione una Dieta para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Extraer el valor real (ID) del ComboBox
                var SelectedCodigoHosp = (dynamic)cbxCodigoHospitalizacion.SelectedItem;
                int codigoHospitalizacionValor = (int)SelectedCodigoHosp.GetType().GetProperty("Value").GetValue(SelectedCodigoHosp, null);

                DietasEntidad eventoDieta = new DietasEntidad
                {
                    CodigoDieta = Convert.ToInt32(txtCodigoDietas.Text),
                    CodigoHospitalizacion = codigoHospitalizacionValor, // 2. Usar la variable extraída
                    TipoDieta = txtTipoConcepto.Text,
                    CostoDiario = nudCostoDiario.Value,
                    Dias = Convert.ToInt32(txtDias.Text),
                    Nutricionista = txtNutricionista.Text,
                    SubTotal = nudSubTotal.Value,
                    Impuesto = nudImpuesto.Value,
                    FechaSistema = dtmFechaSistema.Value.Date,
                    TotalDieta = nudTotalDetalle.Value,
                    Estado = rdbActivo.Checked,
                    UsuarioSistema = txtUsuarioSistema.Text,
                    HoraSistema = dtmHoraSistema.Value.TimeOfDay
                };

                Negocio.MtdEditar(eventoDieta);
                MessageBox.Show("Dieta Editada correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultardietas();
                MtdtrueFilaSelecionada(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoDietas.Text))
            {
                MessageBox.Show("Seleccione una Dieta para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                int codigoDieta = Convert.ToInt32(txtCodigoDietas.Text);

                bool ValidaEliminacion = Negocio.MtdEliminar(codigoDieta);

                if (!ValidaEliminacion)
                {
                    MessageBox.Show("No se pudo eliminar el registro seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("Dieta eliminada correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdDesactivaFilaSeleccionada();
                    MtdConsultardietas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoDietas.Text))
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
            if (dgvDietas.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para exportar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog saveFile = new SaveFileDialog
                {
                    Filter = "Archivo Excel (*.xlsx)|*.xlsx",
                    FileName = "Listado_Dietas"
                };

                if (saveFile.ShowDialog() != DialogResult.OK)
                    return;

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Control Dietas");

                    int colIndex = 1;

                    foreach (DataGridViewColumn col in dgvDietas.Columns)
                    {
                        if (col.Visible && col.Name != "Seleccionar")
                        {
                            ws.Cell(1, colIndex).Value = col.HeaderText;
                            ws.Cell(1, colIndex).Style.Font.Bold = true;
                            colIndex++;
                        }
                    }

                    int rowIndex = 2;

                    foreach (DataGridViewRow row in dgvDietas.Rows)
                    {
                        colIndex = 1;

                        foreach (DataGridViewColumn col in dgvDietas.Columns)
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font tituloFont = new Font("Arial", 16, FontStyle.Bold);
            Font textFont = new Font("Arial", 11);
            Brush brush = Brushes.Black;

            float y = 40;
            float margenizquierdo = 50;

            e.Graphics.DrawString("DATOS DE LA DIETA", tituloFont, brush, margenizquierdo, y); y += 40;
            e.Graphics.DrawString($"Codigo Dieta: {txtCodigoDietas.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Codigo Hospitalizacion: {cbxCodigoHospitalizacion.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Tipo Dieta: {txtTipoConcepto.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Costo Diario: {Convert.ToString(nudCostoDiario.Value)}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Dias: {txtDias.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Nutricionista: {txtNutricionista.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"SubTotal: {Convert.ToString(nudSubTotal.Value)}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Impuesto: {Convert.ToString(nudImpuesto.Value)}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Total Dieta: {Convert.ToString(nudTotalDetalle.Value)}", textFont, brush, margenizquierdo, y); y += 25;
            string estado = rdbActivo.Checked ? "Activo" : "Inactivo";
            e.Graphics.DrawString($"Estado: {estado}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Usuario Sistema: {txtUsuarioSistema.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Fecha Sistema: {dtmFechaSistema.Value.ToString("dd/MM/yyyy")}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Hora Sistema: {dtmHoraSistema.Value.ToString("HH:mm:ss")}", textFont, brush, margenizquierdo, y); y += 25;

        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            dgvDietas.Columns["Seleccionar"].ReadOnly = !chkSeleccionar.Checked;
            btnEditar.Enabled = chkSeleccionar.Checked;

            MtdDesactivaFilaSeleccionada();
        }

        private void txtDias_TextChanged(object sender, EventArgs e)
        {

            nudSubTotal.Value = Convert.ToDecimal(Negocio.mtdDietasSubtotal(nudCostoDiario.Value, Convert.ToInt32("0" + txtDias.Text)));
        }

        private void nudSubTotal_ValueChanged(object sender, EventArgs e)
        {
            nudImpuesto.Value = Convert.ToDecimal(Negocio.mtdDietasImpuesto(nudSubTotal.Value));

            nudTotalDetalle.Value = Convert.ToDecimal(Negocio.mtdTotalDietas(nudSubTotal.Value, nudImpuesto.Value));
        }

        private void nudImpuesto_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
