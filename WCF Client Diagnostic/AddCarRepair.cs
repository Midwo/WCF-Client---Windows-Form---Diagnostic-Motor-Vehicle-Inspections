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
    public partial class AddCarRepair : Form
    {
        public AddCarRepair()
        {
            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == string.Empty & textBox1.Text.Trim() == string.Empty & textBox3.Text.Trim() == string.Empty & textBox4.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter value in field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                WCF_Client_Diagnostic.refwcf.Repair composite = new refwcf.Repair();
                composite.Mileage = textBox2.Text;
                composite.RepairDescrition = textBox1.Text;
                composite.ReplacedParts = textBox3.Text;
                composite.Cost = textBox4.Text;
                composite.WhoRepairbusiness = GlobalInformation.Name_Business;
                composite.WhereRepairbusiness = GlobalInformation.Adress_Business;
                composite.WhoRepairEmployee = GlobalInformation.Login;
                composite.VIN = GlobalInformation.VIN;

                refwcf.Service1Client newrepair = new refwcf.Service1Client();
                bool responsebool = newrepair.NewRepair(composite);

                if (responsebool == true)
                {
                    MessageBox.Show("Success - entered data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Failed - don't entered data","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
