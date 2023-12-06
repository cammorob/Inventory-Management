﻿using FontAwesome.WinForms;
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
        public AddEditUser()
        {
            InitializeComponent();
            _eQU = new EQUInventoryEntities();
            AddEditUserlbl.Text = "Add New User";
            formMode = false;
            _eQU = new EQUInventoryEntities();
            UserOptions();
        }

        public AddEditUser(User UserToEdit)
        {


            InitializeComponent();
            AddEditUserlbl.Text = "Edit User";
            _eQU = new EQUInventoryEntities();
            populateFields(UserToEdit);
            formMode = true;
          // UserOptions();


        }

        private void populateFields(User UserToEdit)
        {
            var roles = _eQU.Roles.ToList();
            roles.Insert(0, new Role { Id = -1, RoleName = "Select Option" });

            cbUserRole.DisplayMember = "RoleName";
            cbUserRole.ValueMember = "Id";
            cbUserRole.DataSource = roles;

            tbUserName.Text = UserToEdit.Username ?? "";
            tbPassword.Text = UserToEdit.Password ?? "";
            cbActiveMode.Text = UserToEdit.isActive.HasValue ? UserToEdit.isActive.Value.ToString() : "";

           
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

            var active = _eQU.Users.ToList();
            //users.Insert(0, new User { Id = -1, isActive = "Select Option" });
            cbActiveMode.DisplayMember = "isActive";
            cbActiveMode.ValueMember = "isActive";
            cbActiveMode.DataSource = active; 



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

                        var UserToEdit = _eQU.Users.FirstOrDefault(q => q.Id == id);
                      
                        UserToEdit.Username= tbUserName.Text;
                      //  UserToEdit.UserRoles = cbUserRole; 
                        UserToEdit.Password= tbPassword.Text;   
                      
                        _eQU.SaveChanges();
                    }
                }
                else
                {

                    var username = tbUserName.Text;
                    var userRoles = cbUserRole.SelectedValue;
                    var password = tbPassword.Text;
                    var activate = cbActiveMode.SelectedValue;

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
                         $"Status: {activate}\n"  ;

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

                    var user= new User();


                    user.Username = username;
                    cbUserRole.SelectedValue = userRoles;
                    user.Password = password;
                    cbUserRole.SelectedValue = activate;
                   

                    _eQU.Users.Add(user);
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



    }

}