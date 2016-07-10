using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeChanger
{
    public partial class LoginForm : Form
    {
        private ILogin CallingControl;

        public LoginForm(ILogin callingControl)
        {
            InitializeComponent();
            this.CallingControl = callingControl;
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            Secrets secrets = new Secrets();
            secrets.email = tboxEmail.Text;
            secrets.password = tboxPassword.Text;
            this.CallingControl.PassSecrets(secrets);
            if (chboxRemember.Checked)
            {
                Misc.WriteSecrets(secrets);
            }
            this.Close();
        }
    }
}
