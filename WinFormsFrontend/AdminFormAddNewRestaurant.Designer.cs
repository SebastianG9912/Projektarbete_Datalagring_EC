namespace WinFormsFrontend
{
    partial class AdminFormAddNewRestaurant
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.txtBoxPhone = new System.Windows.Forms.TextBox();
            this.txtBoxLocation = new System.Windows.Forms.TextBox();
            this.btnAddRestaurant = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblName.Location = new System.Drawing.Point(35, 46);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(258, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Write the name of the new restaurant:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblLocation.Location = new System.Drawing.Point(35, 90);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(275, 20);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Text = "Write the location of the new restaurant:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblPhone.Location = new System.Drawing.Point(35, 134);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(318, 20);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Write the phone number of the new restaurant:";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(375, 43);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(233, 27);
            this.txtBoxName.TabIndex = 1;
            // 
            // txtBoxPhone
            // 
            this.txtBoxPhone.Location = new System.Drawing.Point(375, 131);
            this.txtBoxPhone.Name = "txtBoxPhone";
            this.txtBoxPhone.Size = new System.Drawing.Size(233, 27);
            this.txtBoxPhone.TabIndex = 3;
            // 
            // txtBoxLocation
            // 
            this.txtBoxLocation.Location = new System.Drawing.Point(375, 87);
            this.txtBoxLocation.Name = "txtBoxLocation";
            this.txtBoxLocation.Size = new System.Drawing.Size(233, 27);
            this.txtBoxLocation.TabIndex = 2;
            // 
            // btnAddRestaurant
            // 
            this.btnAddRestaurant.Location = new System.Drawing.Point(253, 198);
            this.btnAddRestaurant.Name = "btnAddRestaurant";
            this.btnAddRestaurant.Size = new System.Drawing.Size(134, 38);
            this.btnAddRestaurant.TabIndex = 4;
            this.btnAddRestaurant.Text = "Add restaurant";
            this.btnAddRestaurant.UseVisualStyleBackColor = true;
            this.btnAddRestaurant.Click += new System.EventHandler(this.btnAddRestaurant_Click);
            // 
            // AdminFormAddNewRestaurant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(654, 264);
            this.Controls.Add(this.btnAddRestaurant);
            this.Controls.Add(this.txtBoxLocation);
            this.Controls.Add(this.txtBoxPhone);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblName);
            this.Name = "AdminFormAddNewRestaurant";
            this.Text = "Add new restaurant";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblName;
        private Label lblLocation;
        private Label lblPhone;
        private TextBox txtBoxName;
        private TextBox txtBoxPhone;
        private TextBox txtBoxLocation;
        private Button btnAddRestaurant;
    }
}