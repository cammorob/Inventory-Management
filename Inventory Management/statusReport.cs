using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Inventory_Management
{
    public class statusReport
    {
       
        private readonly EQUInventoryEntities _eQU;
        private readonly ReportsPage _reportsPage;
        private int pageNumber = 1;
        private int pageSize = 15;
        public statusReport(EQUInventoryEntities eQU)
        {
            _eQU = eQU ?? throw new ArgumentNullException(nameof(eQU));
            _reportsPage = new ReportsPage();
            Chart reportChart = new Chart();
        }
        public void DisplayByStatus(DataGridView reportDataGridView, Label lblPageNumber, string status1, string status2)
        {
            DataTable dataTable = CreateDataTable();




            var recordsForStatus = _eQU.Records
                .Where(q => q.Status.StatusName == status1 || q.Status.StatusName == status2)
                .Select(q => new
                {
                    Location = q.Location != null ? q.Location.LocationName : "Unknown Location",
                    Asset_Tag = q.AssetTag,
                    Category = q.Category.CategoryName,
                    Type = q.ItemType.TypeName,
                    Brand = q.Brand,
                    Description = q.Description,
                    Serial_No = q.SerialNo,
                    Status = q.Status != null ? q.Status.StatusName : "Status Unknown",
                    Purchase_Date = q.PurchaseDate
                })
                .ToList();

            foreach (var record in recordsForStatus)
            {
                var values = new List<object>
            {
                record.Status,
                record.Location,
                record.Asset_Tag,
                record.Category,
                record.Type,
                record.Brand,
                record.Description,
                record.Serial_No,

                record.Purchase_Date
            };

                dataTable.Rows.Add(values.ToArray());
            }

            UpdateDataGridView(reportDataGridView, lblPageNumber, dataTable);
        }

        private DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Location", typeof(string));
            dataTable.Columns.Add("Asset_Tag", typeof(string));
            dataTable.Columns.Add("Category", typeof(string));
            dataTable.Columns.Add("Type", typeof(string));
            dataTable.Columns.Add("Brand", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("Serial_No", typeof(string));
            dataTable.Columns.Add("Status", typeof(string));
            dataTable.Columns.Add("Purchase_Date", typeof(DateTime));
            return dataTable;
        }

        private void UpdateDataGridView(DataGridView reportDataGridView, Label lblPageNumber, DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
            {
                var pagedData = dataTable.AsEnumerable()
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .CopyToDataTable();

                reportDataGridView.DataSource = pagedData;
                lblPageNumber.Text = string.Format("Page {0}/{1}", pageNumber, (int)Math.Ceiling((double)dataTable.Rows.Count / pageSize));
            }
            else
            {
                // No data, clear the DataGridView
                reportDataGridView.DataSource = null;
                lblPageNumber.Text = "No data to display.";
            }
        }


        public void LoadChart(Chart reportChart)
        {
            Chart chart = reportChart as Chart;
            reportChart.Series.Clear();

            reportChart.ChartAreas.Clear();
            reportChart.ChartAreas.Add(new ChartArea("DefaultArea"));
            reportChart.Titles.Clear();
            reportChart.BringToFront();   

            foreach (Series chartSeries in reportChart.Series)
            {
                chartSeries.Points.Clear();
            }
         

            // Fetch records from the database
            var records = _eQU.Records.ToList();

            // Count records with "Working" and "Not Working" status
            int workingCount = records.Count(q => q.Status.StatusName == "Working");
            int notWorkingCount = records.Count(q => q.Status.StatusName == "Not Working");

            

            // Add a new series for "Working" and "Not Working" counts
            Series series = new Series("Status Count");
            series.Points.AddXY("Working", workingCount);
            series.Points.AddXY("Not Working", notWorkingCount);

            // Set chart type and other properties for a bar chart
            series.ChartType = SeriesChartType.Column;
            reportChart.Series.Add(series);

            // Set chart title
            reportChart.Titles.Clear();
            reportChart.Titles.Add("Working vs Not Working Status");
            reportChart.Titles[0].Font = new Font("Time New Roman", 10, FontStyle.Bold);
            reportChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            reportChart.ChartAreas[0].AxisY.MajorGrid.LineColor= Color.Red;
            // Display counts within the chart
            foreach (DataPoint point in reportChart.Series["Status Count"].Points)
            {
                point.Label = point.YValues[0].ToString(); // Display count within the chart
            }
        }




    }


}


    




