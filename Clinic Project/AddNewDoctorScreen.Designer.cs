namespace Clinic_Project
{
    partial class AddNewDoctorScreen
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
            this.ctrAddNewDoctor1 = new Clinic_Project.ctrAddNewDoctor();
            this.btnAddNewDoctor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrAddNewDoctor1
            // 
            this.ctrAddNewDoctor1.Location = new System.Drawing.Point(12, 3);
            this.ctrAddNewDoctor1.Name = "ctrAddNewDoctor1";
            this.ctrAddNewDoctor1.Size = new System.Drawing.Size(651, 532);
            this.ctrAddNewDoctor1.TabIndex = 0;
            // 
            // btnAddNewDoctor
            // 
            this.btnAddNewDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewDoctor.Location = new System.Drawing.Point(55, 554);
            this.btnAddNewDoctor.Name = "btnAddNewDoctor";
            this.btnAddNewDoctor.Size = new System.Drawing.Size(340, 82);
            this.btnAddNewDoctor.TabIndex = 1;
            this.btnAddNewDoctor.Text = "Add New Doctor";
            this.btnAddNewDoctor.UseVisualStyleBackColor = true;
            this.btnAddNewDoctor.Click += new System.EventHandler(this.btnAddNewDoctor_Click);
            // 
            // AddNewDoctorScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 688);
            this.Controls.Add(this.btnAddNewDoctor);
            this.Controls.Add(this.ctrAddNewDoctor1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddNewDoctorScreen";
            this.Text = "AddNewDoctorScreen";
            this.Load += new System.EventHandler(this.AddNewDoctorScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrAddNewDoctor ctrAddNewDoctor1;
        private System.Windows.Forms.Button btnAddNewDoctor;
    }
}