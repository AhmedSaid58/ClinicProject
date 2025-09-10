namespace Clinic_Project
{
    partial class SystemLogsScreen
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
            this.components = new System.ComponentModel.Container();
            this.dgvAllSystemLogs = new System.Windows.Forms.DataGridView();
            this.cmsSystemLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.systemLogMoreInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSystemLogID = new System.Windows.Forms.Label();
            this.txbSystemLogID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClrear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAllSystemLogs = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSystemLogs)).BeginInit();
            this.cmsSystemLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAllSystemLogs
            // 
            this.dgvAllSystemLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllSystemLogs.Location = new System.Drawing.Point(2, 276);
            this.dgvAllSystemLogs.Name = "dgvAllSystemLogs";
            this.dgvAllSystemLogs.RowHeadersWidth = 51;
            this.dgvAllSystemLogs.RowTemplate.Height = 24;
            this.dgvAllSystemLogs.Size = new System.Drawing.Size(976, 410);
            this.dgvAllSystemLogs.TabIndex = 0;
            this.dgvAllSystemLogs.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSystemLogs_CellMouseClick);
            // 
            // cmsSystemLog
            // 
            this.cmsSystemLog.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsSystemLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemLogMoreInfoToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsSystemLog.Name = "cmsSystemLog";
            this.cmsSystemLog.Size = new System.Drawing.Size(261, 68);
            // 
            // systemLogMoreInfoToolStripMenuItem
            // 
            this.systemLogMoreInfoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemLogMoreInfoToolStripMenuItem.Name = "systemLogMoreInfoToolStripMenuItem";
            this.systemLogMoreInfoToolStripMenuItem.Size = new System.Drawing.Size(260, 32);
            this.systemLogMoreInfoToolStripMenuItem.Text = "System Log Details ";
            this.systemLogMoreInfoToolStripMenuItem.Click += new System.EventHandler(this.systemLogMoreInfoToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(260, 32);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // lblSystemLogID
            // 
            this.lblSystemLogID.AutoSize = true;
            this.lblSystemLogID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemLogID.Location = new System.Drawing.Point(12, 223);
            this.lblSystemLogID.Name = "lblSystemLogID";
            this.lblSystemLogID.Size = new System.Drawing.Size(195, 29);
            this.lblSystemLogID.TabIndex = 2;
            this.lblSystemLogID.Text = "System Log ID: ";
            // 
            // txbSystemLogID
            // 
            this.txbSystemLogID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSystemLogID.Location = new System.Drawing.Point(213, 223);
            this.txbSystemLogID.Name = "txbSystemLogID";
            this.txbSystemLogID.Size = new System.Drawing.Size(157, 34);
            this.txbSystemLogID.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(353, 218);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 41);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.DarkViolet;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(792, 31);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(164, 52);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClrear
            // 
            this.btnClrear.BackColor = System.Drawing.Color.Crimson;
            this.btnClrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClrear.ForeColor = System.Drawing.Color.White;
            this.btnClrear.Location = new System.Drawing.Point(792, 212);
            this.btnClrear.Name = "btnClrear";
            this.btnClrear.Size = new System.Drawing.Size(164, 51);
            this.btnClrear.TabIndex = 6;
            this.btnClrear.TabStop = false;
            this.btnClrear.Text = "Clear";
            this.btnClrear.UseVisualStyleBackColor = false;
            this.btnClrear.Click += new System.EventHandler(this.btnClrear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 699);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "All System Logs: ";
            // 
            // lblAllSystemLogs
            // 
            this.lblAllSystemLogs.AutoSize = true;
            this.lblAllSystemLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllSystemLogs.Location = new System.Drawing.Point(231, 699);
            this.lblAllSystemLogs.Name = "lblAllSystemLogs";
            this.lblAllSystemLogs.Size = new System.Drawing.Size(27, 29);
            this.lblAllSystemLogs.TabIndex = 8;
            this.lblAllSystemLogs.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Clinic_Project.Properties.Resources.log_file;
            this.pictureBox1.Location = new System.Drawing.Point(325, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // SystemLogsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 758);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblAllSystemLogs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClrear);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txbSystemLogID);
            this.Controls.Add(this.lblSystemLogID);
            this.Controls.Add(this.dgvAllSystemLogs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SystemLogsScreen";
            this.Tag = "16";
            this.Text = "SystemLogsScreen";
            this.Load += new System.EventHandler(this.SystemLogsScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllSystemLogs)).EndInit();
            this.cmsSystemLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAllSystemLogs;
        private System.Windows.Forms.ContextMenuStrip cmsSystemLog;
        private System.Windows.Forms.ToolStripMenuItem systemLogMoreInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label lblSystemLogID;
        private System.Windows.Forms.TextBox txbSystemLogID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClrear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAllSystemLogs;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}