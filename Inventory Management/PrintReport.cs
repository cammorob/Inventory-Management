using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace Inventory_Management
{
    public class PrintReport
    {
        private readonly System.Windows.Forms.Panel printReport;
       

        public PrintReport(System.Windows.Forms.Panel panel)
        {
            printReport = panel;
            

        }
        public void Print()
        {
            
            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("Legal", 850, 1400);
            printDocument.PrintPage += PrintPageHandler;


            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDocument
            }; 
        

            printPreviewDialog.Resize += (sender, e) => AdjustPreviewWindowSize(printPreviewDialog);

            printPreviewDialog.ShowDialog();
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            Bitmap chartBitmap = new Bitmap(printReport.Width, printReport.Height);
            printReport.DrawToBitmap(chartBitmap, new Rectangle(1, 1, chartBitmap.Width, chartBitmap.Height));

            e.Graphics.DrawImage(chartBitmap, e.PageBounds);
           

        }
        private void AdjustPreviewWindowSize(PrintPreviewDialog printPreviewDialog)
        {
            // Optional: Adjust the size of the preview window as needed
           
            const int maxWidth = 1500;
            const int maxHeight = 1200;

            if (printPreviewDialog.Width > maxWidth || printPreviewDialog.Height > maxHeight)
            {
                printPreviewDialog.Width = maxWidth;
                printPreviewDialog.Height = maxHeight;
            }
        }




    }
}
