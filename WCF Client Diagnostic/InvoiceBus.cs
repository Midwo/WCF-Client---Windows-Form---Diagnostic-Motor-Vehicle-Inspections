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
    public partial class InvoiceBus : Form
    {
        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                return Name;
            }
        }
        public class IDnumber
        {
            public int Id;

            public void set(int id)
            {
                Id = id;
            }
            public int get()
            {
                return Id;
            }
        }

        IDnumber number = new IDnumber();

        public InvoiceBus()
        {
            InitializeComponent();

            comboBox1.Items.Add(new Item("Standard car review - PB/Diesel", 111));
            comboBox1.Items.Add(new Item("Standard car review - LPG", 122));
            comboBox1.Items.Add(new Item("Standard car review - Electric", 153));
            comboBox1.Items.Add(new Item("Taxi - PB/Diesel", 141));
            comboBox1.Items.Add(new Item("Taxi - LPG", 194));
            comboBox1.Items.Add(new Item("Taxi - Electric", 294));
            comboBox1.Items.Add(new Item("Bus - PB/Diesel", 393));
            comboBox1.Items.Add(new Item("Bus - LPG", 494));
            comboBox1.Items.Add(new Item("Bus - Electric", 694));

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item itm = (Item)comboBox1.SelectedItem;
            textBox1.Text = itm.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                refwcf.Bill component = new refwcf.Bill();
                component.Cost = float.Parse(textBox1.Text);
                component.Employee = GlobalInformation.Login;
                component.TypePayment = "Cash";
                component.Rest = float.Parse(textBox3.Text);
                component.ReceivedCash = float.Parse(textBox2.Text);
                component.WhereBusiness = GlobalInformation.Adress_Business;
                component.WhoBusiness = GlobalInformation.Name_Business;
                component.What = comboBox1.Text;
                component.WhoBill = textBox4.Text;
                component.InformationClient = textBox5.Text;

                refwcf.Service1Client save = new refwcf.Service1Client();
                int ResponseID = save.BillSave(component);

                number.set(ResponseID);

                if (ResponseID > 0)
                {
                    MessageBox.Show("Saved this bill/facture", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Not Saved this Bill", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                refwcf.Bill component = new refwcf.Bill();
                component.Cost = float.Parse(textBox1.Text);
                component.Employee = GlobalInformation.Login;
                component.TypePayment = "Card";
                component.Rest = 0;
                component.ReceivedCash = 0;
                component.WhereBusiness = GlobalInformation.Adress_Business;
                component.WhoBusiness = GlobalInformation.Name_Business;
                component.What = comboBox1.Text;
                component.WhoBill = textBox4.Text;
                component.InformationClient = textBox5.Text;


                refwcf.Service1Client save = new refwcf.Service1Client();
                int ResponseID = save.BillSave(component);

                number.set(ResponseID);

                if (ResponseID > 0)
                {
                    MessageBox.Show("Saved this bill/facture", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    printPreviewDialog1.Document = printDocument2;
                    printPreviewDialog1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Not Saved this Bill", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Trim() != string.Empty & textBox1.Text.Trim() != string.Empty)
                {
                    var result = Convert.ToDecimal(textBox2.Text.Replace('.', ',')) - Convert.ToDecimal(textBox1.Text.Replace('.', ','));
                    if (result < 0)
                    {
                        MessageBox.Show("Received cash is not enough!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        textBox3.Text = (Convert.ToDecimal(textBox2.Text.Replace('.', ',')) - Convert.ToDecimal(textBox1.Text.Replace('.', ','))).ToString();
                        button2.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("You must enter the received cash", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != string.Empty & textBox4.Text.Trim() != string.Empty & textBox5.Text.Trim() != string.Empty)
            {

                if (checkBox1.Checked == true)
                {
                    label4.Visible = true;
                    textBox2.Visible = true;
                    button1.Visible = true;
                    label3.Visible = true;
                    textBox3.Visible = true;
                    checkBox2.Checked = false;

                }
                else
                {
                    label4.Visible = false;
                    textBox2.Visible = false;
                    button1.Visible = false;
                    label3.Visible = false;
                    textBox3.Visible = false;
                    checkBox2.Checked = false;
                    button2.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please select service or other information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != string.Empty & textBox4.Text.Trim() != string.Empty & textBox5.Text.Trim() != string.Empty)
            {
                if (checkBox2.Checked == true)
                {
                    label4.Visible = false;
                    textBox2.Visible = false;
                    button1.Visible = false;
                    label3.Visible = false;
                    textBox3.Visible = false;
                    checkBox1.Checked = false;
                    button2.Enabled = true;
                }
                else
                {
                    label4.Visible = false;
                    textBox2.Visible = false;
                    button1.Visible = false;
                    label3.Visible = false;
                    textBox3.Visible = false;
                    checkBox1.Checked = false;
                    button2.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please select service or other information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image, 5, 25, 800, 200);
            e.Graphics.DrawString("Facture business", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 240));
            e.Graphics.DrawString("Date: " + DateTime.Now + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 260));
            e.Graphics.DrawString("Number: " + number.Id + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 280));
            e.Graphics.DrawString("__________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 320));
            e.Graphics.DrawString("Type Service: " + comboBox1.Text.ToString() + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 340));
            e.Graphics.DrawString("Quantity: 1", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(100, 360));
            e.Graphics.DrawString("Cost with tax 23%: " + textBox1.Text + "$", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(520, 360));
            e.Graphics.DrawString("Cost without tax 23%: " + (Convert.ToDecimal(textBox1.Text) * 0.77m) + "$", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(520, 380));
            e.Graphics.DrawString("__________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 400));
            e.Graphics.DrawString("Type payment: Cash", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 420));
            e.Graphics.DrawString("Received cash: " + textBox2.Text + "$", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(520, 440));
            e.Graphics.DrawString("Rest: " + textBox3.Text + "$", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(520, 460));
            e.Graphics.DrawString("__________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 480));

            e.Graphics.DrawString("Dealer:", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 580));
            e.Graphics.DrawString("" + GlobalInformation.Name_Business + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(70, 600));
            e.Graphics.DrawString("" + GlobalInformation.Adress_Business + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(70, 620));
            e.Graphics.DrawString("Employee:" + GlobalInformation.Login + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(70, 640));

            e.Graphics.DrawString("Buyer:", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 700));
            e.Graphics.DrawString("" + textBox4.Text + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(70, 720));
            e.Graphics.DrawString("" + textBox5.Text + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(70, 740));

            e.Graphics.DrawString("______________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(450, 900));
            e.Graphics.DrawString("Rubber stamp and signature", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(520, 920));
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image, 5, 25, 800, 200);
            e.Graphics.DrawString("Facture business", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 240));
            e.Graphics.DrawString("Date: " + DateTime.Now + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 260));
            e.Graphics.DrawString("Number: " + number.Id + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 280));
            e.Graphics.DrawString("__________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 320));
            e.Graphics.DrawString("Type Service: " + comboBox1.Text.ToString() + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 340));
            e.Graphics.DrawString("Quantity: 1", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(100, 360));
            e.Graphics.DrawString("Cost with tax 23%: " + textBox1.Text + "$", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(520, 360));
            e.Graphics.DrawString("Cost without tax 23%: " + (Convert.ToDecimal(textBox1.Text) * 0.77m) + "$", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(520, 380));
            e.Graphics.DrawString("__________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 400));
            e.Graphics.DrawString("Type payment: Card", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 420));
            e.Graphics.DrawString("Received cash: 0$", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(520, 440));
            e.Graphics.DrawString("Rest: 0$", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(520, 460));
            e.Graphics.DrawString("__________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 500));
            e.Graphics.DrawString("Information: account is debited", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 520));
            e.Graphics.DrawString("Dealer:", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 600));
            e.Graphics.DrawString("" + GlobalInformation.Name_Business + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(70, 620));
            e.Graphics.DrawString("" + GlobalInformation.Adress_Business + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(70, 640));
            e.Graphics.DrawString("Employee: " + GlobalInformation.Login + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(70, 660));


            e.Graphics.DrawString("Buyer:", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 720));
            e.Graphics.DrawString("" + textBox4.Text + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(70, 740));
            e.Graphics.DrawString("" + textBox5.Text + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(70, 760));

            e.Graphics.DrawString("______________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(450, 920));
            e.Graphics.DrawString("Rubber stamp and signature", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(520, 940));
            //e.Graphics.DrawString("__________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 210));
        }
    }
}
