using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckVinClient
{
    public partial class Repairs : Form
    {
     
        PaperSize paperSize = new PaperSize("papersize", 850, 1350);
        int Number = 0;
        int PerPageItem = 0;
        public Repairs()
        {
            InitializeComponent();

            WCFVIN.Service1Client con = new WCFVIN.Service1Client();
            DataSet response = con.ShowRepairTable(Global.VIN);
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

        private void button1_Click(object sender, EventArgs e)
        {

            PerPageItem = Number = 0;
            printPreviewDialog1.Document = printDocument1;
            ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled = false;
            printDocument1.DefaultPageSettings.PaperSize = paperSize;
            printPreviewDialog1.ShowDialog();

        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources._2017_02_06_at_03_47, 20, 10, 800, 140);
            e.Graphics.DrawString("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 140));
            e.Graphics.DrawString("Selected VIN: " + Global.VIN + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(270, 170));
            e.Graphics.DrawString("Date create report: " + DateTime.Now + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(250, 190));
            e.Graphics.DrawString("__________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 200));

            int currentY = 240;
  
            while (Number <= dataGridView1.Rows.Count-2) 
            {
                //cells info
                //0 - number vin
                //1 - mileage
                //2 - repair description
                //3 - replaced parts 
                //4 - cost
                //5 - repair business name
                //6 - repair - business address
                //7 - date repair
                //8 - repair employee
                e.Graphics.DrawString("Nr.: " + (Number+1), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                currentY += 40;
                e.Graphics.DrawString("Repair date: " + dataGridView1.Rows[Number].Cells[7].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                e.Graphics.DrawString("Number VIN: " + dataGridView1.Rows[Number].Cells[0].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(543, currentY));
                e.Graphics.DrawString("____________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(543, currentY));
                currentY += 20;
                e.Graphics.DrawString("Business name: " + dataGridView1.Rows[Number].Cells[5].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                currentY += 20;
                e.Graphics.DrawString("Business address: " + dataGridView1.Rows[Number].Cells[6].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                currentY += 20;
                e.Graphics.DrawString("Employee: " + dataGridView1.Rows[Number].Cells[8].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                e.Graphics.DrawString("Cost: " + dataGridView1.Rows[Number].Cells[4].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(543, currentY));
                e.Graphics.DrawString("____________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(543, currentY));
                currentY += 40;
                e.Graphics.DrawString("Repair description: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                currentY += 20;
                string Parts = dataGridView1.Rows[Number].Cells[2].Value.ToString();
                Font stringFont = new Font("Arial", 12);
       
  
                // description
                #region description
                var x = Parts.Length;
              
                int ile = 94;
                int start = 0;
                do
                {
                    if (start + ile > Parts.Length)
                    {
                        int o = Parts.Length - start;
                        string x1 = Parts.Substring(start, o);
                        e.Graphics.DrawString(x1, stringFont, Brushes.Black, new PointF(50, currentY));
                        currentY += 20;
                        start += ile;
                        x -= ile;
                    }
                    else
                    {

                        string x1 = Parts.Substring(start, ile);
                        e.Graphics.DrawString(x1, stringFont, Brushes.Black, new PointF(50, currentY));
                        currentY += 20;
                        start += ile;
                        x -= ile;
                }
                } while (0 < x);

                currentY += 40;
                e.Graphics.DrawString("Repair parts: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                currentY += 20;
                #endregion
                Parts = dataGridView1.Rows[Number].Cells[3].Value.ToString();
                // parts
                #region parts
                x = Parts.Length;
                start = 0;
                do
                {
                    if (start + ile > Parts.Length)
                    {
                        int o = Parts.Length - start;
                        string x1 = Parts.Substring(start, o);
                        e.Graphics.DrawString(x1, stringFont, Brushes.Black, new PointF(50, currentY));
                        currentY += 20;
                        start += ile;
                        x -= ile;
                    }
                    else
                    {

                        string x1 = Parts.Substring(start, ile);
                        e.Graphics.DrawString(x1, stringFont, Brushes.Black, new PointF(50, currentY));
                        currentY += 20;
                        start += ile;
                        x -= ile;
                    }
                } while (0 < x);
                #endregion

                currentY += 100;
                Number += 1;
     
                if (PerPageItem < 1) 
                {
                    PerPageItem += 1; 
                    e.HasMorePages = false; 
                }
                else 
                {
                    PerPageItem = 0; 
                    e.HasMorePages = true; 
                    return;
                }
            }

        }
    }


}