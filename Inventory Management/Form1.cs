using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Inventory_Management
{
    public partial class Form1 : Form

    {

        readonly EQUInventoryEntities _eQU;
        //Fields
        private List<Record> records;
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        
        public Form1()
        {
            InitializeComponent();
            _eQU = new EQUInventoryEntities();
           random = new Random();
         
            LoadChartData();
            LoadPieChartData();
        }

        private void Form1_Load(object sender, EventArgs e, List<object> data)
        {
          

            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

            LoadChartData();


        }


         private void LoadChartData()
        {

            records = _eQU.Records.ToList(); // Fetch records from the database

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
                point.Label = point.AxisLabel +" "+ point.YValues[0]; // Display count within the chart
                point.LabelForeColor = Color.Black;
            }


        }





        private Color SelectThemeColor()
        {
            
            
                int index = random.Next(themecolor.ColorList.Count);
                while (tempIndex == index)
                {
                    index = random.Next(themecolor.ColorList.Count);
                }
                tempIndex = index;
                string color = themecolor.ColorList[index];
                return ColorTranslator.FromHtml(color);
            
           
            
        
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //FPHeader.BackColor = color;
                   // MainTitlePanel.BackColor = themecolor.ChangeColorBrightness(color, -0.3);
                    themecolor.PrimaryColor = color;
                    themecolor.SecondaryColor = themecolor.ChangeColorBrightness(color, -0.3);
                   // btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in MenuPanel1.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            Asset_Check_Out_Form asset_Check_Out_Form = new Asset_Check_Out_Form();
            asset_Check_Out_Form.ShowDialog();   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender);
            UserAdmin userAdmin=new UserAdmin();    
            userAdmin.ShowDialog(); 

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }



}
