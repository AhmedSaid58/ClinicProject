namespace Clinic_Project
{
    partial class ctrAddNewPatient
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
            this.SuspendLayout();
            // 
            // ctrAddNewPerson1
            // 
            this.ctrAddNewPerson1.Location = new System.Drawing.Point(17, 20);
            this.ctrAddNewPerson1.Name = "ctrAddNewPerson1";
            this.ctrAddNewPerson1.Size = new System.Drawing.Size(574, 517);
            this.ctrAddNewPerson1.TabIndex = 0;
            // 
            // ctrAddNewPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrAddNewPerson1);
            this.Name = "ctrAddNewPatient";
            this.Size = new System.Drawing.Size(618, 523);
            this.Load += new System.EventHandler(this.ctrAddNewPatient_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrAddNewPerson ctrAddNewPerson1;
    }
}
