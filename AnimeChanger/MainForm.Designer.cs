namespace AnimeChanger
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lCurrent = new MetroFramework.Controls.MetroLabel();
            this.lTitle = new MetroFramework.Controls.MetroLabel();
            this.bLogin = new MetroFramework.Controls.MetroButton();
            this.pCover = new System.Windows.Forms.PictureBox();
            this.bMal = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pCover)).BeginInit();
            this.SuspendLayout();
            // 
            // lCurrent
            // 
            this.lCurrent.AutoSize = true;
            this.lCurrent.BackColor = System.Drawing.Color.Transparent;
            this.lCurrent.Location = new System.Drawing.Point(149, 30);
            this.lCurrent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lCurrent.Name = "lCurrent";
            this.lCurrent.Size = new System.Drawing.Size(117, 19);
            this.lCurrent.TabIndex = 0;
            this.lCurrent.Text = "Currently watching";
            this.lCurrent.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lCurrent.UseCustomBackColor = true;
            // 
            // lTitle
            // 
            this.lTitle.BackColor = System.Drawing.Color.Transparent;
            this.lTitle.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lTitle.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lTitle.Location = new System.Drawing.Point(149, 47);
            this.lTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(280, 120);
            this.lTitle.TabIndex = 1;
            this.lTitle.Text = "nothing ヾ(｡>﹏<｡)ﾉﾞ✧*。";
            this.lTitle.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lTitle.UseCustomBackColor = true;
            this.lTitle.UseCustomForeColor = true;
            this.lTitle.WrapToLine = true;
            // 
            // bLogin
            // 
            this.bLogin.Location = new System.Drawing.Point(145, 170);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(75, 23);
            this.bLogin.TabIndex = 2;
            this.bLogin.Text = "Log in";
            this.bLogin.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.bLogin.UseSelectable = true;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // pCover
            // 
            this.pCover.ErrorImage = global::AnimeChanger.Properties.Resources.noAni;
            this.pCover.Image = global::AnimeChanger.Properties.Resources.noAni;
            this.pCover.Location = new System.Drawing.Point(0, 5);
            this.pCover.Name = "pCover";
            this.pCover.Size = new System.Drawing.Size(140, 195);
            this.pCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pCover.TabIndex = 3;
            this.pCover.TabStop = false;
            this.pCover.DoubleClick += new System.EventHandler(this.pCover_DoubleClick);
            // 
            // bMal
            // 
            this.bMal.Enabled = false;
            this.bMal.Location = new System.Drawing.Point(297, 170);
            this.bMal.Name = "bMal";
            this.bMal.Size = new System.Drawing.Size(132, 23);
            this.bMal.TabIndex = 4;
            this.bMal.Text = "Connect with MAL";
            this.bMal.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.bMal.UseSelectable = true;
            this.bMal.Click += new System.EventHandler(this.bMal_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 200);
            this.Controls.Add(this.bMal);
            this.Controls.Add(this.bLogin);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.lCurrent);
            this.Controls.Add(this.pCover);
            this.DisplayHeader = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(18, 30, 18, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Magenta;
            this.Text = "AnimeChanger";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lCurrent;
        private MetroFramework.Controls.MetroLabel lTitle;
        private MetroFramework.Controls.MetroButton bLogin;
        private System.Windows.Forms.PictureBox pCover;
        private MetroFramework.Controls.MetroButton bMal;
    }
}