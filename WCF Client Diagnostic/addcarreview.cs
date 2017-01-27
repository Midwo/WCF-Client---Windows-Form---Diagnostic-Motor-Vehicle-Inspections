using System;
using System.Collections;
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
    public partial class AddCarReview : Form
    {
        public AddCarReview()
        {
            InitializeComponent();

            textBox1.Text = GlobalInformation.VIN;
     
            Array valArray = typeof(WCF_Client_Diagnostic.refwcf.Fueltypeenum).GetEnumValues();
            foreach (object obj in valArray)
            {
                comboBox1.Items.Add(obj);
            }
        
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != string.Empty & textBox3.Text.Trim() != string.Empty & comboBox38.SelectedIndex > -1 & comboBox1.SelectedIndex > -1 & comboBox36.SelectedIndex > -1 & comboBox37.SelectedIndex > -1 & comboBox39.SelectedIndex > -1 & comboBox40.SelectedIndex > -1)
            {

                refwcf.Service1Client wcf = new refwcf.Service1Client();
                bool response = wcf.NewReview(GlobalInformation.Name_Business, GlobalInformation.Adress_Business, textBox2.Text, textBox3.Text, GlobalInformation.Login, comboBox38.SelectedItem.ToString(), comboBox39.SelectedItem.ToString(), comboBox40.SelectedItem.ToString(), comboBox37.SelectedItem.ToString(), comboBox36.SelectedItem.ToString(), textBox1.Text, comboBox1.SelectedItem.ToString());

                if (response == true)
                {
                    MessageBox.Show("Saved - Review", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Not Saved - Review", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter text in field or select value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
