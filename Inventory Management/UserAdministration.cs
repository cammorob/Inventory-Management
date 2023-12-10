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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Inventory_Management
{
    public partial class UserAdministration : UserControl
    {
        private EQUInventoryEntities _eQU;
        public DataGridView userGridView1;

        public UserAdministration()
        {
            InitializeComponent();
            _eQU = new EQUInventoryEntities();
            InitializeComponents();
            ApplyGridViewStyle();


        }
        private void ApplyGridViewStyle()
        {
            // Assuming you have a DataGridView named usersGridView1 in your form.
            GridViewStyle.ApplyStyle(usersGridView1);
        }


        private void InitializeComponents()
        {
            userGridView1 = new DataGridView();

        }
        private void DeAct_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }
        public void PopulateGrid()
        {
            var users = _eQU.Users
         .Select(user => new
         {
             user.Id,
             user.Username,
             user.Password,
             RoleName = user.UserRoles.Any() ? user.UserRoles.FirstOrDefault().Role.RoleName : null,
             isActive = user.isActive ?? false
         })
         .ToList();

            usersGridView1.DataSource = users;
            usersGridView1.Columns["Username"].HeaderText = "Username";
            usersGridView1.Columns["RoleName"].HeaderText = "Role Name";
            usersGridView1.Columns["Password"].HeaderText = "Password";
            usersGridView1.Columns["isActive"].HeaderText = "Active/Not Active";
            usersGridView1.Columns["Id"].Visible = false;
            usersGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            usersGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            usersGridView1.AllowUserToAddRows = false;


        }


        private void btAddUser_Click(object sender, EventArgs e)
        { // Categories
            var ativate = _eQU.Users.ToList();
            AddEditUser addEditUser = new AddEditUser();
            addEditUser.ShowDialog();

        }

        private void btEdit_Click(object sender, EventArgs e)
        {


            if (usersGridView1.SelectedRows.Count > 0)
            {
                var id = (int)usersGridView1.SelectedRows[0].Cells["Id"].Value;

                // Use await to get the actual User object
                var user = _eQU.Users.FirstOrDefaultAsync(q => q.Id == id).Result;

                AddEditUser addEditUser = new AddEditUser(user);
                addEditUser.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a record to edit.", "No Record Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btResetPassword_Click_1(object sender, EventArgs e)
        {
            try
            {

                var id = (int)usersGridView1.SelectedRows[0].Cells["Id"].Value;
                var user = _eQU.Users.FirstOrDefault(x => x.Id == id);

                var genericPassword = "Password@123";
                var hash_password = PassEncryption.DefaultHashPassword();
                user.Password = hash_password;
                _eQU.SaveChanges();

                MessageBox.Show($"{user.Username})'s password has been reset!");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"error :{ex.Message}");

            }

        }

        private void UserAdministration_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (usersGridView1.SelectedRows.Count > 0)
            {
                var id = (int)usersGridView1.SelectedRows[0].Cells["Id"].Value;
                var user = _eQU.Users.Include(u => u.UserRoles).FirstOrDefault(q => q.Id == id);

                if (user != null)
                {
                    // Display a confirmation dialog
                    var confirmationMessage = $"Are you sure you want to delete the user '{user.Username}'?";
                    var confirmResult = MessageBox.Show(confirmationMessage, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            // Manually delete related records in UserRoles
                            _eQU.UserRoles.RemoveRange(user.UserRoles);

                            // Remove the user
                            _eQU.Users.Remove(user);

                            // Save changes to the database
                            _eQU.SaveChanges();

                            // Show a success message
                            MessageBox.Show("User deleted successfully.", "Delete Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the grid after deletion
                            PopulateGrid();
                        }
                        catch (Exception ex)
                        {
                            // Handle any exceptions
                            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a record to delete.", "No Record Selected.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.", "No Record Selected.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
