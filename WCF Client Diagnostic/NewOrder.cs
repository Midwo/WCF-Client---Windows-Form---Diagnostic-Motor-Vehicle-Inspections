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
    public partial class NewOrder : Form
    {
        public NewOrder()
        {
            InitializeComponent();

            refwcf.Service1Client wcf = new refwcf.Service1Client();
            DataSet responseDs = wcf.ClientOptionStatus();
            
            comboBox1.DataSource = responseDs.Tables[0];
            comboBox1.ValueMember = "Status";
            comboBox1.DisplayMember = "Status";

        }

  
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            label5.Text = "Your date: " + monthCalendar1.SelectionStart.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != string.Empty & DateTime.Parse(monthCalendar1.SelectionStart.ToShortDateString()) > DateTime.Now.AddDays(1)) 
            {
                refwcf.Order contentOrder = new refwcf.Order();
                
                contentOrder.Items = textBox1.Text;
                contentOrder.Status = comboBox1.SelectedValue.ToString();
                contentOrder.WhereOrder = GlobalInformation.Adress_Business;
                contentOrder.WhoOrderBusiness = GlobalInformation.Name_Business;
                contentOrder.WhoOrderEmployee = GlobalInformation.Login;
                contentOrder.WhenDateNecessary = monthCalendar1.SelectionStart;

                refwcf.Service1Client SaveOrder = new refwcf.Service1Client();
                bool responsebool = SaveOrder.NewOrder(contentOrder);

                refwcf.ContractIServiceSendEmailOrder email = new refwcf.ContractIServiceSendEmailOrder();
                email.Body = GlobalInformation.Adress_Business + " with " + GlobalInformation.Name_Business + " || Order: " + textBox1.Text;
                email.DateNecessary = monthCalendar1.SelectionStart;
                email.Priority = comboBox1.SelectedValue.ToString();
                SaveOrder.SendOrderEmial(email);

                if( responsebool == true)
                {
                    MessageBox.Show("Saved this order!", "Order saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Not saved - try again with correct information/data", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter the text and choose correct data (min. 2 days)", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
