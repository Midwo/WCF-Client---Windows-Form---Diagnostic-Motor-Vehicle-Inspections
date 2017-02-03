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
            toolStripStatusLabel1.Text = "Welcome, " + Crypt.cryptLogin + " with " + GlobalInformation.Name_Business + " : " + GlobalInformation.Adress_Business ;

            label2.Text = "";


            refwcf.Service1Client client1 = new refwcf.Service1Client();
            label18.Text = String.Format("Start of work: {0}", client1.getstartwork(Crypt.cryptLogin));

            //Array valArray = typeof(WCF_Client_Diagnostic.refwcf.CarCondition).GetEnumValues();
            //foreach (object obj in valArray)
            //{
            //    listBox1.Items.Add(obj);
            //}
            timer1.Start();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != string.Empty)
            {
                if (textBox1.Text.Length != 17)
                {
                    
                    if (textBox1.Text.Length < 17)
                    {
                        MessageBox.Show("Vin number is to short!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Vin number is to long!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    }
                }
                else
                {
                    label2.Text = String.Format("Save VIN: {0}", textBox1.Text);
                    GlobalInformation.VIN = textBox1.Text;
                    textBox1.Clear();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = System.DateTime.Now.ToLongTimeString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (label2.Text.Trim() != string.Empty)
            {
                using (AddCarReview m = new AddCarReview())
                {
                    m.ShowDialog(this);
                }
            }
            else
            {
                MessageBox.Show("Enter the number Vin", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            pictureBox1_Click(e, null);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
       
            ShowHistoryReview m = new ShowHistoryReview();
            if (label2.Text.Trim() != string.Empty)
            {
                if (GlobalInformation.Error == 1)
                {
                    MessageBox.Show("Not found this number VIN", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    m.Show();
                }
            }
            else
            {
                MessageBox.Show("Please enter number Vin", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(e, null);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (label2.Text.Trim() != string.Empty)
            {
                using (EditCarReview m = new EditCarReview())
                {
                    if (GlobalInformation.Error == 1)
                    {
                        MessageBox.Show("You can't edit last review", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        m.ShowDialog(this);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter number Vin", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            pictureBox3_Click(e, null);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            pictureBox4_Click(e, null);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (label2.Text.Trim() != string.Empty)
            {
                using (AddCarRepair m = new AddCarRepair())
                {
                    m.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please enter number Vin", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (label2.Text.Trim() != string.Empty)
            {
                using (EditCarRepair m = new EditCarRepair())
                {
                    if(GlobalInformation.Error == 1)
                    {
                        MessageBox.Show("You can't edit last repair", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        m.ShowDialog();
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Please enter number Vin", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            pictureBox5_Click(e, null);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (label2.Text.Trim() != string.Empty)
            {
                ShowHistoryRepair m = new ShowHistoryRepair();
                if (GlobalInformation.Error == 1)
                {
                    MessageBox.Show("Not found this number VIN", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    m.Show();
                }
            }
            else
            {
                MessageBox.Show("Please enter number Vin", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            pictureBox6_Click(e, null);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            using (NewOrder m = new NewOrder())
            {
                m.ShowDialog();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            pictureBox8_Click(e, null);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            pictureBox7_Click(e, null);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Bill m = new Bill();
            m.ShowDialog();

        }

        private void label12_Click(object sender, EventArgs e)
        {
            pictureBox9_Click(e, null);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

            OrderHistory m = new OrderHistory();
            if (GlobalInformation.Error == 1)
            {
                MessageBox.Show("Not found your orders", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                m.Show();
            }
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            pictureBox10_Click(e, null);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            InvoiceBus m = new InvoiceBus();
            m.ShowDialog();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            pictureBox11_Click(e, null);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            InvoicePers m = new InvoicePers();
            m.ShowDialog();
        }
    }
}
