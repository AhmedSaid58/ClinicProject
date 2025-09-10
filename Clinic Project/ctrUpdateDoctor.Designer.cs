namespace Clinic_Project
{
    partial class ctrUpdateDoctor
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
            this.lbl = new System.Windows.Forms.Label();
            this.tbSpecialization = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ctrUpdatePerson1
            // 
            this.ctrUpdatePerson1.Location = new System.Drawing.Point(3, 3);
            this.ctrUpdatePerson1.Name = "ctrUpdatePerson1";
            this.ctrUpdatePerson1.Size = new System.Drawing.Size(481, 472);
            this.ctrUpdatePerson1.TabIndex = 0;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(53, 450);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(160, 25);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "Specialization: ";
            // 
            // tbSpecialization
            // 
            this.tbSpecialization.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSpecialization.Location = new System.Drawing.Point(219, 450);
            this.tbSpecialization.Name = "tbSpecialization";
            this.tbSpecialization.Size = new System.Drawing.Size(218, 30);
            this.tbSpecialization.TabIndex = 1;
            // 
            // ctrUpdateDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbSpecialization);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.ctrUpdatePerson1);
            this.Name = "ctrUpdateDoctor";
            this.Size = new System.Drawing.Size(571, 499);
            this.Load += new System.EventHandler(this.ctrUpdateDoctor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrUpdatePerson ctrUpdatePerson1;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox tbSpecialization;
    }
}
