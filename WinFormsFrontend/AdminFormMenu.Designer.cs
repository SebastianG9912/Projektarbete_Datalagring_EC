namespace WinFormsFrontend
{
    partial class AdminFormMenu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnResetDB = new System.Windows.Forms.Button();
            this.btnViewUsers = new System.Windows.Forms.Button();
            this.btnViewRestaurants = new System.Windows.Forms.Button();
            this.btnAddRestaurant = new System.Windows.Forms.Button();
            this.txtBoxInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnResetDB
            // 
            this.btnResetDB.Location = new System.Drawing.Point(12, 19);
            this.btnResetDB.Name = "btnResetDB";
            this.btnResetDB.Size = new System.Drawing.Size(174, 50);
            this.btnResetDB.TabIndex = 0;
            this.btnResetDB.Text = "Reset database";
            this.btnResetDB.UseVisualStyleBackColor = true;
            this.btnResetDB.Click += new System.EventHandler(this.btnResetDB_Click);
            // 
            // btnViewUsers
            // 
            this.btnViewUsers.Location = new System.Drawing.Point(12, 75);
            this.btnViewUsers.Name = "btnViewUsers";
            this.btnViewUsers.Size = new System.Drawing.Size(174, 50);
            this.btnViewUsers.TabIndex = 1;
            this.btnViewUsers.Text = "View all users";
            this.btnViewUsers.UseVisualStyleBackColor = true;
            this.btnViewUsers.Click += new System.EventHandler(this.btnViewUsers_Click);
            // 
            // btnViewRestaurants
            // 
            this.btnViewRestaurants.Location = new System.Drawing.Point(12, 131);
            this.btnViewRestaurants.Name = "btnViewRestaurants";
            this.btnViewRestaurants.Size = new System.Drawing.Size(174, 50);
            this.btnViewRestaurants.TabIndex = 2;
            this.btnViewRestaurants.Text = "View all restaurants";
            this.btnViewRestaurants.UseVisualStyleBackColor = true;
            this.btnViewRestaurants.Click += new System.EventHandler(this.btnViewRestaurants_Click);
            // 
            // btnAddRestaurant
            // 
            this.btnAddRestaurant.Location = new System.Drawing.Point(12, 187);
            this.btnAddRestaurant.Name = "btnAddRestaurant";
            this.btnAddRestaurant.Size = new System.Drawing.Size(174, 50);
            this.btnAddRestaurant.TabIndex = 3;
            this.btnAddRestaurant.Text = "Add a new restaurant";
            this.btnAddRestaurant.UseVisualStyleBackColor = true;
            this.btnAddRestaurant.Click += new System.EventHandler(this.btnAddRestaurant_Click);
            // 
            // txtBoxInfo
            // 
            this.txtBoxInfo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxInfo.Location = new System.Drawing.Point(192, 19);
            this.txtBoxInfo.Multiline = true;
            this.txtBoxInfo.Name = "txtBoxInfo";
            this.txtBoxInfo.ReadOnly = true;
            this.txtBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxInfo.Size = new System.Drawing.Size(667, 581);
            this.txtBoxInfo.TabIndex = 5;
            // 
            // AdminFormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(871, 612);
            this.Controls.Add(this.txtBoxInfo);
            this.Controls.Add(this.btnAddRestaurant);
            this.Controls.Add(this.btnViewRestaurants);
            this.Controls.Add(this.btnViewUsers);
            this.Controls.Add(this.btnResetDB);
            this.Name = "AdminFormMenu";
            this.Text = "Admin Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnResetDB;
        private Button btnViewUsers;
        private Button btnViewRestaurants;
        private Button btnAddRestaurant;
        private TextBox txtBoxInfo;
    }
}