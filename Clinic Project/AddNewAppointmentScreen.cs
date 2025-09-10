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
    public partial class AddNewAppointmentScreen : Form
    {
        clsUser CurrentUser = null;

        public AddNewAppointmentScreen(clsUser user)
        {
            InitializeComponent();
            CurrentUser = user; 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            AddNewPatientScreen addNewPatient = new AddNewPatientScreen(CurrentUser);
            addNewPatient.ShowDialog();
        }

        private void AddNewAppointmentScreen_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.MinDate = DateTime.Now; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            int PatientID = Convert.ToInt32(tbPatientID.Text);
            int DoctorID = Convert.ToInt32(tbDoctorID.Text);

            if (clsPatient.FindPatient(PatientID) != null && clsDoctor.FindDoctor(DoctorID) != null)
            {
                // Appointment Status (Pending) = 0 in Data base.
                // Medical RecordID = -1 = Null in Data Base.
                // PaymentID = -1 = Null in Data Base.
                clsAppointment appointment = new clsAppointment(PatientID, DoctorID, dateTimePicker1.Value, 0, -1, -1);

                clsAppointment NewAppointment = clsAppointment.AddNewAppointment(appointment);

                if (NewAppointment != null)
                {
                    MessageBox.Show("Added New Appointment Successfuly...");

                    clsSystemLog systemLog = new clsSystemLog
                        (
                            CurrentUser.UserID,
                            "Add New Appointment",
                            DateTime.Now,
                            $"Added New Appointment For The Patient With PatientID " +
                            $"{PatientID} And Doctor With DoctorID {DoctorID}," +
                            $" in DateTime {DateTime.Now}, By User With UserID {CurrentUser.UserID} "
                        );

                    if (!clsSystemLog.AddNewSystemLog(systemLog))
                        MessageBox.Show("Error, While Saving System Log!!!!!");

                }

                this.Close();

            }
            else
                MessageBox.Show("Error, PatientID Or DoctorID is Wrong!!!!!");

        }

    }
}
