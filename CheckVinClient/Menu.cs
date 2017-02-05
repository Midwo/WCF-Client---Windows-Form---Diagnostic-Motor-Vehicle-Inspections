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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxVin.Text.Trim().Length < 17)
            {
                MessageBox.Show("Number Vin is too short", "Error Vin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxVin.Select();
                return;
            }
            if (textBoxVin.Text.Trim().Length > 17)
            {
                MessageBox.Show("Number Vin is too long", "Error Vin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxVin.Select();
                return;
            }
            labelVIN.Text = textBoxVin.Text;
            Global.VIN = textBoxVin.Text;
            buttonRepairsHistory.Enabled = true;
            buttonReviewsHistory.Enabled = true;
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBoxVin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(e, null);
            }
        }

        private void buttonReviewsHistory_Click(object sender, EventArgs e)
        {

        }

        private void buttonRepairsHistory_Click(object sender, EventArgs e)
        {

        }
    }
}
