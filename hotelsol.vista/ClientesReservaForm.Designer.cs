namespace HotelSol.hotelsol.vista
{
    partial class ClientesReservaForm
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
            dataGridClientesreserva = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridClientesreserva).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridClientesreserva);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(722, 423);
            panel1.TabIndex = 0;
            // 
            // dataGridClientesreserva
            // 
            dataGridClientesreserva.AllowUserToAddRows = false;
            dataGridClientesreserva.AllowUserToDeleteRows = false;
            dataGridClientesreserva.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridClientesreserva.Dock = DockStyle.Fill;
            dataGridClientesreserva.Location = new Point(0, 0);
            dataGridClientesreserva.Name = "dataGridClientesreserva";
            dataGridClientesreserva.ReadOnly = true;
            dataGridClientesreserva.RowHeadersWidth = 51;
            dataGridClientesreserva.Size = new Size(722, 423);
            dataGridClientesreserva.TabIndex = 0;
            dataGridClientesreserva.CellContentClick += dataGridClientesreserva_CellContentClick;
            // 
            // ClientesReservaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(722, 423);
            Controls.Add(panel1);
            Name = "ClientesReservaForm";
            Text = "ClientesReserva";
            Load += ClientesReservaForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridClientesreserva).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridClientesreserva;
    }
}