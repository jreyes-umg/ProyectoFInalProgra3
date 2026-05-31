using Entidad;
using Negocio.SegurosMedicos;
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
    public partial class SegurosMedicosForms : Form
    {
        public SegurosMedicosForms()
        {
            InitializeComponent();
        }
        private void dgvSeguros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
                if (e.RowIndex >= 0)
                {
                  
                    DataGridViewRow fila = dgvSeguros.Rows[e.RowIndex];

                    txtCodigoSeguro.Text = fila.Cells["CodigoSeguro"].Value.ToString();
                    txtNombreSeguro.Text = fila.Cells["NombreSeguro"].Value.ToString();
                    cbxTipoSeguro.Text = fila.Cells["TipoSeguro"].Value.ToString();
                    nudPorcentaje.Value = Convert.ToDecimal(fila.Cells["PorcentajeCobertura"].Value);
                    txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                    txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();
                    nudMontoMaximo.Value = Convert.ToDecimal(fila.Cells["MontoMaximo"].Value);

                   
                    bool estadoActivo = Convert.ToBoolean(fila.Cells["Estado"].Value);
                    if (estadoActivo)
                    {
                        rdbActivo.Checked = true;
                    }
                    else
                    {
                        rdbInactivo.Checked = true; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el registro de la tabla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MtdCalcularPorcentajeAutomatico()
        {
            if (cbxTipoSeguro.SelectedIndex != -1)
            {
                string tipoSeleccionado = cbxTipoSeguro.SelectedItem.ToString();

             
                SegurosMedicosNegocio negocioSeguros = new SegurosMedicosNegocio();

               
                nudPorcentaje.Value = negocioSeguros.CalcularPorcentajeCobertura(tipoSeleccionado);
            }
        }

      
        private void cbxTipoSeguro_SelectedIndexChanged(object sender, EventArgs e)
        {
            MtdCalcularPorcentajeAutomatico();
        }


        private void MtdCargarDatosEnTabla()
        {
            try
            {
                SegurosMedicosNegocio negocioSeguros = new SegurosMedicosNegocio();
                dgvSeguros.DataSource = negocioSeguros.MtdConsultarSeguros();
                dgvSeguros.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar seguros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void SegurosMedicosForms_Load(object sender, EventArgs e)
        {
            MtdCargarDatosEnTabla();
            MtdLimpiarCampos();
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoSeguro.Text = "";
            txtNombreSeguro.Text = "";
            cbxTipoSeguro.SelectedIndex = -1;
            nudPorcentaje.Value = 0;
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            nudMontoMaximo.Value = 0;
            rdbActivo.Checked = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e) => MtdLimpiarCampos();
        private void btnCancelar_Click(object sender, EventArgs e) => MtdLimpiarCampos();


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                SegurosMedicosEntidad nuevoSeguro = new SegurosMedicosEntidad();

                nuevoSeguro.NombreSeguro = txtNombreSeguro.Text;
                nuevoSeguro.TipoSeguro = cbxTipoSeguro.SelectedItem?.ToString() ?? "";
                nuevoSeguro.PorcentajeCobertura = nudPorcentaje.Value;
                nuevoSeguro.Telefono = txtTelefono.Text;
                nuevoSeguro.Direccion = txtDireccion.Text;
                nuevoSeguro.MontoMaximo = nudMontoMaximo.Value;
                nuevoSeguro.Estado = rdbActivo.Checked;

               
                nuevoSeguro.UsuarioSistema = "Admin";
                nuevoSeguro.FechaSistema = DateTime.Now;
                nuevoSeguro.HoraSistema = DateTime.Now;

                SegurosMedicosNegocio negocio = new SegurosMedicosNegocio();
                if (negocio.MtdAgregar(nuevoSeguro))
                {
                    MessageBox.Show("Seguro médico guardado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdCargarDatosEnTabla();
                    MtdLimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodigoSeguro.Text)) return;

                SegurosMedicosEntidad seguroEditado = new SegurosMedicosEntidad();
                seguroEditado.CodigoSeguro = Convert.ToInt32(txtCodigoSeguro.Text);
                seguroEditado.NombreSeguro = txtNombreSeguro.Text;
                seguroEditado.TipoSeguro = cbxTipoSeguro.SelectedItem?.ToString() ?? "";
                seguroEditado.PorcentajeCobertura = nudPorcentaje.Value;
                seguroEditado.Telefono = txtTelefono.Text;
                seguroEditado.Direccion = txtDireccion.Text;
                seguroEditado.MontoMaximo = nudMontoMaximo.Value;
                seguroEditado.Estado = rdbActivo.Checked;

                seguroEditado.UsuarioSistema = "Admin";
                seguroEditado.FechaSistema = DateTime.Now;
                seguroEditado.HoraSistema = DateTime.Now;

                SegurosMedicosNegocio negocio = new SegurosMedicosNegocio();
                if (negocio.MtdEditar(seguroEditado))
                {
                    MessageBox.Show("Seguro médico actualizado.");
                    MtdCargarDatosEnTabla();
                    MtdLimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodigoSeguro.Text)) return;

                if (MessageBox.Show("¿Eliminar este seguro?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SegurosMedicosNegocio negocio = new SegurosMedicosNegocio();
                    if (negocio.MtdEliminar(Convert.ToInt32(txtCodigoSeguro.Text)))
                    {
                        MessageBox.Show("Eliminado correctamente.");
                        MtdCargarDatosEnTabla();
                        MtdLimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                
                string textoBusqueda = txtNombreBusqueda.Text.Trim().ToLower();

                if (string.IsNullOrEmpty(textoBusqueda))
                {
                 
                    MtdCargarDatosEnTabla();
                    return;
                }

                
                SegurosMedicosNegocio negocio = new SegurosMedicosNegocio();
                var listaCompleta = negocio.MtdConsultarSeguros();

              
                var listaFiltrada = listaCompleta.Where(s => s.NombreSeguro.ToLower().Contains(textoBusqueda)).ToList();

              
                dgvSeguros.DataSource = listaFiltrada;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la búsqueda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreBusqueda.Text = ""; 
            MtdCargarDatosEnTabla();
        }

        private void BtnCerrarr_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSeguros.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog guardarArchivo = new SaveFileDialog();
                guardarArchivo.Filter = "Archivo CSV (*.csv)|*.csv";
                guardarArchivo.FileName = "Reporte_SegurosMedicos_" + DateTime.Now.ToString("ddMMyyyy") + ".csv";

                if (guardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(guardarArchivo.FileName, false, System.Text.Encoding.UTF8))
                    {
                        
                        for (int i = 0; i < dgvSeguros.Columns.Count; i++)
                        {
                            sw.Write(dgvSeguros.Columns[i].HeaderText);
                            if (i < dgvSeguros.Columns.Count - 1) sw.Write(",");
                        }
                        sw.WriteLine();

                      
                        foreach (DataGridViewRow fila in dgvSeguros.Rows)
                        {
                            for (int i = 0; i < dgvSeguros.Columns.Count; i++)
                            {
                                if (fila.Cells[i].Value != null)
                                {
                                    sw.Write(fila.Cells[i].Value.ToString().Replace(",", " ")); // Evitar comas conflictivas
                                }
                                if (i < dgvSeguros.Columns.Count - 1) sw.Write(",");
                            }
                            sw.WriteLine();
                        }
                    }
                    MessageBox.Show("Datos exportados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font tituloFont = new Font("Arial", 16, FontStyle.Bold);
            Font textFont = new Font("Arial", 11);
            Brush brush = Brushes.Black;

            float y = 40;
            float margenizquierdo = 50;

            e.Graphics.DrawString("DATOS DEL SEGURO MÉDICO", tituloFont, brush, margenizquierdo, y);
            y += 40;

            e.Graphics.DrawString($"Código de Seguro: {txtCodigoSeguro.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Nombre del Seguro: {txtNombreSeguro.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Tipo de Seguro: {cbxTipoSeguro.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Porcentaje de Cobertura: {nudPorcentaje.Value}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Teléfono: {txtTelefono.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Dirección: {txtDireccion.Text}", textFont, brush, margenizquierdo, y); y += 25;
            e.Graphics.DrawString($"Monto Máximo: Q{nudMontoMaximo.Value}", textFont, brush, margenizquierdo, y); y += 25;

            string estado = rdbActivo.Checked ? "Activo" : "Inactivo";
            e.Graphics.DrawString($"Estado: {estado}", textFont, brush, margenizquierdo, y); y += 25;
        }
    }
}
