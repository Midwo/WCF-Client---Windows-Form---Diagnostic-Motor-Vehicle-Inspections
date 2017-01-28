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
    public partial class EditCarRepair : Form
    {
        public EditCarRepair()
        {
            InitializeComponent();

            refwcf.Service1Client wcfdsresponse = new refwcf.Service1Client();
            DataSet dsResposne = wcfdsresponse.ShowEditRepair(GlobalInformation.VIN, GlobalInformation.Name_Business);
            if (dsResposne.Tables[0].Rows.Count > 0)
            {
                GlobalInformation.ID = dsResposne.Tables[0].Rows[0][0].ToString();
                textBox2.Text = dsResposne.Tables[0].Rows[0][1].ToString();
                textBox1.Text = dsResposne.Tables[0].Rows[0][2].ToString();
                textBox3.Text = dsResposne.Tables[0].Rows[0][3].ToString();
                textBox4.Text = dsResposne.Tables[0].Rows[0][4].ToString();
                textBox5.Text = dsResposne.Tables[0].Rows[0][5].ToString();
                GlobalInformation.Error = 0;
            }
            else
            {
                GlobalInformation.Error = 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == string.Empty & textBox2.Text.Trim() == string.Empty & textBox3.Text.Trim() == string.Empty & textBox4.Text.Trim() == string.Empty & textBox5.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter value to field", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                refwcf.Repair component = new refwcf.Repair();
                component.VIN = GlobalInformation.VIN;
                component.WhereRepairbusiness = GlobalInformation.Adress_Business;
                component.WhoRepairbusiness = GlobalInformation.Name_Business;
                component.WhoRepairEmployee = GlobalInformation.Login;
                component.Mileage = textBox1.Text;
                component.RepairDescrition = textBox3.Text;
                component.ReplacedParts = textBox4.Text;
                component.Cost = textBox5.Text;
                component.ID = int.Parse(GlobalInformation.ID);
                refwcf.Service1Client send = new refwcf.Service1Client();
                bool response = send.EditRepair(component);
                if (response == true)
                {
                    MessageBox.Show("Success - entered data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Failed - don't entered data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

        }
          
            
        }
    }
}
