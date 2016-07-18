namespace AnimeChanger
{
    partial class MainFormMetro
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.titleLabel = new MetroFramework.Controls.MetroLabel();
            this.LoginBtn = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.metroLabel1.Location = new System.Drawing.Point(24, 28);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(117, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Currently watching";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.titleLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.titleLabel.Location = new System.Drawing.Point(24, 47);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(222, 25);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "nothing ヾ(｡>﹏<｡)ﾉﾞ✧*。";
            this.titleLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(24, 84);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(75, 23);
            this.LoginBtn.TabIndex = 2;
            this.LoginBtn.Text = "Log in";
            this.LoginBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.LoginBtn.UseSelectable = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // MainFormMetro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 130);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.metroLabel1);
            this.DisplayHeader = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.MaximizeBox = false;
            this.Name = "MainFormMetro";
            this.Padding = new System.Windows.Forms.Padding(18, 30, 18, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Magenta;
            this.Text = "AnimeChanger";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormMetro_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel titleLabel;
        private MetroFramework.Controls.MetroButton LoginBtn;
    }
}