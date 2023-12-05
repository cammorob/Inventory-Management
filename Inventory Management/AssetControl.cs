using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management
{       
    public partial class AssetControl : UserControl
    {

       
        private readonly EQUInventoryEntities _eQU;
        private DataTable originalDataTable;
        private QueryDataBase dbQuery;
        int pageNumber = 1;
        int pageSize = 15;
        private List<object> query;
       
        public AssetControl()
        {
            InitializeComponent();
            EQUInventoryEntities context = new EQUInventoryEntities();
            _eQU = new EQUInventoryEntities();
            StyleGridView();
            dbQuery = new QueryDataBase(context);
            DisplayCurrentPage();
        }
        private void StyleGridView()
        {
            // Call the ApplyStyle method from GridViewStyle class
            GridViewStyle.ApplyStyle(AssetdataGridView1);
        }

        private void AssetControl_Load(object sender, EventArgs e)
        {

            query = dbQuery.GetAssetRecords();
            SetButtonStates();


        }

        private void LoadAssetRecords()
        {


            // DisplayCurrentPage();






        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (pageNumber * pageSize < query.Count)
            {
                pageNumber++;
                DisplayCurrentPage();
                SetButtonStates();
            }

                
            



        }


        
        private void DisplayCurrentPage()
        {
            var query = dbQuery.GetAssetRecords();
            AssetdataGridView1.DataSource = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            lblPageNumber.Text = string.Format("Page {0}/{1}", pageNumber, (int)Math.Ceiling((double)query.Count / pageSize));

        }
        
        private void btPrevious_Click(object sender, EventArgs e)
        {
            if (pageNumber > 1)
            {
                pageNumber--;
                DisplayCurrentPage();
                SetButtonStates();
            }

            
        }
        
        private void SetButtonStates()
        {
            btPrevious.Enabled = pageNumber > 1;
            btNext.Enabled = pageNumber * pageSize < query.Count;
        }
        
        
       

        private void LoadCategoryRecords(string keyword)
        {
            try
            {
                List<object> SpecificRecords;
                if (keyword.Contains("Location"))
                    SpecificRecords = dbQuery.GetRecordsContainingKeyword(keyword);
                else
                    SpecificRecords = dbQuery.GetRecordsContainingKeyword(keyword);

                AssetdataGridView1.DataSource = SpecificRecords;
                if (SpecificRecords.Count == 0)
                {
                    MessageBox.Show($"No items found for '{keyword}'.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayCurrentPage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void LoadAllRecords()
        {
            try
            {
                var allRecords = dbQuery.GetAssetRecords();
                AssetdataGridView1.DataSource = allRecords;



            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

      

        

        
        private void UpdateDataGridView(List<object> records)
        {
            AssetdataGridView1.DataSource = records.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            SetButtonStates();
        }



        



            private void furnitureToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Furniture"; // The keyword to search for

                    List<object> SpecificRecords = dbQuery.GetRecordsContainingKeyword(keyword);

                   AssetdataGridView1.DataSource= SpecificRecords;  


                    if (SpecificRecords.Count==0)
                    {

                        MessageBox.Show("No 'Furniture' records found.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }

            }


            private void iTEquipmentToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "IT Equipment"; // The keyword to search for

                    List<object> SpecificRecords = dbQuery.GetRecordsContainingKeyword(keyword);

                    AssetdataGridView1.DataSource = SpecificRecords;

                    if (SpecificRecords.Count == 0)
                    {

                        MessageBox.Show("No 'IT Equipment' records found.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            private void applianceToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Appliance"; // The keyword to search for

                    List<object> SpecificRecords = dbQuery.GetRecordsContainingKeyword(keyword);

                    AssetdataGridView1.DataSource = SpecificRecords;

                    if (SpecificRecords.Count == 0)
                    {

                        MessageBox.Show("No 'Appliance' records found.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }



            }

            private void receptionToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Reception"; // The keyword to search for

                    List<object> Locations = dbQuery.GetRecordsByLocation(keyword);

                    AssetdataGridView1.DataSource = Locations;

                    if (Locations.Count == 0)
                    {

                        MessageBox.Show("No Items found for location 'Reception'.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }

            }

            private void libraryToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Libary"; // The keyword to search for

                    List<object> Locations = dbQuery.GetRecordsByLocation(keyword);

                    AssetdataGridView1.DataSource = Locations;

                    if (Locations.Count == 0)
                    {

                        MessageBox.Show("No Items found for location 'Library'.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            private void kBOfficeToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "KB Office"; // The keyword to search for

                    List<object> Locations = dbQuery.GetRecordsByLocation(keyword);

                    AssetdataGridView1.DataSource = Locations;

                    if (Locations.Count == 0)
                    {

                        MessageBox.Show("No Items found for location 'KB Ofice'.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            private void dBOfficeToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "DB Office"; // The keyword to search for

                    List<object> Locations = dbQuery.GetRecordsByLocation(keyword);

                    AssetdataGridView1.DataSource = Locations;

                    if (Locations.Count == 0)
                    {

                        MessageBox.Show("No Items found for location 'DB Office'.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }




            private void technicianOfficeToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Technicians Office"; // The keyword to search for

                    List<object> Locations = dbQuery.GetRecordsByLocation(keyword);

                    AssetdataGridView1.DataSource = Locations;

                    if (Locations.Count == 0)
                    {

                        MessageBox.Show("No Items found for location 'Technicians Office'.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            private void hOUOfficeToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "HOU Office"; // The keyword to search for

                    List<object> Locations = dbQuery.GetRecordsByLocation(keyword);

                    AssetdataGridView1.DataSource = Locations;

                    if (Locations.Count == 0)
                    {

                        MessageBox.Show("No Items found for location 'HOU Office'.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            private void mainOfficeToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Main Office"; // The keyword to search for

                    List<object> Locations = dbQuery.GetRecordsByLocation(keyword);

                    AssetdataGridView1.DataSource = Locations;

                    if (Locations.Count == 0)
                    {

                        MessageBox.Show("No Items found for location 'Main Office'.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }





            private void serverToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Server Room"; // The keyword to search for

                    List<object> Locations = dbQuery.GetRecordsByLocation(keyword);

                    AssetdataGridView1.DataSource = Locations;

                    if (Locations.Count == 0)
                    {

                        MessageBox.Show("No Items found for location 'Server Room'.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            private void kitchenToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Kitchen"; // The keyword to search for

                    List<object> Locations = dbQuery.GetRecordsByLocation(keyword);

                    AssetdataGridView1.DataSource = Locations;

                    if (Locations.Count == 0)
                    {

                        MessageBox.Show("No Items found for location 'Kitchen'.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            private void centralRecordingStationToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Central Recording Station"; // The keyword to search for

                    List<object> Locations = dbQuery.GetRecordsByLocation(keyword);

                    AssetdataGridView1.DataSource = Locations;

                    if (Locations.Count == 0)
                    {

                        MessageBox.Show("No Items found for location 'Central Recording Station'.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }





            private void outDoorStoreroomToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Outdoor Storeroom"; // The keyword to search for

                    List<object> Locations = dbQuery.GetRecordsByLocation(keyword);

                    AssetdataGridView1.DataSource = Locations;

                    if (Locations.Count == 0)
                    {

                        MessageBox.Show("No Items found for location 'Outdoor Storeroom'.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            private void monitorToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Monitor"; // The keyword to search for

                    List<object> Types = dbQuery.GetRecordsByType(keyword);

                    AssetdataGridView1.DataSource = Types;

                    if (Types.Count == 0)
                    {

                        MessageBox.Show("No Items of type 'Keyboard' found.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            private void keypoardToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Keyboard"; // The keyword to search for

                    List<object> Types = dbQuery.GetRecordsByType(keyword);

                    AssetdataGridView1.DataSource = Types;

                    if (Types.Count == 0)
                    {

                        MessageBox.Show("No Items of type 'Keyboard' found.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            private void desktopToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Destop"; // The keyword to search for

                    List<object> Types = dbQuery.GetRecordsByType(keyword);

                    AssetdataGridView1.DataSource = Types;

                    if (Types.Count == 0)
                    {

                        MessageBox.Show("No Items of type 'Desktop' found.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            private void laptopToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Laptop"; // The keyword to search for

                    List<object> Types = dbQuery.GetRecordsByType(keyword);

                    AssetdataGridView1.DataSource = Types;

                    if (Types.Count == 0)
                    {

                        MessageBox.Show("No Items of type 'Laptop' found.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            private void serverToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Server"; // The keyword to search for

                    List<object> Types = dbQuery.GetRecordsByType(keyword);

                    AssetdataGridView1.DataSource = Types;

                    if (Types.Count == 0)
                    {

                        MessageBox.Show("No Items of type 'Server' found.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            private void networkStorageToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Network Storage"; // The keyword to search for

                    List<object> Types = dbQuery.GetRecordsByType(keyword);

                    AssetdataGridView1.DataSource = Types;

                    if (Types.Count == 0)
                    {

                        MessageBox.Show("No Items of type 'Network Storage' found.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            private void printerToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Printer"; // The keyword to search for

                    List<object> Types = dbQuery.GetRecordsByType(keyword);

                    AssetdataGridView1.DataSource = Types;

                    if (Types.Count == 0)
                    {

                        MessageBox.Show("No Items of type 'Printer' found.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            private void switchToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Switch"; // The keyword to search for

                    List<object> Types = dbQuery.GetRecordsByType(keyword);

                    AssetdataGridView1.DataSource = Types;

                    if (Types.Count == 0)
                    {

                        MessageBox.Show("No Items of type 'Switch' found.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }




            private void uPSToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "UPS"; // The keyword to search for

                    List<object> Types = dbQuery.GetRecordsByType(keyword);

                    AssetdataGridView1.DataSource = Types;

                    if (Types.Count == 0)
                    {

                        MessageBox.Show("No Items of type 'UPS' found.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            private void surgeProtectorToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Surge Protector"; // The keyword to search for

                    List<object> Types = dbQuery.GetRecordsByType(keyword);

                    AssetdataGridView1.DataSource = Types;

                    if (Types.Count == 0)
                    {

                        MessageBox.Show("No Items of type 'Surge Protector' found.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            private void routerToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Router"; // The keyword to search for

                    List<object> Types = dbQuery.GetRecordsByType(keyword);

                    AssetdataGridView1.DataSource = Types;

                    if (Types.Count == 0)
                    {

                        MessageBox.Show("No Items of type 'Router' found.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

        private void BtAdd_Click(object sender, EventArgs e)
            {
                Add_New_Record add_New_Record = new Add_New_Record();
           
                add_New_Record.ShowDialog();  
                
            }
        
            private void fireExtinguisherToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    string keyword = "Fire Extinguisher"; // The keyword to search for

                    List<object> Types = dbQuery.GetRecordsByType(keyword);

                    AssetdataGridView1.DataSource = Types;

                    if (Types.Count == 0)
                    {

                        MessageBox.Show("No Items of type 'Fire Extinguisher' found.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayCurrentPage();

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

        private void EditBt_Click(object sender, EventArgs e)
        {
            if (AssetdataGridView1.SelectedRows.Count > 0)
            {
                var id = (int)AssetdataGridView1.SelectedRows[0].Cells["Id"].Value;
                var record = _eQU.Records.FirstOrDefault(q => q.Id == id);
                var Add_New_Record = new Add_New_Record(record);
                Add_New_Record.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a record to edit.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            if (AssetdataGridView1.SelectedRows.Count > 0)
            {
                var id = (int)AssetdataGridView1.SelectedRows[0].Cells["Id"].Value;
                var record = _eQU.Records.FirstOrDefault(q => q.Id == id);
                _eQU.Records.Remove(record);
                _eQU.SaveChanges();
                AssetdataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a record to delete.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void searchBox1_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchBox1.Text.ToLower();

            var filteredRecords = _eQU.Records
                .Where(record => string.IsNullOrEmpty(searchTerm) ||
                                 record.Brand.ToLower().Contains(searchTerm) ||
                                 record.Category.CategoryName.ToLower().Contains(searchTerm)).
                Select(q => new
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
                })
                .ToList();

            AssetdataGridView1.DataSource = filteredRecords;

        }

        private void button6_Click(object sender, EventArgs e)
        {

            query = dbQuery.GetAssetRecords();
        }
    }
}
