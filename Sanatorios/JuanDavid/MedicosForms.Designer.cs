namespace Sanatorios
{
    partial class MedicosForms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedicosForms));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuscarNombre = new System.Windows.Forms.TextBox();
            this.chkSeleccionar = new System.Windows.Forms.CheckBox();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.dgvRegistroMedicos = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.btnImprimir = new FontAwesome.Sharp.IconButton();
            this.btnExportar = new FontAwesome.Sharp.IconButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigomedico = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.rdbActivo = new System.Windows.Forms.RadioButton();
            this.rdbInactivo = new System.Windows.Forms.RadioButton();
            this.btnNuevo = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnEditar = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.label13 = new System.Windows.Forms.Label();
            this.txtcorreo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.nudhonorarioBase = new System.Windows.Forms.NumericUpDown();
            this.nudAñosdeexperiencia = new System.Windows.Forms.NumericUpDown();
            this.nudBonoporexperiencia = new System.Windows.Forms.NumericUpDown();
            this.BtnCerrarr = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.picPrestamoLibros = new System.Windows.Forms.PictureBox();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroMedicos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudhonorarioBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAñosdeexperiencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBonoporexperiencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrestamoLibros)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.btnExportar);
            this.tabPage1.Controls.Add(this.btnImprimir);
            this.tabPage1.Controls.Add(this.btnLimpiar);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.dgvRegistroMedicos);
            this.tabPage1.Controls.Add(this.lblTotalRegistros);
            this.tabPage1.Controls.Add(this.chkSeleccionar);
            this.tabPage1.Controls.Add(this.txtBuscarNombre);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnCerrar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(1016, 462);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            // 
            // btnCerrar
            // 
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnCerrar.IconColor = System.Drawing.Color.Black;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 20;
            this.btnCerrar.Location = new System.Drawing.Point(959, 540);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(90, 28);
            this.btnCerrar.TabIndex = 19;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre";
            // 
            // txtBuscarNombre
            // 
            this.txtBuscarNombre.Location = new System.Drawing.Point(70, 24);
            this.txtBuscarNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscarNombre.Name = "txtBuscarNombre";
            this.txtBuscarNombre.Size = new System.Drawing.Size(352, 20);
            this.txtBuscarNombre.TabIndex = 11;
            // 
            // chkSeleccionar
            // 
            this.chkSeleccionar.AutoSize = true;
            this.chkSeleccionar.Location = new System.Drawing.Point(19, 56);
            this.chkSeleccionar.Margin = new System.Windows.Forms.Padding(2);
            this.chkSeleccionar.Name = "chkSeleccionar";
            this.chkSeleccionar.Size = new System.Drawing.Size(82, 17);
            this.chkSeleccionar.TabIndex = 12;
            this.chkSeleccionar.Text = "Seleccionar";
            this.chkSeleccionar.UseVisualStyleBackColor = true;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Location = new System.Drawing.Point(883, 57);
            this.lblTotalRegistros.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(76, 13);
            this.lblTotalRegistros.TabIndex = 13;
            this.lblTotalRegistros.Text = "Total registros:";
            // 
            // dgvRegistroMedicos
            // 
            this.dgvRegistroMedicos.AllowUserToAddRows = false;
            this.dgvRegistroMedicos.AllowUserToDeleteRows = false;
            this.dgvRegistroMedicos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRegistroMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistroMedicos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dgvRegistroMedicos.Location = new System.Drawing.Point(12, 77);
            this.dgvRegistroMedicos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRegistroMedicos.MultiSelect = false;
            this.dgvRegistroMedicos.Name = "dgvRegistroMedicos";
            this.dgvRegistroMedicos.ReadOnly = true;
            this.dgvRegistroMedicos.RowHeadersWidth = 51;
            this.dgvRegistroMedicos.RowTemplate.Height = 24;
            this.dgvRegistroMedicos.Size = new System.Drawing.Size(995, 335);
            this.dgvRegistroMedicos.TabIndex = 14;
            // 
            // Seleccionar
            // 
            this.Seleccionar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Seleccionar.FalseValue = "False";
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.MinimumWidth = 6;
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Seleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Seleccionar.TrueValue = "True";
            this.Seleccionar.Width = 88;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiar.IconColor = System.Drawing.Color.Black;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 20;
            this.btnLimpiar.Location = new System.Drawing.Point(560, 20);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 28);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(14, 66);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1024, 488);
            this.tabControl1.TabIndex = 28;
            // 
            // btnBuscar
            // 
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar.IconColor = System.Drawing.Color.Black;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 20;
            this.btnBuscar.Location = new System.Drawing.Point(454, 18);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 28);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimir.IconColor = System.Drawing.Color.Black;
            this.btnImprimir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimir.IconSize = 20;
            this.btnImprimir.Location = new System.Drawing.Point(664, 20);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(90, 28);
            this.btnImprimir.TabIndex = 17;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnExportar.IconColor = System.Drawing.Color.Black;
            this.btnExportar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportar.IconSize = 20;
            this.btnExportar.Location = new System.Drawing.Point(12, 417);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(90, 28);
            this.btnExportar.TabIndex = 18;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(1016, 462);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gestiona";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Codigo Medico:";
            // 
            // txtCodigomedico
            // 
            this.txtCodigomedico.Location = new System.Drawing.Point(133, 44);
            this.txtCodigomedico.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigomedico.Name = "txtCodigomedico";
            this.txtCodigomedico.ReadOnly = true;
            this.txtCodigomedico.Size = new System.Drawing.Size(236, 20);
            this.txtCodigomedico.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nombre:";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(133, 88);
            this.txtNombreUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(236, 20);
            this.txtNombreUsuario.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 144);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Apellido:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(494, 137);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Años de experiencia:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(494, 91);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Honorario Base:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 189);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Especialidad:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(61, 230);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Telefono:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(494, 230);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Estado:";
            // 
            // rdbActivo
            // 
            this.rdbActivo.AutoSize = true;
            this.rdbActivo.Location = new System.Drawing.Point(617, 226);
            this.rdbActivo.Margin = new System.Windows.Forms.Padding(2);
            this.rdbActivo.Name = "rdbActivo";
            this.rdbActivo.Size = new System.Drawing.Size(55, 17);
            this.rdbActivo.TabIndex = 19;
            this.rdbActivo.TabStop = true;
            this.rdbActivo.Text = "Activo";
            this.rdbActivo.UseVisualStyleBackColor = true;
            // 
            // rdbInactivo
            // 
            this.rdbInactivo.AutoSize = true;
            this.rdbInactivo.Location = new System.Drawing.Point(616, 251);
            this.rdbInactivo.Margin = new System.Windows.Forms.Padding(2);
            this.rdbInactivo.Name = "rdbInactivo";
            this.rdbInactivo.Size = new System.Drawing.Size(63, 17);
            this.rdbInactivo.TabIndex = 20;
            this.rdbInactivo.TabStop = true;
            this.rdbInactivo.Text = "Inactivo";
            this.rdbInactivo.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnNuevo.IconColor = System.Drawing.Color.Black;
            this.btnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevo.IconSize = 20;
            this.btnNuevo.Location = new System.Drawing.Point(873, 80);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 28);
            this.btnNuevo.TabIndex = 21;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.btnCancelar.IconColor = System.Drawing.Color.Black;
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 20;
            this.btnCancelar.Location = new System.Drawing.Point(873, 129);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 28);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor = System.Drawing.Color.Black;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 20;
            this.btnGuardar.Location = new System.Drawing.Point(873, 181);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 28);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            this.btnEditar.IconColor = System.Drawing.Color.Black;
            this.btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditar.IconSize = 20;
            this.btnEditar.Location = new System.Drawing.Point(873, 230);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(90, 28);
            this.btnEditar.TabIndex = 24;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnEliminar.IconColor = System.Drawing.Color.Black;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize = 20;
            this.btnEliminar.Location = new System.Drawing.Point(873, 277);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 28);
            this.btnEliminar.TabIndex = 25;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(494, 47);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Correo:";
            // 
            // txtcorreo
            // 
            this.txtcorreo.Location = new System.Drawing.Point(617, 44);
            this.txtcorreo.Margin = new System.Windows.Forms.Padding(2);
            this.txtcorreo.Name = "txtcorreo";
            this.txtcorreo.Size = new System.Drawing.Size(210, 20);
            this.txtcorreo.TabIndex = 28;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudBonoporexperiencia);
            this.groupBox1.Controls.Add(this.nudAñosdeexperiencia);
            this.groupBox1.Controls.Add(this.nudhonorarioBase);
            this.groupBox1.Controls.Add(this.txtEspecialidad);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtcorreo);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnEditar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.rdbInactivo);
            this.groupBox1.Controls.Add(this.rdbActivo);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNombreUsuario);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCodigomedico);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(18, 22);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(974, 403);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del doctor";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(494, 189);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Bono de experiencia:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(133, 227);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(236, 20);
            this.txtTelefono.TabIndex = 31;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(133, 134);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(236, 20);
            this.textBox2.TabIndex = 32;
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Location = new System.Drawing.Point(133, 186);
            this.txtEspecialidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(236, 20);
            this.txtEspecialidad.TabIndex = 33;
            // 
            // nudhonorarioBase
            // 
            this.nudhonorarioBase.DecimalPlaces = 2;
            this.nudhonorarioBase.Location = new System.Drawing.Point(616, 88);
            this.nudhonorarioBase.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudhonorarioBase.Name = "nudhonorarioBase";
            this.nudhonorarioBase.Size = new System.Drawing.Size(211, 20);
            this.nudhonorarioBase.TabIndex = 34;
            // 
            // nudAñosdeexperiencia
            // 
            this.nudAñosdeexperiencia.Location = new System.Drawing.Point(616, 135);
            this.nudAñosdeexperiencia.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudAñosdeexperiencia.Name = "nudAñosdeexperiencia";
            this.nudAñosdeexperiencia.Size = new System.Drawing.Size(211, 20);
            this.nudAñosdeexperiencia.TabIndex = 35;
            // 
            // nudBonoporexperiencia
            // 
            this.nudBonoporexperiencia.DecimalPlaces = 2;
            this.nudBonoporexperiencia.Location = new System.Drawing.Point(617, 182);
            this.nudBonoporexperiencia.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudBonoporexperiencia.Name = "nudBonoporexperiencia";
            this.nudBonoporexperiencia.Size = new System.Drawing.Size(211, 20);
            this.nudBonoporexperiencia.TabIndex = 36;
            // 
            // BtnCerrarr
            // 
            this.BtnCerrarr.IconChar = FontAwesome.Sharp.IconChar.X;
            this.BtnCerrarr.IconColor = System.Drawing.Color.Black;
            this.BtnCerrarr.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnCerrarr.IconSize = 20;
            this.BtnCerrarr.Location = new System.Drawing.Point(944, 558);
            this.BtnCerrarr.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCerrarr.Name = "BtnCerrarr";
            this.BtnCerrarr.Size = new System.Drawing.Size(90, 28);
            this.BtnCerrarr.TabIndex = 29;
            this.BtnCerrarr.Text = "Cerrar";
            this.BtnCerrarr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCerrarr.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(674, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 29);
            this.label1.TabIndex = 27;
            this.label1.Text = "Registro de Medicos";
            // 
            // picPrestamoLibros
            // 
            this.picPrestamoLibros.Image = ((System.Drawing.Image)(resources.GetObject("picPrestamoLibros.Image")));
            this.picPrestamoLibros.Location = new System.Drawing.Point(933, 11);
            this.picPrestamoLibros.Margin = new System.Windows.Forms.Padding(2);
            this.picPrestamoLibros.Name = "picPrestamoLibros";
            this.picPrestamoLibros.Size = new System.Drawing.Size(66, 53);
            this.picPrestamoLibros.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPrestamoLibros.TabIndex = 30;
            this.picPrestamoLibros.TabStop = false;
            // 
            // MedicosForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 589);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCerrarr);
            this.Controls.Add(this.picPrestamoLibros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MedicosForms";
            this.Text = "MedicosForms";
            this.Load += new System.EventHandler(this.MedicosForms_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroMedicos)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudhonorarioBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAñosdeexperiencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBonoporexperiencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrestamoLibros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private FontAwesome.Sharp.IconButton btnExportar;
        private FontAwesome.Sharp.IconButton btnImprimir;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.DataGridView dgvRegistroMedicos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.CheckBox chkSeleccionar;
        private System.Windows.Forms.TextBox txtBuscarNombre;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudBonoporexperiencia;
        private System.Windows.Forms.NumericUpDown nudAñosdeexperiencia;
        private System.Windows.Forms.NumericUpDown nudhonorarioBase;
        private System.Windows.Forms.TextBox txtEspecialidad;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtcorreo;
        private System.Windows.Forms.Label label13;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnNuevo;
        private System.Windows.Forms.RadioButton rdbInactivo;
        private System.Windows.Forms.RadioButton rdbActivo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigomedico;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton BtnCerrarr;
        private System.Windows.Forms.Label label1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PictureBox picPrestamoLibros;
    }
}