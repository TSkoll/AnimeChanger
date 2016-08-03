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
            this.tEmail = new MetroFramework.Controls.MetroTextBox();
            this.tPassword = new MetroFramework.Controls.MetroTextBox();
            this.chRemember = new MetroFramework.Controls.MetroCheckBox();
            this.bLogin = new MetroFramework.Controls.MetroButton();
            this.lHint = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // tEmail
            // 
            // 
            // 
            // 
            this.tEmail.CustomButton.Image = null;
            this.tEmail.CustomButton.Location = new System.Drawing.Point(218, 1);
            this.tEmail.CustomButton.Name = "";
            this.tEmail.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tEmail.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tEmail.CustomButton.TabIndex = 1;
            this.tEmail.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tEmail.CustomButton.UseSelectable = true;
            this.tEmail.CustomButton.Visible = false;
            this.tEmail.Lines = new string[] {
        "Email"};
            this.tEmail.Location = new System.Drawing.Point(20, 45);
            this.tEmail.MaxLength = 32767;
            this.tEmail.Name = "tEmail";
            this.tEmail.PasswordChar = '\0';
            this.tEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tEmail.SelectedText = "";
            this.tEmail.SelectionLength = 0;
            this.tEmail.SelectionStart = 0;
            this.tEmail.Size = new System.Drawing.Size(240, 23);
            this.tEmail.TabIndex = 0;
            this.tEmail.Text = "Email";
            this.tEmail.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tEmail.UseSelectable = true;
            this.tEmail.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tEmail.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tPassword
            // 
            // 
            // 
            // 
            this.tPassword.CustomButton.Image = null;
            this.tPassword.CustomButton.Location = new System.Drawing.Point(218, 1);
            this.tPassword.CustomButton.Name = "";
            this.tPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tPassword.CustomButton.TabIndex = 1;
            this.tPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tPassword.CustomButton.UseSelectable = true;
            this.tPassword.CustomButton.Visible = false;
            this.tPassword.Lines = new string[] {
        "Password"};
            this.tPassword.Location = new System.Drawing.Point(20, 74);
            this.tPassword.MaxLength = 32767;
            this.tPassword.Name = "tPassword";
            this.tPassword.PasswordChar = '*';
            this.tPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tPassword.SelectedText = "";
            this.tPassword.SelectionLength = 0;
            this.tPassword.SelectionStart = 0;
            this.tPassword.Size = new System.Drawing.Size(240, 23);
            this.tPassword.TabIndex = 1;
            this.tPassword.Text = "Password";
            this.tPassword.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tPassword.UseSelectable = true;
            this.tPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // chRemember
            // 
            this.chRemember.AutoSize = true;
            this.chRemember.Location = new System.Drawing.Point(20, 117);
            this.chRemember.Name = "chRemember";
            this.chRemember.Size = new System.Drawing.Size(101, 15);
            this.chRemember.TabIndex = 2;
            this.chRemember.Text = "Remember me";
            this.chRemember.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chRemember.UseSelectable = true;
            // 
            // bLogin
            // 
            this.bLogin.Location = new System.Drawing.Point(185, 110);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(75, 23);
            this.bLogin.TabIndex = 3;
            this.bLogin.Text = "Log in";
            this.bLogin.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.bLogin.UseSelectable = true;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // lHint
            // 
            this.lHint.AutoSize = true;
            this.lHint.Location = new System.Drawing.Point(20, 16);
            this.lHint.Name = "lHint";
            this.lHint.Size = new System.Drawing.Size(63, 19);
            this.lHint.Style = MetroFramework.MetroColorStyle.Black;
            this.lHint.TabIndex = 4;
            this.lHint.Text = "login hint";
            this.lHint.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 151);
            this.Controls.Add(this.lHint);
            this.Controls.Add(this.bLogin);
            this.Controls.Add(this.chRemember);
            this.Controls.Add(this.tPassword);
            this.Controls.Add(this.tEmail);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Magenta;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox tEmail;
        private MetroFramework.Controls.MetroTextBox tPassword;
        private MetroFramework.Controls.MetroCheckBox chRemember;
        private MetroFramework.Controls.MetroButton bLogin;
        private MetroFramework.Controls.MetroLabel lHint;
    }
}