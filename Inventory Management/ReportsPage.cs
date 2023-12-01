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
        private DataGridView reportDataGridView;
     
        private Chart Chart;
        public ReportsPage()
        {
            InitializeComponent();
            _eQU = new EQUInventoryEntities();
            LoadChartData();
            this.Controls.Add(reportChart);
            StyleDatagridview();
            InitializeComponents();


        }
        private void InitializeComponents()
        {
            reportDataGridView = new DataGridView();
            // ... (other initialization code)
        }
        private void LoadChartData()
        {

            var records = _eQU.Records.ToList();


            int applianceCount = records.Count(q => q.Category.CategoryName == "Appliance");
            int furnitureCount = records.Count(q => q.Category.CategoryName == "Furniture");
            int itEquipmentCount = records.Count(q => q.Category.CategoryName == "IT Equipment");
            int LaptopCount = records.Count(q => q.ItemType.TypeName == "Laptop");
            int keyBoardCount = records.Count(q => q.ItemType.TypeName == "Keyboard");
            int DesktopCount = records.Count(q => q.ItemType.TypeName == "Desktop");

            // Binding the data to the chart
            reportChart2.Series.Clear();
            reportChart2.Series.Add("Categories");

            int pointHeight = 20;
            int totalPoints = reportChart2.Series["Categories"].Points.Count;
            reportChart2.Height = totalPoints * pointHeight;
            int minimumChartHeight = 200; // Set your desired minimum height here
            if (reportChart2.Height < minimumChartHeight)
            {
                reportChart2.Height = minimumChartHeight;
            }


            reportChart2.Series["Categories"].Points.AddXY("Appliance", applianceCount);
            reportChart2.Series["Categories"].Points.AddXY("Furniture", furnitureCount);
            reportChart2.Series["Categories"].Points.AddXY("IT Equipment", itEquipmentCount);
            reportChart2.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);


            reportChart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            reportChart2.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LawnGreen;

            reportChart2.Series["Categories"].ChartType = SeriesChartType.Column;


            foreach (DataPoint point in reportChart2.Series["Categories"].Points)
            {
                point.Label = point.YValues[0].ToString(); // Display count within the chart
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

            PrintReport printReport = new PrintReport(reportdataGridView);
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
           
            SearchReport searchReport = new SearchReport(_eQU, this);
            searchReport.PopulateChartBySelection(catFil, typeFil, statusFil,reportdataGridView);
            
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


            LocationReport locationReport = new LocationReport(_eQU);

            locationReport.PopulateChartByLocation(reportChart2);
            locationReport.fillGridView(reportdataGridView, lblPageNumber);


        }

        private void btTypeReport_Click(object sender, EventArgs e)
        {

            EQUInventoryEntities _eQU = new EQUInventoryEntities(); 

            FilteredReport filteredReport = new FilteredReport(_eQU);
            

           filteredReport.PopulateChartByRecordType(reportChart2);
            //Chart reportChart = new Chart();
            filteredReport.PopulateGridViewByType(reportdataGridView);
           

        }

        void StyleDatagridview()
        {


            reportdataGridView.BorderStyle = BorderStyle.None;
            reportdataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            reportdataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            reportdataGridView.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            reportdataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            reportdataGridView.BackgroundColor = Color.FromArgb(30, 30, 30);
            reportdataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;//optional

            reportdataGridView.EnableHeadersVisualStyles = false;
            reportdataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            reportdataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Times New Roman ", 14);
            reportdataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            reportdataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            reportdataGridView.AutoResizeColumns();
            reportdataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            for (int i = 0; i <= reportdataGridView.Columns.Count - 1; i++)
            {
                // Store Auto Sized Widths:
                int colw = reportdataGridView.Columns[i].Width;

                // Remove AutoSizing:
                reportdataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // Set Width to calculated AutoSize value:
                reportdataGridView.Columns[i].Width = colw;
            }



        }

        private void statusReport_Click(object sender, EventArgs e)
        {
            statusReport stReport = new statusReport(_eQU);
            stReport.DisplayByStatus(reportdataGridView, lblPageNumber,"Working" , "Not Working");
            stReport.LoadChart(reportChart2);

        }
    }
}
