using System;
using MetroFramework.Forms;

namespace AnimeChanger
{
    public partial class LoginForm : MetroForm
    {
        private string _target;
        public Secrets Sec { get; set; }

        public LoginForm(string target)
        {
            _target = target;
            InitializeComponent();
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            Secrets buffer = new Secrets();
            buffer.id = tEmail.Text;
            buffer.pass = tPassword.Text;

            if (chRemember.Checked)
                Misc.WriteSecrets(buffer, _target);

            Sec = buffer;
            Close();
        }
    }
}
