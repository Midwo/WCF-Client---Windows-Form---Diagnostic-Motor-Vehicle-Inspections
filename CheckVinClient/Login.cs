using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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

            try
            {
                WebRequest rq = WebRequest.Create("http://localhost:56054/version.txt");
                rq.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse rp = (HttpWebResponse)rq.GetResponse();

                Stream st = rp.GetResponseStream();
                StreamReader sr = new StreamReader(st);
                string odpowiedz = sr.ReadToEnd();
                if (Global.version != odpowiedz)
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
