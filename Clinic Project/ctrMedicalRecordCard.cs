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
    public partial class ctrMedicalRecordCard : UserControl
    {
        public ctrMedicalRecordCard()
        {
            InitializeComponent();
        }

        public void LoadMedicalRecord(clsMedicalRecord CurrentMedicalRecord)
        {
            if (CurrentMedicalRecord == null) { return; }

            lblMedicalRecordID.Text = Convert.ToString(CurrentMedicalRecord.MedicalRecordID);
            lblDiagnosis.Text = Convert.ToString(CurrentMedicalRecord.Diagnosis);
            lblVisitDescription.Text = Convert.ToString(CurrentMedicalRecord.VisitDescription);
            lblAdditionalNots.Text = Convert.ToString(CurrentMedicalRecord.AdditionalNotes);

        }

    }
}
