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
            StyleGridView();
            dbQuery =new QueryDataBase(context);
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

        private void furnitureToolStripMenuItem_Click(object sender, EventArgs e)

        {

            try

            {
                bool recordsFound = false;
                btNext.Enabled= false; btPrevious.Enabled= false;
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[2].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[2].Value.ToString() == "Furniture")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
                {
                    MessageBox.Show("No 'Furniture' records found.");
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[2].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[2].Value.ToString() == "IT Equipment")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[2].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[2].Value.ToString() == "Appliance")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[6].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[6].Value.ToString() == "Reception")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[6].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[6].Value.ToString() == "Library")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[6].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[6].Value.ToString() == "KB Office")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
                {
                    MessageBox.Show("No Items found for location 'KB Office'.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[6].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[6].Value.ToString() == "DB Office")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[6].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[6].Value.ToString() == "Technical Office")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
                {
                    MessageBox.Show("No Items found for location 'Technical Office'.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[6].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[6].Value.ToString() == "HOU Office")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[6].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[6].Value.ToString() == "Main Office")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[6].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[6].Value.ToString() == "Server Room")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[6].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[6].Value.ToString() == "Kitchen")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[6].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[6].Value.ToString() == "Central Recording Station")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[6].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[6].Value.ToString() == "Outdoor Storeroom")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[3].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "Monitor")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
                {
                    MessageBox.Show("No Items of type 'Monitor' found.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[3].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "Keyboard")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
                {
                    MessageBox.Show("No Items of type 'Keyboard' found.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[3].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "Desktop")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
                {
                    MessageBox.Show("No Items of type 'Desktop' found.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[3].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "Laptop")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
                {
                    MessageBox.Show("No Items of type 'Laptop' found.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[3].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "Server")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
                {
                    MessageBox.Show("No Items of type 'Server' found.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[3].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "Network Storage")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
                {
                    MessageBox.Show("No Items of type 'Network Storage' found.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[3].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "Printer")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
                {
                    MessageBox.Show("No Items of type 'Printer' found.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[3].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "Switch")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
                {
                    MessageBox.Show("No Items of type 'Switch' found.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[3].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "UPS")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
                {
                    MessageBox.Show("No Items of type 'UPS' found.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[3].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "Surge Protector")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
                {
                    MessageBox.Show("No Items of type 'Surge Protector' found.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                bool recordsFound = false;
                btNext.Enabled = false; btPrevious.Enabled = false;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[AssetdataGridView1.DataSource];
                currencyManager.SuspendBinding();
                for (int u = 0; u < AssetdataGridView1.RowCount; u++)
                {
                    if (AssetdataGridView1.Rows[u].Cells[3].Value != null &&
                 AssetdataGridView1.Rows[u].Cells[3].Value.ToString() == "Router")
                    {
                        AssetdataGridView1.Rows[u].Visible = true;
                        recordsFound = true;
                    }
                    else
                    {
                        AssetdataGridView1.Rows[u].Visible = false;
                    }
                }

                if (!recordsFound)
                {
                    MessageBox.Show("No Items of type 'Router' found.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
