using System;
using MetroFramework.Forms;

namespace AnimeChanger
{
    public partial class LoginFormMetro : MetroForm
    {
        private ILogin CallingControl;

        public LoginFormMetro(ILogin callingControl)
        {
            InitializeComponent();
            CallingControl = callingControl;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Secrets s = new Secrets();
            s.email = eBox.Text;
            s.password = pBox.Text;
            if (rBox.Checked)
            {
                Misc.WriteSecrets(s);
            }
            CallingControl.PassSecrets(s);
            Close();
        }
    }
}
