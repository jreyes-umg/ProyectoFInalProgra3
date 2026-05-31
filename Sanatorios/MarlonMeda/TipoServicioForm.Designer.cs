namespace Sanatorios.MarlonMeda
{
    partial class TipoServicioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TipoServicioForm));
            this.chkSeleccionar = new System.Windows.Forms.CheckBox();
            this.txtUsuarioSistema = new System.Windows.Forms.TextBox();
            this.dtmHoraSistema = new System.Windows.Forms.DateTimePicker();
            this.dtmFechaSistema = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.nudRecargoBase = new System.Windows.Forms.NumericUpDown();
            this.dgvTipoServicios = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNivelComplejidad = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rdbInactivoLaboratorio = new System.Windows.Forms.RadioButton();
            this.rdbActivoLaboratorio = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.rdbInactivoHospitalizacion = new System.Windows.Forms.RadioButton();
            this.rdbActivoHospitalizacion = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.rdbInactivoEmergencia = new System.Windows.Forms.RadioButton();
            this.rdbActivoEmergencia = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudTarifaBase = new System.Windows.Forms.NumericUpDown();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnEditar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.btnNuevo = new FontAwesome.Sharp.IconButton();
            this.rdbInactivo = new System.Windows.Forms.RadioButton();
            this.rdbActivo = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombreServicio = new System.Windows.Forms.TextBox();
            this.yhuedrgbe = new System.Windows.Forms.Label();
            this.txtCodigoTipoServicio = new System.Windows.Forms.TextBox();
            this.CodigoHospitalizacion = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnExportar = new FontAwesome.Sharp.IconButton();
            this.btnImprimir = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.txtBuscarNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCerrarr = new FontAwesome.Sharp.IconButton();
            this.picPrestamoLibros = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecargoBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoServicios)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTarifaBase)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPrestamoLibros)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSeleccionar
            // 
            this.chkSeleccionar.AutoSize = true;
            this.chkSeleccionar.Location = new System.Drawing.Point(25, 69);
            this.chkSeleccionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkSeleccionar.Name = "chkSeleccionar";
            this.chkSeleccionar.Size = new System.Drawing.Size(101, 20);
            this.chkSeleccionar.TabIndex = 12;
            this.chkSeleccionar.Text = "Seleccionar";
            this.chkSeleccionar.UseVisualStyleBackColor = true;
            this.chkSeleccionar.CheckedChanged += new System.EventHandler(this.chkSeleccionar_CheckedChanged);
            // 
            // txtUsuarioSistema
            // 
            this.txtUsuarioSistema.Location = new System.Drawing.Point(819, 228);
            this.txtUsuarioSistema.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsuarioSistema.Name = "txtUsuarioSistema";
            this.txtUsuarioSistema.Size = new System.Drawing.Size(281, 22);
            this.txtUsuarioSistema.TabIndex = 47;
            this.txtUsuarioSistema.TextChanged += new System.EventHandler(this.txtUsuarioSistema_TextChanged);
            // 
            // dtmHoraSistema
            // 
            this.dtmHoraSistema.Location = new System.Drawing.Point(819, 360);
            this.dtmHoraSistema.Margin = new System.Windows.Forms.Padding(4);
            this.dtmHoraSistema.Name = "dtmHoraSistema";
            this.dtmHoraSistema.Size = new System.Drawing.Size(281, 22);
            this.dtmHoraSistema.TabIndex = 46;
            // 
            // dtmFechaSistema
            // 
            this.dtmFechaSistema.Location = new System.Drawing.Point(819, 295);
            this.dtmFechaSistema.Margin = new System.Windows.Forms.Padding(4);
            this.dtmFechaSistema.Name = "dtmFechaSistema";
            this.dtmFechaSistema.Size = new System.Drawing.Size(281, 22);
            this.dtmFechaSistema.TabIndex = 45;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(648, 366);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 16);
            this.label16.TabIndex = 43;
            this.label16.Text = "Hora Sistema:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(648, 300);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 16);
            this.label15.TabIndex = 42;
            this.label15.Text = "Fecha Sistema:";
            // 
            // nudRecargoBase
            // 
            this.nudRecargoBase.DecimalPlaces = 2;
            this.nudRecargoBase.Location = new System.Drawing.Point(819, 104);
            this.nudRecargoBase.Margin = new System.Windows.Forms.Padding(4);
            this.nudRecargoBase.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudRecargoBase.Name = "nudRecargoBase";
            this.nudRecargoBase.ReadOnly = true;
            this.nudRecargoBase.Size = new System.Drawing.Size(281, 22);
            this.nudRecargoBase.TabIndex = 50;
            // 
            // dgvTipoServicios
            // 
            this.dgvTipoServicios.AllowUserToAddRows = false;
            this.dgvTipoServicios.AllowUserToDeleteRows = false;
            this.dgvTipoServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTipoServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipoServicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dgvTipoServicios.Location = new System.Drawing.Point(16, 95);
            this.dgvTipoServicios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTipoServicios.MultiSelect = false;
            this.dgvTipoServicios.Name = "dgvTipoServicios";
            this.dgvTipoServicios.ReadOnly = true;
            this.dgvTipoServicios.RowHeadersWidth = 51;
            this.dgvTipoServicios.RowTemplate.Height = 24;
            this.dgvTipoServicios.Size = new System.Drawing.Size(1327, 412);
            this.dgvTipoServicios.TabIndex = 14;
            this.dgvTipoServicios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTipoServicios_CellContentClick);
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
            this.Seleccionar.Width = 108;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1357, 572);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gestiona";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNivelComplejidad);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.rdbInactivoLaboratorio);
            this.groupBox1.Controls.Add(this.rdbActivoLaboratorio);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.rdbInactivoHospitalizacion);
            this.groupBox1.Controls.Add(this.rdbActivoHospitalizacion);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.rdbInactivoEmergencia);
            this.groupBox1.Controls.Add(this.rdbActivoEmergencia);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.nudRecargoBase);
            this.groupBox1.Controls.Add(this.txtUsuarioSistema);
            this.groupBox1.Controls.Add(this.dtmHoraSistema);
            this.groupBox1.Controls.Add(this.dtmFechaSistema);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudTarifaBase);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnEditar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.rdbInactivo);
            this.groupBox1.Controls.Add(this.rdbActivo);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtNombreServicio);
            this.groupBox1.Controls.Add(this.yhuedrgbe);
            this.groupBox1.Controls.Add(this.txtCodigoTipoServicio);
            this.groupBox1.Controls.Add(this.CodigoHospitalizacion);
            this.groupBox1.Location = new System.Drawing.Point(24, 27);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1299, 523);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtNivelComplejidad
            // 
            this.txtNivelComplejidad.Location = new System.Drawing.Point(819, 49);
            this.txtNivelComplejidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNivelComplejidad.Name = "txtNivelComplejidad";
            this.txtNivelComplejidad.Size = new System.Drawing.Size(281, 22);
            this.txtNivelComplejidad.TabIndex = 68;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(644, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 16);
            this.label10.TabIndex = 67;
            this.label10.Text = "Nivel Complejidad";
            // 
            // rdbInactivoLaboratorio
            // 
            this.rdbInactivoLaboratorio.AutoSize = true;
            this.rdbInactivoLaboratorio.Location = new System.Drawing.Point(352, 311);
            this.rdbInactivoLaboratorio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbInactivoLaboratorio.Name = "rdbInactivoLaboratorio";
            this.rdbInactivoLaboratorio.Size = new System.Drawing.Size(74, 20);
            this.rdbInactivoLaboratorio.TabIndex = 66;
            this.rdbInactivoLaboratorio.TabStop = true;
            this.rdbInactivoLaboratorio.Text = "Inactivo";
            this.rdbInactivoLaboratorio.UseVisualStyleBackColor = true;
            // 
            // rdbActivoLaboratorio
            // 
            this.rdbActivoLaboratorio.AutoSize = true;
            this.rdbActivoLaboratorio.Location = new System.Drawing.Point(225, 309);
            this.rdbActivoLaboratorio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbActivoLaboratorio.Name = "rdbActivoLaboratorio";
            this.rdbActivoLaboratorio.Size = new System.Drawing.Size(65, 20);
            this.rdbActivoLaboratorio.TabIndex = 65;
            this.rdbActivoLaboratorio.TabStop = true;
            this.rdbActivoLaboratorio.Text = "Activo";
            this.rdbActivoLaboratorio.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 311);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 16);
            this.label13.TabIndex = 64;
            this.label13.Text = "Aplica laboratorio";
            // 
            // rdbInactivoHospitalizacion
            // 
            this.rdbInactivoHospitalizacion.AutoSize = true;
            this.rdbInactivoHospitalizacion.Location = new System.Drawing.Point(352, 257);
            this.rdbInactivoHospitalizacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbInactivoHospitalizacion.Name = "rdbInactivoHospitalizacion";
            this.rdbInactivoHospitalizacion.Size = new System.Drawing.Size(74, 20);
            this.rdbInactivoHospitalizacion.TabIndex = 63;
            this.rdbInactivoHospitalizacion.TabStop = true;
            this.rdbInactivoHospitalizacion.Text = "Inactivo";
            this.rdbInactivoHospitalizacion.UseVisualStyleBackColor = true;
            // 
            // rdbActivoHospitalizacion
            // 
            this.rdbActivoHospitalizacion.AutoSize = true;
            this.rdbActivoHospitalizacion.Location = new System.Drawing.Point(225, 255);
            this.rdbActivoHospitalizacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbActivoHospitalizacion.Name = "rdbActivoHospitalizacion";
            this.rdbActivoHospitalizacion.Size = new System.Drawing.Size(65, 20);
            this.rdbActivoHospitalizacion.TabIndex = 62;
            this.rdbActivoHospitalizacion.TabStop = true;
            this.rdbActivoHospitalizacion.Text = "Activo";
            this.rdbActivoHospitalizacion.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 257);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 16);
            this.label11.TabIndex = 61;
            this.label11.Text = "Aplica Hospitalizacion";
            // 
            // rdbInactivoEmergencia
            // 
            this.rdbInactivoEmergencia.AutoSize = true;
            this.rdbInactivoEmergencia.Location = new System.Drawing.Point(354, 207);
            this.rdbInactivoEmergencia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbInactivoEmergencia.Name = "rdbInactivoEmergencia";
            this.rdbInactivoEmergencia.Size = new System.Drawing.Size(74, 20);
            this.rdbInactivoEmergencia.TabIndex = 60;
            this.rdbInactivoEmergencia.TabStop = true;
            this.rdbInactivoEmergencia.Text = "Inactivo";
            this.rdbInactivoEmergencia.UseVisualStyleBackColor = true;
            // 
            // rdbActivoEmergencia
            // 
            this.rdbActivoEmergencia.AutoSize = true;
            this.rdbActivoEmergencia.Location = new System.Drawing.Point(227, 205);
            this.rdbActivoEmergencia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbActivoEmergencia.Name = "rdbActivoEmergencia";
            this.rdbActivoEmergencia.Size = new System.Drawing.Size(65, 20);
            this.rdbActivoEmergencia.TabIndex = 59;
            this.rdbActivoEmergencia.TabStop = true;
            this.rdbActivoEmergencia.Text = "Activo";
            this.rdbActivoEmergencia.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 16);
            this.label7.TabIndex = 58;
            this.label7.Text = "Aplica Emergencia";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(648, 234);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 16);
            this.label14.TabIndex = 41;
            this.label14.Text = "Usuario Sistema:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(644, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "RecargoBase";
            // 
            // nudTarifaBase
            // 
            this.nudTarifaBase.DecimalPlaces = 2;
            this.nudTarifaBase.Location = new System.Drawing.Point(177, 149);
            this.nudTarifaBase.Margin = new System.Windows.Forms.Padding(4);
            this.nudTarifaBase.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudTarifaBase.Name = "nudTarifaBase";
            this.nudTarifaBase.Size = new System.Drawing.Size(313, 22);
            this.nudTarifaBase.TabIndex = 34;
            this.nudTarifaBase.ValueChanged += new System.EventHandler(this.nudTarifaBase_ValueChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnEliminar.IconColor = System.Drawing.Color.Black;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize = 20;
            this.btnEliminar.Location = new System.Drawing.Point(1164, 341);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 34);
            this.btnEliminar.TabIndex = 25;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            this.btnEditar.IconColor = System.Drawing.Color.Black;
            this.btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditar.IconSize = 20;
            this.btnEditar.Location = new System.Drawing.Point(1164, 283);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(120, 34);
            this.btnEditar.TabIndex = 24;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor = System.Drawing.Color.Black;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 20;
            this.btnGuardar.Location = new System.Drawing.Point(1164, 223);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 34);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.btnCancelar.IconColor = System.Drawing.Color.Black;
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 20;
            this.btnCancelar.Location = new System.Drawing.Point(1164, 159);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 34);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnNuevo.IconColor = System.Drawing.Color.Black;
            this.btnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevo.IconSize = 20;
            this.btnNuevo.Location = new System.Drawing.Point(1164, 98);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(120, 34);
            this.btnNuevo.TabIndex = 21;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // rdbInactivo
            // 
            this.rdbInactivo.AutoSize = true;
            this.rdbInactivo.Location = new System.Drawing.Point(986, 163);
            this.rdbInactivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbInactivo.Name = "rdbInactivo";
            this.rdbInactivo.Size = new System.Drawing.Size(74, 20);
            this.rdbInactivo.TabIndex = 20;
            this.rdbInactivo.TabStop = true;
            this.rdbInactivo.Text = "Inactivo";
            this.rdbInactivo.UseVisualStyleBackColor = true;
            // 
            // rdbActivo
            // 
            this.rdbActivo.AutoSize = true;
            this.rdbActivo.Location = new System.Drawing.Point(859, 161);
            this.rdbActivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdbActivo.Name = "rdbActivo";
            this.rdbActivo.Size = new System.Drawing.Size(65, 20);
            this.rdbActivo.TabIndex = 19;
            this.rdbActivo.TabStop = true;
            this.rdbActivo.Text = "Activo";
            this.rdbActivo.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(648, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 16);
            this.label12.TabIndex = 18;
            this.label12.Text = "Estado:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Tarifa Base";
            // 
            // txtNombreServicio
            // 
            this.txtNombreServicio.Location = new System.Drawing.Point(177, 95);
            this.txtNombreServicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombreServicio.Name = "txtNombreServicio";
            this.txtNombreServicio.Size = new System.Drawing.Size(313, 22);
            this.txtNombreServicio.TabIndex = 3;
            // 
            // yhuedrgbe
            // 
            this.yhuedrgbe.AutoSize = true;
            this.yhuedrgbe.Location = new System.Drawing.Point(14, 101);
            this.yhuedrgbe.Name = "yhuedrgbe";
            this.yhuedrgbe.Size = new System.Drawing.Size(108, 16);
            this.yhuedrgbe.TabIndex = 2;
            this.yhuedrgbe.Text = "Nombre Servicio";
            // 
            // txtCodigoTipoServicio
            // 
            this.txtCodigoTipoServicio.Location = new System.Drawing.Point(177, 46);
            this.txtCodigoTipoServicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigoTipoServicio.Name = "txtCodigoTipoServicio";
            this.txtCodigoTipoServicio.ReadOnly = true;
            this.txtCodigoTipoServicio.Size = new System.Drawing.Size(313, 22);
            this.txtCodigoTipoServicio.TabIndex = 1;
            // 
            // CodigoHospitalizacion
            // 
            this.CodigoHospitalizacion.AutoSize = true;
            this.CodigoHospitalizacion.Location = new System.Drawing.Point(14, 52);
            this.CodigoHospitalizacion.Name = "CodigoHospitalizacion";
            this.CodigoHospitalizacion.Size = new System.Drawing.Size(153, 16);
            this.CodigoHospitalizacion.TabIndex = 0;
            this.CodigoHospitalizacion.Text = "Codigo Tipo de Servicio";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(31, 78);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1365, 601);
            this.tabControl1.TabIndex = 52;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.btnExportar);
            this.tabPage1.Controls.Add(this.btnImprimir);
            this.tabPage1.Controls.Add(this.btnLimpiar);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.dgvTipoServicios);
            this.tabPage1.Controls.Add(this.lblTotalRegistros);
            this.tabPage1.Controls.Add(this.chkSeleccionar);
            this.tabPage1.Controls.Add(this.txtBuscarNombre);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnCerrar);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1357, 572);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            // 
            // btnExportar
            // 
            this.btnExportar.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnExportar.IconColor = System.Drawing.Color.Black;
            this.btnExportar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportar.IconSize = 20;
            this.btnExportar.Location = new System.Drawing.Point(16, 513);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(120, 34);
            this.btnExportar.TabIndex = 18;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimir.IconColor = System.Drawing.Color.Black;
            this.btnImprimir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimir.IconSize = 20;
            this.btnImprimir.Location = new System.Drawing.Point(885, 25);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(120, 34);
            this.btnImprimir.TabIndex = 17;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiar.IconColor = System.Drawing.Color.Black;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 20;
            this.btnLimpiar.Location = new System.Drawing.Point(747, 25);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 34);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar.IconColor = System.Drawing.Color.Black;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 20;
            this.btnBuscar.Location = new System.Drawing.Point(605, 22);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 34);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Location = new System.Drawing.Point(1177, 70);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(96, 16);
            this.lblTotalRegistros.TabIndex = 13;
            this.lblTotalRegistros.Text = "Total registros:";
            // 
            // txtBuscarNombre
            // 
            this.txtBuscarNombre.Location = new System.Drawing.Point(93, 30);
            this.txtBuscarNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscarNombre.Name = "txtBuscarNombre";
            this.txtBuscarNombre.Size = new System.Drawing.Size(468, 22);
            this.txtBuscarNombre.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre";
            // 
            // btnCerrar
            // 
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnCerrar.IconColor = System.Drawing.Color.Black;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 20;
            this.btnCerrar.Location = new System.Drawing.Point(1279, 665);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 34);
            this.btnCerrar.TabIndex = 19;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(961, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 36);
            this.label1.TabIndex = 51;
            this.label1.Text = "Tipo De Servicio";
            // 
            // BtnCerrarr
            // 
            this.BtnCerrarr.IconChar = FontAwesome.Sharp.IconChar.X;
            this.BtnCerrarr.IconColor = System.Drawing.Color.Black;
            this.BtnCerrarr.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnCerrarr.IconSize = 20;
            this.BtnCerrarr.Location = new System.Drawing.Point(1271, 723);
            this.BtnCerrarr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCerrarr.Name = "BtnCerrarr";
            this.BtnCerrarr.Size = new System.Drawing.Size(120, 34);
            this.BtnCerrarr.TabIndex = 53;
            this.BtnCerrarr.Text = "Cerrar";
            this.BtnCerrarr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCerrarr.UseVisualStyleBackColor = true;
            // 
            // picPrestamoLibros
            // 
            this.picPrestamoLibros.Image = ((System.Drawing.Image)(resources.GetObject("picPrestamoLibros.Image")));
            this.picPrestamoLibros.Location = new System.Drawing.Point(1220, 21);
            this.picPrestamoLibros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picPrestamoLibros.Name = "picPrestamoLibros";
            this.picPrestamoLibros.Size = new System.Drawing.Size(88, 65);
            this.picPrestamoLibros.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPrestamoLibros.TabIndex = 54;
            this.picPrestamoLibros.TabStop = false;
            // 
            // TipoServicioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 769);
            this.Controls.Add(this.picPrestamoLibros);
            this.Controls.Add(this.BtnCerrarr);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "TipoServicioForm";
            this.Text = "TipoServicioForm";
            this.Load += new System.EventHandler(this.TipoServicioForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudRecargoBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoServicios)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTarifaBase)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPrestamoLibros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSeleccionar;
        private System.Windows.Forms.TextBox txtUsuarioSistema;
        private System.Windows.Forms.DateTimePicker dtmHoraSistema;
        private System.Windows.Forms.DateTimePicker dtmFechaSistema;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private FontAwesome.Sharp.IconButton BtnCerrarr;
        private System.Windows.Forms.NumericUpDown nudRecargoBase;
        private System.Windows.Forms.DataGridView dgvTipoServicios;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudTarifaBase;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnNuevo;
        private System.Windows.Forms.RadioButton rdbInactivo;
        private System.Windows.Forms.RadioButton rdbActivo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNombreServicio;
        private System.Windows.Forms.Label yhuedrgbe;
        private System.Windows.Forms.TextBox txtCodigoTipoServicio;
        private System.Windows.Forms.Label CodigoHospitalizacion;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private FontAwesome.Sharp.IconButton btnExportar;
        private FontAwesome.Sharp.IconButton btnImprimir;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.TextBox txtBuscarNombre;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbInactivoEmergencia;
        private System.Windows.Forms.RadioButton rdbActivoEmergencia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNivelComplejidad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rdbInactivoLaboratorio;
        private System.Windows.Forms.RadioButton rdbActivoLaboratorio;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rdbInactivoHospitalizacion;
        private System.Windows.Forms.RadioButton rdbActivoHospitalizacion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox picPrestamoLibros;
    }
}