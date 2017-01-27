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
    public partial class EditCarReview : Form
    {
        public EditCarReview()
        {
            InitializeComponent();

            Array valArray = typeof(WCF_Client_Diagnostic.refwcf.Fueltypeenum).GetEnumValues();
            foreach (object obj in valArray)
            {
                comboBox1.Items.Add(obj);
            }

            refwcf.Service1Client wcf = new refwcf.Service1Client();
            DataSet response = wcf.ShowEditReview(GlobalInformation.VIN, GlobalInformation.Name_Business);
            if (response.Tables[0].Rows.Count < 1)
            {
                GlobalInformation.Error = 1;
            }
            else
            {
                GlobalInformation.ID = response.Tables[0].Rows[0][0].ToString();
                textBox2.Text = response.Tables[0].Rows[0][4].ToString();
                textBox3.Text = response.Tables[0].Rows[0][5].ToString();
                comboBox38.Text = response.Tables[0].Rows[0][8].ToString();
                comboBox39.Text = response.Tables[0].Rows[0][9].ToString();
                comboBox40.Text = response.Tables[0].Rows[0][10].ToString();
                comboBox37.Text = response.Tables[0].Rows[0][11].ToString();
                comboBox36.Text = response.Tables[0].Rows[0][12].ToString();
                textBox1.Text = response.Tables[0].Rows[0][13].ToString();
                comboBox1.Text = response.Tables[0].Rows[0][6].ToString();
                GlobalInformation.Error = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            comboBox38.Enabled = true;
            comboBox39.Enabled = true;
            comboBox40.Enabled = true;
            comboBox37.Enabled = true;
            comboBox36.Enabled = true;
          
            comboBox1.Enabled = true;

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refwcf.Review wcfdata = new refwcf.Review();
            wcfdata.Id = GlobalInformation.ID;
            wcfdata.Mileage = textBox2.Text;
            wcfdata.Colour = textBox3.Text;
            wcfdata.Fuel = comboBox1.Text;
            wcfdata.Brakes = comboBox38.Text;
            wcfdata.Damper = comboBox39.Text;
            wcfdata.Exhaust = comboBox40.Text;
            wcfdata.Convergence = comboBox37.Text;
            wcfdata.Light = comboBox36.Text;

            WCF_Client_Diagnostic.refwcf.Service1Client wcfsend = new refwcf.Service1Client();
            MessageBox.Show("" + wcfsend.SaveEditReview(wcfdata) + "", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
