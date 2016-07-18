using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
