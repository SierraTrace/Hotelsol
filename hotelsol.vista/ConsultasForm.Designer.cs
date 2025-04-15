namespace HotelSol.hotelsol.vista
{
    partial class ConsultasForm
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
            btnDisponibilidad = new Button();
            label3 = new Label();
            label2 = new Label();
            dateDisponibilidadSalida = new DateTimePicker();
            dateDisponibilidadLlegada = new DateTimePicker();
            label1 = new Label();
            panel3 = new Panel();
            btnClientesReserva = new Button();
            label7 = new Label();
            dateClientesReserva = new DateTimePicker();
            label6 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDisponibilidad);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dateDisponibilidadSalida);
            panel1.Controls.Add(dateDisponibilidadLlegada);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 44);
            panel1.Name = "panel1";
            panel1.Size = new Size(1017, 260);
            panel1.TabIndex = 0;
            // 
            // btnDisponibilidad
            // 
            btnDisponibilidad.Location = new Point(400, 160);
            btnDisponibilidad.Name = "btnDisponibilidad";
            btnDisponibilidad.Size = new Size(171, 50);
            btnDisponibilidad.TabIndex = 5;
            btnDisponibilidad.Text = "Buscar";
            btnDisponibilidad.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 160);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 4;
            label3.Text = "Fecha Salida";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 75);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 3;
            label2.Text = "Fecha Llegada";
            // 
            // dateDisponibilidadSalida
            // 
            dateDisponibilidadSalida.Location = new Point(68, 183);
            dateDisponibilidadSalida.Name = "dateDisponibilidadSalida";
            dateDisponibilidadSalida.Size = new Size(250, 27);
            dateDisponibilidadSalida.TabIndex = 2;
            // 
            // dateDisponibilidadLlegada
            // 
            dateDisponibilidadLlegada.Location = new Point(68, 98);
            dateDisponibilidadLlegada.Name = "dateDisponibilidadLlegada";
            dateDisponibilidadLlegada.Size = new Size(250, 27);
            dateDisponibilidadLlegada.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 34);
            label1.Name = "label1";
            label1.Size = new Size(216, 20);
            label1.TabIndex = 0;
            label1.Text = "Disponibilidad de habitaciones";
            // 
            // panel3
            // 
            panel3.Controls.Add(btnClientesReserva);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(dateClientesReserva);
            panel3.Controls.Add(label6);
            panel3.Location = new Point(12, 310);
            panel3.Name = "panel3";
            panel3.Size = new Size(1017, 213);
            panel3.TabIndex = 2;
            // 
            // btnClientesReserva
            // 
            btnClientesReserva.Location = new Point(400, 104);
            btnClientesReserva.Name = "btnClientesReserva";
            btnClientesReserva.Size = new Size(171, 50);
            btnClientesReserva.TabIndex = 7;
            btnClientesReserva.Text = "Buscar";
            btnClientesReserva.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(68, 104);
            label7.Name = "label7";
            label7.Size = new Size(47, 20);
            label7.TabIndex = 3;
            label7.Text = "Fecha";
            // 
            // dateClientesReserva
            // 
            dateClientesReserva.Location = new Point(68, 127);
            dateClientesReserva.Name = "dateClientesReserva";
            dateClientesReserva.Size = new Size(250, 27);
            dateClientesReserva.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(68, 55);
            label6.Name = "label6";
            label6.Size = new Size(144, 20);
            label6.TabIndex = 0;
            label6.Text = "Clientes con Reserva";
            // 
            // ConsultasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 519);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "ConsultasForm";
            Text = "Consultas";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel3;
        private DateTimePicker dateDisponibilidadSalida;
        private DateTimePicker dateDisponibilidadLlegada;
        private Button btnDisponibilidad;
        private Label label3;
        private Label label2;
        private DateTimePicker dateClientesReserva;
        private Label label6;
        private Button btnClientesReserva;
        private Label label7;
    }
}