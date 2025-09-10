using ClinicBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_Project
{
    public partial class SystemLogsScreen : Form
    {
        private DataTable _SystemLogTable;
        private DataGridViewRow _selectedRow;
        clsUser CurrentUser = null;

        public SystemLogsScreen(clsUser user)
        {
            InitializeComponent();
            CurrentUser = user;
        }

        public void LoadSystemLogs()
        {
            _SystemLogTable = clsSystemLog.GetAllSystemLogs();
            dgvAllSystemLogs.DataSource = _SystemLogTable;
        }

        private void dgvSystemLogs_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvAllSystemLogs.ClearSelection();
                dgvAllSystemLogs.Rows[e.RowIndex].Selected = true;
                _selectedRow = dgvAllSystemLogs.Rows[e.RowIndex];

                Rectangle cellRect = dgvAllSystemLogs.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Point locationOnScreen = dgvAllSystemLogs.PointToScreen(cellRect.Location);

                cmsSystemLog.Show(locationOnScreen.X, locationOnScreen.Y + cellRect.Height);
            }
        }

        private void SystemLogsScreen_Load(object sender, EventArgs e)
        {
            LoadSystemLogs();
            lblAllSystemLogs.Text = dgvAllSystemLogs.RowCount.ToString();
            dgvAllSystemLogs.Columns["Details"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchID = txbSystemLogID.Text.Trim();

            if (string.IsNullOrEmpty(searchID))
            {
                dgvAllSystemLogs.DataSource = _SystemLogTable;
                return;
            }

            DataView dv = _SystemLogTable.DefaultView;
            dv.RowFilter = $"LogID = '{searchID.Replace("'", "''")}'";

            dgvAllSystemLogs.DataSource = dv.ToTable();
        }

        private void systemLogMoreInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedRow != null)
            {
                int SystemLogID = Convert.ToInt32(_selectedRow.Cells["LogID"].Value);
                clsSystemLog systemLog = clsSystemLog.FindSystemLog(SystemLogID);

                SystemLogMoreInfo systemLogMoreInfo = new SystemLogMoreInfo(systemLog);

                systemLogMoreInfo.ShowDialog();

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvAllSystemLogs.DataSource = clsSystemLog.GetAllSystemLogs();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedRow != null)
            {
                int LogID = Convert.ToInt32(_selectedRow.Cells["LogID"].Value);

                DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this Log?", "Confirm Deletion", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {

                    if (clsSystemLog.DeleteSystemLog(LogID))
                    {
                        MessageBox.Show("Log deleted successfully.");
                        dgvAllSystemLogs.DataSource = clsSystemLog.GetAllSystemLogs();

                        clsSystemLog systemLog = new clsSystemLog
                        (
                            CurrentUser.UserID,
                            "Delete A System Log",
                            DateTime.Now,
                            $"Delete A System Log by UserID {CurrentUser.UserID} in {DateTime.Now}"
                        );

                        clsSystemLog.AddNewSystemLog(systemLog);


                    }
                    else
                        MessageBox.Show("Log was not deleted.");

                }
            }
        }

        private void btnClrear_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to Remove All System Logs?", "Confirm Deletion", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {

                if (clsSystemLog.ClearSystemLogs())
                {
                    MessageBox.Show("Remove All System Logs successfully.");
                    dgvAllSystemLogs.DataSource = clsSystemLog.GetAllSystemLogs();

                    clsSystemLog systemLog = new clsSystemLog
                   (
                       CurrentUser.UserID,
                       "Clear System Logs",
                       DateTime.Now,
                       $"Clear System Logs by UserID {CurrentUser.UserID} in {DateTime.Now}"
                   );

                    clsSystemLog.AddNewSystemLog(systemLog);

                }
                else
                    MessageBox.Show("Error While deleting.");

            }


        }
    }
}
