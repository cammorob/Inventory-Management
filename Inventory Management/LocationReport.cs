using ExCSS;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Inventory_Management
{

    public class LocationReport
    {
        private readonly EQUInventoryEntities _eQU;
        private readonly ReportsPage _reportsPage;
        int pageNumber = 1;
        int pageSize = 15;
        public LocationReport(EQUInventoryEntities eQU)
        {

            _eQU = eQU ?? throw new ArgumentNullException(nameof(eQU));
            _reportsPage = new ReportsPage();


        }

        public void PopulateChartByLocation(Chart reportChart)
        {
            // Clear existing data in the chart
            reportChart.Series.Clear();
            reportChart.ChartAreas.Clear(); // Clear existing chart areas

            // Add a new chart area
            reportChart.ChartAreas.Add(new ChartArea("DefaultArea"));

            // Add the "Location" series
            reportChart.Series.Add("Location");

            // Get all records from the database
            var allRecords = _eQU.Records.ToList();

            // Execute the query and get counts
            var counts = allRecords.GroupBy(q => q.LocationID)
                .Select(g => new LocationCount { Location = g.Key, Count = g.Count() })
                .ToList();

            // Count records with unknown or null LocationID
            int unknownCount = allRecords.Count(q => string.IsNullOrWhiteSpace(q.LocationID?.ToString() ?? ""));
            counts.Add(new LocationCount { Location = (int?)null, Count = unknownCount });

            var locationNames = _eQU.Locations.ToDictionary(loc => loc.Id, loc => loc.LocationName);

            foreach (var count in counts)
            {
                string locationName = "Unknown Location";

                if (count.Location.HasValue)
                {
                    locationName = locationNames.ContainsKey(count.Location.Value)
                        ? locationNames[count.Location.Value]
                        : "Unknown Location";
                }

                // Add a separate point for each Location type within the "Location" series
                DataPoint dataPoint = new DataPoint();
                dataPoint.SetValueY(count.Count);
                dataPoint.AxisLabel = locationName;

                reportChart.Series["Location"].Points.Add(dataPoint);
            }

            // Customize chart appearance (you can add more customization as needed)
            reportChart.ChartAreas["DefaultArea"].AxisX.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 10, System.Drawing.FontStyle.Bold);
            reportChart.ChartAreas["DefaultArea"].AxisX.MajorGrid.Enabled = false;
            reportChart.ChartAreas["DefaultArea"].AxisY.MajorGrid.LineColor = System.Drawing.Color.LawnGreen;
            reportChart.Series["Location"].ChartType = SeriesChartType.Column;
            reportChart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            foreach (DataPoint point in reportChart.Series["Location"].Points)
            {
                point.Label = point.YValues[0].ToString(); // Display count within the chart
                point.LabelForeColor = System.Drawing.Color.Black;
            }

            // Populate DataGridView with grouped records and all attributes
            // reportDataGridView.Columns.Add("Location", "Location");
            // reportDataGridView.Columns.Add("Count", "Count");

            // Add specific columns for the attributes


        }
        private Dictionary<int, string> locationNames;

        // ... (other class members)

        public void fillGridView(DataGridView reportDataGridView, Label lblPageNumber)
        {   DataGridView dataGridView = reportDataGridView;
            
            
           //dataGridView .Rows.Clear();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Location", typeof(string));
           // dataTable.Columns.Add("ID", typeof(int));  // Adjust the type accordingly
            dataTable.Columns.Add("Asset_Tag", typeof(string));
            dataTable.Columns.Add("Category", typeof(string));
            dataTable.Columns.Add("Type", typeof(string));
            dataTable.Columns.Add("Brand", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("Serial_No", typeof(string));
            dataTable.Columns.Add("Status", typeof(string));
            dataTable.Columns.Add("Purchase_Date", typeof(DateTime));
            // Get all records from the database
            // ... (other class members)

            var allRecords = _eQU.Records.ToList();

            // Execute the query and get counts
            var counts = allRecords.GroupBy(q => q.LocationID)
                .Select(g => new LocationCount { Location = g.Key, Count = g.Count() })
                .ToList();

            // Count records with unknown or null LocationID
            int unknownCount = allRecords.Count(q => string.IsNullOrWhiteSpace(q.LocationID?.ToString() ?? ""));
            counts.Add(new LocationCount { Location = (int?)null, Count = unknownCount });

            foreach (var group in counts)
            {
                var recordsForLocation = allRecords
                    .Where(q => q.LocationID.GetValueOrDefault() == group.Location || (group.Location == null && string.IsNullOrWhiteSpace(q.LocationID?.ToString())))
                    .Select(q => new
                    {
                        ID = q.Id,
                        Asset_Tag = q.AssetTag,
                        Category = q.Category?.CategoryName,
                        Type = q.ItemType?.TypeName,
                        Brand = q.Brand,
                        Description = q.Description,
                        Location = q.Location != null ? q.Location.LocationName : "Unknown Location",
                        Serial_No = q.SerialNo,
                        Status = q.Status?.StatusName,
                        Purchase_Date = q.PurchaseDate
                    })
                    .ToList();
              //  DataTable dataTable = new DataTable();
                foreach (var record in recordsForLocation)
                {
                    var values = new List<object>
            {
                record.Location,
               // record.ID,
                record.Asset_Tag,
                record.Category,
                record.Type,
                record.Brand,
                record.Description,

                record.Serial_No,
                record.Status,
                record.Purchase_Date
            };

                    // reportDataGridView.Rows.Add(values.ToArray().);

                    // reportDataGridView.Rows.Add(values.ToArray()).

                    dataTable.Rows.Add(values.ToArray());
                    var pagedData = dataTable.AsEnumerable()
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                     .CopyToDataTable();
                    reportDataGridView.DataSource = pagedData;


                    lblPageNumber.Text = string.Format("Page {0}/{1}", pageNumber, (int)Math.Ceiling((double)dataTable.Rows.Count / pageSize));


                }







            }


        }
    }
}


