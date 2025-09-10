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
    public partial class ctrPrescriptionCard : UserControl
    {
        public ctrPrescriptionCard()
        {
            InitializeComponent();
        }

        public void LoadPrescription(clsPrescription prescription)
        {
            if (prescription == null) { return; }

            lblPrescriptionID.Text = prescription.PrescriptionID.ToString();
            lblMedicationName.Text = prescription.MedicationName.ToString();
            lblDosage.Text = prescription.Dosage.ToString();
            lblFrequency.Text = prescription.Frequency.ToString();
            lblStartDate.Text = prescription.StartDate.ToShortDateString();
            lblEndDate.Text = prescription.EndDate.ToShortDateString();
            lblSpecialInstructions.Text = prescription.SpecialInstructions.ToString();

        }


    }
}
