namespace Clinic_Project
{
    partial class ctrAddNewDoctor
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
            this.lblSpecialization = new System.Windows.Forms.Label();
            this.tbSpecialization = new System.Windows.Forms.TextBox();
            this.ctrAddNewPerson1 = new Clinic_Project.ctrAddNewPerson();
            this.SuspendLayout();
            // 
            // lblSpecialization
            // 
            this.lblSpecialization.AutoSize = true;
            this.lblSpecialization.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecialization.Location = new System.Drawing.Point(31, 474);
            this.lblSpecialization.Name = "lblSpecialization";
            this.lblSpecialization.Size = new System.Drawing.Size(160, 25);
            this.lblSpecialization.TabIndex = 1;
            this.lblSpecialization.Text = "Specialization: ";
            // 
            // tbSpecialization
            // 
            this.tbSpecialization.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSpecialization.Location = new System.Drawing.Point(197, 474);
            this.tbSpecialization.Name = "tbSpecialization";
            this.tbSpecialization.Size = new System.Drawing.Size(182, 30);
            this.tbSpecialization.TabIndex = 1;
            // 
            // ctrAddNewPerson1
            // 
            this.ctrAddNewPerson1.Location = new System.Drawing.Point(3, 3);
            this.ctrAddNewPerson1.Name = "ctrAddNewPerson1";
            this.ctrAddNewPerson1.Size = new System.Drawing.Size(714, 465);
            this.ctrAddNewPerson1.TabIndex = 0;
            // 
            // ctrAddNewDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbSpecialization);
            this.Controls.Add(this.lblSpecialization);
            this.Controls.Add(this.ctrAddNewPerson1);
            this.Name = "ctrAddNewDoctor";
            this.Size = new System.Drawing.Size(712, 551);
            this.Load += new System.EventHandler(this.ctrAddNewDoctor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrAddNewPerson ctrAddNewPerson1;
        private System.Windows.Forms.Label lblSpecialization;
        private System.Windows.Forms.TextBox tbSpecialization;
    }
}
