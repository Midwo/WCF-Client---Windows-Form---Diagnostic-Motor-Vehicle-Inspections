using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCF_Client_Diagnostic
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Crypt crypt = new Crypt();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sendpassword();

          
        }



        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pictureBox1_Click(e, null);
            }
        }

        void sendpassword()
        {
            try
            {
                if (maskedTextBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter your login/password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    refwcf.Service1Client client = new refwcf.Service1Client();
                    var hmm = client.Authentication(crypt.encrypt(textBox2.Text), crypt.encrypt(maskedTextBox1.Text));
                    if (hmm == true)
                    {
                        Crypt.cryptLogin = textBox2.Text;
                        Crypt.cryptPassword = maskedTextBox1.Text;
                        MessageBox.Show("Welcome to MD WCF Client Diagnostic Motor Vehicle Inspections\nYou used login: "+textBox2.Text+"", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information );
                        Menu m = new Menu();
                        m.Show();
                        this.Hide();
                        // next form
                    }
                    else
                    {
                        MessageBox.Show("bad");
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error: " + e.Message + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                maskedTextBox1.Select();
            }
           
        }

       

     
    }
}
