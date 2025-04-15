namespace HotelSol.hotelsol.vista
{
    partial class ServiciosForm : Form
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
            btnModificar = new Button();
            numPrecio = new NumericUpDown();
            btnBuscarCliente = new Button();
            panel2 = new Panel();
            dataGridServicios = new DataGridView();
            label6 = new Label();
            btnAgregar = new Button();
            txtConcepto = new TextBox();
            cmbClientes = new ComboBox();
            label1 = new Label();
            lblCliente = new Label();
            label5 = new Label();
            label4 = new Label();
            txtBuscarDni = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridServicios).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnModificar);
            panel1.Controls.Add(numPrecio);
            panel1.Controls.Add(btnBuscarCliente);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnAgregar);
            panel1.Controls.Add(txtConcepto);
            panel1.Controls.Add(cmbClientes);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblCliente);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtBuscarDni);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1018, 691);
            panel1.TabIndex = 13;
            panel1.Paint += panel1_Paint;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(197, 377);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(179, 49);
            btnModificar.TabIndex = 17;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // numPrecio
            // 
            numPrecio.DecimalPlaces = 2;
            numPrecio.Increment = new decimal(new int[] { 10, 0, 0, 131072 });
            numPrecio.Location = new Point(233, 252);
            numPrecio.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrecio.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(150, 27);
            numPrecio.TabIndex = 16;
            numPrecio.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.Location = new Point(693, 71);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(165, 29);
            btnBuscarCliente.TabIndex = 15;
            btnBuscarCliente.Text = "Buscar Cliente";
            btnBuscarCliente.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridServicios);
            panel2.Location = new Point(12, 466);
            panel2.Name = "panel2";
            panel2.Size = new Size(515, 475);
            panel2.TabIndex = 13;
            // 
            // dataGridServicios
            // 
            dataGridServicios.AllowUserToAddRows = false;
            dataGridServicios.AllowUserToDeleteRows = false;
            dataGridServicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridServicios.Dock = DockStyle.Fill;
            dataGridServicios.Location = new Point(0, 0);
            dataGridServicios.Name = "dataGridServicios";
            dataGridServicios.ReadOnly = true;
            dataGridServicios.RowHeadersWidth = 51;
            dataGridServicios.Size = new Size(515, 475);
            dataGridServicios.TabIndex = 0;
            // 
            // label6
            // 
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 377);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(179, 49);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Cargar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // txtConcepto
            // 
            txtConcepto.Location = new Point(233, 192);
            txtConcepto.MaxLength = 100;
            txtConcepto.Name = "txtConcepto";
            txtConcepto.Size = new Size(400, 27);
            txtConcepto.TabIndex = 3;
            // 
            // cmbClientes
            // 
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(233, 129);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(400, 28);
            cmbClientes.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(142, 80);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 1;
            label1.Text = "DNI";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(111, 137);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(58, 20);
            lblCliente.TabIndex = 2;
            lblCliente.Text = "Cliente:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(99, 259);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 9;
            label5.Text = "Precio";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(103, 199);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 4;
            label4.Text = "Concepto";
            // 
            // txtBuscarDni
            // 
            txtBuscarDni.Location = new Point(233, 71);
            txtBuscarDni.MaxLength = 30;
            txtBuscarDni.Name = "txtBuscarDni";
            txtBuscarDni.Size = new Size(394, 27);
            txtBuscarDni.TabIndex = 1;
            // 
            // ServiciosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 691);
            Controls.Add(panel1);
            Name = "ServiciosForm";
            Text = "Servicios";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridServicios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DataGridView dataGridServicios;
        private Label label6;
        private Button btnAgregar;
        private TextBox txtConcepto;
        private ComboBox cmbClientes;
        private Label label1;
        private Label lblCliente;
        private Label label5;
        private Label label4;
        private TextBox txtBuscarDni;
        private Button btnBuscarCliente;
        private NumericUpDown numPrecio;
        private Button btnModificar;
    }
}