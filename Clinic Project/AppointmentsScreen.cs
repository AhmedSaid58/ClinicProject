using ClinicBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_Project
{
    public partial class AppointmentsScreen : Form
    {
        clsUser CurrentUser = null;
        private DataTable _appointmentsTable;
        private DataGridViewRow _selectedRow;

        public AppointmentsScreen(clsUser user )
        {
            InitializeComponent();
            CurrentUser = user;
        }

        private void AppointmentsScreen_Load(object sender, EventArgs e)
        {
            _appointmentsTable = clsAppointment.GetAllAppointments(); 
            dgvAllAppointments.DataSource = _appointmentsTable;
            lblTotalAppointments.Text = dgvAllAppointments.RowCount.ToString();
            cbStatus.SelectedIndex = 0;

            clsAppointment.UpdateNoShowAppointments();

        }

        private void dgvAllAppointments_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvAllAppointments.ClearSelection();
                dgvAllAppointments.Rows[e.RowIndex].Selected = true;
                _selectedRow = dgvAllAppointments.Rows[e.RowIndex];

                Rectangle cellRect = dgvAllAppointments.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Point locationOnScreen = dgvAllAppointments.PointToScreen(cellRect.Location);

                cmsAppointments.Show(locationOnScreen.X, locationOnScreen.Y + cellRect.Height);
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string searchID = tbSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchID))
            {
                dgvAllAppointments.DataSource = _appointmentsTable;
                return;
            }
       
            DataView dv = _appointmentsTable.DefaultView;
            dv.RowFilter = $"AppointmentID = '{searchID.Replace("'", "''")}'";

            dgvAllAppointments.DataSource = dv.ToTable();
        }

        private void moreInformationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedRow != null)
            {
                int AppointmentID = Convert.ToInt32(_selectedRow.Cells["AppointmentID"].Value);
                clsAppointment appointment = clsAppointment.FindAppointment(AppointmentID);

                frmAppointmentMoreInfo appointmentMoreInfoScreen = new frmAppointmentMoreInfo(appointment);

                appointmentMoreInfoScreen.ShowDialog();

            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvAllAppointments.DataSource = clsAppointment.GetAllAppointments();
            lblTotalAppointments.Text = dgvAllAppointments.RowCount.ToString();

            clsAppointment.UpdateNoShowAppointments();

        }

        private void btAddNewAppointment_Click(object sender, EventArgs e)
        {
            AddNewAppointmentScreen addNewAppointmentScreen = new AddNewAppointmentScreen(CurrentUser);
            addNewAppointmentScreen.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = Convert.ToInt32(_selectedRow.Cells["AppointmentID"].Value);
            clsAppointment appointment = clsAppointment.FindAppointment(AppointmentID);

            if (appointment.PaymentID != -1)
            {
                MessageBox.Show("This Appointment is AlReady Confirmed!!!!");
                return;
            }

            ConfirmAppointmentScreen NewPaymentScreen = new ConfirmAppointmentScreen(appointment, CurrentUser);
            NewPaymentScreen.ShowDialog();
        }

        private void CompleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = Convert.ToInt32(_selectedRow.Cells["AppointmentID"].Value);
            clsAppointment appointment = clsAppointment.FindAppointment(AppointmentID);

            if (appointment.AppointmentStatus == 2)
            {
                MessageBox.Show("This Appointment is Already Completed!!!");
                return;
            }

            if (appointment.PaymentID == -1)
            {
                MessageBox.Show("This Appointment is Not Confirmed!!, Please Confirme The appointment befor Complete.");
                return;
            }

            if (appointment.AppointmentDateTime > DateTime.Now)
            {
                MessageBox.Show("This Appointment Date Time is Not Now!!!!");
                return;
            }

            CompleteAppointmentScreen completeAppointmentScreen = new CompleteAppointmentScreen(CurrentUser, appointment);
            completeAppointmentScreen.ShowDialog();

        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = Convert.ToInt32(_selectedRow.Cells["AppointmentID"].Value);
            clsAppointment appointment = clsAppointment.FindAppointment(AppointmentID);

            DialogResult confirmResult = MessageBox.Show("Are you sure you want to Cancel This Appointment?", "Confirm Canceltion", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                appointment.AppointmentStatus = 3;

                if (clsAppointment.UpdateAppointment(appointment))
                { 
                    MessageBox.Show("Canceld The Appointment Successfuly..");

                    clsSystemLog systemLog = new clsSystemLog
                    (
                        CurrentUser.UserID,
                        "Cancele Appointment",
                        DateTime.Now,
                        $"Cancel Appointment With ID {AppointmentID}, By User With UserID {CurrentUser.UserID}, " +
                        $"in {DateTime.Now}"
                    );

                    if (!clsSystemLog.AddNewSystemLog(systemLog))
                        MessageBox.Show("Error, Whiel Saving A System Log!!!");

                }
                else
                    MessageBox.Show("Error, Whiel Cancele The Appointment!!!");

            }

        }

        private void resheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = Convert.ToInt32(_selectedRow.Cells["AppointmentID"].Value);
            clsAppointment appointment = clsAppointment.FindAppointment(AppointmentID);

            if (appointment.AppointmentStatus == 2)
            {
                MessageBox.Show("This Appointment is Already Completed!!!");
                return;
            }

            ResheduleAppointmentScreen resheduleAppointment = new ResheduleAppointmentScreen(CurrentUser, appointment);
            resheduleAppointment.ShowDialog();

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cbStatus.SelectedItem.ToString() == "Pending")
                dgvAllAppointments.DataSource = clsAppointment.GetAppointmentsByStatus(0);
            else if (cbStatus.SelectedItem.ToString() == "Confirmed")
                dgvAllAppointments.DataSource = clsAppointment.GetAppointmentsByStatus(1);
            else if (cbStatus.SelectedItem.ToString() == "Completed")
                dgvAllAppointments.DataSource = clsAppointment.GetAppointmentsByStatus(2);
            else if (cbStatus.SelectedItem.ToString() == "Cancelled")
                dgvAllAppointments.DataSource = clsAppointment.GetAppointmentsByStatus(3);
            else if (cbStatus.SelectedItem.ToString() == "Resheduled")
                dgvAllAppointments.DataSource = clsAppointment.GetAppointmentsByStatus(4);
            else if (cbStatus.SelectedItem.ToString() == "No Show")
                dgvAllAppointments.DataSource = clsAppointment.GetAppointmentsByStatus(5);

            lblTotalAppointments.Text = dgvAllAppointments.RowCount.ToString();

        }
    }

}
