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
            using (AddCarReview m = new AddCarReview())
            {
                m.ShowDialog(this);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            pictureBox1_Click(e, null);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ShowHistoryReview m = new ShowHistoryReview();
            m.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(e, null);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            using (EditCarReview m = new EditCarReview())
            {
                m.ShowDialog(this);
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
            using (AddCarRepair m = new AddCarRepair())
            {
                m.ShowDialog();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            using(EditCarRepair m = new EditCarRepair())
            {
                m.ShowDialog();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            pictureBox5_Click(e, null);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ShowHistoryRepair m = new ShowHistoryRepair();
            m.Show();
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
            m.Show();
        }
    }
}
