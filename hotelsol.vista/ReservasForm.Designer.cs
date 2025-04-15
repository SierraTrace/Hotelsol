namespace HotelSol.hotelsol.vista
{
    partial class ReservasForm : Form
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
            panel5 = new Panel();
            label1 = new Label();
            this.txtBuscarDni = new TextBox();
            btnBuscarCliente = new Button();
            cmbCliente = new ComboBox();
            panel6 = new Panel();
            dataGridReservas = new DataGridView();
            btnAgregar = new Button();
            label17 = new Label();
            label18 = new Label();
            label20 = new Label();
            dateFechaLlegada = new DateTimePicker();
            label2 = new Label();
            dateFechaSalida = new DateTimePicker();
            cmbTipoAlojamiento = new ComboBox();
            label3 = new Label();
            cmbHabitacion = new ComboBox();
            lblTemporadaDetectada = new Label();
            btnModificar = new Button();
            btnCancelar = new Button();
            btnCheckIn = new Button();
            btnCheckOut = new Button();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridReservas).BeginInit();
            SuspendLayout();
            // 
            // panel5
            // 
            panel5.Controls.Add(btnCheckOut);
            panel5.Controls.Add(btnCheckIn);
            panel5.Controls.Add(btnCancelar);
            panel5.Controls.Add(btnModificar);
            panel5.Controls.Add(lblTemporadaDetectada);
            panel5.Controls.Add(cmbHabitacion);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(cmbTipoAlojamiento);
            panel5.Controls.Add(dateFechaSalida);
            panel5.Controls.Add(label2);
            panel5.Controls.Add(dateFechaLlegada);
            panel5.Controls.Add(label1);
            panel5.Controls.Add(this.txtBuscarDni);
            panel5.Controls.Add(btnBuscarCliente);
            panel5.Controls.Add(cmbCliente);
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(btnAgregar);
            panel5.Controls.Add(label17);
            panel5.Controls.Add(label18);
            panel5.Controls.Add(label20);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(1282, 819);
            panel5.TabIndex = 30;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 73);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 38;
            label1.Text = "DNI";
            // 
            // txtBuscarDni
            // 
            this.txtBuscarDni.Location = new Point(251, 66);
            this.txtBuscarDni.Name = "txtBuscarDni";
            this.txtBuscarDni.Size = new Size(250, 27);
            this.txtBuscarDni.TabIndex = 37;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.Location = new Point(557, 64);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(170, 31);
            btnBuscarCliente.TabIndex = 36;
            btnBuscarCliente.Text = "Buscar Cliente";
            btnBuscarCliente.UseVisualStyleBackColor = true;
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(251, 123);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(250, 28);
            cmbCliente.TabIndex = 29;
            // 
            // panel6
            // 
            panel6.Controls.Add(dataGridReservas);
            panel6.Location = new Point(12, 535);
            panel6.Name = "panel6";
            panel6.Size = new Size(984, 272);
            panel6.TabIndex = 15;
            // 
            // dgvFacturas
            // 
            dataGridReservas.AllowUserToAddRows = false;
            dataGridReservas.AllowUserToDeleteRows = false;
            dataGridReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridReservas.Dock = DockStyle.Fill;
            dataGridReservas.Location = new Point(0, 0);
            dataGridReservas.Name = "dgvFacturas";
            dataGridReservas.ReadOnly = true;
            dataGridReservas.RowHeadersWidth = 51;
            dataGridReservas.Size = new Size(984, 272);
            dataGridReservas.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 462);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(179, 49);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Crear";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(119, 131);
            label17.Name = "label17";
            label17.Size = new Size(55, 20);
            label17.TabIndex = 1;
            label17.Text = "Cliente";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(70, 192);
            label18.Name = "label18";
            label18.Size = new Size(104, 20);
            label18.TabIndex = 2;
            label18.Text = "Fecha Llegada";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(49, 362);
            label20.Name = "label20";
            label20.Size = new Size(125, 20);
            label20.TabIndex = 4;
            label20.Text = "Tipo Alojamiento";
            // 
            // dateFechaLlegada
            // 
            dateFechaLlegada.Location = new Point(251, 185);
            dateFechaLlegada.Name = "dateFechaLlegada";
            dateFechaLlegada.Size = new Size(250, 27);
            dateFechaLlegada.TabIndex = 43;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(82, 253);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 44;
            label2.Text = "Fecha Salida";
            // 
            // dateFechaSalida
            // 
            dateFechaSalida.Location = new Point(251, 246);
            dateFechaSalida.Name = "dateFechaSalida";
            dateFechaSalida.Size = new Size(250, 27);
            dateFechaSalida.TabIndex = 45;
            // 
            // cmbTipoAlojamiento
            // 
            cmbTipoAlojamiento.FormattingEnabled = true;
            cmbTipoAlojamiento.Location = new Point(251, 354);
            cmbTipoAlojamiento.Name = "cmbTipoAlojamiento";
            cmbTipoAlojamiento.Size = new Size(250, 28);
            cmbTipoAlojamiento.TabIndex = 46;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(92, 309);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 47;
            label3.Text = "Habitación";
            // 
            // cmbHabitacion
            // 
            cmbHabitacion.FormattingEnabled = true;
            cmbHabitacion.Location = new Point(251, 301);
            cmbHabitacion.Name = "cmbHabitacion";
            cmbHabitacion.Size = new Size(250, 28);
            cmbHabitacion.TabIndex = 48;
            // 
            // lblTemporadaDetectada
            // 
            lblTemporadaDetectada.AutoSize = true;
            lblTemporadaDetectada.Location = new Point(86, 412);
            lblTemporadaDetectada.Name = "lblTemporadaDetectada";
            lblTemporadaDetectada.Size = new Size(88, 20);
            lblTemporadaDetectada.TabIndex = 49;
            lblTemporadaDetectada.Text = "Temporada:";
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(197, 462);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(179, 49);
            btnModificar.TabIndex = 50;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(382, 462);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(179, 49);
            btnCancelar.TabIndex = 51;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnCheckIn
            // 
            btnCheckIn.Location = new Point(567, 462);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(179, 49);
            btnCheckIn.TabIndex = 52;
            btnCheckIn.Text = "Check In";
            btnCheckIn.UseVisualStyleBackColor = true;
            // 
            // btnCheckOut
            // 
            btnCheckOut.Location = new Point(752, 462);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(179, 49);
            btnCheckOut.TabIndex = 53;
            btnCheckOut.Text = "Check Out";
            btnCheckOut.UseVisualStyleBackColor = true;
            // 
            // ReservasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 819);
            Controls.Add(panel5);
            Name = "ReservasForm";
            Text = "Reservas";
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridReservas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel5;
        private CheckedListBox chkServicios;
        private CheckedListBox chkReservas;
        private Label label1;
        private TextBox txtBuscarDni;
        private Button btnBuscarCliente;
        private ComboBox cmbCliente;
        private Panel panel6;
        private DataGridView dataGridReservas;
        private Button btnAgregar;
        private Label label17;
        private Label label18;
        private Label label20;
        private ComboBox cmbTipoAlojamiento;
        private DateTimePicker dateFechaSalida;
        private Label label2;
        private DateTimePicker dateFechaLlegada;
        private Label label3;
        private ComboBox cmbHabitacion;
        private Label lblTemporadaDetectada;
        private Button btnModificar;
        private Button btnCheckIn;
        private Button btnCancelar;
        private Button btnCheckOut;
    }
}