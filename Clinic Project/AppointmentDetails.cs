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
    public partial class frmAppointmentMoreInfo : Form
    {
        clsAppointment CurrentAppointment = null;

        public frmAppointmentMoreInfo(clsAppointment appointment)
        {
            InitializeComponent();
            CurrentAppointment = appointment;
        }

        private string LoadAppointmentStatus(Byte AppointmentStatus)
        {
            if (AppointmentStatus == 0)
                return "Pending";
            else if (AppointmentStatus == 1)
                return "Confirmed";
            else if (AppointmentStatus == 2)
                return "Completed";
            else if (AppointmentStatus == 3)
                return "Canceled";
            else if (AppointmentStatus == 4)
                return "Rescheduled";
            else if (AppointmentStatus == 5)
                return "No Show";

            return null;

        }

        private void frmAppointmentMoreInfo_Load(object sender, EventArgs e)
        {
            clsPatient CurrentPatient = clsPatient.FindPatient(CurrentAppointment.PatientID);
            clsDoctor CurrentDoctor = clsDoctor.FindDoctor(CurrentAppointment.DoctorID);
            clsMedicalRecord CurrentMedicalRecord = clsMedicalRecord.FindMedicalRecord(CurrentAppointment.MedicalRecordID);
            clsPrescription CurrentPrescription = null;
            clsPayment CurrentPayment = clsPayment.FindPayment(CurrentAppointment.PaymentID);
            string strAppointmentStatus = LoadAppointmentStatus(CurrentAppointment.AppointmentStatus);

            if (CurrentMedicalRecord != null)
                CurrentPrescription = clsPrescription.FindPrescription(CurrentMedicalRecord.PrescriptionsID);

            lblAppointmentID.Text = CurrentAppointment.AppointmentID.ToString();
            ctrPatientCard1.LoadPatientInfo(CurrentPatient);
            ctrDoctorCard1.LoadDoctorInfo(CurrentDoctor);
            ctrMedicalRecordCard1.LoadMedicalRecord(CurrentMedicalRecord);
            ctrPrescription1.LoadPrescription(CurrentPrescription);
            ctrPaymentCard1.LoadPayment(CurrentPayment);
            lblAppointmentDateTime.Text = CurrentAppointment.AppointmentDateTime.ToString();
            lblAppointmentStatus.Text = strAppointmentStatus ;

        }


    }
}
