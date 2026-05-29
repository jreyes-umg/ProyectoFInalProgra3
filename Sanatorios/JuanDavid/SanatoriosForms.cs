using Entidad;
using Entidad.JuanDavid;
using Negocio;
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
                    UsuarioSistema = "Consola",
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
    }
}
