using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data;
using System.Data.Entity;

namespace Inventory_Management
{
    public class FilteredReport
    {
        private readonly EQUInventoryEntities _eQU;
        private readonly ReportsPage _reportsPage;
     //   private Dictionary<int, string> locationNames;

        public FilteredReport(EQUInventoryEntities eQU)
        {

            //_eQU = _eQU ?? throw new ArgumentNullException(nameof(_eQU));
            _eQU = eQU ?? throw new ArgumentNullException(nameof(eQU));
           
                _reportsPage = new ReportsPage();
          //  locationNames = new Dictionary<int, string>();
        }


        public void PopulateGridViewByType(DataGridView reportDataGridView)
        {
            // Clear existing data in the DataGridView
            DataGridView dataGridView = reportDataGridView;
            //reportDataGridView.Rows.Clear();

            // Get all records from the database
            if (_eQU == null)
            {

                return;
            }

            var allRecords = _eQU.Records.ToList();

            // Create a DataTable to store the data
            DataTable dataTable = new DataTable();

            {
                
                dataTable.Columns.Add("Location", typeof(string));
                dataTable.Columns.Add("Asset Tag", typeof(string));
                dataTable.Columns.Add("Category", typeof(string));
                dataTable.Columns.Add("Type", typeof(string));
                dataTable.Columns.Add("Brand", typeof(string));
                dataTable.Columns.Add("Description", typeof(string));
                dataTable.Columns.Add("Serial_No", typeof(string));
                dataTable.Columns.Add("Status", typeof(string));
                dataTable.Columns.Add("Purchase_Date", typeof(DateTime));
               
            }
            // Execute the query and add records to the DataTable
            foreach (var record in allRecords)
            {
                var values = new List<object>
        {
            record.Location != null ? record.Location.LocationName : "Unknown Location",
            record.AssetTag,
            record.Category?.CategoryName,
            record.ItemType?.TypeName,
            record.Brand,
            record.Description,
            record.SerialNo,
            record.Status?.StatusName,
            record.PurchaseDate
        };

                dataTable.Rows.Add(values.ToArray());
            }

            // Update the DataGridView with paged data
            reportDataGridView.DataSource = dataTable;  
        }






        public void PopulateChartByRecordType(Chart reportChart)
{
           
           
           //  Clear existing data in the chart
            reportChart.Series.Clear();
            reportChart.ChartAreas.Clear();
            reportChart.Titles.Clear();
           
            reportChart.ChartAreas.Add(new ChartArea("DefaultArea"));
           
            // Add a single series for all record types
            reportChart.Series.Add("Record Type");
            if (_eQU == null)
            {
                
                return;
            }

            // Get all records from the database
            var allRecords = _eQU.Records.ToList();

    // Execute the query and get counts by record type
    var countsByType = allRecords
        .GroupBy(q => new { RecordTypeId = q.ItemType.Id, ItemName = q.ItemType.TypeName })
        .Select(g => new { g.Key.RecordTypeId, g.Key.ItemName, Count = g.Count() })
        .ToList();

    // Customize chart appearance
    reportChart.ChartAreas["DefaultArea"].AxisX.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 10, System.Drawing.FontStyle.Bold);
    reportChart.ChartAreas["DefaultArea"].AxisX.MajorGrid.Enabled = false;
    reportChart.ChartAreas["DefaultArea"].AxisY.MajorGrid.LineColor = System.Drawing.Color.LawnGreen;
    reportChart.ChartAreas["DefaultArea"].AxisX.LabelStyle.Angle = -60;
    reportChart.Series["Record Type"].ChartType = SeriesChartType.Column;
            reportChart.Series["Record Type"].IsValueShownAsLabel = true;
            reportChart.Series["Record Type"]["PointWidth"] = " 0.8";
            reportChart.ChartAreas["DefaultArea"].Area3DStyle.IsClustered = false;
            // Binding the data to the chart
            int xValue = 0; // X value to differentiate between record types

    foreach (var count in countsByType)
    {
        // Add a data point to the series for each record type
        reportChart.Series["Record Type"].Points.AddXY(xValue, count.Count);

        // Set the data point label to display count within the chart
        reportChart.Series["Record Type"].Points[reportChart.Series["Record Type"].Points.Count - 1].Label = count.Count.ToString();

        // Set the axis label to display the record type name
        reportChart.ChartAreas[0].AxisX.CustomLabels.Add(xValue - 0.5, xValue + 0.5, count.ItemName);

        xValue++;
    }

    // Use different chart types based on your preference
    reportChart.Series["Record Type"].ChartType = SeriesChartType.Column;
    reportChart.Series["Record Type"].IsValueShownAsLabel = true;
    reportChart.Series["Record Type"].LabelForeColor = System.Drawing.Color.Black;

    // Refresh the chart
    reportChart.Refresh();
    reportChart.Update();
}


    }
}
    
