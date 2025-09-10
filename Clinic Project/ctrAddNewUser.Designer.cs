namespace Clinic_Project
{
    partial class ctrAddNewUser
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
            this.ctrAddNewPerson1 = new Clinic_Project.ctrAddNewPerson();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPermissions = new System.Windows.Forms.Label();
            this.chbAppointments = new System.Windows.Forms.CheckBox();
            this.chbPatients = new System.Windows.Forms.CheckBox();
            this.chbDoctors = new System.Windows.Forms.CheckBox();
            this.chbUsers = new System.Windows.Forms.CheckBox();
            this.chbSystemLogs = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ctrAddNewPerson1
            // 
            this.ctrAddNewPerson1.Location = new System.Drawing.Point(13, -3);
            this.ctrAddNewPerson1.Name = "ctrAddNewPerson1";
            this.ctrAddNewPerson1.Size = new System.Drawing.Size(518, 464);
            this.ctrAddNewPerson1.TabIndex = 0;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(37, 470);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(132, 25);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "User Name: ";
            // 
            // tbUserName
            // 
            this.tbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserName.Location = new System.Drawing.Point(169, 467);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(219, 30);
            this.tbUserName.TabIndex = 1;
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(169, 514);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(219, 30);
            this.tbPassword.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(37, 517);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(119, 25);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password: ";
            // 
            // lblPermissions
            // 
            this.lblPermissions.AutoSize = true;
            this.lblPermissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPermissions.Location = new System.Drawing.Point(37, 574);
            this.lblPermissions.Name = "lblPermissions";
            this.lblPermissions.Size = new System.Drawing.Size(142, 25);
            this.lblPermissions.TabIndex = 4;
            this.lblPermissions.Text = "Permissions: ";
            // 
            // chbAppointments
            // 
            this.chbAppointments.AutoSize = true;
            this.chbAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAppointments.Location = new System.Drawing.Point(75, 615);
            this.chbAppointments.Name = "chbAppointments";
            this.chbAppointments.Size = new System.Drawing.Size(166, 29);
            this.chbAppointments.TabIndex = 5;
            this.chbAppointments.Text = "Appointments";
            this.chbAppointments.UseVisualStyleBackColor = true;
            // 
            // chbPatients
            // 
            this.chbPatients.AutoSize = true;
            this.chbPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbPatients.Location = new System.Drawing.Point(259, 615);
            this.chbPatients.Name = "chbPatients";
            this.chbPatients.Size = new System.Drawing.Size(112, 29);
            this.chbPatients.TabIndex = 6;
            this.chbPatients.Text = "Patients";
            this.chbPatients.UseVisualStyleBackColor = true;
            // 
            // chbDoctors
            // 
            this.chbDoctors.AutoSize = true;
            this.chbDoctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbDoctors.Location = new System.Drawing.Point(259, 650);
            this.chbDoctors.Name = "chbDoctors";
            this.chbDoctors.Size = new System.Drawing.Size(108, 29);
            this.chbDoctors.TabIndex = 7;
            this.chbDoctors.Text = "Doctors";
            this.chbDoctors.UseVisualStyleBackColor = true;
            // 
            // chbUsers
            // 
            this.chbUsers.AutoSize = true;
            this.chbUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbUsers.Location = new System.Drawing.Point(377, 615);
            this.chbUsers.Name = "chbUsers";
            this.chbUsers.Size = new System.Drawing.Size(90, 29);
            this.chbUsers.TabIndex = 8;
            this.chbUsers.Text = "Users";
            this.chbUsers.UseVisualStyleBackColor = true;
            // 
            // chbSystemLogs
            // 
            this.chbSystemLogs.AutoSize = true;
            this.chbSystemLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbSystemLogs.Location = new System.Drawing.Point(75, 650);
            this.chbSystemLogs.Name = "chbSystemLogs";
            this.chbSystemLogs.Size = new System.Drawing.Size(153, 29);
            this.chbSystemLogs.TabIndex = 9;
            this.chbSystemLogs.Text = "SystemLogs";
            this.chbSystemLogs.UseVisualStyleBackColor = true;
            // 
            // ctrAddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chbSystemLogs);
            this.Controls.Add(this.chbUsers);
            this.Controls.Add(this.chbDoctors);
            this.Controls.Add(this.chbPatients);
            this.Controls.Add(this.chbAppointments);
            this.Controls.Add(this.lblPermissions);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.ctrAddNewPerson1);
            this.Name = "ctrAddNewUser";
            this.Size = new System.Drawing.Size(550, 746);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrAddNewPerson ctrAddNewPerson1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblPermissions;
        private System.Windows.Forms.CheckBox chbAppointments;
        private System.Windows.Forms.CheckBox chbPatients;
        private System.Windows.Forms.CheckBox chbDoctors;
        private System.Windows.Forms.CheckBox chbUsers;
        private System.Windows.Forms.CheckBox chbSystemLogs;
    }
}
