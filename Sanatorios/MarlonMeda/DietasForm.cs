using Entidad.MarlonMeda;
using Negocio.MarlonMeda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void MtdConsultarDoctores()
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

        private void MtdLimpiarControlesForm()
        {
            // ---> CAMBIAR: Controles forms de Dietas

            // Campos de texto y ComboBox
            txtCodigoDietas.Clear();
            cbxCodigoHospitalizacion.SelectedIndex = -1; // O cbxCodigoHospitalizacion.Text = "";
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
            // Asumiendo que el DataGridView se llama dgvRegistroDietas (probablemente en la pestaña 'Consulta')
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
            cbxCodigoHospitalizacion.Text = Dieta.CodigoHospitalizacion.ToString();
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
            // Nombre botones Forms (Asumiendo que conservas los mismos nombres de botones)
            btnEditar.Enabled = Estado;
            btnEliminar.Enabled = Estado;
            btnCancelar.Enabled = Estado;
            btnImprimir.Enabled = Estado;
            btnNuevo.Enabled = !Estado;
            btnGuardar.Enabled = false;

            // ---> CAMBIAR: Controles forms de Dietas
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
            // Nombre botones Forms
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

        private void DietasForm_Load(object sender, EventArgs e)
        {
            MtdConsultardietas();
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
    }
}
