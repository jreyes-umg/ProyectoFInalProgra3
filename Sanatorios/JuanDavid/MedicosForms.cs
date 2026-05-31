using ClosedXML.Excel;
using Entidad;
using Negocio.JuanDavid;
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
using static ClosedXML.Excel.XLPredefinedFormat;

namespace Sanatorios
{
    public partial class MedicosForms : Form
    {
        MedicosNegocio Negocio = new MedicosNegocio();
        MeedicosEntidad Entidad = new MeedicosEntidad();
        public MedicosForms()
        {
            InitializeComponent();
        }
        /*-------------*METODOS*-------------*/
        /*  ----- Consultar -----   */
        // Consultar datos de la tabla e imprimir en DataGridView
        private void MtdConsultarControlDoctores()
        {
            try
            {
                dgvRegistroMedicos.DataSource = Negocio.MtdConsultar();
                dgvRegistroMedicos.ClearSelection();
                dgvRegistroMedicos.CurrentCell = null;
                MtdActualizarTotalRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MtdActualizarTotalRegistros()
        {
            int total = dgvRegistroMedicos.Rows.Count;

            lblTotalRegistros.Text = $"Cantidad registros: {total}";
        }
        
        private void MtdLimpiarControlesForm()
        {
            // ---> CAMBIAR: Controles forms


            txtCodigomedico.Clear();
            txtNombreDoctor.Clear();
            txtApellidoDoctor.Clear();
            txtEspecialidad.Clear();
            txtTelefono.Clear();
            txtcorreo.Clear();
            nudhonorarioBase.Value = 0;
            nudAñosdeexperiencia.Value = 0;
            nudBonoporexperiencia.Value = 0;
            
            rdbActivo.Checked = false;
            rdbInactivo.Checked = false;

            // ---> CAMBIAR: Nombre del DataGridView
            dgvRegistroMedicos.ClearSelection();
            dgvRegistroMedicos.CurrentCell = null;

            foreach (DataGridViewRow row in dgvRegistroMedicos.Rows)
            {
                row.Cells["Seleccionar"].Value = false;
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }
        private void MtdCargarDatosFilaEnControlesForm(int filaSeleccionada)
        {
            // ---> CAMBIAR: Nombres por Controles del forms <----- //
            var Doctor = (MeedicosEntidad)dgvRegistroMedicos.Rows[filaSeleccionada].DataBoundItem;

            txtCodigomedico.Text = Doctor.CodigoMedico.ToString();
            txtNombreDoctor.Text = Doctor.Nombre;
            txtApellidoDoctor.Text = Doctor.Apellido;
            txtEspecialidad.Text = Doctor.Especialidad;
            txtTelefono.Text = Doctor.Telefono;
            txtcorreo.Text = Doctor.Correo;
            nudhonorarioBase.Value = Doctor.HonorarioBase;
            nudAñosdeexperiencia.Value = Doctor.AniosExperiencia;
            nudBonoporexperiencia.Value = Doctor.BonoExperiencia;
            rdbActivo.Checked = Doctor.Estado;
            rdbInactivo.Checked = !Doctor.Estado;
        }
        private int? filaActiva = null;
        private void MtdActivarFilaSeleccionada(int filaSeleccionada)
        {
            // ---> CAMBIAR: Nombre del DataGridView <----- //
            if (filaActiva.HasValue)
            {
                dgvRegistroMedicos.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvRegistroMedicos.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = filaSeleccionada;

            dgvRegistroMedicos.Rows[filaSeleccionada].Cells["Seleccionar"].Value = true;
            dgvRegistroMedicos.Rows[filaSeleccionada].DefaultCellStyle.BackColor = Color.FromArgb(220, 235, 255);

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
            txtCodigomedico.Enabled = Estado;
            txtNombreDoctor.Enabled = Estado;
            txtApellidoDoctor.Enabled = Estado;
            txtEspecialidad.Enabled = Estado;
            txtTelefono.Enabled = Estado;
            txtcorreo.Enabled = Estado;
            nudhonorarioBase.Enabled = Estado;
            nudAñosdeexperiencia.Enabled = Estado;
            nudBonoporexperiencia.Enabled = Estado;
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
            txtCodigomedico.Enabled = false;
            txtNombreDoctor.Enabled = true;
            txtApellidoDoctor.Enabled = true;
            txtEspecialidad.Enabled = true;
            txtTelefono.Enabled = true;
            txtcorreo.Enabled = true;
            nudhonorarioBase.Enabled = true;
            nudAñosdeexperiencia.Enabled = true;
            nudBonoporexperiencia.Enabled = true;
            rdbActivo.Enabled = true;
            rdbInactivo.Enabled = true;
        }
        private void MtdDesactivaFilaSeleccionada()
        {
            // ---> CAMBIAR: Nombre del DataGridView <----- //
            if (filaActiva.HasValue)
            {
                dgvRegistroMedicos.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvRegistroMedicos.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = null;

            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
        }

        /*-------------*BOTONES O CAMPOS*-------------*/
        private void MedicosForms_Load(object sender, EventArgs e)
        {
            MtdConsultarControlDoctores();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MtdLimpiarControlesForm();
            MtdtrueBotonNuevo();

            // ---> CAMBIAR: Nombre Control del forms
            txtCodigomedico.Focus();
        }

        private void dgvRegistroMedicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvRegistroMedicos.Columns[e.ColumnIndex].Name != "Seleccionar")
                return;

            if (!chkSeleccionar.Checked)
                return;

            bool seleccionado = Convert.ToBoolean(
                dgvRegistroMedicos.Rows[e.RowIndex].Cells["Seleccionar"].Value ?? false);

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

        private void nudAñosdeexperiencia_ValueChanged(object sender, EventArgs e)
        {
            nudBonoporexperiencia.Value= Negocio.BonoExperiencia(nudAñosdeexperiencia.Value);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<MeedicosEntidad> lista = Negocio.MtdBuscar(txtBuscarNombre.Text.Trim());

                dgvRegistroMedicos.DataSource = lista;

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
            {
                txtBuscarNombre.Clear();
                MtdConsultarControlDoctores();

                MtdLimpiarControlesForm();
                MtdtrueFilaSelecionada(false);
                MtdActualizarTotalRegistros();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                MeedicosEntidad controlMedicos = new MeedicosEntidad
                {
                    Nombre = txtNombreDoctor.Text,
                    Apellido = txtApellidoDoctor.Text,
                    Especialidad = txtEspecialidad.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtcorreo.Text,
                    HonorarioBase = nudhonorarioBase.Value,
                    AniosExperiencia = Convert.ToInt32(nudAñosdeexperiencia.Value),
                    BonoExperiencia = nudBonoporexperiencia.Value,
                    Estado = rdbActivo.Checked,
                    UsuarioSistema = "Consola",
                    FechaSistema = System.DateTime.Today,
                    HoraSistema = System.DateTime.Now.TimeOfDay,



                };

                Negocio.MtdAgregar(controlMedicos);
                MessageBox.Show("Docotor agreagdo correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultarControlDoctores();
                MtdtrueFilaSelecionada(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigomedico.Text))
            {
                MessageBox.Show("Seleccione un Docotor para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           

            try
            {

                // Guardar valores del combobox
                MeedicosEntidad evento = new MeedicosEntidad
                {
                    CodigoMedico = Convert.ToInt32(txtCodigomedico.Text),
                    Nombre = txtNombreDoctor.Text,
                    Apellido = txtApellidoDoctor.Text,
                    Especialidad = txtEspecialidad.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtcorreo.Text,
                    HonorarioBase = nudhonorarioBase.Value,
                    AniosExperiencia = Convert.ToInt32(nudAñosdeexperiencia.Value),
                    BonoExperiencia = nudBonoporexperiencia.Value,
                    Estado = rdbActivo.Checked,
                    UsuarioSistema = "Consola",
                    FechaSistema = System.DateTime.Today,
                    HoraSistema = System.DateTime.Now.TimeOfDay,   
                }; 
                Negocio.MtdEditar(evento);
                MessageBox.Show("Evento Editado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultarControlDoctores();
                MtdtrueFilaSelecionada(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigomedico.Text))
            {
                MessageBox.Show("Seleccione un Codigo de Docotor para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                int CodigoRenta = Convert.ToInt32(txtCodigomedico.Text);

                bool ValidaEliminacion = Negocio.MtdEliminar(CodigoRenta);

                if (!ValidaEliminacion)
                {
                    MessageBox.Show("No se pudo eliminar el registro seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {

                    MessageBox.Show("Docotor eliminado correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdDesactivaFilaSeleccionada();
                    MtdConsultarControlDoctores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigomedico.Text))
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
            // ---> CAMBIAR: Nombre a DataGridView
            if (dgvRegistroMedicos.Rows.Count == 0)
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
                    FileName = "Listado_Doctores"
                };

                if (saveFile.ShowDialog() != DialogResult.OK)
                    return;

                // ---> CAMBIAR: Nombre a pestaña de excel (hoja)
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Control Doctores");

                    int colIndex = 1;

                    //  Encabezados 
                    foreach (DataGridViewColumn col in dgvRegistroMedicos.Columns)
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

                    foreach (DataGridViewRow row in dgvRegistroMedicos.Rows)
                    {
                        colIndex = 1;

                        foreach (DataGridViewColumn col in dgvRegistroMedicos.Columns)
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

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font tituloFont = new Font("Arial", 16, FontStyle.Bold);
            Font textFont = new Font("Arial", 11);
            Brush brush = Brushes.Black;

            float y = 40;
            float margenizquierdo = 50;

            // ---> CAMBIAR: cambiar nombres a controles y titutlo

            e.Graphics.DrawString("DATOS DEL DOCOTOR", textFont, brush, margenizquierdo, y); y += 40;
            e.Graphics.DrawString($"Codigo Medico: {txtCodigomedico.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Nombre del Docotor: {txtNombreDoctor.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Apellido del Docotor: {txtApellidoDoctor.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Especialidad: {txtEspecialidad.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Telefono: {txtTelefono.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Correo Electronico: {txtcorreo.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Honorario Base: {Convert.ToString(nudhonorarioBase.Value)}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Años de Experiencia: {Convert.ToString(nudAñosdeexperiencia.Value)} Años", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Bono Por sus Años de Experiencia: {Convert.ToString(nudBonoporexperiencia.Value)}", textFont, brush, margenizquierdo, y); y += 25;
            string estado = rdbActivo.Checked ? "Activo" : "Inactivo";
            e.Graphics.DrawString($"Estado: {estado}", textFont, brush, margenizquierdo, y); y += 25;

        }
    }
}
