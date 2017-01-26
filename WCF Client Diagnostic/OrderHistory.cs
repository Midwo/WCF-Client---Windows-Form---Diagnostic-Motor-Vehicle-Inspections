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
    public partial class OrderHistory : Form
    {
        public OrderHistory()
        {
            InitializeComponent();

            refwcf.Service1Client client = new refwcf.Service1Client();
            DataSet DsResponse = client.ShowOrderTable(GlobalInformation.Name_Business);

            if (GlobalInformation.Name_Business == null || DsResponse.Tables[0].Rows.Count < 1)
            {

                GlobalInformation.Error = 1;
                Close();
            }
            else
            {

                dataGridView1.DataSource = DsResponse.Tables[0];
                GlobalInformation.Error = 0;
            }

        }
    }
}
