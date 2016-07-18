namespace AnimeChanger
{
    partial class LoginFormMetro
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
            this.eBox = new MetroFramework.Controls.MetroTextBox();
            this.pBox = new MetroFramework.Controls.MetroTextBox();
            this.rBox = new MetroFramework.Controls.MetroCheckBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // eBox
            // 
            // 
            // 
            // 
            this.eBox.CustomButton.Image = null;
            this.eBox.CustomButton.Location = new System.Drawing.Point(218, 1);
            this.eBox.CustomButton.Name = "";
            this.eBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.eBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.eBox.CustomButton.TabIndex = 1;
            this.eBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.eBox.CustomButton.UseSelectable = true;
            this.eBox.CustomButton.Visible = false;
            this.eBox.Lines = new string[] {
        "Email"};
            this.eBox.Location = new System.Drawing.Point(23, 34);
            this.eBox.MaxLength = 32767;
            this.eBox.Name = "eBox";
            this.eBox.PasswordChar = '\0';
            this.eBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.eBox.SelectedText = "";
            this.eBox.SelectionLength = 0;
            this.eBox.SelectionStart = 0;
            this.eBox.Size = new System.Drawing.Size(240, 23);
            this.eBox.TabIndex = 0;
            this.eBox.Text = "Email";
            this.eBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.eBox.UseSelectable = true;
            this.eBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.eBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pBox
            // 
            // 
            // 
            // 
            this.pBox.CustomButton.Image = null;
            this.pBox.CustomButton.Location = new System.Drawing.Point(218, 1);
            this.pBox.CustomButton.Name = "";
            this.pBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.pBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.pBox.CustomButton.TabIndex = 1;
            this.pBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.pBox.CustomButton.UseSelectable = true;
            this.pBox.CustomButton.Visible = false;
            this.pBox.Lines = new string[] {
        "Password"};
            this.pBox.Location = new System.Drawing.Point(23, 63);
            this.pBox.MaxLength = 32767;
            this.pBox.Name = "pBox";
            this.pBox.PasswordChar = '*';
            this.pBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.pBox.SelectedText = "";
            this.pBox.SelectionLength = 0;
            this.pBox.SelectionStart = 0;
            this.pBox.Size = new System.Drawing.Size(240, 23);
            this.pBox.TabIndex = 1;
            this.pBox.Text = "Password";
            this.pBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.pBox.UseSelectable = true;
            this.pBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.pBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // rBox
            // 
            this.rBox.AutoSize = true;
            this.rBox.Location = new System.Drawing.Point(23, 106);
            this.rBox.Name = "rBox";
            this.rBox.Size = new System.Drawing.Size(101, 15);
            this.rBox.TabIndex = 2;
            this.rBox.Text = "Remember me";
            this.rBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.rBox.UseSelectable = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(188, 99);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 3;
            this.metroButton1.Text = "Log in";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // LoginFormMetro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 145);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.rBox);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.eBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 145);
            this.Name = "LoginFormMetro";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Magenta;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox eBox;
        private MetroFramework.Controls.MetroTextBox pBox;
        private MetroFramework.Controls.MetroCheckBox rBox;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}