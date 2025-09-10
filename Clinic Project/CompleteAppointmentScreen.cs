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
    public partial class CompleteAppointmentScreen : Form
    {
        clsUser CurrentUser = null;
        clsAppointment CurrentAppointment = null;
        public CompleteAppointmentScreen(clsUser user, clsAppointment appointment)
        {
            InitializeComponent();
            CurrentUser = user;
            CurrentAppointment = appointment;
        }

        private void VisableMedicalRecordComponents()
        {
            lblMedicalRecordID.Visible = true;
            lblVisitDescription.Visible = true;
            lblDiagnosis.Visible = true;
            lblAdditionalNotes.Visible = true;

            tbMedicalRecordID.Visible = true;
            tbVisitDescription.Visible = true;
            tbDiagnosis.Visible = true;
            tbAdditionalNotes.Visible = true;
            btnComplete.Visible = true;
            btnCancel.Visible = true;
        }

        private void btnSavePrescription_Click(object sender, EventArgs e)
        {
            clsPrescription prescription = new clsPrescription
                (
                    tbMedicationName.Text,
                    tbDosage.Text,
                    tbFrequency.Text,
                    dateTimePickerStartDate.Value,
                    dateTimePickerEndDate.Value,
                    tbSpecialInstructions.Text
                );

            prescription = clsPrescription.AddNewPrescription(prescription);

            if ( prescription != null)
            { 
                VisableMedicalRecordComponents();
                tbPrescriptionID.Text = prescription.PrescriptionID.ToString();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            clsMedicalRecord medicalRecord = new clsMedicalRecord
                (
                    Convert.ToInt32(tbPrescriptionID.Text),
                    tbVisitDescription.Text,
                    tbDiagnosis.Text,
                    tbAdditionalNotes.Text
                );

            medicalRecord = clsMedicalRecord.AddNewMedicalRecord(medicalRecord);

            if ( medicalRecord != null)
            {
                CurrentAppointment.MedicalRecordID = medicalRecord.MedicalRecordID;
                CurrentAppointment.AppointmentStatus = 2;
                clsAppointment.UpdateAppointment(CurrentAppointment);

                MessageBox.Show("Complete Appointment Successfuly..");

                clsSystemLog systemLog = new clsSystemLog
                    (
                        CurrentUser.UserID,
                        "Complete Appointment",
                        DateTime.Now,
                        $"Complete Appointment With AppointmentID {CurrentAppointment.AppointmentID}, " +
                        $"Adding (PrescriptionID {tbPrescriptionID} And MedicalRecordID {tbMedicalRecordID})," +
                        $"By UserID {CurrentUser}, in {DateTime.Now}"

                    );

                if (!clsSystemLog.AddNewSystemLog(systemLog))
                    MessageBox.Show("Error While Adding System Log!!!!");

            }

            this.Close();

        }
    }
}
