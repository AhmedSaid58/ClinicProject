namespace Clinic_Project
{
    partial class UserMoreInfoScreen
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
            this.ctrUserCard1 = new Clinic_Project.ctrUserCard();
            this.SuspendLayout();
            // 
            // ctrUserCard1
            // 
            this.ctrUserCard1.Location = new System.Drawing.Point(3, 12);
            this.ctrUserCard1.Name = "ctrUserCard1";
            this.ctrUserCard1.Size = new System.Drawing.Size(701, 480);
            this.ctrUserCard1.TabIndex = 0;
            this.ctrUserCard1.Load += new System.EventHandler(this.ctrUserCard1_Load);
            // 
            // UserMoreInfoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 499);
            this.Controls.Add(this.ctrUserCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserMoreInfoScreen";
            this.Text = "UserMoreInfoScreen";
            this.Load += new System.EventHandler(this.UserMoreInfoScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrUserCard ctrUserCard1;
    }
}