using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckVinClient
{
    public partial class Reviews : Form
    {
        public Reviews()
        {
            InitializeComponent();

            WCFVIN.Service1Client con = new WCFVIN.Service1Client();
            DataSet response = con.ShowReviewsTable(Global.VIN);
            if (response.Tables[0].Rows.Count > 0)
            {
                Global.Error = 1;
                dataGridView1.DataSource = response.Tables[0];
            }
            else
            {
                Global.Error = 0;

            }
        }
    }
}
