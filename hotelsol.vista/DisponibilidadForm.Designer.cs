namespace HotelSol.hotelsol.vista
{
    partial class DisponibilidadForm : Form 
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
            dataGridDisponibilidad = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridDisponibilidad).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridDisponibilidad);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(588, 450);
            panel1.TabIndex = 0;
            // 
            // dataGridDisponibilidad
            // 
            dataGridDisponibilidad.AllowUserToAddRows = false;
            dataGridDisponibilidad.AllowUserToDeleteRows = false;
            dataGridDisponibilidad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridDisponibilidad.Dock = DockStyle.Fill;
            dataGridDisponibilidad.Location = new Point(0, 0);
            dataGridDisponibilidad.Name = "dataGridDisponibilidad";
            dataGridDisponibilidad.ReadOnly = true;
            dataGridDisponibilidad.RowHeadersWidth = 51;
            dataGridDisponibilidad.Size = new Size(588, 450);
            dataGridDisponibilidad.TabIndex = 0;
            // 
            // DisponibilidadForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(588, 450);
            Controls.Add(panel1);
            Name = "DisponibilidadForm";
            Text = "Disponibilidad";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridDisponibilidad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridDisponibilidad;
    }
}