using Entidad.JuanDavid;
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
    public partial class LaboratoriosForms : Form
    {
        LaboratoriosNegocio Negocio = new LaboratoriosNegocio();
        public LaboratoriosForms()
        {
            InitializeComponent();
        }
        /*-------------*METODOS*-------------*/
        /*  ----- Consultar -----   */
        // Consultar datos de la tabla e imprimir en DataGridView
        private void MtdConsultarControlLaboratorios()
        {
            try
            {
                dgvRegistroLaboratorios.DataSource = Negocio.MtdConsultar();
                dgvRegistroLaboratorios.ClearSelection();
                dgvRegistroLaboratorios.CurrentCell = null;
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


            txtcodigoLaboratorio.Clear();
            cbxCodigodeatencion.SelectedIndex = -1;
            txtTipoExamen.Clear();
            nudCostoExamen.Value = 0;
            nudCantidad.Value = 0;
            nudRecargoUrgencia.Value = 0;
            nudSubtotal.Value = 0;
            nudTotalLaboratorio.Value = 0;
            chkUrgente.Checked = false;
            rdbActivo.Checked = false;
            rdbInactivo.Checked = false;

            // ---> CAMBIAR: Nombre del DataGridView
            dgvRegistroLaboratorios.ClearSelection();
            dgvRegistroLaboratorios.CurrentCell = null;

            foreach (DataGridViewRow row in dgvRegistroLaboratorios.Rows)
            {
                row.Cells["Seleccionar"].Value = false;
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }
        private void MtdCargarDatosFilaEnControlesForm(int filaSeleccionada)
        {
            // ---> CAMBIAR: Nombres por Controles del forms <----- //
            var Atencion = (LaboratoriosEntidad)dgvRegistroLaboratorios.Rows[filaSeleccionada].DataBoundItem;

            txtcodigoLaboratorio.Text = Convert.ToString(Atencion.CodigoLaboratorio);
            int CodigoAtencionSeleccionado = Atencion.CodigoAtencion;
            foreach (var item in cbxCodigodeatencion.Items)
            {
                var Laboratorio = (dynamic)item;
                int CodigoLaboratorioItem = (int)Laboratorio.GetType().GetProperty("Value").GetValue(Laboratorio, null);
                if (CodigoLaboratorioItem == CodigoAtencionSeleccionado)
                {
                    cbxCodigodeatencion.SelectedItem = item;
                    break;
                }
            }
            txtTipoExamen.Text = Atencion.TipoExamen;
            nudCostoExamen.Value = Atencion.CostoExamen;
            nudCantidad.Value = Atencion.Cantidad;
            nudRecargoUrgencia.Value = Atencion.RecargoUrgente;
            if (Atencion.RecargoUrgente == 0)
            {
                chkUrgente.Checked = false;
            }
            else
            {
                chkUrgente.Checked = true;
            }
            nudSubtotal.Value = Atencion.SubTotal;
            nudTotalLaboratorio.Value = Atencion.TotalLaboratorio;
            rdbActivo.Checked = Atencion.Estado;
            rdbInactivo.Checked = !Atencion.Estado;
        }
        private int? filaActiva = null;
        private void MtdActivarFilaSeleccionada(int filaSeleccionada)
        {
            // ---> CAMBIAR: Nombre del DataGridView <----- //
            if (filaActiva.HasValue)
            {
                dgvRegistroLaboratorios.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvRegistroLaboratorios.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = filaSeleccionada;

            dgvRegistroLaboratorios.Rows[filaSeleccionada].Cells["Seleccionar"].Value = true;
            dgvRegistroLaboratorios.Rows[filaSeleccionada].DefaultCellStyle.BackColor = Color.FromArgb(220, 235, 255);

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

            cbxCodigodeatencion.Enabled = Estado;
            txtTipoExamen.Enabled = Estado;
            nudCostoExamen.Enabled = Estado;
            nudCantidad.Enabled = Estado;
            chkUrgente.Enabled = Estado;
            nudRecargoUrgencia.Enabled = Estado;
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
            cbxCodigodeatencion.Enabled = true;
            txtTipoExamen.Enabled = true;
            nudCostoExamen.Enabled = true;
            nudCantidad.Enabled = true;
            chkUrgente.Enabled = true;
            nudRecargoUrgencia.Enabled = true;
            rdbActivo.Enabled = true;
            rdbInactivo.Enabled = true;
        }
        private void MtdActualizarTotalRegistros()
        {
            int total = dgvRegistroLaboratorios.Rows.Count;

            lblTotalRegistros.Text = $"Cantidad registros: {total}";
        }
        private void MtdDesactivaFilaSeleccionada()
        {
            // ---> CAMBIAR: Nombre del DataGridView <----- //
            if (filaActiva.HasValue)
            {
                dgvRegistroLaboratorios.Rows[filaActiva.Value].Cells["Seleccionar"].Value = false;
                dgvRegistroLaboratorios.Rows[filaActiva.Value].DefaultCellStyle.BackColor = Color.White;
            }

            filaActiva = null;

            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
        }
        /*-----------COMBOBOX-------------*/
        private void MtdMostrarListaAtenciones() // Cambiar nombre del metodo
        {
            var Lista = Negocio.MtdListarAtenciones(); // Instanciar clase y cambiar nombre de metodo
            cbxCodigodeatencion.Items.Clear(); //Cambiar el nombre del combobox

            foreach (var Clientes in Lista)
            {
                cbxCodigodeatencion.Items.Add(Clientes); //Cambiar el nombre del combobox
            }
            cbxCodigodeatencion.DisplayMember = "Text"; //Cambiar el nombre del combobox
            cbxCodigodeatencion.ValueMember = "Value"; //Cambiar el nombre del combobox
        }
        /*----------------BOTONES-------------------------------------------------------------------------------------------*/
        private void LaboratoriosForms_Load(object sender, EventArgs e)
        {
            MtdConsultarControlLaboratorios();
            MtdMostrarListaAtenciones();
        }

        private void nudCostoExamen_ValueChanged(object sender, EventArgs e)
        {
            nudSubtotal.Value = Negocio.CalcularSubtotal(nudCostoExamen.Value, Convert.ToInt32(nudCantidad.Value));
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            nudSubtotal.Value = Negocio.CalcularSubtotal(nudCostoExamen.Value, Convert.ToInt32(nudCantidad.Value));
        }

        private void chkUrgente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUrgente.Checked == true)
            {
                nudRecargoUrgencia.Value = Negocio.CalcularRecargoUrgente(nudSubtotal.Value);
            }
            else
            {
                nudRecargoUrgencia.Value = 0;
            }
            nudTotalLaboratorio.Value = Negocio.CalcularTotalLaboratorio(nudSubtotal.Value, nudRecargoUrgencia.Value);

        }

        private void nudSubtotal_ValueChanged(object sender, EventArgs e)
        {
            nudTotalLaboratorio.Value = Negocio.CalcularTotalLaboratorio(nudSubtotal.Value, nudRecargoUrgencia.Value);
            if (chkUrgente.Checked == true)
            {
                nudRecargoUrgencia.Value = Negocio.CalcularRecargoUrgente(nudSubtotal.Value);
            }
            else
            {
                nudRecargoUrgencia.Value = 0;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MtdLimpiarControlesForm();
            MtdtrueBotonNuevo();

            // ---> CAMBIAR: Nombre Control del forms
            cbxCodigodeatencion.Focus();
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
                List<LaboratoriosEntidad> lista = Negocio.MtdBuscar(txtBuscarNombre.Text.Trim());

                dgvRegistroLaboratorios.DataSource = lista;
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

        private void dgvRegistroLaboratorios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvRegistroLaboratorios.Columns[e.ColumnIndex].Name != "Seleccionar")
                return;

            if (!chkSeleccionar.Checked)
                return;

            bool seleccionado = Convert.ToBoolean(
                dgvRegistroLaboratorios.Rows[e.RowIndex].Cells["Seleccionar"].Value ?? false);

            if (seleccionado)
                MtdDesactivaFilaSeleccionada();
            else
                MtdActivarFilaSeleccionada(e.RowIndex);
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            dgvRegistroLaboratorios.Columns["Seleccionar"].ReadOnly = !chkSeleccionar.Checked;
            btnEditar.Enabled = chkSeleccionar.Checked;
            MtdDesactivaFilaSeleccionada();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                var atencion = (dynamic)cbxCodigodeatencion.SelectedItem;
                int codigoatencion = (int)atencion.GetType().GetProperty("Value").GetValue(atencion, null);
                LaboratoriosEntidad ControlLaboratorio = new LaboratoriosEntidad
                {

                    CodigoAtencion = codigoatencion,
                    TipoExamen = txtTipoExamen.Text,
                    CostoExamen = nudCostoExamen.Value,
                    Cantidad = Convert.ToInt32(nudCantidad.Value),
                    RecargoUrgente = nudRecargoUrgencia.Value,
                    SubTotal = nudSubtotal.Value,
                    TotalLaboratorio = nudTotalLaboratorio.Value,
                    Estado = rdbActivo.Checked,
                    UsuarioSistema = "Consola",
                    FechaSistema = System.DateTime.Today,
                    HoraSistema = System.DateTime.Now.TimeOfDay,

                };

                Negocio.MtdAgregar(ControlLaboratorio);
                MessageBox.Show("Laboratorio agregado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdLimpiarControlesForm();
                MtdConsultarControlLaboratorios();
                MtdtrueFilaSelecionada(false);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarNombre.Clear();
            MtdConsultarControlLaboratorios();

            MtdLimpiarControlesForm();
            MtdtrueFilaSelecionada(false);
            MtdActualizarTotalRegistros();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcodigoLaboratorio.Text))
            {
                MessageBox.Show("Seleccione una Atencion para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {

                var atencion = (dynamic)cbxCodigodeatencion.SelectedItem;
                int codigoatencion = (int)atencion.GetType().GetProperty("Value").GetValue(atencion, null);
                LaboratoriosEntidad ControlLaboratorio = new LaboratoriosEntidad
                {
                    CodigoLaboratorio = Convert.ToInt32(txtcodigoLaboratorio.Text),
                    CodigoAtencion = codigoatencion,
                    TipoExamen = txtTipoExamen.Text,
                    CostoExamen = nudCostoExamen.Value,
                    Cantidad = Convert.ToInt32(nudCantidad.Value),
                    RecargoUrgente = nudRecargoUrgencia.Value,
                    SubTotal = nudSubtotal.Value,
                    TotalLaboratorio = nudTotalLaboratorio.Value,
                    Estado = rdbActivo.Checked,
                    UsuarioSistema = "Consola",
                    FechaSistema = System.DateTime.Today,
                    HoraSistema = System.DateTime.Now.TimeOfDay,

                };

            Negocio.MtdEditar(ControlLaboratorio);
            MessageBox.Show("Laboratorio Editada correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MtdLimpiarControlesForm();
            MtdConsultarControlLaboratorios();
            MtdtrueFilaSelecionada(false);
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcodigoLaboratorio.Text))
            {
                MessageBox.Show("Seleccione un Codigo de Laboratorio para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar el registro del Laboratorio seleccionado?", "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                int CodigoAtencion = Convert.ToInt32(txtcodigoLaboratorio.Text);

                bool ValidaEliminacion = Negocio.MtdEliminar(CodigoAtencion);

                if (!ValidaEliminacion)
                {
                    MessageBox.Show("No se pudo eliminar el registro seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {

                    MessageBox.Show("Laboratorio eliminado correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdDesactivaFilaSeleccionada();
                    MtdConsultarControlLaboratorios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudRecargoUrgencia_ValueChanged(object sender, EventArgs e)
        {
            nudTotalLaboratorio.Value = Negocio.CalcularTotalLaboratorio(nudSubtotal.Value, nudRecargoUrgencia.Value);
        }
    }
}
