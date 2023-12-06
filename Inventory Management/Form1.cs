using System;
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
        //Fields
        private List<Record> records;
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
      //  public string _RoleName;
        
        public Form1()
        {
            InitializeComponent();
            _eQU = new EQUInventoryEntities();
           random = new Random();
            
         
          
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
            _loginPage.Close();
        }

        private void btManageUsers_Click(object sender, EventArgs e)
        {
            var userAdministration = new UserAdministration();
            AssetControl assetControl = new AssetControl();
            addUserControl(userAdministration);

            mainLbL.Text = "User Administration";

        }

        private void btAssets_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            // asset_Check_Out_Form.ShowDialog();   
            AssetControl assetControl = new AssetControl();
            addUserControl(assetControl);
            mainLbL.Text = "Assets";
        }
    }



}
