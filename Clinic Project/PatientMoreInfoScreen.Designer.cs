namespace Clinic_Project
{
    partial class PatientMoreInfoScreen
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
            this.ctrPatientCard1 = new Clinic_Project.ctrPatientCard();
            this.SuspendLayout();
            // 
            // ctrPatientCard1
            // 
            this.ctrPatientCard1.Location = new System.Drawing.Point(12, 26);
            this.ctrPatientCard1.Name = "ctrPatientCard1";
            this.ctrPatientCard1.Size = new System.Drawing.Size(712, 345);
            this.ctrPatientCard1.TabIndex = 0;
            // 
            // PatientMoreInfoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 385);
            this.Controls.Add(this.ctrPatientCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PatientMoreInfoScreen";
            this.Text = "PatientMoreInfo";
            this.Load += new System.EventHandler(this.PatientMoreInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrPatientCard ctrPatientCard1;
    }
}