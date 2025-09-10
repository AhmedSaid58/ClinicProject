namespace Clinic_Project
{
    partial class AddNewUserScreen
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
            this.ctrAddNewUser1 = new Clinic_Project.ctrAddNewUser();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrAddNewUser1
            // 
            this.ctrAddNewUser1.Location = new System.Drawing.Point(12, 8);
            this.ctrAddNewUser1.Name = "ctrAddNewUser1";
            this.ctrAddNewUser1.Size = new System.Drawing.Size(503, 688);
            this.ctrAddNewUser1.TabIndex = 0;
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewUser.Location = new System.Drawing.Point(35, 712);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(266, 59);
            this.btnAddNewUser.TabIndex = 1;
            this.btnAddNewUser.Text = "AddNewUser";
            this.btnAddNewUser.UseVisualStyleBackColor = true;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // AddNewUserScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 792);
            this.Controls.Add(this.btnAddNewUser);
            this.Controls.Add(this.ctrAddNewUser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddNewUserScreen";
            this.Text = "AddNewUserScreen";
            this.Load += new System.EventHandler(this.AddNewUserScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrAddNewUser ctrAddNewUser1;
        private System.Windows.Forms.Button btnAddNewUser;
    }
}