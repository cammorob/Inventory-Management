using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using ComboBox = System.Windows.Forms.ComboBox;
using System.Data;

namespace Inventory_Management
{
    public class SearchReport
    {
        private readonly EQUInventoryEntities _eQU;
        private readonly ReportsPage _reportsPage;
        

        public SearchReport(EQUInventoryEntities eQU, ReportsPage reportsPage)
        {
            _eQU = eQU ?? throw new ArgumentNullException(nameof(eQU));
            _reportsPage = reportsPage ?? throw new ArgumentNullException(nameof(reportsPage));
            // _reportsPage = new ReportsPage();
            
        }



            public void PopulateChartBySelection(ComboBox catFil, ComboBox typeFil, ComboBox statusFil,DataGridView reportdataGridView)
       
            {
            // Build the query based on selected criteria
            DataGridView dataGridView = reportdataGridView;
           if(_eQU == null)
            {

              return;
           }
            var query = _eQU.Records.AsQueryable();

            if (catFil.SelectedIndex >= 0)
            {
                var selectedCategory = (Category)catFil.SelectedItem;
                query = query.Where(q => q.Category.Id == selectedCategory.Id);
            }

            if (typeFil.SelectedIndex > 0)
            {
                var selectedType = (ItemType)typeFil.SelectedItem;
                query = query.Where(q => q.ItemType.Id == selectedType.Id);
            }

            if (statusFil.SelectedIndex > 0)
            {
                var selectedStatus = (Status)statusFil.SelectedItem;
                query = query.Where(q => q.Status.Id == selectedStatus.Id);
            }

            DataTable dataTable = new DataTable();

            {
                dataTable.Columns.Add("Location", typeof(string));
                dataTable.Columns.Add("Asset Tag", typeof(string));
                dataTable.Columns.Add("Category", typeof(string));
                dataTable.Columns.Add("Type", typeof(string));
                dataTable.Columns.Add("Brand", typeof(string));
                dataTable.Columns.Add("Description", typeof(string));
                dataTable.Columns.Add("Serial_No", typeof(string));
                dataTable.Columns.Add("Status", typeof(string));
                dataTable.Columns.Add("Purchase_Date", typeof(DateTime));
            }

            // Execute the query
            var filteredRecords = query.ToList();

            // Populate the DataGridView on ReportsPage
             // Assuming you have a method to get the DataGridView
          //  reportDataGridView.Rows.Clear();

            foreach (var record in filteredRecords)
            {
                var values = new List<object>
            {
                record.Location != null ? record.Location.LocationName : "Unknown Location",
                record.AssetTag,
                record.Category?.CategoryName,
                record.ItemType?.TypeName,
                record.Brand,
                record.Description,
                record.SerialNo,
                record.Status?.StatusName,
                record.PurchaseDate
            };
                dataTable.Rows.Add(values.ToArray());
            }

            reportdataGridView.DataSource = dataTable;
        }





    }
}
