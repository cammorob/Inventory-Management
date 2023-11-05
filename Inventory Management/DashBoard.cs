using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Inventory_Management
{
    public partial class DashBoard : UserControl
    {
        private readonly EQUInventoryEntities _eQU;
        public DashBoard()
        {
            InitializeComponent();
            _eQU = new EQUInventoryEntities();
           
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            LoadChartData();
            LoadPieChartData();
        }

        private void LoadChartData()
        {

           var records = _eQU.Records.ToList(); // Fetch records from the database

            int applianceCount = records.Count(q => q.Category.CategoryName == "Appliance");
            int furnitureCount = records.Count(q => q.Category.CategoryName == "Furniture");
            int itEquipmentCount = records.Count(q => q.Category.CategoryName == "IT Equipment");
            int LaptopCount = records.Count(q => q.ItemType.TypeName == "Laptop");
            int keyBoardCount = records.Count(q => q.ItemType.TypeName == "Keyboard");
            int DesktopCount = records.Count(q => q.ItemType.TypeName == "Desktop");
            // Binding the data to the chart
            chart1.Series.Clear();
            chart1.Series.Add("Categories");
            chart1.Series["Categories"].Points.AddXY("Appliance", applianceCount);
            chart1.Series["Categories"].Points.AddXY("Furniture", furnitureCount);
            chart1.Series["Categories"].Points.AddXY("IT Equipment", itEquipmentCount);
            chart1.Series["Categories"].Points.AddXY("Laptop", LaptopCount);
            chart1.Series["Categories"].Points.AddXY("Keyboard", keyBoardCount);
            chart1.Series["Categories"].Points.AddXY("Laptop", DesktopCount);
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LawnGreen;
            // Set chart type and other properties
            chart1.Series["Categories"].ChartType = SeriesChartType.Column;
            chart1.Titles.Add("Instant Record Report");
            chart1.Titles[0].ForeColor = Color.MediumPurple;
            chart1.Titles[0].Font = new Font("Time New Roman", 10, FontStyle.Bold);
        }


        private void LoadPieChartData()
        {

            var records = _eQU.Records.ToList(); // Fetch records from the database
            int workingCount = records.Count(q => q.Status.StatusName == "Working");
            int notWorkingCount = records.Count(q => q.Status.StatusName == "Not Working");

            // Populate the pie chart
            chart2.Series.Clear();
            chart2.Series.Add("Status");
            chart2.Series["Status"].Points.AddXY("Working", workingCount);
            chart2.Series["Status"].Points.AddXY("Not Working", notWorkingCount);

            // Set chart type and other properties for a pie chart
            chart2.Series["Status"].ChartType = SeriesChartType.Pie;
            chart2.Titles.Add("Working vs Not Working Status");

            // Display counts within the pie chart
            foreach (DataPoint point in chart2.Series["Status"].Points)
            {
                point.Label = point.AxisLabel + " " + point.YValues[0]; // Display count within the chart
                point.LabelForeColor = Color.Black;
            }


        }


    }
}
