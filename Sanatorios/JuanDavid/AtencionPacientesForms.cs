using ClosedXML.Excel;
using Entidad;
using Entidad.JuanDavid;
using Negocio.JuanDavid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sanatorios.JuanDavid
{
    public partial class AtencionPacientesForms : Form
    {
        AntencionNegocio Negocio = new AntencionNegocio();
        public AtencionPacientesForms()
        {
            InitializeComponent();
        }
        /*-------------*METODOS*-------------*/
        /*  ----- Consultar -----   */
        // Consultar datos de la tabla e imprimir en DataGridView
        private void MtdConsultarControlAtenciones()
        {
            try
            {
                dgvRegistroAtenciones.DataSource = Negocio.MtdConsultar();
                dgvRegistroAtenciones.ClearSelection();
                dgvRegistroAtenciones.CurrentCell = null;
                MtdActualizarTotalRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MtdActualizarTotalRegistros()
        {
            int total = dgvRegistroAtenciones.Rows.Count;

            lblTotalRegistros.Text = $"Cantidad registros: {total}";
        }
        private void MtdLimpiarControlesForm()
        {
            // ---> CAMBIAR: Controles forms


            txtcodigoAtencion.Clear();
            cbxCodigodePaciente.SelectedIndex = 0;
            cbxCodigoMedico.SelectedIndex = 0;
            cbxCodigoTIpoDeservicio.SelectedIndex = 0;
            cbxCodigoSanatorio.SelectedIndex = 0;
            dtpFechaDeatencion.Value = DateTime.Today;
            nudCostoBase.Value = 0;
            nudRecargoEmergencia.Value = 0;
            nudTotal.Value = 0;
            rdbUrgente.Checked = false;
            rdbActivo.Checked = false;
            rdbInactivo.Checked = false;

            // ---> CAMBIAR: Nombre del DataGridView
            dgvRegistroAtenciones.ClearSelection();
            dgvRegistroAtenciones.CurrentCell = null;

            foreach (DataGridViewRow row in dgvRegistroAtenciones.Rows)
            {
                row.Cells["Seleccionar"].Value = false;
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }
        private void MtdCargarDatosFilaEnControlesForm(int filaSeleccionada)
        {
            // ---> CAMBIAR: Nombres por Controles del forms <----- //
            var Atencion = (AntencionPacientesEntidad)dgvRegistroAtenciones.Rows[filaSeleccionada].DataBoundItem;

            txtcodigoAtencion.Text = Atencion.CodigoAtencion.ToString();
            int CodigoPacienteSeleccionado = Atencion.CodigoPaciente;
            foreach (var item in cbxCodigodePaciente.Items)
            {
                var paciente = (dynamic)item;
                int CodigoPacienteItem = (int)paciente.GetType().GetProperty("Value").GetValue(paciente, null);
                if (CodigoPacienteItem == CodigoPacienteSeleccionado)
                {
                    cbxCodigodePaciente.SelectedItem = item;
                    break;
                }
            }
            int CodigoMedicoSeleccionado = Atencion.CodigoMedico;
            foreach (var item in cbxCodigoMedico.Items)
            {
                var Doctor = (dynamic)item;
                int CodigoDcotorItem = (int)Doctor.GetType().GetProperty("Value").GetValue(Doctor, null);
                if (CodigoDcotorItem == CodigoMedicoSeleccionado)
                {
                    cbxCodigoMedico.SelectedItem = item;
                    break;
                }
            }
            int CodigoTipoDeServiciosSeleccionado = Atencion.CodigoTipoServicio;
            foreach (var item in cbxCodigoTIpoDeservicio.Items)
            {
                var TipoDeservicio = (dynamic)item;
                int CodigoTipoDeservicio = (int)TipoDeservicio.GetType().GetProperty("Value").GetValue(TipoDeservicio, null);
                if (CodigoTipoDeservicio == CodigoTipoDeServiciosSeleccionado)
                {
                    cbxCodigoTIpoDeservicio.SelectedItem = item;
                    break;
                }
            }
            int CodigoSanatorioSeleccionado = Atencion.CodigoSanatorio;
            foreach (var item in cbxCodigoSanatorio.Items)
            {
                var Sanatorio = (dynamic)item;
                int CodigoSanatorioItem = (int)Sanatorio.GetType().GetProperty("Value").GetValue(Sanatorio, null);
                if (CodigoSanatorioItem == CodigoSanatorioSeleccionado)
                {
                    cbxCodigoSanatorio.SelectedItem = item;
                    break;
                }
            }
            dtpFechaDeatencion.Value = Atencion.FechaAtencion;
            nudCostoBase.Value = Atencion.CostoBase;
            nudRecargoEmergencia.Value = Atencion.RecargoEmergencia;
            if (Atencion.RecargoEmergencia == 0)
            {
                rdbUrgente.Checked = false;
            }
            else
            {
                rdbUrgente.Checked = true;
            }
            nudTotal.Value = Atencion.TotalAtencion;
            rdbActivo.Checked = Atencion.Estado;
            rdbInactivo.Checked = !Atencion.Estado;
        }
        private int? filaActiva = null;
        private void MtdActivarFilaSeleccionada(int filaSeleccionada)
        {
            // ---> CAMBIAR: Nombre del DataGridView <----- //
            if (filaActiva.HasValue)
            {
                dgvRegistroAtenciones.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvRegistroAtenciones.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = filaSeleccionada;

            dgvRegistroAtenciones.Rows[filaSeleccionada].Cells["Seleccionar"].Value = true;
            dgvRegistroAtenciones.Rows[filaSeleccionada].DefaultCellStyle.BackColor = Color.FromArgb(220, 235, 255);

            MtdCargarDatosFilaEnControlesForm(filaSeleccionada);
            MtdtrueFilaSelecionada(true);
        }
        private void MtdtrueFilaSelecionada(bool Estado)
        {
            // Nombre botones Forms
            btnEditar.Enabled = Estado;
            btnEliminar.Enabled = Estado;
            btnCancelar.Enabled = Estado;
            btnImprimir.Enabled = Estado;
            btnNuevo.Enabled = !Estado;
            btnGuardar.Enabled = false;

            // ---> CAMBIAR: Controles forms
            txtcodigoAtencion.Enabled = Estado;
            cbxCodigodePaciente.Enabled = Estado;
            cbxCodigoMedico.Enabled = Estado;
            cbxCodigoTIpoDeservicio.Enabled = Estado;
            cbxCodigoSanatorio.Enabled = Estado;
            dtpFechaDeatencion.Enabled = Estado;
            nudCostoBase.Enabled = Estado;
            nudRecargoEmergencia.Enabled = Estado;
            nudTotal.Enabled = Estado;
            rdbUrgente.Enabled = Estado;
            rdbActivo.Enabled = Estado;
            rdbInactivo.Enabled = Estado;
        }
        private void MtdtrueBotonNuevo()
        {
            // Nombre botones Forms
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;

            // ---> CAMBIAR: Controles forms
            txtcodigoAtencion.Enabled = true;
            cbxCodigodePaciente.Enabled = true;
            cbxCodigoMedico.Enabled = true;
            cbxCodigoTIpoDeservicio.Enabled = true;
            cbxCodigoSanatorio.Enabled = true;
            dtpFechaDeatencion.Enabled = true;
            nudCostoBase.Enabled = true;
            nudRecargoEmergencia.Enabled = true;
            nudTotal.Enabled = true;
            rdbUrgente.Enabled = true;
            rdbActivo.Enabled = true;
            rdbInactivo.Enabled = true;
        }
        private void MtdDesactivaFilaSeleccionada()
        {
            // ---> CAMBIAR: Nombre del DataGridView <----- //
            if (filaActiva.HasValue)
            {
                dgvRegistroAtenciones.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvRegistroAtenciones.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = null;

            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
        }

        /*-----------COMBOBOX-------------*/
        private void MtdMostrarListaPacientes() // Cambiar nombre del metodo
        {
            var Lista = Negocio.MtdListaPacientes(); // Instanciar clase y cambiar nombre de metodo
            cbxCodigodePaciente.Items.Clear(); //Cambiar el nombre del combobox

            foreach (var Clientes in Lista)
            {
                cbxCodigodePaciente.Items.Add(Clientes); //Cambiar el nombre del combobox
            }
            cbxCodigodePaciente.DisplayMember = "Text"; //Cambiar el nombre del combobox
            cbxCodigodePaciente.ValueMember = "Value"; //Cambiar el nombre del combobox
        }
        private void MtdMostrarListaMedicos() // Cambiar nombre del metodo
        {
            var Lista = Negocio.MtdListaMedicos(); // Instanciar clase y cambiar nombre de metodo
            cbxCodigoMedico.Items.Clear(); //Cambiar el nombre del combobox

            foreach (var Clientes in Lista)
            {
                cbxCodigoMedico.Items.Add(Clientes); //Cambiar el nombre del combobox
            }
            cbxCodigoMedico.DisplayMember = "Text"; //Cambiar el nombre del combobox
            cbxCodigoMedico.ValueMember = "Value"; //Cambiar el nombre del combobox
        }
        private void MtdMostrarListaSanatorios() // Cambiar nombre del metodo
        {
            var Lista = Negocio.MtdListaSanatorios(); // Instanciar clase y cambiar nombre de metodo
            cbxCodigoSanatorio.Items.Clear(); //Cambiar el nombre del combobox

            foreach (var Clientes in Lista)
            {
                cbxCodigoSanatorio.Items.Add(Clientes); //Cambiar el nombre del combobox
            }
            cbxCodigoSanatorio.DisplayMember = "Text"; //Cambiar el nombre del combobox
            cbxCodigoSanatorio.ValueMember = "Value"; //Cambiar el nombre del combobox
        }
        private void MtdListaTiposdeServicios() // Cambiar nombre del metodo
        {
            var Lista = Negocio.MtdListaTiposdeServicios(); // Instanciar clase y cambiar nombre de metodo
            cbxCodigoTIpoDeservicio.Items.Clear(); //Cambiar el nombre del combobox

            foreach (var Clientes in Lista)
            {
                cbxCodigoTIpoDeservicio.Items.Add(Clientes); //Cambiar el nombre del combobox
            }
            cbxCodigoTIpoDeservicio.DisplayMember = "Text"; //Cambiar el nombre del combobox
            cbxCodigoTIpoDeservicio.ValueMember = "Value"; //Cambiar el nombre del combobox
        }

        /*----------------BOTONES-------------------------------------------------------------------------------------------*/
        private void AtencionPacientesForms_Load(object sender, EventArgs e)
        {
            MtdConsultarControlAtenciones();
            MtdMostrarListaPacientes();
            MtdMostrarListaMedicos();
            MtdMostrarListaSanatorios();
            MtdListaTiposdeServicios();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<AntencionPacientesEntidad> lista = Negocio.MtdBuscar(txtBuscarNombre.Text.Trim());

                dgvRegistroAtenciones.DataSource = lista;
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

        private void dgvRegistroAtenciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvRegistroAtenciones.Columns[e.ColumnIndex].Name != "Seleccionar")
                return;

            if (!chkSeleccionar.Checked)
                return;

            bool seleccionado = Convert.ToBoolean(
                dgvRegistroAtenciones.Rows[e.RowIndex].Cells["Seleccionar"].Value ?? false);

            if (seleccionado)
                MtdDesactivaFilaSeleccionada();
            else
                MtdActivarFilaSeleccionada(e.RowIndex);
        }

        private void rdbUrgente_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUrgente.Checked)
            {
                nudRecargoEmergencia.Value = Negocio.MtdRecargoemergencia(nudCostoBase.Value);
            }
            else
            {
                nudRecargoEmergencia.Value = 0;
            }
        }

        private void nudRecargoEmergencia_ValueChanged(object sender, EventArgs e)
        {
            nudTotal.Value = Negocio.MtdTotal(nudCostoBase.Value, nudRecargoEmergencia.Value);
        }

        private void cbxCodigoTIpoDeservicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            var TipoServicio = (dynamic)cbxCodigoTIpoDeservicio.SelectedItem;
            int codigoTipoServicio = (int)TipoServicio.GetType().GetProperty("Value").GetValue(TipoServicio, null);
            nudCostoBase.Value = Negocio.MtdCostoBase(codigoTipoServicio);
        }

        private void nudCostoBase_ValueChanged(object sender, EventArgs e)
        {
            nudTotal.Value = Negocio.MtdTotal(nudCostoBase.Value, nudRecargoEmergencia.Value);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MtdLimpiarControlesForm();
            MtdtrueBotonNuevo();

            // ---> CAMBIAR: Nombre Control del forms
            txtcodigoAtencion.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                var Pacente = (dynamic)cbxCodigodePaciente.SelectedItem;
                int codigoPacente = (int)Pacente.GetType().GetProperty("Value").GetValue(Pacente, null);
                var Medico = (dynamic)cbxCodigoMedico.SelectedItem;
                int codigoMedico = (int)Medico.GetType().GetProperty("Value").GetValue(Medico, null);
                var TipoServicio = (dynamic)cbxCodigoTIpoDeservicio.SelectedItem;
                int codigoTipoServicio = (int)TipoServicio.GetType().GetProperty("Value").GetValue(TipoServicio, null);
                var Sanatorio = (dynamic)cbxCodigoSanatorio.SelectedItem;
                int codigoSanatorio = (int)Sanatorio.GetType().GetProperty("Value").GetValue(Sanatorio, null);

                AntencionPacientesEntidad ControlAtencion = new AntencionPacientesEntidad
                {

                    CodigoPaciente = codigoPacente,
                    CodigoMedico = codigoMedico,
                    CodigoTipoServicio = codigoTipoServicio,
                    CodigoSanatorio = codigoSanatorio,
                    FechaAtencion = dtpFechaDeatencion.Value,
                    CostoBase = nudCostoBase.Value,
                    RecargoEmergencia = nudRecargoEmergencia.Value,
                    TotalAtencion = nudTotal.Value,
                    Estado = rdbActivo.Checked,
                    UsuarioSistema = "Consola",
                    FechaSistema = System.DateTime.Today,
                    HoraSistema = System.DateTime.Now.TimeOfDay,

                };

                Negocio.MtdAgregar(ControlAtencion);
                MessageBox.Show("Atencion agregada correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultarControlAtenciones();
                MtdtrueFilaSelecionada(false);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcodigoAtencion.Text))
            {
                MessageBox.Show("Seleccione una Atencion para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var Pacente = (dynamic)cbxCodigodePaciente.SelectedItem;
                int codigoPacente = (int)Pacente.GetType().GetProperty("Value").GetValue(Pacente, null);
                var Medico = (dynamic)cbxCodigoMedico.SelectedItem;
                int codigoMedico = (int)Medico.GetType().GetProperty("Value").GetValue(Medico, null);
                var TipoServicio = (dynamic)cbxCodigoTIpoDeservicio.SelectedItem;
                int codigoTipoServicio = (int)TipoServicio.GetType().GetProperty("Value").GetValue(TipoServicio, null);
                var Sanatorio = (dynamic)cbxCodigoSanatorio.SelectedItem;
                int codigoSanatorio = (int)Sanatorio.GetType().GetProperty("Value").GetValue(Sanatorio, null);
                AntencionPacientesEntidad ControlAtencion = new AntencionPacientesEntidad
                {
                    CodigoAtencion = Convert.ToInt32(txtcodigoAtencion.Text),
                    CodigoPaciente = codigoPacente,
                    CodigoMedico = codigoMedico,
                    CodigoTipoServicio = codigoTipoServicio,
                    CodigoSanatorio = codigoSanatorio,
                    FechaAtencion = dtpFechaDeatencion.Value,
                    CostoBase = nudCostoBase.Value,
                    RecargoEmergencia = nudRecargoEmergencia.Value,
                    TotalAtencion = nudTotal.Value,
                    Estado = rdbActivo.Checked,
                    UsuarioSistema = "Consola",
                    FechaSistema = System.DateTime.Today,
                    HoraSistema = System.DateTime.Now.TimeOfDay,

                };
                Negocio.MtdEditar(ControlAtencion);
                MessageBox.Show("Atencion Editada correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultarControlAtenciones();
                MtdtrueFilaSelecionada(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcodigoAtencion.Text))
            {
                MessageBox.Show("Seleccione un Codigo de Atencion para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar el registro de la Atencion seleccionado?", "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                int CodigoAtencion = Convert.ToInt32(txtcodigoAtencion.Text);

                bool ValidaEliminacion = Negocio.MtdEliminar(CodigoAtencion);

                if (!ValidaEliminacion)
                {
                    MessageBox.Show("No se pudo eliminar el registro seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {

                    MessageBox.Show("Atencion eliminada correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdDesactivaFilaSeleccionada();
                    MtdConsultarControlAtenciones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar asdasdasdds", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            dgvRegistroAtenciones.Columns["Seleccionar"].ReadOnly = !chkSeleccionar.Checked;
            btnEditar.Enabled = chkSeleccionar.Checked;
            MtdDesactivaFilaSeleccionada();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font tituloFont = new Font("Arial", 16, FontStyle.Bold);
            Font textFont = new Font("Arial", 11);
            Brush brush = Brushes.Black;

            float y = 40;
            float margenizquierdo = 50;

            // ---> CAMBIAR: cambiar nombres a controles y titutlo

            e.Graphics.DrawString("DATOS DE LA ATENCION", textFont, brush, margenizquierdo, y); y += 40;
            e.Graphics.DrawString($"Codigo de Atencion: {txtcodigoAtencion.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Codigo Paciente: {cbxCodigodePaciente.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Codigo Medico: {cbxCodigoMedico.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Codigo Tipo de Servicio: {cbxCodigoTIpoDeservicio.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Codigo Sanatorio: {cbxCodigoSanatorio.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Fecha de la Atencion: {dtpFechaDeatencion.Value:d}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Costo Base: {nudCostoBase.Text}", textFont, brush, margenizquierdo, y); y += 25;
            string Urgente = rdbUrgente.Checked ? "Urgente" : "Normal";
            e.Graphics.DrawString($"Importancia: {Urgente}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Recargo Por Emergencia: {nudRecargoEmergencia.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Total de la Atencion {nudTotal.Text}", textFont, brush, margenizquierdo, y); y += 25;
            string estado = rdbActivo.Checked ? "Activo" : "Inactivo";
            e.Graphics.DrawString($"Estado: {estado}", textFont, brush, margenizquierdo, y); y += 25;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            // ---> CAMBIAR: Nombre a DataGridView
            if (dgvRegistroAtenciones.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para exportar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // ---> CAMBIAR: Nombre al archivo de excel a exportar
                SaveFileDialog saveFile = new SaveFileDialog
                {
                    Filter = "Archivo Excel (*.xlsx)|*.xlsx",
                    FileName = "Listado_Atenciones"
                };

                if (saveFile.ShowDialog() != DialogResult.OK)
                    return;

                // ---> CAMBIAR: Nombre a pestaña de excel (hoja)
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Control Atenciones");

                    int colIndex = 1;

                    //  Encabezados 
                    foreach (DataGridViewColumn col in dgvRegistroAtenciones.Columns)
                    {
                        if (col.Visible && col.Name != "Seleccionar")
                        {
                            ws.Cell(1, colIndex).Value = col.HeaderText;
                            ws.Cell(1, colIndex).Style.Font.Bold = true;
                            colIndex++;
                        }
                    }

                    //  Datos DataGridView
                    int rowIndex = 2;

                    foreach (DataGridViewRow row in dgvRegistroAtenciones.Rows)
                    {
                        colIndex = 1;

                        foreach (DataGridViewColumn col in dgvRegistroAtenciones.Columns)
                        {
                            if (col.Visible && col.Name != "Seleccionar")
                            {
                                object valorCelda = row.Cells[col.Name].Value;

                                if (valorCelda is System.DateTime fecha)
                                {
                                    // Mostrar solo fecha (sin hora)
                                    ws.Cell(rowIndex, colIndex).Value = fecha.ToString("dd/MM/yyyy");
                                }
                                else if (valorCelda is bool estado)
                                {
                                    // Convertir true / false a Activo / Inactivo
                                    ws.Cell(rowIndex, colIndex).Value = estado ? "Activo" : "Inactivo";
                                }
                                else
                                {
                                    // Mostrar valores con formato del datagridview
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarNombre.Clear();
            MtdConsultarControlAtenciones();

            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
            MtdActualizarTotalRegistros();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcodigoAtencion.Text))
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
    }
    
}
