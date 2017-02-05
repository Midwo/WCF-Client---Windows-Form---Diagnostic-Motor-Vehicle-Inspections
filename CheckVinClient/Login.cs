using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckVinClient
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            CreateAccount m = new CreateAccount();
            m.ShowDialog();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            SignIn m = new SignIn();
            m.Show();
            this.Hide();
        }
    }
}
