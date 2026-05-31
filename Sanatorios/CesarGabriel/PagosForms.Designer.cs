namespace Sanatorios
{
    partial class PagosForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagosForms));
            this.chkSeleccionar = new System.Windows.Forms.CheckBox();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.dgvRegistroPagos = new System.Windows.Forms.DataGridView();
            this.nudTotalCancelado = new System.Windows.Forms.NumericUpDown();
            this.nudCambio = new System.Windows.Forms.NumericUpDown();
            this.nudMontoPagado = new System.Windows.Forms.NumericUpDown();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnExportar = new FontAwesome.Sharp.IconButton();
            this.btnImprimir = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtBuscarNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.cmbCodigoFactura = new System.Windows.Forms.ComboBox();
            this.nudMora = new System.Windows.Forms.NumericUpDown();
            this.nudMontoFactura = new System.Windows.Forms.NumericUpDown();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnEditar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.btnNuevo = new FontAwesome.Sharp.IconButton();
            this.rdbInactivo = new System.Windows.Forms.RadioButton();
            this.rdbActivo = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.yhuedrgbe = new System.Windows.Forms.Label();
            this.txtCodigoPago = new System.Windows.Forms.TextBox();
            this.CodigoSeguro = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picPrestamoLibros = new System.Windows.Forms.PictureBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.BtnCerrarr = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalCancelado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCambio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoPagado)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrestamoLibros)).BeginInit();
            this.SuspendLayout();
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
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvRegistroPagos
            // 
            this.dgvRegistroPagos.AllowUserToAddRows = false;
            this.dgvRegistroPagos.AllowUserToDeleteRows = false;
            this.dgvRegistroPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRegistroPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistroPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dgvRegistroPagos.Location = new System.Drawing.Point(12, 77);
            this.dgvRegistroPagos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRegistroPagos.MultiSelect = false;
            this.dgvRegistroPagos.Name = "dgvRegistroPagos";
            this.dgvRegistroPagos.ReadOnly = true;
            this.dgvRegistroPagos.RowHeadersWidth = 51;
            this.dgvRegistroPagos.RowTemplate.Height = 24;
            this.dgvRegistroPagos.Size = new System.Drawing.Size(995, 335);
            this.dgvRegistroPagos.TabIndex = 14;
            this.dgvRegistroPagos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistroPagos_CellContentClick);
            // 
            // nudTotalCancelado
            // 
            this.nudTotalCancelado.DecimalPlaces = 2;
            this.nudTotalCancelado.Location = new System.Drawing.Point(148, 323);
            this.nudTotalCancelado.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudTotalCancelado.Name = "nudTotalCancelado";
            this.nudTotalCancelado.Size = new System.Drawing.Size(211, 20);
            this.nudTotalCancelado.TabIndex = 50;
            // 
            // nudCambio
            // 
            this.nudCambio.DecimalPlaces = 2;
            this.nudCambio.Location = new System.Drawing.Point(613, 122);
            this.nudCambio.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudCambio.Name = "nudCambio";
            this.nudCambio.Size = new System.Drawing.Size(211, 20);
            this.nudCambio.TabIndex = 49;
            // 
            // nudMontoPagado
            // 
            this.nudMontoPagado.DecimalPlaces = 2;
            this.nudMontoPagado.Location = new System.Drawing.Point(615, 82);
            this.nudMontoPagado.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudMontoPagado.Name = "nudMontoPagado";
            this.nudMontoPagado.Size = new System.Drawing.Size(211, 20);
            this.nudMontoPagado.TabIndex = 48;
            this.nudMontoPagado.ValueChanged += new System.EventHandler(this.nudMontoPagado_ValueChanged);
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Location = new System.Drawing.Point(160, 115);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(209, 20);
            this.dtpFechaPago.TabIndex = 45;
            this.dtpFechaPago.ValueChanged += new System.EventHandler(this.dtpFechaPago_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(526, 126);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 13);
            this.label16.TabIndex = 43;
            this.label16.Text = "Cambio:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(42, 115);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 13);
            this.label15.TabIndex = 42;
            this.label15.Text = "Fecha de Pago:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(42, 325);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "Total Cancelado:";
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
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
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
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
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
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(23, 64);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1024, 488);
            this.tabControl1.TabIndex = 44;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.btnExportar);
            this.tabPage1.Controls.Add(this.btnImprimir);
            this.tabPage1.Controls.Add(this.btnLimpiar);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.dgvRegistroPagos);
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
            // txtBuscarNombre
            // 
            this.txtBuscarNombre.Location = new System.Drawing.Point(70, 24);
            this.txtBuscarNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscarNombre.Name = "txtBuscarNombre";
            this.txtBuscarNombre.Size = new System.Drawing.Size(352, 20);
            this.txtBuscarNombre.TabIndex = 11;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbMetodoPago);
            this.groupBox1.Controls.Add(this.cmbCodigoFactura);
            this.groupBox1.Controls.Add(this.nudMora);
            this.groupBox1.Controls.Add(this.nudTotalCancelado);
            this.groupBox1.Controls.Add(this.nudCambio);
            this.groupBox1.Controls.Add(this.nudMontoPagado);
            this.groupBox1.Controls.Add(this.dtpFechaPago);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.nudMontoFactura);
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
            this.groupBox1.Controls.Add(this.yhuedrgbe);
            this.groupBox1.Controls.Add(this.txtCodigoPago);
            this.groupBox1.Controls.Add(this.CodigoSeguro);
            this.groupBox1.Location = new System.Drawing.Point(18, 22);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(974, 425);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta",
            "Transferencia",
            "Deposito"});
            this.cmbMetodoPago.Location = new System.Drawing.Point(615, 37);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(219, 21);
            this.cmbMetodoPago.TabIndex = 56;
            // 
            // cmbCodigoFactura
            // 
            this.cmbCodigoFactura.FormattingEnabled = true;
            this.cmbCodigoFactura.Location = new System.Drawing.Point(148, 71);
            this.cmbCodigoFactura.Name = "cmbCodigoFactura";
            this.cmbCodigoFactura.Size = new System.Drawing.Size(219, 21);
            this.cmbCodigoFactura.TabIndex = 55;
            this.cmbCodigoFactura.SelectedIndexChanged += new System.EventHandler(this.cbCodigoFactura_SelectedIndexChanged);
            // 
            // nudMora
            // 
            this.nudMora.DecimalPlaces = 2;
            this.nudMora.Location = new System.Drawing.Point(148, 285);
            this.nudMora.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudMora.Name = "nudMora";
            this.nudMora.Size = new System.Drawing.Size(211, 20);
            this.nudMora.TabIndex = 52;
            // 
            // nudMontoFactura
            // 
            this.nudMontoFactura.DecimalPlaces = 2;
            this.nudMontoFactura.Location = new System.Drawing.Point(148, 247);
            this.nudMontoFactura.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.nudMontoFactura.Name = "nudMontoFactura";
            this.nudMontoFactura.Size = new System.Drawing.Size(211, 20);
            this.nudMontoFactura.TabIndex = 34;
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
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
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
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // rdbInactivo
            // 
            this.rdbInactivo.AutoSize = true;
            this.rdbInactivo.Location = new System.Drawing.Point(266, 153);
            this.rdbInactivo.Margin = new System.Windows.Forms.Padding(2);
            this.rdbInactivo.Name = "rdbInactivo";
            this.rdbInactivo.Size = new System.Drawing.Size(63, 17);
            this.rdbInactivo.TabIndex = 20;
            this.rdbInactivo.TabStop = true;
            this.rdbInactivo.Text = "Inactivo";
            this.rdbInactivo.UseVisualStyleBackColor = true;
            // 
            // rdbActivo
            // 
            this.rdbActivo.AutoSize = true;
            this.rdbActivo.Location = new System.Drawing.Point(156, 153);
            this.rdbActivo.Margin = new System.Windows.Forms.Padding(2);
            this.rdbActivo.Name = "rdbActivo";
            this.rdbActivo.Size = new System.Drawing.Size(55, 17);
            this.rdbActivo.TabIndex = 19;
            this.rdbActivo.TabStop = true;
            this.rdbActivo.Text = "Activo";
            this.rdbActivo.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(61, 155);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Estado:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(70, 287);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Mora:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(509, 40);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Metodo Pago:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 249);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Monto Factura:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(506, 84);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Monto Pagado:";
            // 
            // yhuedrgbe
            // 
            this.yhuedrgbe.AutoSize = true;
            this.yhuedrgbe.Location = new System.Drawing.Point(28, 80);
            this.yhuedrgbe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.yhuedrgbe.Name = "yhuedrgbe";
            this.yhuedrgbe.Size = new System.Drawing.Size(97, 13);
            this.yhuedrgbe.TabIndex = 2;
            this.yhuedrgbe.Text = "Codigo de Factura:";
            // 
            // txtCodigoPago
            // 
            this.txtCodigoPago.Location = new System.Drawing.Point(133, 37);
            this.txtCodigoPago.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoPago.Name = "txtCodigoPago";
            this.txtCodigoPago.ReadOnly = true;
            this.txtCodigoPago.Size = new System.Drawing.Size(236, 20);
            this.txtCodigoPago.TabIndex = 1;
            // 
            // CodigoSeguro
            // 
            this.CodigoSeguro.AutoSize = true;
            this.CodigoSeguro.Location = new System.Drawing.Point(39, 44);
            this.CodigoSeguro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CodigoSeguro.Name = "CodigoSeguro";
            this.CodigoSeguro.Size = new System.Drawing.Size(83, 13);
            this.CodigoSeguro.TabIndex = 0;
            this.CodigoSeguro.Text = "Codigo de Pago";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(825, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 29);
            this.label1.TabIndex = 43;
            this.label1.Text = "Pagos";
            // 
            // picPrestamoLibros
            // 
            this.picPrestamoLibros.Image = ((System.Drawing.Image)(resources.GetObject("picPrestamoLibros.Image")));
            this.picPrestamoLibros.Location = new System.Drawing.Point(931, 2);
            this.picPrestamoLibros.Margin = new System.Windows.Forms.Padding(2);
            this.picPrestamoLibros.Name = "picPrestamoLibros";
            this.picPrestamoLibros.Size = new System.Drawing.Size(70, 58);
            this.picPrestamoLibros.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPrestamoLibros.TabIndex = 46;
            this.picPrestamoLibros.TabStop = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage_1);
            // 
            // BtnCerrarr
            // 
            this.BtnCerrarr.IconChar = FontAwesome.Sharp.IconChar.X;
            this.BtnCerrarr.IconColor = System.Drawing.Color.Black;
            this.BtnCerrarr.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnCerrarr.IconSize = 20;
            this.BtnCerrarr.Location = new System.Drawing.Point(953, 588);
            this.BtnCerrarr.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCerrarr.Name = "BtnCerrarr";
            this.BtnCerrarr.Size = new System.Drawing.Size(90, 28);
            this.BtnCerrarr.TabIndex = 45;
            this.BtnCerrarr.Text = "Cerrar";
            this.BtnCerrarr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCerrarr.UseVisualStyleBackColor = true;
            // 
            // PagosForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 625);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picPrestamoLibros);
            this.Controls.Add(this.BtnCerrarr);
            this.Name = "PagosForms";
            this.Text = "PagosForms";
            this.Load += new System.EventHandler(this.PagosForms_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalCancelado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCambio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoPagado)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrestamoLibros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSeleccionar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.DataGridView dgvRegistroPagos;
        private System.Windows.Forms.NumericUpDown nudTotalCancelado;
        private System.Windows.Forms.NumericUpDown nudCambio;
        private System.Windows.Forms.NumericUpDown nudMontoPagado;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private FontAwesome.Sharp.IconButton btnExportar;
        private FontAwesome.Sharp.IconButton btnImprimir;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtBuscarNombre;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudMontoFactura;
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
        private System.Windows.Forms.Label yhuedrgbe;
        private System.Windows.Forms.TextBox txtCodigoPago;
        private System.Windows.Forms.Label CodigoSeguro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picPrestamoLibros;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private FontAwesome.Sharp.IconButton BtnCerrarr;
        private System.Windows.Forms.NumericUpDown nudMora;
        private System.Windows.Forms.ComboBox cmbCodigoFactura;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
    }
}