namespace HotelSol.hotelsol.vista
{
    partial class ClientesForm
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
            panel1 = new Panel();
            btnHistorial = new Button();
            btnModificar = new Button();
            label8 = new Label();
            label7 = new Label();
            txtTelefono = new TextBox();
            panel3 = new Panel();
            dataGridViewClientes = new DataGridView();
            txtNombre = new TextBox();
            btnAgregar = new Button();
            txtEmail = new TextBox();
            txtDNI = new TextBox();
            cmbTipoCliente = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtApellido = new TextBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnHistorial);
            panel1.Controls.Add(btnModificar);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtTelefono);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(txtNombre);
            panel1.Controls.Add(btnAgregar);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(txtDNI);
            panel1.Controls.Add(cmbTipoCliente);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtApellido);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(994, 1001);
            panel1.TabIndex = 14;
            panel1.Paint += panel1_Paint;
            // 
            // btnHistorial
            // 
            btnHistorial.Location = new Point(382, 470);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(179, 49);
            btnHistorial.TabIndex = 21;
            btnHistorial.Text = "Historial Cliente";
            btnHistorial.UseVisualStyleBackColor = true;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(197, 470);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(179, 49);
            btnModificar.TabIndex = 20;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(97, 396);
            label8.Name = "label8";
            label8.Size = new Size(85, 20);
            label8.TabIndex = 19;
            label8.Text = "TipoCliente";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(115, 327);
            label7.Name = "label7";
            label7.Size = new Size(67, 20);
            label7.TabIndex = 17;
            label7.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(251, 320);
            txtTelefono.MaxLength = 13;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(400, 27);
            txtTelefono.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGridViewClientes);
            panel3.Location = new Point(12, 553);
            panel3.Name = "panel3";
            panel3.Size = new Size(861, 436);
            panel3.TabIndex = 15;
            // 
            // dataGridViewClientes
            // 
            dataGridViewClientes.AllowUserToAddRows = false;
            dataGridViewClientes.AllowUserToDeleteRows = false;
            dataGridViewClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClientes.Dock = DockStyle.Fill;
            dataGridViewClientes.Location = new Point(0, 0);
            dataGridViewClientes.Name = "dataGridViewClientes";
            dataGridViewClientes.ReadOnly = true;
            dataGridViewClientes.RowHeadersWidth = 51;
            dataGridViewClientes.Size = new Size(861, 436);
            dataGridViewClientes.TabIndex = 0;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(251, 72);
            txtNombre.MaxLength = 30;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(400, 27);
            txtNombre.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 470);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(179, 49);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Crear";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(251, 256);
            txtEmail.MaxLength = 30;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(400, 27);
            txtEmail.TabIndex = 3;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(251, 192);
            txtDNI.MaxLength = 15;
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(400, 27);
            txtDNI.TabIndex = 2;
            // 
            // cmbTipoCliente
            // 
            cmbTipoCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoCliente.FormattingEnabled = true;
            cmbTipoCliente.Location = new Point(251, 388);
            cmbTipoCliente.Name = "cmbTipoCliente";
            cmbTipoCliente.Size = new Size(400, 28);
            cmbTipoCliente.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(113, 79);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 1;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(111, 137);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 2;
            label2.Text = "Apellido";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(131, 263);
            label5.Name = "label5";
            label5.Size = new Size(46, 20);
            label5.TabIndex = 9;
            label5.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(142, 199);
            label4.Name = "label4";
            label4.Size = new Size(35, 20);
            label4.TabIndex = 4;
            label4.Text = "DNI";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(251, 130);
            txtApellido.MaxLength = 30;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(400, 27);
            txtApellido.TabIndex = 1;
            // 
            // ClientesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(994, 1001);
            Controls.Add(panel1);
            Name = "ClientesForm";
            Text = "Clientes";
            Load += ClientesForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private DataGridView dataGridViewClientes;
        private TextBox txtNombre;
        private Button btnAgregar;
        private TextBox txtEmail;
        private TextBox txtDNI;
        private ComboBox cmbTipoCliente;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label label4;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private Label label8;
        private Label label7;
        private Button btnModificar;
        private Button btnHistorial;
    }
}