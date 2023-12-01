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
        private DataGridView dgvToPrint;
        private int pageNumber = 1;
        private int pageSize = 20; // Adjust this based on your requirements

        public PrintReport(DataGridView dataGridView)
        {
            dgvToPrint = dataGridView;
        }

        public void Print()
        {
            if (dgvToPrint == null)
            {
                MessageBox.Show("DataGridView not provided.");
                return;
            }

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
            int rowsPerPage = e.MarginBounds.Height / dgvToPrint.RowTemplate.Height;
            int rowIndex = 0;

            while (rowIndex < rowsPerPage && pageNumber <= dgvToPrint.Rows.Count)
            {
                for (int columnIndex = 0; columnIndex < dgvToPrint.Columns.Count; columnIndex++)
                {
                    object cellValue = dgvToPrint.Rows[pageNumber - 1].Cells[columnIndex].Value;
                    e.Graphics.DrawString(cellValue != null ? cellValue.ToString() : string.Empty,
                        dgvToPrint.Font, Brushes.Black, e.MarginBounds.Left + columnIndex * 100,
                        e.MarginBounds.Top + rowIndex * dgvToPrint.RowTemplate.Height);
                }

                rowIndex++;
                pageNumber++;
                e.HasMorePages = (rowIndex < rowsPerPage && pageNumber <= dgvToPrint.Rows.Count);
            }
        }

        private void AdjustPreviewWindowSize(PrintPreviewDialog printPreviewDialog)
        {
            const int maxWidth = 1500;
            const int maxHeight = 1200;

            if (printPreviewDialog.Width > maxWidth || printPreviewDialog.Height > maxHeight)
            {
                printPreviewDialog.Width = maxWidth;
                printPreviewDialog.Height = maxHeight;
            }
        }

        private int CalculatePageCount(DataGridView dgv)
        {
            int rowCount = dgv.Rows.Count;
            return (int)Math.Ceiling((double)rowCount / pageSize);
        }

    }
}