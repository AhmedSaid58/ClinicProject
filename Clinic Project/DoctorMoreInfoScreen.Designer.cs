namespace Clinic_Project
{
    partial class DoctorMoreInfoScreen
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
            this.ctrDoctorCard1 = new Clinic_Project.ctrDoctorCard();
            this.SuspendLayout();
            // 
            // ctrDoctorCard1
            // 
            this.ctrDoctorCard1.Location = new System.Drawing.Point(12, 12);
            this.ctrDoctorCard1.Name = "ctrDoctorCard1";
            this.ctrDoctorCard1.Size = new System.Drawing.Size(740, 348);
            this.ctrDoctorCard1.TabIndex = 0;
            // 
            // DoctorMoreInfoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 410);
            this.Controls.Add(this.ctrDoctorCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DoctorMoreInfoScreen";
            this.Text = "DoctorMoreInfoScreen";
            this.Load += new System.EventHandler(this.DoctorMoreInfoScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrDoctorCard ctrDoctorCard1;
    }
}