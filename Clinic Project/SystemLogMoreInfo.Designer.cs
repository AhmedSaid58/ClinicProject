namespace Clinic_Project
{
    partial class SystemLogMoreInfo
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
            this.lblSystemLog = new System.Windows.Forms.Label();
            this.ctrUserCard1 = new Clinic_Project.ctrUserCard();
            this.ctrSystemLogCard1 = new Clinic_Project.ctrSystemLogCard();
            this.SuspendLayout();
            // 
            // lblSystemLog
            // 
            this.lblSystemLog.AutoSize = true;
            this.lblSystemLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemLog.ForeColor = System.Drawing.Color.DarkViolet;
            this.lblSystemLog.Location = new System.Drawing.Point(178, 9);
            this.lblSystemLog.Name = "lblSystemLog";
            this.lblSystemLog.Size = new System.Drawing.Size(382, 46);
            this.lblSystemLog.TabIndex = 0;
            this.lblSystemLog.Text = "System Log Details";
            // 
            // ctrUserCard1
            // 
            this.ctrUserCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrUserCard1.Location = new System.Drawing.Point(1, 373);
            this.ctrUserCard1.Name = "ctrUserCard1";
            this.ctrUserCard1.Size = new System.Drawing.Size(774, 343);
            this.ctrUserCard1.TabIndex = 2;
            // 
            // ctrSystemLogCard1
            // 
            this.ctrSystemLogCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrSystemLogCard1.Location = new System.Drawing.Point(1, 67);
            this.ctrSystemLogCard1.Name = "ctrSystemLogCard1";
            this.ctrSystemLogCard1.Size = new System.Drawing.Size(774, 300);
            this.ctrSystemLogCard1.TabIndex = 1;
            // 
            // SystemLogMoreInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 772);
            this.Controls.Add(this.ctrUserCard1);
            this.Controls.Add(this.ctrSystemLogCard1);
            this.Controls.Add(this.lblSystemLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SystemLogMoreInfo";
            this.Text = "SystemLogMoreInfo";
            this.Load += new System.EventHandler(this.SystemLogMoreInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSystemLog;
        private ctrSystemLogCard ctrSystemLogCard1;
        private ctrUserCard ctrUserCard1;
    }
}