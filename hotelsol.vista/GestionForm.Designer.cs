namespace HotelSol.hotelsol.vista
{
    partial class GestionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelContenedor;
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
            panelContenedor = new Panel();
            panel1 = new Panel();
            panelContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor
            // 
            panelContenedor.Controls.Add(panel1);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 0);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1082, 753);
            panelContenedor.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1082, 753);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // GestionForm
            // 
            ClientSize = new Size(1082, 753);
            Controls.Add(panelContenedor);
            Name = "GestionForm";
            Text = "Gestión";
            panelContenedor.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
    }
}