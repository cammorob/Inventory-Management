using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Inventory_Management
{
    public partial class AdminLoginDialog: Form
    {
        private EQUInventoryEntities _eQU;
        public string AdminUsername { get; private set; }
        public string AdminPassword { get; private set; }

        public AdminLoginDialog()
        {
            InitializeComponent();
            _eQU = new EQUInventoryEntities();  
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            AdminUsername = tbUserName.Text;
            AdminPassword = tbPassword.Text;
           

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
