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
    public partial class UserAdministration : UserControl
    {
        private EQUInventoryEntities _eQU;
        public UserAdministration()
        {
            InitializeComponent();
            _eQU = new EQUInventoryEntities();  
        }

        private void DeAct_Click(object sender, EventArgs e)
        {
            try
            {

                var id = (int)usersGridView1.SelectedRows[0].Cells["Id"].Value;
                var user = _eQU.Users.FirstOrDefault(x => x.Id == id);

                user.isActive = user.isActive == true ? true : false;

                if (user.isActive == false)
                {
                    MessageBox.Show($"{user.Username}) deactivated");

                }
                else
                {
                    MessageBox.Show($"{user.Username}) Activated");
                }
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error :{ex.Message}");



            }
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

        }
      

        private void btAddUser_Click(object sender, EventArgs e)
        { // Categories
            var ativate = _eQU.Users.ToList();
            AddEditUser addEditUser = new AddEditUser();
            addEditUser.ShowDialog();

        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            var ativate = _eQU.Users.ToList();
            AddEditUser addEditUser = new AddEditUser();
            addEditUser.ShowDialog();
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
    }
}
