using Sanatorios.JuanDavid;
using Sanatorios.MarlonMeda;
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
    public partial class InicioForms : Form
    {
        public InicioForms()
        {
            InitializeComponent();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            PacientesForm menu = new PacientesForm();
            menu.FormClosed += (s, args) => this.Close();
            menu.Show();
            this.Hide();
        }

        private void btnSanatorios_Click(object sender, EventArgs e)
        {
            Sanatorios.JuanDavid.Sanatorios menu = new Sanatorios.JuanDavid.Sanatorios();
            menu.FormClosed += (s, args) => this.Close();
            menu.Show();
            this.Hide();
        }

        private void btnSegurosMedicos_Click(object sender, EventArgs e)
        {
            SegurosMedicosForms menu = new SegurosMedicosForms();
            menu.FormClosed += (s, args) => this.Close();
            menu.Show();
            this.Hide();
        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {
            MedicosForms menu = new MedicosForms();
            menu.FormClosed += (s, args) => this.Close();
            menu.Show();
            this.Hide();
        }

        private void btnHospitalizaciones_Click(object sender, EventArgs e)
        {
            HospitalizacionesForm menu = new HospitalizacionesForm();
            menu.FormClosed += (s, args) => this.Close();
            menu.Show();
            this.Hide();
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            FacturasForms menu = new FacturasForms();
            menu.FormClosed += (s, args) => this.Close();
            menu.Show();
            this.Hide();
        }

        private void btnTipoServicios_Click(object sender, EventArgs e)
        {
            TipoServicioForm menu = new TipoServicioForm();
            menu.FormClosed += (s, args) => this.Close();
            menu.Show();
            this.Hide();
        }

        private void btnLaboratorios_Click(object sender, EventArgs e)
        {
            LaboratoriosForms menu = new LaboratoriosForms();
            menu.FormClosed += (s, args) => this.Close();
            menu.Show();
            this.Hide();
        }

        private void btnDetalleFacturas_Click(object sender, EventArgs e)
        {
            DetalleFacturasForms menu = new DetalleFacturasForms();
            menu.FormClosed += (s, args) => this.Close();
            menu.Show();
            this.Hide();
        }

        private void btnAtencionesPacientes_Click(object sender, EventArgs e)
        {
            AtencionPacientesForms menu = new AtencionPacientesForms();
            menu.FormClosed += (s, args) => this.Close();
            menu.Show();
            this.Hide();
        }

        private void btnDietas_Click(object sender, EventArgs e)
        {
            DietasForm menu = new DietasForm();
            menu.FormClosed += (s, args) => this.Close();
            menu.Show();
            this.Hide();
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            PagosForms menu = new PagosForms();
            menu.FormClosed += (s, args) => this.Close();
            menu.Show();
            this.Hide();
        }
    }
}
