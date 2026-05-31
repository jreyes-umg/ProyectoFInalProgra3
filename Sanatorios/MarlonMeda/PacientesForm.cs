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
    public partial class PacientesForm : Form
    {
        PacientesNegocio Negocio = new PacientesNegocio();
        
        public PacientesForm()
        {
            InitializeComponent();
        }

        private void MtdConsultarPacientes()
        {
            try
            {      dgvHospitalizaciones.DataSource = Negocio.MtdConsultar();
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
            txtCodigoPacientes.Clear();
            txtNombrePaciente.Clear();
            txtApellidoPaciente.Clear(); 
            txtDpi.Clear(); 
            txtGenero.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtEdad.Clear();
            txtUsuarioSistema.Clear();

            dtpFechaNacimiento.Value = DateTime.Now;

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
            var Paciente = (PacientesEntidad)dgvHospitalizaciones.Rows[filaSeleccionada].DataBoundItem;

            txtCodigoPacientes.Text = Paciente.CodigoPaciente.ToString();
            txtNombrePaciente.Text = Paciente.Nombre;
            txtApellidoPaciente.Text = Paciente.Apellido;
            txtDpi.Text = Paciente.Dpi.ToString();
            dtpFechaNacimiento.Value = Paciente.FechaNacimiento;
            txtGenero.Text = Paciente.Genero;
            txtTelefono.Text = Paciente.Telefono;
            txtDireccion.Text = Paciente.Direccion;
            txtEdad.Text = Paciente.Edad.ToString();

            rdbActivo.Checked = Paciente.Estado;
            rdbInactivo.Checked = !Paciente.Estado;
            txtUsuarioSistema.Text = Paciente.UsuarioSistema;

            dtmFechaSistema.Value = Paciente.FechaSistema;
            dtmHoraSistema.Value = DateTime.Today.Add(Paciente.HoraSistema);
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

            txtCodigoPacientes.Enabled = Estado;
            txtNombrePaciente.Enabled = Estado;
            txtApellidoPaciente.Enabled = Estado;
            txtDpi.Enabled = Estado;
            dtpFechaNacimiento.Enabled = Estado;
            txtGenero.Enabled = Estado;
            txtTelefono.Enabled = Estado;
            txtDireccion.Enabled = Estado;
            txtEdad.Enabled = Estado;

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

            txtCodigoPacientes.Enabled = false;

            txtNombrePaciente.Enabled = true;
            txtApellidoPaciente.Enabled = true;
            txtDpi.Enabled = true;
            dtpFechaNacimiento.Enabled = true;
            txtGenero.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
            txtEdad.Enabled = true;

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void PacientesForm_Load(object sender, EventArgs e)
        {
            MtdConsultarPacientes();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MtdLimpiarControlesForm();
            MtdtrueBotonNuevo();
            txtNombrePaciente.Focus();
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
                if (!int.TryParse(txtBuscarNombre.Text.Trim(), out int codigoPacienteBusqueda))
                {
                    MessageBox.Show("Ingrese un Código de Paciente numérico válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<PacientesEntidad> lista = Negocio.MtdBuscar(codigoPacienteBusqueda);

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
            MtdConsultarPacientes();

            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
            MtdActualizarTotalRegistros();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                PacientesEntidad controlPaciente = new PacientesEntidad
                {
                    Nombre = txtNombrePaciente.Text,
                    Apellido = txtApellidoPaciente.Text,
                    Dpi = Convert.ToInt64(txtDpi.Text),
                    FechaNacimiento = dtpFechaNacimiento.Value.Date,
                    Genero = txtGenero.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    Edad = Convert.ToInt32(txtEdad.Text),
                    Estado = rdbActivo.Checked,
                    UsuarioSistema = txtUsuarioSistema.Text,
                    FechaSistema = dtmFechaSistema.Value.Date,
                    HoraSistema = dtmHoraSistema.Value.TimeOfDay
                };

                Negocio.MtdAgregar(controlPaciente);

                MessageBox.Show("Paciente agregado correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultarPacientes();
                MtdtrueFilaSelecionada(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoPacientes.Text))
            {
                MessageBox.Show("Seleccione un Paciente para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PacientesEntidad controlPaciente = new PacientesEntidad
                {
                    CodigoPaciente = Convert.ToInt32(txtCodigoPacientes.Text),
                    Nombre = txtNombrePaciente.Text,
                    Apellido = txtApellidoPaciente.Text,
                    Dpi = Convert.ToInt64(txtDpi.Text),
                    FechaNacimiento = dtpFechaNacimiento.Value.Date,
                    Genero = txtGenero.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    Edad = Convert.ToInt32(txtEdad.Text),
                    Estado = rdbActivo.Checked,
                    UsuarioSistema = txtUsuarioSistema.Text,
                    FechaSistema = dtmFechaSistema.Value.Date,
                    HoraSistema = dtmHoraSistema.Value.TimeOfDay
                };

                Negocio.MtdEditar(controlPaciente);

                MessageBox.Show("Paciente editado correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultarPacientes();
                MtdtrueFilaSelecionada(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoPacientes.Text))
            {
                MessageBox.Show("Seleccione un Paciente para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                int codigoPaciente = Convert.ToInt32(txtCodigoPacientes.Text);

                bool ValidaEliminacion = Negocio.MtdEliminar(codigoPaciente);

                if (!ValidaEliminacion)
                {
                    MessageBox.Show("No se pudo eliminar el registro seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("Paciente eliminado correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdDesactivaFilaSeleccionada();
                    MtdConsultarPacientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoPacientes.Text))
            {
                MessageBox.Show("Seleccione un registro a imprimir", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                printDocument1.DefaultPageSettings.Margins = new Margins(20, 20, 20, 20);

                int AltoDocumento = 400;
                int AnchoDocumento = 450;

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
                    FileName = "Listado_Pacientes"
                };

                if (saveFile.ShowDialog() != DialogResult.OK)
                    return;

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Control Pacientes");

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

            e.Graphics.DrawString("DATOS DEL PACIENTE", tituloFont, brush, margenizquierdo, y); y += 40;
            e.Graphics.DrawString($"Código Paciente: {txtCodigoPacientes.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Nombre: {txtNombrePaciente.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Apellido: {txtApellidoPaciente.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"DPI: {txtDpi.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Fecha Nacimiento: {dtpFechaNacimiento.Value.ToString("dd/MM/yyyy")}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Género: {txtGenero.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Teléfono: {txtTelefono.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Dirección: {txtDireccion.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Edad: {txtEdad.Text}", textFont, brush, margenizquierdo, y); y += 25;

            string estado = rdbActivo.Checked ? "Activo" : "Inactivo";
            e.Graphics.DrawString($"Estado: {estado}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Usuario Sistema: {txtUsuarioSistema.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Fecha Sistema: {dtmFechaSistema.Value.ToString("dd/MM/yyyy")}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Hora Sistema: {dtmHoraSistema.Value.ToString("HH:mm:ss")}", textFont, brush, margenizquierdo, y); y += 25;
        }

       

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            txtEdad.Text = Negocio.mtdEdadPaciente(dtpFechaNacimiento.Value.Year).ToString();
           
        }
    }
}
