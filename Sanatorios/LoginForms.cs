using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sanatorios.UsuarioLogueado;

namespace Sanatorios
{
    public partial class LoginForms : Form
    {
        loginNegocio Negocio = new loginNegocio();

        public LoginForms()
        {
            InitializeComponent();
        }
       

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreUsuario.Text))
            {
                MessageBox.Show("Ingrese un nombre de Usuario .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (string.IsNullOrEmpty(txtContraseña.Text))
                {
                    MessageBox.Show("Ingrese una Contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if(txtContraseña.Text == Negocio.MtdObtenerContraseñaUsuario(txtNombreUsuario.Text))
                    {
                        Sesion.NombreUsuario = txtNombreUsuario.Text;
                        InicioForms menu = new InicioForms();
                        menu.FormClosed += (s, args) => this.Close();
                        menu.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Verifique el Usuario o Contraseña Ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
