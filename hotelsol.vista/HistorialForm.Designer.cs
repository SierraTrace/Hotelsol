namespace HotelSol.hotelsol.vista
{
    partial class HistorialForm : Form  
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
            dataGridHistorial = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridHistorial).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridHistorial);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(856, 337);
            panel1.TabIndex = 0;
            // 
            // dataGridHistorial
            // 
            dataGridHistorial.AllowUserToAddRows = false;
            dataGridHistorial.AllowUserToDeleteRows = false;
            dataGridHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridHistorial.Dock = DockStyle.Fill;
            dataGridHistorial.Location = new Point(0, 0);
            dataGridHistorial.Name = "dataGridHistorial";
            dataGridHistorial.ReadOnly = true;
            dataGridHistorial.RowHeadersWidth = 51;
            dataGridHistorial.Size = new Size(856, 337);
            dataGridHistorial.TabIndex = 0;
            // 
            // HistorialForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 337);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "HistorialForm";
            Text = "Historial";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridHistorial).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridHistorial;
    }
}