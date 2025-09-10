namespace Clinic_Project
{
    partial class AddNewPatientScreen
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
            this.ctrAddNewPatient1 = new Clinic_Project.ctrAddNewPatient();
            this.btnAddNewPatient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrAddNewPatient1
            // 
            this.ctrAddNewPatient1.Location = new System.Drawing.Point(12, 12);
            this.ctrAddNewPatient1.Name = "ctrAddNewPatient1";
            this.ctrAddNewPatient1.Size = new System.Drawing.Size(543, 500);
            this.ctrAddNewPatient1.TabIndex = 0;
            // 
            // btnAddNewPatient
            // 
            this.btnAddNewPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewPatient.Location = new System.Drawing.Point(47, 529);
            this.btnAddNewPatient.Name = "btnAddNewPatient";
            this.btnAddNewPatient.Size = new System.Drawing.Size(347, 77);
            this.btnAddNewPatient.TabIndex = 1;
            this.btnAddNewPatient.Text = "Add New Patient";
            this.btnAddNewPatient.UseVisualStyleBackColor = true;
            this.btnAddNewPatient.Click += new System.EventHandler(this.btnAddNewPatient_Click);
            // 
            // AddNewPatientScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 635);
            this.Controls.Add(this.btnAddNewPatient);
            this.Controls.Add(this.ctrAddNewPatient1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddNewPatientScreen";
            this.Text = "AddNewPatientScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrAddNewPatient ctrAddNewPatient1;
        private System.Windows.Forms.Button btnAddNewPatient;
    }
}