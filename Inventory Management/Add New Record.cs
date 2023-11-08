using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management
{
    public partial class Add_New_Record : Form
    {
        private readonly EQUInventoryEntities _eQU;

        public Add_New_Record()
        {
            InitializeComponent();
            this.Text = string.Empty;
            _eQU = new EQUInventoryEntities();
        }

        private void Add_New_Record_Load(object sender, EventArgs e)
        {
            var category = _eQU.Categories.ToList();
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "Id";
            cbCategory.DataSource = category;

            var location = _eQU.Locations.ToList();
            cbLocation.DisplayMember = "LocationName";
            cbLocation.ValueMember = "Id";
            cbLocation.DataSource = location;

            var status = _eQU.Statuses.ToList();
            cbStatus.DisplayMember = "StatusName";
            cbStatus.ValueMember = "Id";
            cbStatus.DataSource = status;

            var itemtype = _eQU.ItemTypes.ToList();
            cbType.DisplayMember = "TypeName";
            cbType.ValueMember = "Id";
            cbType.DataSource = itemtype;
        }

        private void btSubmit_Click(object sender, EventArgs e)
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
            
        }
    }
}
