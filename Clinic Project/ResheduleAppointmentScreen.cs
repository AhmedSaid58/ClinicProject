using ClinicBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_Project
{
    public partial class ResheduleAppointmentScreen : Form
    {
        clsUser CurrentUser = null;
        clsAppointment CurrentAppointment = null;

        public ResheduleAppointmentScreen(clsUser user, clsAppointment appointment)
        {
            InitializeComponent();
            CurrentUser = user;
            CurrentAppointment = appointment;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btbSave_Click(object sender, EventArgs e)
        {
            CurrentAppointment.AppointmentDateTime = dateTimePicker1.Value;
            CurrentAppointment.AppointmentStatus = 4;

            if (clsAppointment.UpdateAppointment(CurrentAppointment))
            {
                MessageBox.Show("Resheduled The Appointment Successfuly..");

                clsSystemLog systemLog = new clsSystemLog
                    (
                        CurrentUser.UserID,
                        "Reshedule",
                        DateTime.Now,
                        $"Resheduled The Appointment With AppointmentID {CurrentAppointment.AppointmentID}," +
                        $" User With UserID {CurrentUser.UserID}, in {DateTime.Now}."
                    );

                if (!clsSystemLog.AddNewSystemLog(systemLog))
                    MessageBox.Show("Error, While Saving A System Log!!!!"); 
                    
            }
            else
                MessageBox.Show("Error, While Resheduled An Appointment!!!!");

            this.Close();

        }

        private void ResheduleAppointmentScreen_Load(object sender, EventArgs e)
        {
            tbAppointmentID.Text = CurrentAppointment.AppointmentID.ToString();
            dateTimePicker1.MinDate = DateTime.Now;
        }

    }
}
