namespace AnimeChanger
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
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.tboxEmail = new System.Windows.Forms.TextBox();
            this.tboxPassword = new System.Windows.Forms.TextBox();
            this.chboxRemember = new System.Windows.Forms.CheckBox();
            this.bLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(12, 9);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(38, 13);
            this.labelEmail.TabIndex = 0;
            this.labelEmail.Text = "E-mail:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 34);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password:";
            // 
            // tboxEmail
            // 
            this.tboxEmail.Location = new System.Drawing.Point(68, 6);
            this.tboxEmail.Name = "tboxEmail";
            this.tboxEmail.Size = new System.Drawing.Size(204, 20);
            this.tboxEmail.TabIndex = 2;
            // 
            // tboxPassword
            // 
            this.tboxPassword.Location = new System.Drawing.Point(68, 31);
            this.tboxPassword.Name = "tboxPassword";
            this.tboxPassword.PasswordChar = '⬤';
            this.tboxPassword.Size = new System.Drawing.Size(204, 20);
            this.tboxPassword.TabIndex = 3;
            // 
            // chboxRemember
            // 
            this.chboxRemember.AutoSize = true;
            this.chboxRemember.Location = new System.Drawing.Point(15, 61);
            this.chboxRemember.Name = "chboxRemember";
            this.chboxRemember.Size = new System.Drawing.Size(94, 17);
            this.chboxRemember.TabIndex = 4;
            this.chboxRemember.Text = "Remember me";
            this.chboxRemember.UseVisualStyleBackColor = true;
            // 
            // bLogin
            // 
            this.bLogin.Location = new System.Drawing.Point(197, 57);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(75, 23);
            this.bLogin.TabIndex = 5;
            this.bLogin.Text = "Log in";
            this.bLogin.UseVisualStyleBackColor = true;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 89);
            this.Controls.Add(this.bLogin);
            this.Controls.Add(this.chboxRemember);
            this.Controls.Add(this.tboxPassword);
            this.Controls.Add(this.tboxEmail);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Log in to Discord";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox tboxEmail;
        private System.Windows.Forms.TextBox tboxPassword;
        private System.Windows.Forms.CheckBox chboxRemember;
        private System.Windows.Forms.Button bLogin;
    }
}