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
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isEmail(textBoxEmail.Text) == false)
            {
                MessageBox.Show("Enter a valid email", "Error - email", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (textBoxName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter a your name", "Error - name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBoxSurname.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter a your surname", "Error - surname", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string z = maskedTextBoxPhone.Text;
            int index = z.IndexOf(" ");
            if (index > 0)
            {
                MessageBox.Show("Enter a valid number", "Error - phone", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            WCFVIN.CheckVinClient_Account component = new WCFVIN.CheckVinClient_Account();
            EncryptDecrypt SendText = new EncryptDecrypt();
            component.AdressEmail = SendText.encrypt(textBoxEmail.Text);
            component.Name = SendText.encrypt(textBoxName.Text);
            component.Phone = SendText.encrypt(maskedTextBoxPhone.Text);
            component.Surname = SendText.encrypt(textBoxSurname.Text);

         
        }

        public static bool isEmail(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
                return false;

            Regex EmailAddress = new Regex(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");

            return EmailAddress.IsMatch(emailAddress);
        }
    }
}
