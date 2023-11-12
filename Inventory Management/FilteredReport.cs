using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace Inventory_Management
{
    public class FilteredReport
    {


        private readonly EQUInventoryEntities _eQU;
        private readonly ReportsPage _reportsPage;
        private Dictionary<int, string> locationNames;

        public FilteredReport(EQUInventoryEntities eQU)
        {
            _eQU = eQU ?? throw new ArgumentNullException(nameof(eQU));
            _reportsPage = new ReportsPage();
            locationNames = new Dictionary<int, string>();
        }


        public void PopulateChart(Chart reportChart, ComboBox catFil, ComboBox statusFil, ComboBox typeFil)
        {
            // Clear existing data in the chart
            reportChart.Series.Clear();
            reportChart.Series.Add("Categories");

            // Build the query based on selected criteria
            var query = _eQU.Records.AsQueryable();

            if (catFil.SelectedIndex >= 0)
            {
                var selectedCategory = (Category)catFil.SelectedItem;
                query = query.Where(q => q.Category.Id == selectedCategory.Id);
            }

            if (statusFil.SelectedIndex > 0)
            {
                var selectedStatus = (Status)statusFil.SelectedItem;
                query = query.Where(q => q.Status.Id == selectedStatus.Id);
            }

            if (typeFil.SelectedIndex > 0)
            {
                var selectedType = (ItemType)typeFil.SelectedItem;
                query = query.Where(q => q.ItemType.Id == selectedType.Id);
            }

            // Execute the query and get counts
            var counts = query.GroupBy(q => q.Category.CategoryName)
                              .Select(g => new { Category = g.Key, Count = g.Count() })
                              .ToList();

            // Binding the data to the chart
            foreach (var count in counts)
            {
                reportChart.Series["Categories"].Points.AddXY(count.Category, count.Count);
            }

            // Customize chart appearance (you can add more customization as needed)
            reportChart.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 10, System.Drawing.FontStyle.Bold);
            reportChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            reportChart.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.LawnGreen;
            reportChart.Series["Categories"].ChartType = SeriesChartType.Column;

            foreach (DataPoint point in reportChart.Series["Categories"].Points)
            {
                point.Label = point.YValues[0].ToString(); // Display count within the chart
                point.LabelForeColor = System.Drawing.Color.Black;
            }
        }


       public class LocationCount
{
    public int? Location { get; set; }
    public int Count { get; set; }
}

public void PopulateChartByLocation(Chart reportChart)
{
    // Clear existing data in the chart
    reportChart.Series.Clear();
    reportChart.Series.Add("Location");

    // Get all records from the database
    var allRecords = _eQU.Records.ToList();

    // Execute the query and get counts
    var counts = allRecords.GroupBy(q => q.LocationID)
        .Select(g => new LocationCount { Location = g.Key, Count = g.Count() })
        .ToList();

    // Count records with unknown or null LocationID
    int unknownCount = allRecords.Count(q => q.LocationID == null || q.ToString() == "NULL");

  // counts.Add(new LocationCount { Location = (int?)null, Count = unknownCount });

    var locationNames = _eQU.Locations.ToDictionary(loc => loc.Id, loc => loc.LocationName);

    // Debug output
    foreach (var kvp in locationNames)
    {
        Console.WriteLine($"LocationID: {kvp.Key}, LocationName: {kvp.Value}");
    }

    // Binding the data to the chart
    foreach (var count in counts)
    {
                string locationName = count.Location.HasValue
                         ? locationNames.ContainsKey(count.Location.Value)
                        ? locationNames[count.Location.Value]
                        : "Unknown Location":
                        "Unknown Location";
            

        reportChart.Series["Location"].Points.AddXY(locationName, count.Count);
    }

    // Customize chart appearance (you can add more customization as needed)
    reportChart.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 10, System.Drawing.FontStyle.Bold);
    reportChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
    reportChart.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.LawnGreen;
    reportChart.Series["Location"].ChartType = SeriesChartType.Column;

    foreach (DataPoint point in reportChart.Series["Location"].Points)
    {
        point.Label = point.YValues[0].ToString(); // Display count within the chart
        point.LabelForeColor = System.Drawing.Color.Black;
    }
}

        
    }
}
    
