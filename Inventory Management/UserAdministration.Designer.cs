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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MainTitlePanel = new System.Windows.Forms.Panel();
            this.usersGridView1 = new System.Windows.Forms.DataGridView();
            this.btResetPassword = new System.Windows.Forms.Button();
            this.DeAct = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btAddUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            this.MainTitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(255, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(155, 55);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 72);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(163, 72);
            this.button3.TabIndex = 5;
            this.button3.Text = "Roles";
            this.button3.UseMnemonic = false;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(163, 72);
            this.button1.TabIndex = 4;
            this.button1.Text = " Users";
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(163, 434);
            this.panel2.TabIndex = 11;
            // 
            // MainTitlePanel
            // 
            this.MainTitlePanel.BackColor = System.Drawing.Color.LightSlateGray;
            this.MainTitlePanel.Controls.Add(this.pictureBox3);
            this.MainTitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainTitlePanel.Location = new System.Drawing.Point(0, 0);
            this.MainTitlePanel.Name = "MainTitlePanel";
            this.MainTitlePanel.Size = new System.Drawing.Size(1140, 66);
            this.MainTitlePanel.TabIndex = 9;
            // 
            // usersGridView1
            // 
            this.usersGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usersGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.usersGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGridView1.Location = new System.Drawing.Point(217, 175);
            this.usersGridView1.Name = "usersGridView1";
            this.usersGridView1.Size = new System.Drawing.Size(511, 289);
            this.usersGridView1.TabIndex = 13;
            // 
            // btResetPassword
            // 
            this.btResetPassword.Location = new System.Drawing.Point(438, 105);
            this.btResetPassword.Name = "btResetPassword";
            this.btResetPassword.Size = new System.Drawing.Size(93, 23);
            this.btResetPassword.TabIndex = 21;
            this.btResetPassword.Text = "Reset Password";
            this.btResetPassword.UseVisualStyleBackColor = true;
            this.btResetPassword.Click += new System.EventHandler(this.btResetPassword_Click_1);
            // 
            // DeAct
            // 
            this.DeAct.Location = new System.Drawing.Point(537, 105);
            this.DeAct.Name = "DeAct";
            this.DeAct.Size = new System.Drawing.Size(93, 23);
            this.DeAct.TabIndex = 20;
            this.DeAct.Text = "Deactivate User";
            this.DeAct.UseVisualStyleBackColor = true;
            this.DeAct.Click += new System.EventHandler(this.DeAct_Click);
            // 
            // btEdit
            // 
            this.btEdit.Location = new System.Drawing.Point(339, 105);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(93, 23);
            this.btEdit.TabIndex = 19;
            this.btEdit.Text = "Edit User";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btAddUser
            // 
            this.btAddUser.Location = new System.Drawing.Point(227, 105);
            this.btAddUser.Name = "btAddUser";
            this.btAddUser.Size = new System.Drawing.Size(93, 23);
            this.btAddUser.TabIndex = 18;
            this.btAddUser.Text = "Add New User";
            this.btAddUser.UseVisualStyleBackColor = true;
            this.btAddUser.Click += new System.EventHandler(this.btAddUser_Click);
            // 
            // UserAdministration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btResetPassword);
            this.Controls.Add(this.DeAct);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btAddUser);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MainTitlePanel);
            this.Controls.Add(this.usersGridView1);
            this.Name = "UserAdministration";
            this.Size = new System.Drawing.Size(1140, 500);
            this.Load += new System.EventHandler(this.UserAdministration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.MainTitlePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel MainTitlePanel;
        private System.Windows.Forms.DataGridView usersGridView1;
        private System.Windows.Forms.Button btResetPassword;
        private System.Windows.Forms.Button DeAct;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btAddUser;
    }
}
