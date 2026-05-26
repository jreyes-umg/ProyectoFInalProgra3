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

namespace Sanatorios
{
    public partial class MedicosForms : Form
    {
        MedicosNegocio Negocio = new MedicosNegocio();
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
        private void MtdConsultarControlRentas()
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





        /*-------------*BOTONES O CAMPOS*-------------*/
        private void MedicosForms_Load(object sender, EventArgs e)
        {
            MtdConsultarControlDoctores();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
