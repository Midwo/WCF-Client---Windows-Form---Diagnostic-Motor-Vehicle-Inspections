﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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

            try
            {
                WebRequest rq = WebRequest.Create("http://localhost:56054/version.txt");
                rq.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse rp = (HttpWebResponse)rq.GetResponse();

                Stream st = rp.GetResponseStream();
                StreamReader sr = new StreamReader(st);
                string odpowiedz = sr.ReadToEnd();
                if (GlobalInformation.version != odpowiedz)
                    if (MessageBox.Show("New version is available:  " + odpowiedz + "\n Download now?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            WebClient klient = new WebClient();
                            klient.DownloadFile("http://www.mdwojak.pl/hmm1.txt", saveFileDialog1.FileName); // this location your new program - zip/tar.
                        }
            }
            catch
            {
                MessageBox.Show("Error - check version", "Error connected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        
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
                        DataSet dsresponse = client.Business_employe(crypt.encrypt(textBox2.Text));
                        GlobalInformation.Name_Business = dsresponse.Tables[0].Rows[0][0].ToString();
                        GlobalInformation.Adress_Business = dsresponse.Tables[0].Rows[0][1].ToString();
                        GlobalInformation.Login = textBox2.Text;
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
