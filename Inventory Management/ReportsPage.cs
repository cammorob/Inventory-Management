using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Inventory_Management
{
    public partial class ReportsPage : UserControl
    {
        private readonly EQUInventoryEntities _eQU;
      
        public ReportsPage()
        {
            InitializeComponent();
            _eQU = new EQUInventoryEntities();
            LoadChartData();

            

        }

        private void LoadChartData()
        {
            
            var records = _eQU.Records.ToList();


            int applianceCount = records.Count(q=> q.Category.CategoryName == "Appliance");
            int furnitureCount = records.Count(q => q.Category.CategoryName == "Furniture");
            int itEquipmentCount = records.Count(q => q.Category.CategoryName == "IT Equipment");
            int LaptopCount = records.Count(q => q.ItemType.TypeName == "Laptop");
            int keyBoardCount = records.Count(q => q.ItemType.TypeName == "Keyboard");
            int DesktopCount = records.Count(q => q.ItemType.TypeName == "Desktop");

            // Binding the data to the chart
            ReportChart.Series.Clear();
            ReportChart.Series.Add("Categories");

            int pointHeight = 20;
            int totalPoints = ReportChart.Series["Categories"].Points.Count;
            ReportChart.Height = totalPoints * pointHeight;
            int minimumChartHeight = 200; // Set your desired minimum height here
            if (ReportChart.Height < minimumChartHeight)
            {
                ReportChart.Height = minimumChartHeight;
            }


            ReportChart.Series["Categories"].Points.AddXY("Appliance", applianceCount);
            ReportChart.Series["Categories"].Points.AddXY("Furniture", furnitureCount);
            ReportChart.Series["Categories"].Points.AddXY("IT Equipment", itEquipmentCount);
            ReportChart.ChartAreas[0].AxisX.LabelStyle.Font= new Font("Times New Roman", 10, FontStyle.Bold);


            ReportChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            ReportChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LawnGreen;
 
            ReportChart.Series["Categories"].ChartType = SeriesChartType.Column;
           
            
            foreach (DataPoint point in ReportChart.Series["Categories"].Points)
            {
                point.Label= point.YValues[0].ToString(); // Display count within the chart
                point.LabelForeColor = Color.Black;


            }
        }

      

        private void PrinterIcon_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(PrinterBt, "Print Report");
            
        }

        private void PrinterIcon_MouseLeave(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(PrinterBt, string.Empty);
        }

      
        Bitmap bmp;
        private void PrinterBt_Click(object sender, EventArgs e)
        {

            PrintReport printReport = new PrintReport(PrintPanel);
            printReport.Print();
            
           
        }

        private void btCustomize_Click(object sender, EventArgs e)
        {

            catFil.Visible = true;
            typeFil.Visible = true;
            statusFil.Visible = true;


            var category = _eQU.Categories.ToList();
            catFil.DisplayMember = "CategoryName";
            catFil.ValueMember = "Id";
            catFil.DataSource = category;







            var status = _eQU.Statuses.ToList();
            statusFil.DisplayMember = "StatusName";
            statusFil.ValueMember = "Id";
            statusFil.DataSource = status;
            if (status.Count > 0)
            {
                statusFil.Text = "Select Status";
                statusFil.SelectedIndex = 0; // Select the first item (default value)
            }




            //var itemtype = _eQU.ItemTypes.ToList();
            //typeFil.DisplayMember = "TypeName";
           // typeFil.ValueMember = "Id";
            //typeFil.DataSource = itemtype;

             //if (itemtype.Count > 0)
           // {
            //    typeFil.Text = "Select Item Type";
            //    statusFil.SelectedIndex = 0; // Select the first item (default value)
           // }

            
        }

        private void ReportsPage_Load(object sender, EventArgs e)
        {
            catFil.Visible = false;
            typeFil.Visible = false;
            statusFil.Visible = false;
            catFil.SelectedIndexChanged += catFil_SelectedIndexChanged;




        }

        private void Search_Click(object sender, EventArgs e)
        {
           // ReportChart.Series.Clear();
           // ReportChart.ChartAreas.Clear();
            FilteredReport chartPopulator = new FilteredReport(_eQU);
            chartPopulator.PopulateChart(ReportChart, catFil, statusFil, typeFil);
        }

        private void catFil_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            var selectedCategory = catFil.SelectedItem as Category;

            if (selectedCategory != null)
            {
                // Filter item types based on the selected category
                var filteredItemTypes = _eQU.Records
            .Where(item => item.CategoryID == selectedCategory.Id)
            .Select(item => item.ItemType)   
            .Distinct()
            .ToList();
                // Update the typeFil ComboBox with the filtered item types
                typeFil.DisplayMember = "TypeName";
                typeFil.ValueMember = "Id";
                typeFil.DataSource = filteredItemTypes;

                if (filteredItemTypes.Count > 0)
                {
                    typeFil.Text = "Select Item Type";
                }
                    
                    typeFil.SelectedIndex = 0; // Set the default selected index
            }
        }

        private void LocationReport_Click(object sender, EventArgs e)
        {
            FilteredReport chartPopulator = new FilteredReport(_eQU);
            chartPopulator.PopulateChartByLocation(ReportChart);
        }
    }
}
