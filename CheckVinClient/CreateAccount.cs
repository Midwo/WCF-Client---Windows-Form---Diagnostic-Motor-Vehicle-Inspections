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
           bool x = isEmail(textBoxEmail.Text);
            var y = maskedTextBox1.TextLength; // 11
            MessageBox.Show(y.ToString());
            
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
