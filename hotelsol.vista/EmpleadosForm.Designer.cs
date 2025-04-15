namespace HotelSol.hotelsol.vista
{
    partial class EmpleadosForm
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
            btnAgregar = new Button();
            txtContraseña = new TextBox();
            txtApellido = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtNombre = new TextBox();
            label5 = new Label();
            txtUserName = new TextBox();
            cmbCategoria = new ComboBox();
            panel1 = new Panel();
            panel2 = new Panel();
            dataGridViewEmpleados = new DataGridView();
            label6 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpleados).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 377);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(179, 49);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Crear";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(251, 308);
            txtContraseña.MaxLength = 15;
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(400, 27);
            txtContraseña.TabIndex = 4;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(251, 130);
            txtApellido.MaxLength = 30;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(400, 27);
            txtApellido.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(103, 199);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 4;
            label4.Text = "Categoria";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(94, 315);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 3;
            label3.Text = "Contraseña";
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(113, 79);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 1;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(251, 72);
            txtNombre.MaxLength = 30;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(400, 27);
            txtNombre.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(99, 259);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 9;
            label5.Text = "UserName";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(251, 252);
            txtUserName.MaxLength = 15;
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(400, 27);
            txtUserName.TabIndex = 3;
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(251, 191);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(400, 28);
            cmbCategoria.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtNombre);
            panel1.Controls.Add(btnAgregar);
            panel1.Controls.Add(txtUserName);
            panel1.Controls.Add(txtContraseña);
            panel1.Controls.Add(cmbCategoria);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtApellido);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(882, 953);
            panel1.TabIndex = 12;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridViewEmpleados);
            panel2.Location = new Point(12, 466);
            panel2.Name = "panel2";
            panel2.Size = new Size(621, 475);
            panel2.TabIndex = 13;
            // 
            // dataGridViewEmpleados
            // 
            dataGridViewEmpleados.AllowUserToAddRows = false;
            dataGridViewEmpleados.AllowUserToDeleteRows = false;
            dataGridViewEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmpleados.Dock = DockStyle.Fill;
            dataGridViewEmpleados.Location = new Point(0, 0);
            dataGridViewEmpleados.Name = "dataGridViewEmpleados";
            dataGridViewEmpleados.ReadOnly = true;
            dataGridViewEmpleados.RowHeadersWidth = 51;
            dataGridViewEmpleados.Size = new Size(621, 475);
            dataGridViewEmpleados.TabIndex = 0;
            // 
            // label6
            // 
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 0;
            // 
            // EmpleadosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 953);
            Controls.Add(panel1);
            Name = "EmpleadosForm";
            Text = "Empleados";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpleados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAgregar;
        private TextBox txtContraseña;
        private TextBox txtApellido;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtNombre;
        private Label label5;
        private TextBox txtUserName;
        private ComboBox cmbCategoria;
        private Panel panel1;
        private Label label6;
        private Panel panel2;
        private DataGridView dataGridViewEmpleados;
    }
}