﻿using System;
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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        Crypt crypt = new Crypt();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sendpassword();
        }

        private void button1_Click(object sender, EventArgs e)
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

                    Crypt.cryptLogin = crypt.encrypt(maskedTextBox1.Text);
                    Crypt.cryptPassword = crypt.encrypt(textBox2.Text);
                    //MessageBox.Show("Zalogowany");
                    //Form1 m = new Form1();
                    //m.Show();
                    //this.Hide();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}