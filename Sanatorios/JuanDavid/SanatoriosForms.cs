using ClosedXML.Excel;
using Entidad;
using Entidad.JuanDavid;
using Negocio;
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
using static Sanatorios.UsuarioLogueado;

namespace Sanatorios.JuanDavid
{
    public partial class Sanatorios : Form
    {
        SanatoriosNegocio Negocio = new SanatoriosNegocio();
        public Sanatorios()
        {
            InitializeComponent();
        }
        /*-------------*METODOS*-------------*/
        /*  ----- Consultar -----   */
        // Consultar datos de la tabla e imprimir en DataGridView
        private void MtdConsultarControlSanatorios()
        {
            try
            {
                dgvRegistroSanatorios.DataSource = Negocio.MtdConsultar();
                dgvRegistroSanatorios.ClearSelection();
                dgvRegistroSanatorios.CurrentCell = null;
                MtdActualizarTotalRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MtdActualizarTotalRegistros()
        {
            int total = dgvRegistroSanatorios.Rows.Count;

            lblTotalRegistros.Text = $"Cantidad registros: {total}";
        }
        private void MtdLimpiarControlesForm()
        {
            // ---> CAMBIAR: Controles forms


            txtcodigoSanatorio.Clear();
            txtNombreSanatorio.Clear();
            txtUbicacion.Clear();
            nudCapacidad.Value = 0;
            txtTelefono.Clear();
            txtDirector.Clear();
            txtTipoSanatorio.Clear();
            nudCostodiario.Value = 0;
            txtNiveldeservicio.Clear();
            rdbActivo.Checked = false;
            rdbInactivo.Checked = false;

            // ---> CAMBIAR: Nombre del DataGridView
            dgvRegistroSanatorios.ClearSelection();
            dgvRegistroSanatorios.CurrentCell = null;

            foreach (DataGridViewRow row in dgvRegistroSanatorios.Rows)
            {
                row.Cells["Seleccionar"].Value = false;
                row.DefaultCellStyle.BackColor = Color.White;
            }
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
            txtcodigoSanatorio.Enabled = Estado;
            txtNombreSanatorio.Enabled = Estado;
            txtUbicacion.Enabled = Estado;
            nudCapacidad.Enabled = Estado;
            txtTelefono.Enabled = Estado;
            txtDirector.Enabled = Estado;
            txtTipoSanatorio.Enabled = Estado;
            nudCostodiario.Enabled = Estado;
            txtNiveldeservicio.Enabled = Estado;
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
            txtcodigoSanatorio.Enabled = false;
            txtNombreSanatorio.Enabled = true;
            txtUbicacion.Enabled = true;
            nudCapacidad.Enabled = true;
            txtTelefono.Enabled = true;
            txtDirector.Enabled = true;
            txtTipoSanatorio.Enabled = true;
            nudCostodiario.Enabled = true;
            txtNiveldeservicio.Enabled = true;
            rdbActivo.Enabled = true;
            rdbInactivo.Enabled = true;
        }
        private void MtdCargarDatosFilaEnControlesForm(int filaSeleccionada)
        {
            // ---> CAMBIAR: Nombres por Controles del forms <----- //
            var Doctor = (EntidadSanatorios)dgvRegistroSanatorios.Rows[filaSeleccionada].DataBoundItem;

            txtcodigoSanatorio.Text = Doctor.CodigoSanatorio.ToString();
            txtNombreSanatorio.Text = Doctor.Nombre;
            txtUbicacion.Text = Doctor.Ubicacion;
            nudCapacidad.Value = Doctor.CapacidadHabitaciones;
            txtTelefono.Text = Doctor.Telefono;
            txtDirector.Text = Doctor.Director;
            txtTipoSanatorio.Text = Doctor.TipoSanatorio;
            nudCostodiario.Value = Doctor.CostoOperacionDiario;
            txtNiveldeservicio.Text = Doctor.NivelServicio;
            rdbActivo.Checked = Doctor.Estado;
            rdbInactivo.Checked = !Doctor.Estado;
        }
        private int? filaActiva = null;
        private void MtdActivarFilaSeleccionada(int filaSeleccionada)
        {
            // ---> CAMBIAR: Nombre del DataGridView <----- //
            if (filaActiva.HasValue)
            {
                dgvRegistroSanatorios.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvRegistroSanatorios.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = filaSeleccionada;

            dgvRegistroSanatorios.Rows[filaSeleccionada].Cells["Seleccionar"].Value = true;
            dgvRegistroSanatorios.Rows[filaSeleccionada].DefaultCellStyle.BackColor = Color.FromArgb(220, 235, 255);

            MtdCargarDatosFilaEnControlesForm(filaSeleccionada);
            MtdtrueFilaSelecionada(true);
        }
        private void MtdDesactivaFilaSeleccionada()
        {
            // ---> CAMBIAR: Nombre del DataGridView <----- //
            if (filaActiva.HasValue)
            {
                dgvRegistroSanatorios.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvRegistroSanatorios.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = null;

            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
        }


        /*-------------*BOTONES O CAMPOS*-------------*/
        private void LaboratoriosForms_Load(object sender, EventArgs e)
        {
            MtdConsultarControlSanatorios();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<EntidadSanatorios> lista = Negocio.MtdBuscar(txtBuscarNombre.Text.Trim());

                dgvRegistroSanatorios.DataSource = lista;

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

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            MtdLimpiarControlesForm();
            MtdtrueBotonNuevo();

            // ---> CAMBIAR: Nombre Control del forms
            txtcodigoSanatorio.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                EntidadSanatorios controlSanatorios = new EntidadSanatorios
                {
                    Nombre = txtNombreSanatorio.Text,
                    Ubicacion = txtUbicacion.Text,
                    CapacidadHabitaciones = Convert.ToInt32(nudCapacidad.Value),
                    Telefono = txtTelefono.Text,
                    Director = txtDirector.Text,
                    TipoSanatorio = txtTipoSanatorio.Text,
                    CostoOperacionDiario = nudCostodiario.Value,
                    NivelServicio = txtTipoSanatorio.Text,
                    Estado = rdbActivo.Checked,
                    UsuarioSistema = "Consola",
                    FechaSistema = System.DateTime.Today,
                    HoraSistema = System.DateTime.Now.TimeOfDay,
                };

                Negocio.MtdAgregar(controlSanatorios);
                MessageBox.Show("Sanatorio agreagdo correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultarControlSanatorios();
                MtdtrueFilaSelecionada(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcodigoSanatorio.Text))
            {
                MessageBox.Show("Seleccione un Sanatorio para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Guardar valores del combobox
                EntidadSanatorios Sanatorio = new EntidadSanatorios
                {
                    CodigoSanatorio = Convert.ToInt32(txtcodigoSanatorio.Text),
                    Nombre = txtNombreSanatorio.Text,
                    Ubicacion = txtUbicacion.Text,
                    CapacidadHabitaciones = Convert.ToInt32(nudCapacidad.Value),
                    Telefono = txtTelefono.Text,
                    Director = txtDirector.Text,
                    TipoSanatorio = txtTipoSanatorio.Text,
                    CostoOperacionDiario = nudCostodiario.Value,
                    NivelServicio = txtTipoSanatorio.Text,
                    Estado = rdbActivo.Checked,
                    UsuarioSistema = Sesion.NombreUsuario,
                    FechaSistema = System.DateTime.Today,
                    HoraSistema = System.DateTime.Now.TimeOfDay,
                };
                Negocio.MtdEditar(Sanatorio);
                MessageBox.Show("Sanatorio Editado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultarControlSanatorios();
                MtdtrueFilaSelecionada(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
             if (string.IsNullOrWhiteSpace(txtcodigoSanatorio.Text))
            {
                MessageBox.Show("Seleccione un Codigo de Sanatorio para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                int CodigoRenta = Convert.ToInt32(txtcodigoSanatorio.Text);

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
                    MtdConsultarControlSanatorios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRegistroSanatorios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvRegistroSanatorios.Columns[e.ColumnIndex].Name != "Seleccionar")
                return;

            if (!chkSeleccionar.Checked)
                return;

            bool seleccionado = Convert.ToBoolean(
                dgvRegistroSanatorios.Rows[e.RowIndex].Cells["Seleccionar"].Value ?? false);

            if (seleccionado)
                MtdDesactivaFilaSeleccionada();
            else
                MtdActivarFilaSeleccionada(e.RowIndex);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcodigoSanatorio.Text))
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

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font tituloFont = new Font("Arial", 16, FontStyle.Bold);
            Font textFont = new Font("Arial", 11);
            Brush brush = Brushes.Black;

            float y = 40;
            float margenizquierdo = 50;

            // ---> CAMBIAR: cambiar nombres a controles y titutlo

            e.Graphics.DrawString("DATOS DEL SANATORIO", textFont, brush, margenizquierdo, y); y += 40;
            e.Graphics.DrawString($"Codigo de Sanatorio: {txtcodigoSanatorio.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Nombre del Sanatorio: {txtNombreSanatorio.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Ubicacion del Sanatorio: {txtUbicacion.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Cantidad de Habitaciones: {nudCapacidad.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Numero de Telefono: {txtTelefono.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Direccion del Sanatorio: {txtDirector.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Tipo de Sanatorio: {txtTipoSanatorio.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Costo de Operacion Diario: Q{nudCostodiario.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Nivel de Servicio: {txtNiveldeservicio.Text}", textFont, brush, margenizquierdo, y); y += 25;
            string estado = rdbActivo.Checked ? "Activo" : "Inactivo";
            e.Graphics.DrawString($"Estado: {estado}", textFont, brush, margenizquierdo, y); y += 25;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            // ---> CAMBIAR: Nombre a DataGridView
            if (dgvRegistroSanatorios.Rows.Count == 0)
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
                    FileName = "Listado_Sanatorios"
                };

                if (saveFile.ShowDialog() != DialogResult.OK)
                    return;

                // ---> CAMBIAR: Nombre a pestaña de excel (hoja)
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Control de Sanatorios");

                    int colIndex = 1;

                    //  Encabezados 
                    foreach (DataGridViewColumn col in dgvRegistroSanatorios.Columns)
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

                    foreach (DataGridViewRow row in dgvRegistroSanatorios.Rows)
                    {
                        colIndex = 1;

                        foreach (DataGridViewColumn col in dgvRegistroSanatorios.Columns)
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
    }
    
}
