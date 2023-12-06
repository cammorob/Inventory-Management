using FontAwesome.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using static Inventory_Management.DGVPrinter;

namespace Inventory_Management
{
    public partial class AddEditUser : Form
    {
        private bool formMode;

        private readonly EQUInventoryEntities _eQU;
        private UserAdministration _userAdministration;
        public AddEditUser()
        {
            InitializeComponent();
            _eQU = new EQUInventoryEntities();
            AddEditUserlbl.Text = "Add New User";
            formMode = false;
            _eQU = new EQUInventoryEntities();
            UserOptions();
            _userAdministration = new UserAdministration();
        }

        public AddEditUser(User UserToEdit)
        {


            InitializeComponent();
            AddEditUserlbl.Text = "Edit User";
            _eQU = new EQUInventoryEntities();
            populateFields(UserToEdit);
            formMode = true;
            _userAdministration = new UserAdministration(); 



        }

        private void populateFields(User UserToEdit)
        {
            var roles = _eQU.Roles.ToList();
            // roles.Insert(0, new Role { Id = -1, RoleName = "Select Option" });

            cbUserRole.DisplayMember = "RoleName";
            cbUserRole.ValueMember = "Id";
            cbUserRole.DataSource = roles;

            tbUserName.Text = UserToEdit.Username ?? "";
            tbPassword.Text = UserToEdit.Password ?? "";
            var yesOption = new { isActive = true };
            var noOption = new { isActive = false };

            // Create a list for options
            var optionsList = new List<object> { yesOption, noOption };

            // Set up the combo box
            cbActiveMode.DisplayMember = "isActive";
            cbActiveMode.ValueMember = "isActive";
            cbActiveMode.DataSource = optionsList;
            lblID.Text = UserToEdit.Id.ToString();

            if (UserToEdit.UserRoles.Any())
            {
                cbUserRole.SelectedValue = UserToEdit.UserRoles.First().RoleID;
            }
            else
            {

                cbUserRole.SelectedValue = -1;
            }

        }

        private void UserOptions()
        {

            var roles = _eQU.Roles.ToList();
            roles.Insert(0, new Role { Id = -1, RoleName = "Select Option" });
            cbUserRole.DisplayMember = "RoleName";
            cbUserRole.ValueMember = "Id";
            cbUserRole.DataSource = roles;


            var yesOption = new { isActive = true };
            var noOption = new { isActive = false };

            // Create a list for options
            var optionsList = new List<object> { yesOption, noOption };

            // Set up the combo box
            cbActiveMode.DisplayMember = "isActive";
            cbActiveMode.ValueMember = "isActive";
            cbActiveMode.DataSource = optionsList;

        }
        private void btSubmit_Click(object sender, EventArgs e)
        {

            //try
            //{
            if (formMode)
            {
                if (MessageBox.Show("Do You Want To edit This Record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var id = int.Parse(lblID.Text);

                    var UserToEdit = _eQU.Users.FirstOrDefault(q => q.Id == id );

                    UserToEdit.Username = tbUserName.Text;
                    int selectedRoleId = int.Parse(cbUserRole.SelectedValue.ToString());
                    var selectedUserRole = _eQU.UserRoles.FirstOrDefault(ur => ur.Id == selectedRoleId);
                    if (selectedUserRole != null)
                    {
                        UserToEdit.UserRoles.Clear(); // Clear existing roles (if any)
                        UserToEdit.UserRoles.Add(selectedUserRole);
                    }
                    UserToEdit.Password = tbPassword.Text;

                    // bool isActiveValue = cbActiveMode.SelectedItem.ToString().ToLower() == "yes";
                    // UserToEdit.isActive = isActiveValue;
                    var selectedOption = (dynamic)cbActiveMode.SelectedItem;
                    bool isActiveValue = selectedOption.isActive;
                    int isActiveNumericValue = isActiveValue ? 1 : 0;
                   UserToEdit.isActive = isActiveNumericValue == 1 ? (bool?)true : (bool?)false;
                    _eQU.SaveChanges();
                    UserAdministration userAdministration = new UserAdministration();
                    userAdministration.PopulateGrid();
                    Close();
                }
            }
            else
            {

                var username = tbUserName.Text;
                var userRoles = cbUserRole.SelectedValue;
                var password = tbPassword.Text;
                var mode = cbActiveMode.SelectedValue;
                bool isActiveValue = cbActiveMode.SelectedItem.ToString().ToLower() == "yes";
                var isvalid = true;
                var errorMessage = "";

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    isvalid = false;
                    errorMessage += "Error please enter information";

                }

                if (isvalid)
                {
                    string confirmationMessage = $"Please confirm the details:\n\n" +
                              $"User: {username}\n" +
                     $"User Role: {userRoles}\n" +
                     $"Password: {password}\n" +
                     $"Status: {mode}\n";

                    // Display confirmation message with entered details
                    var confirmResult = MessageBox.Show(confirmationMessage, "Confirm Record Details", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    var selectedOption = (dynamic)cbActiveMode.SelectedItem;
                    bool isActiveValues = selectedOption.isActive;

                    User newUser = new User
                    {
                        Username = tbUserName.Text,
                        Password = tbPassword.Text,
                        isActive = isActiveValues ? (bool?)true : (bool?)false

                    };


                    _eQU.Users.Add(newUser);
                     _eQU.SaveChanges();

                    var newUserId = _eQU.Users.FirstOrDefault(u => u.Username == tbUserName.Text)?.Id;

                    if (newUserId != null)
                    {
                        var selectedUserRoleId = int.Parse(cbUserRole.SelectedValue.ToString());

                        // Create a new UserRole entity and associate it with the user and role
                        var newAssociation = new UserRole
                        {
                            UserID = newUserId.Value,
                            RoleID = selectedUserRoleId
                        };

                        // Add the new association to the UserRoles collection of the User entity
                        _eQU.Users.First(u => u.Id == newUserId.Value).UserRoles.Add(newAssociation);

                        _eQU.SaveChanges();
                    }

                        MessageBox.Show("Record added");



                        MessageBox.Show("Record saved successfully!");
                        if (MessageBox.Show("Do you want to add another record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            tbUserName.Clear();
                            tbPassword.Clear();
                        this.Close();


                    }

                    }
                    else
                    {
                    
                        MessageBox.Show("Record not saved.");

                    }

                }

                

               
               

            }

        private void btExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddEditUser_Load(object sender, EventArgs e)
        {
            lblID.Visible = false;
        }
    }

        //}
        //catch
        // {

        //  MessageBox.Show("An unexpected error has occured, plesae contact you administrator");


        // }
    } 


        
    


