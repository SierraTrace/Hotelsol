namespace HotelSol.hotelsol.vista
{
    partial class LoginForm
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
            label1 = new Label();
            label2 = new Label();
            userNameTxt = new TextBox();
            button1 = new Button();
            contraseñaTxt = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(182, 144);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 0;
            label1.Text = "UserName";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(182, 256);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // userNameTxt
            // 
            userNameTxt.Location = new Point(298, 137);
            userNameTxt.MaxLength = 15;
            userNameTxt.Name = "userNameTxt";
            userNameTxt.Size = new Size(322, 27);
            userNameTxt.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(363, 336);
            button1.Name = "button1";
            button1.Size = new Size(194, 68);
            button1.TabIndex = 2;
            button1.Text = "Inicio de sesión";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnLogin_Click;
            // 
            // contraseñaTxt
            // 
            contraseñaTxt.Location = new Point(298, 249);
            contraseñaTxt.MaxLength = 15;
            contraseñaTxt.Name = "contraseñaTxt";
            contraseñaTxt.Size = new Size(322, 27);
            contraseñaTxt.TabIndex = 1;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(contraseñaTxt);
            Controls.Add(button1);
            Controls.Add(userNameTxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "HotelSol";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox userNameTxt;
        private Button button1;
        private TextBox contraseñaTxt;
    }
}