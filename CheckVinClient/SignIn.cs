using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckVinClient
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        public static bool isEmail(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
                return false;

            Regex EmailAddress = new Regex(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");

            return EmailAddress.IsMatch(emailAddress);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isEmail(textBoxEmail.Text) == true)
            {
                if (maskedTextBoxPassword.Text.Trim() != string.Empty)
                {


                    MessageBox.Show("mamy to", "Error - email", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("Enter a password", "Error - email", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("Enter a valid email", "Error - email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SignIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void maskedTextBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(e, null);
            }
        }

        private void textBoxEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                maskedTextBoxPassword.Select();
            }
        }
    }
}
