using CrystalDecisions.Shared.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management
{
    public partial class Add_New_Record : Form
    {
        private readonly EQUInventoryEntities _eQU;
        private bool formMode;

        public Add_New_Record()
        {
            InitializeComponent();
            this.Text = string.Empty;
            _eQU = new EQUInventoryEntities();
            addEditlabel.Text = "Add New Record";
            formMode = false;
            _eQU = new EQUInventoryEntities();
            loadDataPoints();
        }
        public Add_New_Record(Record recordToEdit)
        {


            InitializeComponent();
            addEditlabel.Text = "Edit Record";
            _eQU = new EQUInventoryEntities();
            loadDataPoints();
            populateFields(recordToEdit);
            formMode = true;


        }

        private void populateFields(Record recordToEdit)
        {
            
            if (recordToEdit.CategoryID != null)
            {
                // Check if the CategoryID is not null and set the selected value
                cbCategory.SelectedValue = recordToEdit.CategoryID;  // Potential issue here
            }
            else
            {
                cbCategory.SelectedValue = -1;
            }
            
            if (recordToEdit.LocationID != null)
            {
                // Check if the CategoryID is not null and set the selected value
                cbLocation.SelectedValue = recordToEdit.LocationID;  // Potential issue here
            }
            else
            {
                cbLocation.SelectedValue = -1;
            }

            
            if (recordToEdit.StatusID != null)
            {
                // Check if the CategoryID is not null and set the selected value
                cbStatus.SelectedValue = recordToEdit.StatusID;  // Potential issue here
            }
            else
            {
                cbStatus.SelectedValue = -1;
            }

            
            if (recordToEdit.TypeID != null)
            {
                // Check if the CategoryID is not null and set the selected value
                cbType.SelectedValue = recordToEdit.TypeID;  // Potential issue here
            }
            else
            {
                cbType.SelectedValue = -1;
            }
            
          
            tbAssetTag.Text = recordToEdit?.AssetTag ?? "";
            tbDescription.Text = recordToEdit?.Description ?? "";
            tbSerialNo.Text = recordToEdit?.SerialNo ?? "";

            if (recordToEdit.PurchaseDate.HasValue)
            {
                dtPicker.Value = recordToEdit.PurchaseDate.Value;
            }
            else
            {

                dtPicker.CustomFormat = "No Date".ToString();
                dtPicker.Format = DateTimePickerFormat.Custom;
            }

            


        }

        private void Add_New_Record_Load(object sender, EventArgs e)
        {

         

        }



        private void loadDataPoints()
        {

            // Categories
            var categoryList = _eQU.Categories.ToList();
            categoryList.Insert(0, new Category { Id = -1, CategoryName = "Select Option" });
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "Id";
            cbCategory.DataSource = categoryList;

            // Locations
            var locationList = _eQU.Locations.ToList();
            locationList.Insert(0, new Location { Id = -1, LocationName = "Select Option" });
            cbLocation.DisplayMember = "LocationName";
            cbLocation.ValueMember = "Id";
            cbLocation.DataSource = locationList;

            // Statuses
            var statusList = _eQU.Statuses.ToList();
            statusList.Insert(0, new Status { Id = -1, StatusName = "Select Option" });
            cbStatus.DisplayMember = "StatusName";
            cbStatus.ValueMember = "Id";
            cbStatus.DataSource = statusList;

            // ItemTypes
            var itemTypeList = _eQU.ItemTypes.ToList();
            itemTypeList.Insert(0, new ItemType { Id = -1, TypeName = "Select Option" });
            cbType.DisplayMember = "TypeName";
            cbType.ValueMember = "Id";
            cbType.DataSource = itemTypeList;

            

        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (formMode)
                {
                    if (MessageBox.Show("Do You Want To edit This Record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var id = int.Parse(lblID.Text);

                        var record = _eQU.Records.FirstOrDefault(q => q.Id == id);

                        record.Brand = cbBrand.Text;
                        record.CategoryID = (int)cbCategory.SelectedValue;
                        record.LocationID = (int)cbLocation.SelectedValue;
                        record.StatusID = (int)cbStatus.SelectedValue;
                        record.TypeID = (int)cbStatus.SelectedValue;
                        record.AssetTag = tbAssetTag.Text;
                        record.Description = tbDescription.Text;
                        record.SerialNo = tbSerialNo.Text;
                        record.PurchaseDate = dtPicker.Value;

                        _eQU.SaveChanges();
                    }
                }
                else
                {

                    string description = tbDescription.Text;
                    var shortdate = dtPicker.Value;
                    string assest = tbAssetTag.Text;
                    var category = (Category)cbCategory.SelectedItem;
                    var location = cbLocation.Text;
                    var status = (Status)cbStatus.SelectedItem;
                    var itemtype = (ItemType)cbType.SelectedItem;
                    string serialno = tbSerialNo.Text;
                    var assets = tbAssetTag.Text;

                    var isvalid = true;
                    var errorMessage = "";

                    if (string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(location))
                    {
                        isvalid = false;
                        errorMessage += "Error please enter information";

                    }

                    if (isvalid)
                    {
                        string confirmationMessage = $"Please confirm the details:\n\n" +
                                 $"Description: {description}\n" +
                         $"Asset Tag: {assest}\n" +
                         $"Category: {category.CategoryName}\n" +
                         $"Location: {location}\n" +
                         $"Status: {status.StatusName}\n" +
                         $"Item Type: {itemtype.TypeName}\n" +
                         $"Serial No: {serialno}\n" +
                         $"Purchase Date: {shortdate}";

                        // Display confirmation message with entered details
                        var confirmResult = MessageBox.Show(confirmationMessage, "Confirm Record Details", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        if (confirmResult == DialogResult.OK)
                        {
                            MessageBox.Show("Record saved successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Record not saved.");
                        }

                    }

                    else
                    {

                        MessageBox.Show(errorMessage);
                    }

                    var record = new Record();


                    record.Description = description;
                    record.PurchaseDate = shortdate;
                    record.TypeID = itemtype.Id;

                    record.SerialNo = serialno;
                    record.AssetTag = assest;
                    record.CategoryID = category.Id;
                    record.StatusID = status.Id;
                    record.AssetTag = assest;

                    _eQU.Records.Add(record);
                    _eQU.SaveChanges();
                    MessageBox.Show("Record added");
                    if (MessageBox.Show("Do you want to add another record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {

                        Close();


                    }

                }
            }
            catch
            {

                MessageBox.Show("An unexpected error has occured, plesae contact you administrator");


            }
        }


       


        
        

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
