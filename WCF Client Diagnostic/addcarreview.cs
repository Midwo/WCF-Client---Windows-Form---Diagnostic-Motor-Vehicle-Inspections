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
     
            Array valArray = typeof(WCF_Client_Diagnostic.refwcf.fueltypeenum).GetEnumValues();
            foreach (object obj in valArray)
            {
                comboBox1.Items.Add(obj);
            }
        
       
        }
    }
}
