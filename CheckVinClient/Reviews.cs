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
    public partial class Reviews : Form
    {

        PaperSize paperSize = new PaperSize("papersize", 850, 1350);
        int Number = 0;
        int PerPageItem = 0;
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

            while (Number <= dataGridView1.Rows.Count - 3)
            {
                //cells info
                //0 - Review date
                //1 - Workshop name
                //2 - Workshop adress
                //3 - Mileage
                //4 - Car colour
                //5 - Fuel
                //6 - Employeee name with workshop
                //7 - Brakes
                //8 - Damper
                //9 - Exhaust 
                //10 - Convergence
                //11 - Light
                //12 - VIN
                e.Graphics.DrawString("Nr.: " + (Number + 1), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                currentY += 40;
                e.Graphics.DrawString("Workshop name: " + dataGridView1.Rows[Number].Cells[1].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                e.Graphics.DrawString("Review date: " + dataGridView1.Rows[Number].Cells[0].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(543, currentY));
                currentY += 20;
                e.Graphics.DrawString("Workshop address: " + dataGridView1.Rows[Number].Cells[2].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                e.Graphics.DrawString("VIN number: " + dataGridView1.Rows[Number].Cells[12].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(543, currentY));
                e.Graphics.DrawString("____________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(543, currentY));
                currentY += 20;
                e.Graphics.DrawString("Employee: " + dataGridView1.Rows[Number].Cells[6].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                currentY += 40;
                e.Graphics.DrawString("Car Colour: " + dataGridView1.Rows[Number].Cells[4].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                currentY += 20;
                e.Graphics.DrawString("Mileage: " + dataGridView1.Rows[Number].Cells[3].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                currentY += 20;
                e.Graphics.DrawString("Fuel: " + dataGridView1.Rows[Number].Cells[5].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                currentY += 20;
                e.Graphics.DrawString("Brakes: " + dataGridView1.Rows[Number].Cells[7].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                currentY += 20;
                e.Graphics.DrawString("Damper: " + dataGridView1.Rows[Number].Cells[8].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                currentY += 20;
                e.Graphics.DrawString("Exhaust: " + dataGridView1.Rows[Number].Cells[9].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                currentY += 20;
                e.Graphics.DrawString("Convergence: " + dataGridView1.Rows[Number].Cells[10].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                currentY += 20;
                e.Graphics.DrawString("Light: " + dataGridView1.Rows[Number].Cells[11].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
                currentY += 20;

                e.Graphics.DrawString("________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, currentY));
               
             
                currentY += 70;
                Number += 1;

                if (PerPageItem < 2)
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
