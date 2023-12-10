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
        public string currentUser;
        public loginPage()
        {
            InitializeComponent();
            _eQU = new EQUInventoryEntities();  
           this.Text = string.Empty;
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
                var password= tbPassword.Text;
                byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++) 
                {
                    stringBuilder.Append(data[i].ToString("x2"));
                
                
                }




                var hashed_password = stringBuilder.ToString();


                
                var user1 = _eQU.Users.FirstOrDefault(q =>
                q.Username == username &&
                 q.Password == password && q.isActive== true 
                );



                if (user1 == null) 
                
                {

                    MessageBox.Show("Please provide valid login credentials.");
                    tbUserName.Clear();
                    tbPassword.Clear();
                
                }
                else

                {
                   
                 currentUser = username;
                    var USER =user1.Username ;
                    var NAME = USER;
                    var role = user1.UserRoles.FirstOrDefault();
                    var Form1 = new Form1(this, role.Role.ShortName, NAME.ToString()) ;
                    Form1.Show();
                    Hide();

                }


            }
            catch 
            {

                MessageBox.Show("Something went wrong. Please try again.");
            }

        }
    }
}
