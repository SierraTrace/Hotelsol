namespace HotelSol.hotelsol.vista
{
    partial class FacturasForm : Form
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
            chkServicios = new CheckedListBox();
            chkReservas = new CheckedListBox();
            btnCalcular = new Button();
            lblPrecioFinal = new Label();
            label1 = new Label();
            txtBuscarDNI = new TextBox();
            btnBuscarCliente = new Button();
            lblDescuento = new Label();
            cmbClientes = new ComboBox();
            panel6 = new Panel();
            dgvFacturas = new DataGridView();
            btnAgregarFactura = new Button();
            label17 = new Label();
            label18 = new Label();
            lblTotal = new Label();
            label20 = new Label();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            SuspendLayout();
            // 
            // panel5
            // 
            panel5.Controls.Add(chkServicios);
            panel5.Controls.Add(chkReservas);
            panel5.Controls.Add(btnCalcular);
            panel5.Controls.Add(lblPrecioFinal);
            panel5.Controls.Add(label1);
            panel5.Controls.Add(txtBuscarDNI);
            panel5.Controls.Add(btnBuscarCliente);
            panel5.Controls.Add(lblDescuento);
            panel5.Controls.Add(cmbClientes);
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(btnAgregarFactura);
            panel5.Controls.Add(label17);
            panel5.Controls.Add(label18);
            panel5.Controls.Add(lblTotal);
            panel5.Controls.Add(label20);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(1012, 953);
            panel5.TabIndex = 29;
            // 
            // chkServicios
            // 
            chkServicios.FormattingEnabled = true;
            chkServicios.Location = new Point(251, 370);
            chkServicios.Name = "chkServicios";
            chkServicios.Size = new Size(734, 136);
            chkServicios.TabIndex = 42;
            // 
            // chkReservas
            // 
            chkReservas.FormattingEnabled = true;
            chkReservas.Location = new Point(251, 192);
            chkReservas.Name = "chkReservas";
            chkReservas.Size = new Size(734, 136);
            chkReservas.TabIndex = 41;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(12, 457);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(179, 49);
            btnCalcular.TabIndex = 40;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            // 
            // lblPrecioFinal
            // 
            lblPrecioFinal.AutoSize = true;
            lblPrecioFinal.Location = new Point(101, 654);
            lblPrecioFinal.Name = "lblPrecioFinal";
            lblPrecioFinal.Size = new Size(90, 20);
            lblPrecioFinal.TabIndex = 39;
            lblPrecioFinal.Text = "Precio Total:";
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
            // txtBuscarDNI
            // 
            txtBuscarDNI.Location = new Point(251, 66);
            txtBuscarDNI.Name = "txtBuscarDNI";
            txtBuscarDNI.Size = new Size(250, 27);
            txtBuscarDNI.TabIndex = 37;
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
            // lblDescuento
            // 
            lblDescuento.AutoSize = true;
            lblDescuento.Location = new Point(109, 601);
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Size = new Size(82, 20);
            lblDescuento.TabIndex = 34;
            lblDescuento.Text = "Descuento:";
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(251, 123);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(250, 28);
            cmbClientes.TabIndex = 29;
            // 
            // panel6
            // 
            panel6.Controls.Add(dgvFacturas);
            panel6.Location = new Point(12, 786);
            panel6.Name = "panel6";
            panel6.Size = new Size(763, 155);
            panel6.TabIndex = 15;
            // 
            // dgvFacturas
            // 
            dgvFacturas.AllowUserToAddRows = false;
            dgvFacturas.AllowUserToDeleteRows = false;
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Dock = DockStyle.Fill;
            dgvFacturas.Location = new Point(0, 0);
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.ReadOnly = true;
            dgvFacturas.RowHeadersWidth = 51;
            dgvFacturas.Size = new Size(763, 155);
            dgvFacturas.TabIndex = 0;
            // 
            // btnAgregarFactura
            // 
            btnAgregarFactura.Location = new Point(12, 705);
            btnAgregarFactura.Name = "btnAgregarFactura";
            btnAgregarFactura.Size = new Size(179, 49);
            btnAgregarFactura.TabIndex = 7;
            btnAgregarFactura.Text = "Crear";
            btnAgregarFactura.UseVisualStyleBackColor = true;
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
            label18.Location = new Point(108, 192);
            label18.Name = "label18";
            label18.Size = new Size(66, 20);
            label18.TabIndex = 2;
            label18.Text = "Reservas";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(126, 543);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(65, 20);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "Importe:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(113, 370);
            label20.Name = "label20";
            label20.Size = new Size(67, 20);
            label20.TabIndex = 4;
            label20.Text = "Servicios";
            // 
            // FacturasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1012, 953);
            Controls.Add(panel5);
            Name = "FacturasForm";
            Text = "Facturas";
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel5;
        private Button btnCalcular;
        private Label lblPrecioFinal;
        private Label label1;
        private TextBox txtBuscarDNI;
        private Button btnBuscarCliente;
        private Label lblDescuento;
        private ComboBox cmbClientes;
        private Panel panel6;
        private DataGridView dgvFacturas;
        private Button btnAgregarFactura;
        private Label label17;
        private Label label18;
        private Label lblTotal;
        private Label label20;
        private CheckedListBox chkServicios;
        private CheckedListBox chkReservas;
    }
}