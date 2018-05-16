using Hextech.LeagueClient;
using System;
using System.Windows.Forms;

namespace PassportPls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnStart.PerformClick();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            PasswordPort pp = Utility.GetPasswordPort();

            if (pp != null)
            {
                txtPassword.Invoke(new Action(() =>
                {
                    txtPassword.Text = pp.Password;
                    txtPort.Text = pp.Port.ToString();
                }));
            }
        }
    }
}
