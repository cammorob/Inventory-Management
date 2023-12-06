using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management
{
    public partial class loginPage : Form
    {
        private readonly EQUInventoryEntities _eQU;
        public loginPage()
        {
            InitializeComponent();
            _eQU = new EQUInventoryEntities();  
           // this.Text = string.Empty;
        }

        private void loginPage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try 
            {
                SHA256 sha =SHA256.Create();
                var username= tbUserName.Text.Trim();  
                var password= tbPassword.Text.Trim();
                var hashed_password = Utils.HashPassword(password);

                var user1 = _eQU.Users.FirstOrDefault(q => q.Username.ToString() == username && 
                q.Password.ToString() == hashed_password && q.isActive== true);

           


                if (user1 != null) 
                
                {

                    MessageBox.Show("Please provide valid credentials");
                
                }
                else

                {
                   
                 
                    // var roleName = role.Role.RoleName;
                     var Form1 = new Form1( );
                    Form1.Show();
                    Hide();

                }


            }
            catch 
            {

                MessageBox.Show("Something went wrong. PLease try again");
            }

        }
    }
}
