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
        private Secrets secrets;
        private ILogin CallingControl;

        public LoginForm(ILogin callingControl)
        {
            InitializeComponent();
            this.CallingControl = callingControl;
            this.secrets = callingControl.secrets;
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            this.secrets.email = tboxEmail.Text;
            this.secrets.password = tboxPassword.Text;
            if (chboxRemember.Checked)
            {
                Misc.WriteSecrets(secrets);
            }
            this.CallingControl.PassSecrets(secrets);
            this.Close();
        }
    }
}
