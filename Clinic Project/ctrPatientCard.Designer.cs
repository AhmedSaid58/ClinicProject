namespace Clinic_Project
{
    partial class ctrPatientCard
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
            this.ctrPersonCard1 = new Clinic_Project.ctrPersonCard();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPatientID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrPersonCard1
            // 
            this.ctrPersonCard1.Location = new System.Drawing.Point(-3, 44);
            this.ctrPersonCard1.Name = "ctrPersonCard1";
            this.ctrPersonCard1.Size = new System.Drawing.Size(667, 275);
            this.ctrPersonCard1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "PatientID: ";
            // 
            // lblPatientID
            // 
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientID.Location = new System.Drawing.Point(149, 26);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(84, 25);
            this.lblPatientID.TabIndex = 2;
            this.lblPatientID.Text = "??????";
            // 
            // ctrPatientCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPatientID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrPersonCard1);
            this.Name = "ctrPatientCard";
            this.Size = new System.Drawing.Size(712, 345);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrPersonCard ctrPersonCard1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPatientID;
    }
}
