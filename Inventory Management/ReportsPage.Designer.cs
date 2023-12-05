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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsPage));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.statusReport = new System.Windows.Forms.Button();
            this.btTypeReport = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.LocationReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PrinterBt = new System.Windows.Forms.PictureBox();
            this.printReport1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.PrintPanel = new System.Windows.Forms.Panel();
            this.reportChart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.reportdataGridView = new System.Windows.Forms.DataGridView();
            this.Search = new System.Windows.Forms.Button();
            this.btCustomize = new System.Windows.Forms.Button();
            this.catFil = new System.Windows.Forms.ComboBox();
            this.typeFil = new System.Windows.Forms.ComboBox();
            this.statusFil = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterBt)).BeginInit();
            this.PrintPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportChart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.statusReport);
            this.panel1.Controls.Add(this.btTypeReport);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.LocationReport);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1143, 74);
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
            // statusReport
            // 
            this.statusReport.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusReport.Location = new System.Drawing.Point(691, 0);
            this.statusReport.Name = "statusReport";
            this.statusReport.Size = new System.Drawing.Size(220, 71);
            this.statusReport.TabIndex = 2;
            this.statusReport.Text = "Status Report";
            this.statusReport.UseVisualStyleBackColor = true;
            this.statusReport.Click += new System.EventHandler(this.statusReport_Click);
            // 
            // btTypeReport
            // 
            this.btTypeReport.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTypeReport.Location = new System.Drawing.Point(465, 0);
            this.btTypeReport.Name = "btTypeReport";
            this.btTypeReport.Size = new System.Drawing.Size(220, 71);
            this.btTypeReport.TabIndex = 1;
            this.btTypeReport.Text = "Type Report";
            this.btTypeReport.UseVisualStyleBackColor = true;
            this.btTypeReport.Click += new System.EventHandler(this.btTypeReport_Click);
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
            this.LocationReport.Location = new System.Drawing.Point(10, 3);
            this.LocationReport.Name = "LocationReport";
            this.LocationReport.Size = new System.Drawing.Size(220, 71);
            this.LocationReport.TabIndex = 0;
            this.LocationReport.Text = "Location Report";
            this.LocationReport.UseVisualStyleBackColor = true;
            this.LocationReport.Click += new System.EventHandler(this.LocationReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 99);
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
            // printReport1
            // 
            this.printReport1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printReport1_PrintPage);
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
            this.PrintPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PrintPanel.Controls.Add(this.reportChart2);
            this.PrintPanel.Controls.Add(this.lblPageNumber);
            this.PrintPanel.Controls.Add(this.reportdataGridView);
            this.PrintPanel.Location = new System.Drawing.Point(0, 122);
            this.PrintPanel.Name = "PrintPanel";
            this.PrintPanel.Size = new System.Drawing.Size(1146, 430);
            this.PrintPanel.TabIndex = 9;
            // 
            // reportChart2
            // 
            this.reportChart2.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea1.Name = "ChartArea1";
            this.reportChart2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.reportChart2.Legends.Add(legend1);
            this.reportChart2.Location = new System.Drawing.Point(757, 67);
            this.reportChart2.Name = "reportChart2";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.reportChart2.Series.Add(series1);
            this.reportChart2.Size = new System.Drawing.Size(383, 300);
            this.reportChart2.TabIndex = 23;
            this.reportChart2.Text = "Report Chart";
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Location = new System.Drawing.Point(3, 51);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(35, 13);
            this.lblPageNumber.TabIndex = 22;
            this.lblPageNumber.Text = "label2";
            // 
            // reportdataGridView
            // 
            this.reportdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportdataGridView.Location = new System.Drawing.Point(3, 67);
            this.reportdataGridView.Name = "reportdataGridView";
            this.reportdataGridView.Size = new System.Drawing.Size(748, 369);
            this.reportdataGridView.TabIndex = 3;
            // 
            // Search
            // 
            this.Search.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search.Location = new System.Drawing.Point(771, 93);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 23);
            this.Search.TabIndex = 14;
            this.Search.Text = "Filter";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // btCustomize
            // 
            this.btCustomize.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCustomize.Location = new System.Drawing.Point(77, 93);
            this.btCustomize.Name = "btCustomize";
            this.btCustomize.Size = new System.Drawing.Size(153, 27);
            this.btCustomize.TabIndex = 13;
            this.btCustomize.Text = "Customize Report";
            this.btCustomize.UseVisualStyleBackColor = true;
            this.btCustomize.Click += new System.EventHandler(this.btCustomize_Click);
            // 
            // catFil
            // 
            this.catFil.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.catFil.FormattingEnabled = true;
            this.catFil.Location = new System.Drawing.Point(345, 93);
            this.catFil.Name = "catFil";
            this.catFil.Size = new System.Drawing.Size(142, 23);
            this.catFil.TabIndex = 3;
            this.catFil.SelectedIndexChanged += new System.EventHandler(this.catFil_SelectedIndexChanged);
            // 
            // typeFil
            // 
            this.typeFil.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeFil.FormattingEnabled = true;
            this.typeFil.Location = new System.Drawing.Point(493, 93);
            this.typeFil.Name = "typeFil";
            this.typeFil.Size = new System.Drawing.Size(135, 23);
            this.typeFil.TabIndex = 4;
            this.typeFil.Text = "Select Type";
            // 
            // statusFil
            // 
            this.statusFil.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusFil.FormattingEnabled = true;
            this.statusFil.Location = new System.Drawing.Point(644, 93);
            this.statusFil.Name = "statusFil";
            this.statusFil.Size = new System.Drawing.Size(121, 23);
            this.statusFil.TabIndex = 5;
            this.statusFil.Text = "Select Status";
            // 
            // ReportsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Search);
            this.Controls.Add(this.catFil);
            this.Controls.Add(this.btCustomize);
            this.Controls.Add(this.PrinterBt);
            this.Controls.Add(this.statusFil);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typeFil);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PrintPanel);
            this.Name = "ReportsPage";
            this.Size = new System.Drawing.Size(1146, 555);
            this.Load += new System.EventHandler(this.ReportsPage_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PrinterBt)).EndInit();
            this.PrintPanel.ResumeLayout(false);
            this.PrintPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportChart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button statusReport;
        private System.Windows.Forms.Button btTypeReport;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button LocationReport;
        private System.Windows.Forms.DataVisualization.Charting.Chart reportChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PictureBox PrinterBt;
        private System.Drawing.Printing.PrintDocument printReport1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Panel PrintPanel;
        private System.Windows.Forms.TextBox statusFilter;
        private System.Windows.Forms.ListBox catFilter;
        private System.Windows.Forms.ListBox typeFilter;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button btCustomize;
        private System.Windows.Forms.ComboBox catFil;
        private System.Windows.Forms.ComboBox typeFil;
        private System.Windows.Forms.ComboBox statusFil;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Label lblPageNumber;
        public System.Windows.Forms.DataGridView reportdataGridView;
        public System.Windows.Forms.DataVisualization.Charting.Chart reportChart2;
    }
}
