namespace Inventory_Management
{
    partial class ReportsPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsPage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.LocationReport = new System.Windows.Forms.Button();
            this.ReportChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.PrinterBt = new System.Windows.Forms.PictureBox();
            this.printReport1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.PrintPanel = new System.Windows.Forms.Panel();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.btCustomize = new System.Windows.Forms.Button();
            this.catFil = new System.Windows.Forms.ComboBox();
            this.typeFil = new System.Windows.Forms.ComboBox();
            this.statusFil = new System.Windows.Forms.ComboBox();
            this.Search = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReportChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterBt)).BeginInit();
            this.PrintPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.LocationReport);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1140, 74);
            this.panel1.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(917, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(220, 71);
            this.button5.TabIndex = 3;
            this.button5.Text = "Total Inventory Report";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(691, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(220, 71);
            this.button4.TabIndex = 2;
            this.button4.Text = "Status Report";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(465, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(220, 71);
            this.button3.TabIndex = 1;
            this.button3.Text = "Type Report";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(239, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(220, 71);
            this.button2.TabIndex = 1;
            this.button2.Text = "Category Report";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // LocationReport
            // 
            this.LocationReport.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocationReport.Location = new System.Drawing.Point(13, 0);
            this.LocationReport.Name = "LocationReport";
            this.LocationReport.Size = new System.Drawing.Size(220, 71);
            this.LocationReport.TabIndex = 0;
            this.LocationReport.Text = "Location Report";
            this.LocationReport.UseVisualStyleBackColor = true;
            this.LocationReport.Click += new System.EventHandler(this.LocationReport_Click);
            // 
            // ReportChart
            // 
            chartArea2.Name = "ChartArea1";
            this.ReportChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ReportChart.Legends.Add(legend2);
            this.ReportChart.Location = new System.Drawing.Point(179, 139);
            this.ReportChart.Name = "ReportChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.ReportChart.Series.Add(series2);
            this.ReportChart.Size = new System.Drawing.Size(774, 251);
            this.ReportChart.TabIndex = 1;
            this.ReportChart.Text = "Reportchart";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filter Report :";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(785, 96);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(81, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(872, 96);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(84, 20);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // PrinterBt
            // 
            this.PrinterBt.Image = ((System.Drawing.Image)(resources.GetObject("PrinterBt.Image")));
            this.PrinterBt.Location = new System.Drawing.Point(989, 83);
            this.PrinterBt.Name = "PrinterBt";
            this.PrinterBt.Size = new System.Drawing.Size(74, 33);
            this.PrinterBt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PrinterBt.TabIndex = 8;
            this.PrinterBt.TabStop = false;
            this.PrinterBt.Click += new System.EventHandler(this.PrinterBt_Click);
            this.PrinterBt.MouseLeave += new System.EventHandler(this.PrinterIcon_MouseLeave);
            this.PrinterBt.MouseHover += new System.EventHandler(this.PrinterIcon_MouseHover);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printReport1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // PrintPanel
            // 
            this.PrintPanel.Controls.Add(this.Logo);
            this.PrintPanel.Controls.Add(this.ReportChart);
            this.PrintPanel.Controls.Add(this.label1);
            this.PrintPanel.Location = new System.Drawing.Point(0, 119);
            this.PrintPanel.Name = "PrintPanel";
            this.PrintPanel.Size = new System.Drawing.Size(1146, 381);
            this.PrintPanel.TabIndex = 9;
            // 
            // Logo
            // 
            this.Logo.Image = global::Inventory_Management.Properties.Resources.Earthquake_unit_logo_png;
            this.Logo.Location = new System.Drawing.Point(13, 15);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(138, 72);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 2;
            this.Logo.TabStop = false;
            // 
            // btCustomize
            // 
            this.btCustomize.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCustomize.Location = new System.Drawing.Point(13, 80);
            this.btCustomize.Name = "btCustomize";
            this.btCustomize.Size = new System.Drawing.Size(220, 36);
            this.btCustomize.TabIndex = 13;
            this.btCustomize.Text = "Customize Report";
            this.btCustomize.UseVisualStyleBackColor = true;
            this.btCustomize.Click += new System.EventHandler(this.btCustomize_Click);
            // 
            // catFil
            // 
            this.catFil.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.catFil.FormattingEnabled = true;
            this.catFil.Location = new System.Drawing.Point(239, 90);
            this.catFil.Name = "catFil";
            this.catFil.Size = new System.Drawing.Size(142, 23);
            this.catFil.TabIndex = 3;
            this.catFil.Text = "Select Category";
            this.catFil.SelectedIndexChanged += new System.EventHandler(this.catFil_SelectedIndexChanged);
            // 
            // typeFil
            // 
            this.typeFil.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeFil.FormattingEnabled = true;
            this.typeFil.Location = new System.Drawing.Point(393, 90);
            this.typeFil.Name = "typeFil";
            this.typeFil.Size = new System.Drawing.Size(135, 23);
            this.typeFil.TabIndex = 4;
            this.typeFil.Text = "Select Type";
            // 
            // statusFil
            // 
            this.statusFil.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusFil.FormattingEnabled = true;
            this.statusFil.Location = new System.Drawing.Point(534, 90);
            this.statusFil.Name = "statusFil";
            this.statusFil.Size = new System.Drawing.Size(121, 23);
            this.statusFil.TabIndex = 5;
            this.statusFil.Text = "Select Status";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(661, 90);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 23);
            this.Search.TabIndex = 14;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // ReportsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Search);
            this.Controls.Add(this.statusFil);
            this.Controls.Add(this.typeFil);
            this.Controls.Add(this.btCustomize);
            this.Controls.Add(this.catFil);
            this.Controls.Add(this.PrinterBt);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PrintPanel);
            this.Name = "ReportsPage";
            this.Size = new System.Drawing.Size(1146, 500);
            this.Load += new System.EventHandler(this.ReportsPage_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReportChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterBt)).EndInit();
            this.PrintPanel.ResumeLayout(false);
            this.PrintPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button LocationReport;
        private System.Windows.Forms.DataVisualization.Charting.Chart ReportChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.PictureBox PrinterBt;
        private System.Drawing.Printing.PrintDocument printReport1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Panel PrintPanel;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.TextBox statusFilter;
        private System.Windows.Forms.ListBox catFilter;
        private System.Windows.Forms.ListBox typeFilter;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button btCustomize;
        private System.Windows.Forms.ComboBox catFil;
        private System.Windows.Forms.ComboBox typeFil;
        private System.Windows.Forms.ComboBox statusFil;
        private System.Windows.Forms.Button Search;
    }
}
