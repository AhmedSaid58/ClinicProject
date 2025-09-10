namespace Clinic_Project
{
    partial class ctrUpdateUser
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
            this.ctrUpdatePerson1 = new Clinic_Project.ctrUpdatePerson();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chbSystemLogs = new System.Windows.Forms.CheckBox();
            this.chbUsers = new System.Windows.Forms.CheckBox();
            this.chbDoctors = new System.Windows.Forms.CheckBox();
            this.chbPatients = new System.Windows.Forms.CheckBox();
            this.chbAppointments = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ctrUpdatePerson1
            // 
            this.ctrUpdatePerson1.Location = new System.Drawing.Point(3, 3);
            this.ctrUpdatePerson1.Name = "ctrUpdatePerson1";
            this.ctrUpdatePerson1.Size = new System.Drawing.Size(457, 472);
            this.ctrUpdatePerson1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 463);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "UserName: ";
            // 
            // tbUserName
            // 
            this.tbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserName.Location = new System.Drawing.Point(182, 463);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(255, 30);
            this.tbUserName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 539);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Permissions: ";
            // 
            // chbSystemLogs
            // 
            this.chbSystemLogs.AutoSize = true;
            this.chbSystemLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbSystemLogs.Location = new System.Drawing.Point(55, 616);
            this.chbSystemLogs.Name = "chbSystemLogs";
            this.chbSystemLogs.Size = new System.Drawing.Size(153, 29);
            this.chbSystemLogs.TabIndex = 14;
            this.chbSystemLogs.Text = "SystemLogs";
            this.chbSystemLogs.UseVisualStyleBackColor = true;
            // 
            // chbUsers
            // 
            this.chbUsers.AutoSize = true;
            this.chbUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbUsers.Location = new System.Drawing.Point(357, 581);
            this.chbUsers.Name = "chbUsers";
            this.chbUsers.Size = new System.Drawing.Size(90, 29);
            this.chbUsers.TabIndex = 13;
            this.chbUsers.Text = "Users";
            this.chbUsers.UseVisualStyleBackColor = true;
            // 
            // chbDoctors
            // 
            this.chbDoctors.AutoSize = true;
            this.chbDoctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbDoctors.Location = new System.Drawing.Point(239, 616);
            this.chbDoctors.Name = "chbDoctors";
            this.chbDoctors.Size = new System.Drawing.Size(108, 29);
            this.chbDoctors.TabIndex = 12;
            this.chbDoctors.Text = "Doctors";
            this.chbDoctors.UseVisualStyleBackColor = true;
            // 
            // chbPatients
            // 
            this.chbPatients.AutoSize = true;
            this.chbPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbPatients.Location = new System.Drawing.Point(239, 581);
            this.chbPatients.Name = "chbPatients";
            this.chbPatients.Size = new System.Drawing.Size(112, 29);
            this.chbPatients.TabIndex = 11;
            this.chbPatients.Text = "Patients";
            this.chbPatients.UseVisualStyleBackColor = true;
            // 
            // chbAppointments
            // 
            this.chbAppointments.AutoSize = true;
            this.chbAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAppointments.Location = new System.Drawing.Point(55, 581);
            this.chbAppointments.Name = "chbAppointments";
            this.chbAppointments.Size = new System.Drawing.Size(166, 29);
            this.chbAppointments.TabIndex = 10;
            this.chbAppointments.Text = "Appointments";
            this.chbAppointments.UseVisualStyleBackColor = true;
            // 
            // ctrUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chbSystemLogs);
            this.Controls.Add(this.chbUsers);
            this.Controls.Add(this.chbDoctors);
            this.Controls.Add(this.chbPatients);
            this.Controls.Add(this.chbAppointments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrUpdatePerson1);
            this.Name = "ctrUpdateUser";
            this.Size = new System.Drawing.Size(521, 663);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrUpdatePerson ctrUpdatePerson1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbSystemLogs;
        private System.Windows.Forms.CheckBox chbUsers;
        private System.Windows.Forms.CheckBox chbDoctors;
        private System.Windows.Forms.CheckBox chbPatients;
        private System.Windows.Forms.CheckBox chbAppointments;
    }
}
