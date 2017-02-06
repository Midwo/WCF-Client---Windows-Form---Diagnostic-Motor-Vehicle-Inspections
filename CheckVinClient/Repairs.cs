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

            float currentY = 240;
            int RowsNumber = 0;
            while (Number+1 <= dataGridView1.Rows.Count-1) 
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
                e.Graphics.DrawString(dataGridView1.Rows[RowsNumber].Cells[0].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, 50, currentY);
                currentY += 20;
                e.Graphics.DrawString(dataGridView1.Rows[RowsNumber].Cells[1].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, 50, currentY);
                currentY += 20;


                string measureString = "Measure String 232 3 2 32 3 Measure String 232 3 2 32 3Measure String 232 3 2 32 3Measure String 232 3 2 32 3Measure String 232 3 2 32 3Measure String 232 3 2 32 3Measure String 232 3 2 32 3Measure String 232 3 2 32 3Measure String 232 3 2 32 3Measure String 232 3 2 32 3Measure String 232 3 2 32 3Measure String 232 3 2 32 3Measure String 232 3 2 3 koniec";
                Font stringFont = new Font("Arial", 12);


                // description and parts
                #region description and parts
                var x = measureString.Length;
                int y = 400;
                int ile = 20;
                int start = 0;
                do
                {
                    if (start + ile > measureString.Length)
                    {
                        int o = measureString.Length - start;
                        string x1 = measureString.Substring(start, o);
                        e.Graphics.DrawString(x1, stringFont, Brushes.Black, new PointF(200, y));
                        y += 20;
                        start += ile;
                        x -= ile;
                    }
                    else
                    {

                        string x1 = measureString.Substring(start, ile);
                        e.Graphics.DrawString(x1, stringFont, Brushes.Black, new PointF(200, y));
                        y += 20;
                        start += ile;
                        x -= ile;
                }
                } while (0 < x);
                #endregion

                
                RowsNumber += 1;
                Number += 1; 
                if (PerPageItem < 25) 
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













            //int x = 25;
            //int y = 240;
            //i = 0;
            //e.Graphics.DrawImage(Properties.Resources._2017_02_06_at_03_47, 20, 10, 800, 140);
            //e.Graphics.DrawString("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 140));
            //e.Graphics.DrawString("Selected VIN: "+Global.VIN+"", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(270, 170));
            //e.Graphics.DrawString("Date create report: "+DateTime.Now+"", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(250, 190));
            //e.Graphics.DrawString("__________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 200));

            //do
            //{
            //    e.Graphics.DrawString("Standard bill", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(x, y));

            //    y = y + 20;
            //    i++;
            //} while (dataGridView1.RowCount > i+1);
            //e.Graphics.DrawRectangle(Pens.Black, 100, 100, 26, 33);
            //e.Graphics.DrawString("__________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new RectangleF(205, 25, 15, 15), 200);
            //e.Graphics.DrawString("Standard bill", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 240));
            //e.Graphics.DrawString("Date: " + DateTime.Now + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 260));
            //e.Graphics.DrawString("Number: " + number.Id + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 280));
            //e.Graphics.DrawString("__________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 320));
            //e.Graphics.DrawString("Type Service: " + comboBox1.Text.ToString() + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 340));
            //e.Graphics.DrawString("Quantity: 1", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(100, 360));
            //e.Graphics.DrawString("Cost with tax 23%: " + textBox1.Text + "$", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(520, 360));
            //e.Graphics.DrawString("Cost without tax 23%: " + (Convert.ToDecimal(textBox1.Text) * 0.77m) + "$", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(520, 380));
            //e.Graphics.DrawString("__________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 400));
            //e.Graphics.DrawString("Type payment: Card", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 420));
            //e.Graphics.DrawString("Received cash: 0$", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(520, 440));
            //e.Graphics.DrawString("Rest: 0$", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(520, 460));
            //e.Graphics.DrawString("__________________________________________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 500));
            //e.Graphics.DrawString("Information: account is debited", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 520));
            //e.Graphics.DrawString("Dealer:", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 600));
            //e.Graphics.DrawString("" + GlobalInformation.Name_Business + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(70, 620));
            //e.Graphics.DrawString("" + GlobalInformation.Adress_Business + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(70, 640));
            //e.Graphics.DrawString("Employee: " + GlobalInformation.Login + "", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(70, 660));

        }
    }


}