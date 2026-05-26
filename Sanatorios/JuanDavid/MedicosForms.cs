using Negocio.JuanDavid;
using System;
using Entidad;
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
        private void MtdConsultarDoctores()
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
                    FechaSistema = DateTime.Today,
                    HoraSistema = DateTime.Now.TimeOfDay,



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
    }
}
