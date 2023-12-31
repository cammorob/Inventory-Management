﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Inventory_Management
{
     
    public partial class Form1 : Form


    {
        
        private loginPage _loginPage;
        readonly EQUInventoryEntities _eQU;
        public string  _Username;
        //Fields
        private List<Record> records;
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public string _RoleName;
        
        public Form1()
        {
            InitializeComponent();
            _eQU = new EQUInventoryEntities();
           random = new Random();
            _loginPage = new loginPage();   
          
         
          
        }
       
        public Form1(loginPage loginPage, string roleName, String Username)
        {
            _eQU = new EQUInventoryEntities();
            InitializeComponent();
            _loginPage = loginPage;
            random = new Random();
            UserLabel.Text = Username;
            _RoleName = roleName;
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            DashBoardDock.Controls.Clear();
            DashBoardDock.Controls.Add(userControl);
            userControl.BringToFront();
          

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
         
           

            
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            
            DashBoard dashBoard = new DashBoard();
            addUserControl(dashBoard);
            mainLbL.Text = "Dash Board";


        }



        private Color SelectThemeColor()
        {
            
            
                int index = random.Next(themecolor.ColorList.Count);
                while (tempIndex == index)
                {
                    index = random.Next(themecolor.ColorList.Count);
                }
                tempIndex = index;
                string color = themecolor.ColorList[index];
                return ColorTranslator.FromHtml(color);
            
           
            
        
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //FPHeader.BackColor = color;
                   // MainTitlePanel.BackColor = themecolor.ChangeColorBrightness(color, -0.3);
                    themecolor.PrimaryColor = color;
                    themecolor.SecondaryColor = themecolor.ChangeColorBrightness(color, -0.3);
                   // btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in MenuPanel1.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ReportsPage reportsPage = new ReportsPage();
            addUserControl(reportsPage);
            mainLbL.Text = "Reports";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            DashBoard dashBoard = new DashBoard();
            addUserControl(dashBoard);
            mainLbL.Text = "Dash Board";
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        
       
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_loginPage.Close();
            Application.Exit();
            
        }



        private void btManageUsers_Click(object sender, EventArgs e)
        {
            using (var adminLoginDialog = new AdminLoginDialog())
            {
                if (adminLoginDialog.ShowDialog() == DialogResult.OK)
                {
                    IsValidAdminCredentials(adminLoginDialog.AdminUsername, adminLoginDialog.AdminPassword);
                    
                        var user1 = _eQU.Users.FirstOrDefault(q =>
                            q.Username == adminLoginDialog.AdminUsername &&
                            q.Password == adminLoginDialog.AdminPassword &&
                            q.isActive == true 
                          
                        );
                    //var id = user1.Id;
                

                        if (user1 != null && user1.isActive== true && user1.UserRoles.First().RoleID.ToString()=="2"
                        
                       )
                        {
                            // Admin credentials are valid, proceed with user management
                            ActivateButton(sender);
                            var userAdministration = new UserAdministration();
                            //AssetControl assetControl = new AssetControl();
                            addUserControl(userAdministration);
                            mainLbL.Text = "User Administration";

                            
                        }
                       
                    
                    else
                    {
                        // Admin credentials are not valid, show an error message or take appropriate action
                        MessageBox.Show("Invalid admin credentials. Access denied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        
        private bool IsValidAdminCredentials(string username, string password )
        {
            var user = _eQU.Users.FirstOrDefault(q => q.Username == username && q.Password == password );
            return user != null;
        }

        private void btAssets_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
  
            AssetControl assetControl = new AssetControl(_RoleName);
            addUserControl(assetControl);
            mainLbL.Text = "Assets";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            loginPage loginPage = new loginPage();
            loginPage.Show();
            Hide(); 
        }
    }



}
