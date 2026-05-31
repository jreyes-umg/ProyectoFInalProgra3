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
    public partial class TipoServicioForm : Form
    {

        TipoServiciosNegocio Negocio = new TipoServiciosNegocio();

        public TipoServicioForm()
        {
            InitializeComponent();
        }


        private void MtdConsultarTipoServicios()
        {
            try
            {
                dgvTipoServicios.DataSource = Negocio.MtdConsultar();
                dgvTipoServicios.ClearSelection();
                dgvTipoServicios.CurrentCell = null;
                MtdActualizarTotalRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MtdActualizarTotalRegistros()
        {
            int total = dgvTipoServicios.Rows.Count;
            lblTotalRegistros.Text = $"Cantidad registros: {total}";
        }

        private void MtdLimpiarControlesForm()
        {
            txtCodigoTipoServicio.Clear();
            txtNombreServicio.Clear();
            txtNivelComplejidad.Clear();
            txtUsuarioSistema.Clear();

            nudTarifaBase.Value = 0;
            nudRecargoBase.Value = 0;

            rdbActivoEmergencia.Checked = false;
            rdbInactivoEmergencia.Checked = false;
            rdbActivoHospitalizacion.Checked = false;
            rdbInactivoHospitalizacion.Checked = false;
            rdbActivoLaboratorio.Checked = false;
            rdbInactivoLaboratorio.Checked = false;
            rdbActivo.Checked = false;
            rdbInactivo.Checked = false;

            dtmFechaSistema.Value = DateTime.Now;
            dtmHoraSistema.Value = DateTime.Now;

            if (dgvTipoServicios != null)
            {
                dgvTipoServicios.ClearSelection();
                dgvTipoServicios.CurrentCell = null;

                foreach (DataGridViewRow row in dgvTipoServicios.Rows)
                {
                    row.Cells["Seleccionar"].Value = false;
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void MtdCargarDatosFilaEnControlesForm(int filaSeleccionada)
        {
            var TipoServicio = (TipoServicioEntidad)dgvTipoServicios.Rows[filaSeleccionada].DataBoundItem;

            txtCodigoTipoServicio.Text = TipoServicio.CodigoTipoServicio.ToString();
            txtNombreServicio.Text = TipoServicio.NombreServicio;
            nudTarifaBase.Value = TipoServicio.TarifaBase;

            rdbActivoEmergencia.Checked = TipoServicio.AplicaEmergencia;
            rdbInactivoEmergencia.Checked = !TipoServicio.AplicaEmergencia;

            rdbActivoHospitalizacion.Checked = TipoServicio.AplicaHospitalizacion;
            rdbInactivoHospitalizacion.Checked = !TipoServicio.AplicaHospitalizacion;

            rdbActivoLaboratorio.Checked = TipoServicio.AplicaLaboratorio;
            rdbInactivoLaboratorio.Checked = !TipoServicio.AplicaLaboratorio;

            txtNivelComplejidad.Text = TipoServicio.NivelComplejidad;
            nudRecargoBase.Value = TipoServicio.RecargoBase;

            rdbActivo.Checked = TipoServicio.Estado;
            rdbInactivo.Checked = !TipoServicio.Estado;
            txtUsuarioSistema.Text = TipoServicio.UsuarioSistema;

            dtmFechaSistema.Value = TipoServicio.FechaSistema;
            dtmHoraSistema.Value = DateTime.Today.Add(TipoServicio.HoraSistema);
        }

        private int? filaActiva = null;

        private void MtdActivarFilaSeleccionada(int filaSeleccionada)
        {
            if (filaActiva.HasValue)
            {
                dgvTipoServicios.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvTipoServicios.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = filaSeleccionada;

            dgvTipoServicios.Rows[filaSeleccionada].Cells["Seleccionar"].Value = true;
            dgvTipoServicios.Rows[filaSeleccionada].DefaultCellStyle.BackColor = Color.FromArgb(220, 235, 255);

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

            txtCodigoTipoServicio.Enabled = Estado;
            txtNombreServicio.Enabled = Estado;
            nudTarifaBase.Enabled = Estado;

            rdbActivoEmergencia.Enabled = Estado;
            rdbInactivoEmergencia.Enabled = Estado;
            rdbActivoHospitalizacion.Enabled = Estado;
            rdbInactivoHospitalizacion.Enabled = Estado;
            rdbActivoLaboratorio.Enabled = Estado;
            rdbInactivoLaboratorio.Enabled = Estado;

            txtNivelComplejidad.Enabled = Estado;
            nudRecargoBase.Enabled = Estado;

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

            txtCodigoTipoServicio.Enabled = false;

            txtNombreServicio.Enabled = true;
            nudTarifaBase.Enabled = true;

            rdbActivoEmergencia.Enabled = true;
            rdbInactivoEmergencia.Enabled = true;
            rdbActivoHospitalizacion.Enabled = true;
            rdbInactivoHospitalizacion.Enabled = true;
            rdbActivoLaboratorio.Enabled = true;
            rdbInactivoLaboratorio.Enabled = true;

            txtNivelComplejidad.Enabled = true;
            nudRecargoBase.Enabled = true;

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
                dgvTipoServicios.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvTipoServicios.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = null;

            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
        }



        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuarioSistema_TextChanged(object sender, EventArgs e)
        {

        }

        private void TipoServicioForm_Load(object sender, EventArgs e)
        {
            MtdConsultarTipoServicios();
        }

        private void dgvTipoServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvTipoServicios.Columns[e.ColumnIndex].Name != "Seleccionar")
                return;

            if (!chkSeleccionar.Checked)
                return;

            bool seleccionado = Convert.ToBoolean(
                dgvTipoServicios.Rows[e.RowIndex].Cells["Seleccionar"].Value ?? false);

            if (seleccionado)
                MtdDesactivaFilaSeleccionada();
            else
                MtdActivarFilaSeleccionada(e.RowIndex);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MtdLimpiarControlesForm();
            MtdtrueBotonNuevo();
            txtNombreServicio.Focus();
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
                if (!int.TryParse(txtBuscarNombre.Text.Trim(), out int codigoTipoServicioBusqueda))
                {
                    MessageBox.Show("Ingrese un Código de Tipo de Servicio numérico válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<TipoServicioEntidad> lista = Negocio.MtdBuscar(codigoTipoServicioBusqueda);

                dgvTipoServicios.DataSource = lista;

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
            MtdConsultarTipoServicios();

            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
            MtdActualizarTotalRegistros();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                TipoServicioEntidad registroServicio = new TipoServicioEntidad
                {
                    NombreServicio = txtNombreServicio.Text,
                    TarifaBase = nudTarifaBase.Value,
                    AplicaEmergencia = rdbActivoEmergencia.Checked,
                    AplicaHospitalizacion = rdbActivoHospitalizacion.Checked,
                    AplicaLaboratorio = rdbActivoLaboratorio.Checked,
                    NivelComplejidad = txtNivelComplejidad.Text,
                    RecargoBase = nudRecargoBase.Value,
                    Estado = rdbActivo.Checked,
                    UsuarioSistema = txtUsuarioSistema.Text,
                    FechaSistema = dtmFechaSistema.Value.Date,
                    HoraSistema = dtmHoraSistema.Value.TimeOfDay
                };

                Negocio.MtdAgregar(registroServicio);

                MessageBox.Show("Tipo de Servicio agregado correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultarTipoServicios();
                MtdtrueFilaSelecionada(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoTipoServicio.Text))
            {
                MessageBox.Show("Seleccione un Tipo de Servicio para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TipoServicioEntidad registroServicio = new TipoServicioEntidad
                {
                    CodigoTipoServicio = Convert.ToInt32(txtCodigoTipoServicio.Text),
                    NombreServicio = txtNombreServicio.Text,
                    TarifaBase = nudTarifaBase.Value,
                    AplicaEmergencia = rdbActivoEmergencia.Checked,
                    AplicaHospitalizacion = rdbActivoHospitalizacion.Checked,
                    AplicaLaboratorio = rdbActivoLaboratorio.Checked,
                    NivelComplejidad = txtNivelComplejidad.Text,
                    RecargoBase = nudRecargoBase.Value,
                    Estado = rdbActivo.Checked,
                    UsuarioSistema = txtUsuarioSistema.Text,
                    FechaSistema = dtmFechaSistema.Value.Date,
                    HoraSistema = dtmHoraSistema.Value.TimeOfDay
                };

                Negocio.MtdEditar(registroServicio);

                MessageBox.Show("Tipo de Servicio editado correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultarTipoServicios();
                MtdtrueFilaSelecionada(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoTipoServicio.Text))
            {
                MessageBox.Show("Seleccione un Tipo de Servicio para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                int codigoTipoServicio = Convert.ToInt32(txtCodigoTipoServicio.Text);

                bool ValidaEliminacion = Negocio.MtdEliminar(codigoTipoServicio);

                if (!ValidaEliminacion)
                {
                    MessageBox.Show("No se pudo eliminar el registro seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("Tipo de Servicio eliminado correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdDesactivaFilaSeleccionada();
                    MtdConsultarTipoServicios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoTipoServicio.Text))
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
            if (dgvTipoServicios.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para exportar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog saveFile = new SaveFileDialog
                {
                    Filter = "Archivo Excel (*.xlsx)|*.xlsx",
                    FileName = "Listado_TipoServicios"
                };

                if (saveFile.ShowDialog() != DialogResult.OK)
                    return;

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Control Tipo Servicios");

                    int colIndex = 1;

                    foreach (DataGridViewColumn col in dgvTipoServicios.Columns)
                    {
                        if (col.Visible && col.Name != "Seleccionar")
                        {
                            ws.Cell(1, colIndex).Value = col.HeaderText;
                            ws.Cell(1, colIndex).Style.Font.Bold = true;
                            colIndex++;
                        }
                    }

                    int rowIndex = 2;

                    foreach (DataGridViewRow row in dgvTipoServicios.Rows)
                    {
                        colIndex = 1;

                        foreach (DataGridViewColumn col in dgvTipoServicios.Columns)
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

            e.Graphics.DrawString("DATOS DE TIPO DE SERVICIO", tituloFont, brush, margenizquierdo, y); y += 40;
            e.Graphics.DrawString($"Código Tipo Servicio: {txtCodigoTipoServicio.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Nombre Servicio: {txtNombreServicio.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Tarifa Base: {Convert.ToString(nudTarifaBase.Value)}", textFont, brush, margenizquierdo, y); y += 25;

            string emergencia = rdbActivoEmergencia.Checked ? "Sí" : "No";
            e.Graphics.DrawString($"Aplica Emergencia: {emergencia}", textFont, brush, margenizquierdo, y); y += 25;

            string hospitalizacion = rdbActivoHospitalizacion.Checked ? "Sí" : "No";
            e.Graphics.DrawString($"Aplica Hospitalización: {hospitalizacion}", textFont, brush, margenizquierdo, y); y += 25;

            string laboratorio = rdbActivoLaboratorio.Checked ? "Sí" : "No";
            e.Graphics.DrawString($"Aplica Laboratorio: {laboratorio}", textFont, brush, margenizquierdo, y); y += 25;

            e.Graphics.DrawString($"Nivel Complejidad: {txtNivelComplejidad.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Recargo Base: {Convert.ToString(nudRecargoBase.Value)}", textFont, brush, margenizquierdo, y); y += 25;

            string estado = rdbActivo.Checked ? "Activo" : "Inactivo";
            e.Graphics.DrawString($"Estado: {estado}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Usuario Sistema: {txtUsuarioSistema.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Fecha Sistema: {dtmFechaSistema.Value.ToString("dd/MM/yyyy")}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Hora Sistema: {dtmHoraSistema.Value.ToString("HH:mm:ss")}", textFont, brush, margenizquierdo, y); y += 25;
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            dgvTipoServicios.Columns["Seleccionar"].ReadOnly = !chkSeleccionar.Checked;
            btnEditar.Enabled = chkSeleccionar.Checked;

            MtdDesactivaFilaSeleccionada();
        }

        private void nudTarifaBase_ValueChanged(object sender, EventArgs e)
        {
            nudRecargoBase.Value = Convert.ToDecimal(Negocio.mtdrecargobaseTipoServicio(Convert.ToDouble(nudTarifaBase.Value)));
        }
    }
}
