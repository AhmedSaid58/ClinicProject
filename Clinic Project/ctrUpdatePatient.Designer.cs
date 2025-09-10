namespace Clinic_Project
{
    partial class ctrUpdatePatient
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
            this.SuspendLayout();
            // 
            // ctrUpdatePerson1
            // 
            this.ctrUpdatePerson1.Location = new System.Drawing.Point(3, 3);
            this.ctrUpdatePerson1.Name = "ctrUpdatePerson1";
            this.ctrUpdatePerson1.Size = new System.Drawing.Size(481, 446);
            this.ctrUpdatePerson1.TabIndex = 0;
            // 
            // ctrUpdatePatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrUpdatePerson1);
            this.Name = "ctrUpdatePatient";
            this.Size = new System.Drawing.Size(501, 482);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrUpdatePerson ctrUpdatePerson1;
    }
}
