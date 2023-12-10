namespace Inventory_Management
{
    partial class UserAdministration
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAdministration));
            this.MainTitlePanel = new System.Windows.Forms.Panel();
            this.usersGridView1 = new System.Windows.Forms.DataGridView();
            this.btResetPassword = new System.Windows.Forms.Button();
            this.ReFreshBrid = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btAddUser = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTitlePanel
            // 
            this.MainTitlePanel.BackColor = System.Drawing.Color.LightSlateGray;
            this.MainTitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainTitlePanel.Location = new System.Drawing.Point(0, 0);
            this.MainTitlePanel.Name = "MainTitlePanel";
            this.MainTitlePanel.Size = new System.Drawing.Size(1140, 39);
            this.MainTitlePanel.TabIndex = 9;
            // 
            // usersGridView1
            // 
            this.usersGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usersGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.usersGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGridView1.Location = new System.Drawing.Point(144, 107);
            this.usersGridView1.Name = "usersGridView1";
            this.usersGridView1.Size = new System.Drawing.Size(735, 289);
            this.usersGridView1.TabIndex = 13;
            // 
            // btResetPassword
            // 
            this.btResetPassword.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btResetPassword.Location = new System.Drawing.Point(773, 66);
            this.btResetPassword.Name = "btResetPassword";
            this.btResetPassword.Size = new System.Drawing.Size(93, 23);
            this.btResetPassword.TabIndex = 21;
            this.btResetPassword.Text = "Reset Password";
            this.btResetPassword.UseVisualStyleBackColor = true;
            this.btResetPassword.Click += new System.EventHandler(this.btResetPassword_Click_1);
            // 
            // ReFreshBrid
            // 
            this.ReFreshBrid.Location = new System.Drawing.Point(144, 402);
            this.ReFreshBrid.Name = "ReFreshBrid";
            this.ReFreshBrid.Size = new System.Drawing.Size(93, 23);
            this.ReFreshBrid.TabIndex = 20;
            this.ReFreshBrid.Text = "Refresh";
            this.ReFreshBrid.UseVisualStyleBackColor = true;
            this.ReFreshBrid.Click += new System.EventHandler(this.DeAct_Click);
            // 
            // btEdit
            // 
            this.btEdit.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEdit.Location = new System.Drawing.Point(473, 65);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(93, 23);
            this.btEdit.TabIndex = 19;
            this.btEdit.Text = "Edit User";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btAddUser
            // 
            this.btAddUser.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddUser.Location = new System.Drawing.Point(144, 65);
            this.btAddUser.Name = "btAddUser";
            this.btAddUser.Size = new System.Drawing.Size(93, 23);
            this.btAddUser.TabIndex = 18;
            this.btAddUser.Text = "Add New User";
            this.btAddUser.UseVisualStyleBackColor = true;
            this.btAddUser.Click += new System.EventHandler(this.btAddUser_Click);
            // 
            // btDelete
            // 
            this.btDelete.BackColor = System.Drawing.Color.Red;
            this.btDelete.Location = new System.Drawing.Point(786, 402);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(93, 23);
            this.btDelete.TabIndex = 22;
            this.btDelete.Text = "Delete User";
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // UserAdministration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btResetPassword);
            this.Controls.Add(this.ReFreshBrid);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btAddUser);
            this.Controls.Add(this.MainTitlePanel);
            this.Controls.Add(this.usersGridView1);
            this.Name = "UserAdministration";
            this.Size = new System.Drawing.Size(1140, 500);
            this.Load += new System.EventHandler(this.UserAdministration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel MainTitlePanel;
        private System.Windows.Forms.DataGridView usersGridView1;
        private System.Windows.Forms.Button btResetPassword;
        private System.Windows.Forms.Button ReFreshBrid;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btAddUser;
        private System.Windows.Forms.Button btDelete;
    }
}
