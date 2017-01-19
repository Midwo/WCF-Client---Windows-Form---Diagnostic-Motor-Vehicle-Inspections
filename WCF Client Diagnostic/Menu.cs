using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCF_Client_Diagnostic
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Welcome, " + Crypt.cryptLogin;
            label2.Text = "";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != string.Empty)
            {
                if (textBox1.Text.Length > 17)
                {
                    MessageBox.Show("Vin number is to long!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);              
                }
                if (textBox1.Text.Length < 17)
                {
                    MessageBox.Show("Vin number is to short!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    label2.Text = String.Format("Save VIN: {0}", textBox1.Text);
                }
            }
            else
            {
                MessageBox.Show("Enter the number Vin","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click( e, null);
            }
        }
    }
}
