using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using PagedList;
using static Inventory_Management.GetGridData;

namespace Inventory_Management
{
    public partial class Asset_Check_Out_Form : Form
    {
        private readonly EQUInventoryEntities _eQU;
        private DataTable originalDataTable;
        int pageNumber=1 ;
        int pageSize = 15;
        
        
        //IPagedList<Record> li;

        public Asset_Check_Out_Form()
        {
            InitializeComponent();
          
            _eQU = new EQUInventoryEntities();   
            StyleDatagridview();

        }


        private void MainTitlePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private async void Asset_Load(object sender, EventArgs e)
        {
            
            var query = _eQU.Records.Select(q => new
            {
                ID = q.Id,
                Asset_Tag = q.AssetTag,
                Category = q.Category.CategoryName,
                Type = q.ItemType.TypeName,
                Brand = q.Brand,
                Description = q.Description,
                Location = q.Location.LocationName,
                Serial_No = q.SerialNo,
                Status = q.Status.StatusName,
                Purchase_Date = q.PurchaseDate

            }).ToList();


            //Asset_Tag=Records.AssetTag,
            // Category = Records.Category.CategoryName,

            
            AssetdataGridView1.DataSource = query.Skip(pageNumber-1*pageSize ).Take(pageSize).ToList();


            btPrevious.Enabled = false;

            btNext.Enabled = true;

            lblPageNumber.Text = string.Format("Page{0}/{1}", pageNumber, query.Count() / pageSize);

            
            
            


            



        }
       public void RefreshGridView()
        {
           
            var query = _eQU.Records.Select(q => new
            {
                ID = q.Id,
                Asset_Tag = q.AssetTag,
                Category = q.Category.CategoryName,
                Type = q.ItemType.TypeName,
                Brand = q.Brand,
                Description = q.Description,
                Location = q.Location.LocationName,
                Serial_No = q.SerialNo,
                Status = q.Status.StatusName,
                Purchase_Date = q.PurchaseDate

            }).ToList();
            AssetdataGridView1.DataSource = query.Skip(pageNumber - 1 * pageSize).Take(pageSize).ToList();
            btNext.Visible = true;
            btPrevious.Visible = true;
            lblPageNumber.Visible = true;

        }

        private void btNext_Click(object sender, EventArgs e)
        {
            

            var query = _eQU.Records.Select(q => new
            {
                ID = q.Id,
                Asset_Tag = q.AssetTag,
                Category = q.Category.CategoryName,
                Type = q.ItemType.TypeName,
                Brand = q.Brand,
                Description = q.Description,
                Location = q.Location.LocationName,
                Serial_No = q.SerialNo,
                Status = q.Status.StatusName,
                Purchase_Date = q.PurchaseDate
            }).ToList();
            
            pageNumber++;

            int startIndex = (pageNumber - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, query.Count);

            var pageData = query.Skip(startIndex).Take(endIndex - startIndex).ToList();

            AssetdataGridView1.DataSource = pageData;

            bool hasNextPage = endIndex < query.Count;
            btNext.Enabled = hasNextPage;

            btPrevious.Enabled = pageNumber > 1;

            lblPageNumber.Text = string.Format("Page {0}/{1}", pageNumber, (query.Count + pageSize - 1) / pageSize);

        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
           
            var query = _eQU.Records.Select(q => new
            {
                ID = q.Id,
                Asset_Tag = q.AssetTag,
                Category = q.Category.CategoryName,
                Type = q.ItemType.TypeName,
                Brand = q.Brand,
                Description = q.Description,
                Location = q.Location.LocationName,
                Serial_No = q.SerialNo,
                Status = q.Status.StatusName,
                Purchase_Date = q.PurchaseDate
            }).ToList();

            pageNumber--;

            int startIndex = (pageNumber - 1) * pageSize;
            int itemsToTake = Math.Min(pageSize, query.Count - startIndex);

            var pageData = query.GetRange(startIndex, itemsToTake);

            AssetdataGridView1.DataSource = pageData;

            bool hasPreviousPage = startIndex > 0;
            btPrevious.Enabled = hasPreviousPage;

            btNext.Enabled = true;

            lblPageNumber.Text = string.Format("Page {0}/{1}", pageNumber, (query.Count + pageSize - 1) / pageSize);



        }
      
  

     

            void StyleDatagridview()
        {


            AssetdataGridView1.BorderStyle = BorderStyle.None;
            AssetdataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            AssetdataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            AssetdataGridView1.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            AssetdataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            AssetdataGridView1.BackgroundColor = Color.FromArgb(30, 30, 30);
            AssetdataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;//optional
           
            AssetdataGridView1.EnableHeadersVisualStyles = false;
            AssetdataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            AssetdataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Times New Roman ", 14);
            AssetdataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            AssetdataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            AssetdataGridView1.AutoResizeColumns();
            AssetdataGridView1.AutoSizeColumnsMode= DataGridViewAutoSizeColumnsMode.AllCells;
            

            for (int i = 0; i <= AssetdataGridView1.Columns.Count - 1; i++)
            {
                // Store Auto Sized Widths:
                int colw = AssetdataGridView1.Columns[i].Width;

                // Remove AutoSizing:
                AssetdataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // Set Width to calculated AutoSize value:
                AssetdataGridView1.Columns[i].Width = colw;
            }



        }

      

        private void button1_Click(object sender, EventArgs e)
        {
              
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AssetType_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SearchPage searchPage = new SearchPage();
            searchPage.ShowDialog();
        }

        private void electronicsToolStripMenuItem1_Click(object sender, EventArgs e)
        {   
          /*  var query = _eQU.Records.Select(q => new
            {
                ID = q.Id,
                Asset_Tag = q.AssetTag,
                Category = q.Category.CategoryName,
                Type = q.ItemType.TypeName,
                Brand = q.Brand,
                Description = q.Description,
                Location = q.Location.LocationName,
                Serial_No = q.SerialNo,
                Status = q.Status.StatusName,
                Purchase_Date = q.PurchaseDate
            }).ToList();
            */
            try
            {
                
                
                
                bool recordsFound = false;
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                   
                    {
                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                    currencyManager.SuspendBinding();

                    if (AssetdataGridView1.Rows[u].Cells[2].Value.ToString() == "Appliance" &&   (AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "Electronics"))
                        {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                        }
                        else
                        {
                            AssetdataGridView1.Rows[u].Visible = true;
                        }
                    }
                if (!recordsFound)
                {
                    MessageBox.Show("No records found.");
                }

            }
            catch(Exception ex) { MessageBox.Show("An error occurred: " + ex.Message); }
            btNext.Visible = false;
            btPrevious.Visible = false;
            lblPageNumber.Visible = false;
        }

        private void furnotureToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
            try
            {
                for (int u = 0; u <= AssetdataGridView1.RowCount; u++)
                {
                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                    currencyManager.SuspendBinding();
                    if (AssetdataGridView1.Rows[u].Cells[2].Value.ToString() == "Furniture")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }
                
            }
            catch { }
            btNext.Visible = false;
            btPrevious.Visible = false; 
            lblPageNumber.Visible = false;  
        }

        private void monitorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
           
            try
            {
                bool recordsFound = false;

                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                    currencyManager.SuspendBinding();
                    if (AssetdataGridView1.Rows[u].Cells[2].Value?.ToString().Trim() != "IT Equipment")
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                }

                if (!recordsFound)
                {
                    MessageBox.Show("No 'IT Equipment' records found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
           
            btNext.Visible = false;
            btPrevious.Visible = false;
            lblPageNumber.Visible = false;
        }

        private void serverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {



                bool recordsFound = false;
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)

                {
                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                    currencyManager.SuspendBinding();

                    if (AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "Servers")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                    }
                }
                if (!recordsFound)
                {
                    MessageBox.Show("No records found.");
                }

            }
            catch (Exception ex) { MessageBox.Show("An error occurred: " + ex.Message); }
            btNext.Visible = false;
            btPrevious.Visible = false;
            lblPageNumber.Visible = false;
        }

        private void printersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {



                bool recordsFound = false;
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)

                {
                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                    currencyManager.SuspendBinding();
                    if (AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "Printers")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                    }
                }
                if (!recordsFound)
                {
                    MessageBox.Show("No records found.");
                }

            }
            catch (Exception ex) { MessageBox.Show("An error occurred: " + ex.Message); }
            btNext.Visible = false;
            btPrevious.Visible = false;
            lblPageNumber.Visible = false;
        }

        private void miniDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {



                bool recordsFound = false;
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)

                {
                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                    currencyManager.SuspendBinding();

                    if (AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "Mini Desktop")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                    }
                }
                if (!recordsFound)
                {
                    MessageBox.Show("No records found.");
                }

            }
            catch (Exception ex) { MessageBox.Show("An error occurred: " + ex.Message); }
            btNext.Visible = false;
            btPrevious.Visible = false;
            lblPageNumber.Visible = false;
        }

        private void switchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {



                bool recordsFound = false;
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)

                {
                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                    currencyManager.SuspendBinding();


                    if (AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "Switches")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                    }
                }
                if (!recordsFound)
                {
                    MessageBox.Show("No records found.");
                }

            }
            catch (Exception ex) { MessageBox.Show("An error occurred: " + ex.Message); }
            btNext.Visible = false;
            btPrevious.Visible = false;
            lblPageNumber.Visible = false;
        }

        private void uPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {



                bool recordsFound = false;
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)

                {
                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                    currencyManager.SuspendBinding();
                    if (AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "Wireless Router")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                    }
                }
                if (!recordsFound)
                {
                    MessageBox.Show("No records found.");
                }

            }
            catch (Exception ex) { MessageBox.Show("An error occurred: " + ex.Message); }
            btNext.Visible = false;
            btPrevious.Visible = false;
            lblPageNumber.Visible = false;
        }

        private void workStationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {



                bool recordsFound = false;
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)

                {
                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                    currencyManager.SuspendBinding();

                    if (AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "Workstation")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                    }
                }
                if (!recordsFound)
                {
                    MessageBox.Show("No records found.");
                }

            }
            catch (Exception ex) { MessageBox.Show("An error occurred: " + ex.Message); }
            btNext.Visible = false;
            btPrevious.Visible = false;
            lblPageNumber.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RefreshGridView();
        }

       
    }
}
