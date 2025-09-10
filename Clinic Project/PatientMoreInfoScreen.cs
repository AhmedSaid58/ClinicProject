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
    public partial class PatientMoreInfoScreen : Form
    {
        clsPatient CurrentPatient = null;

        public PatientMoreInfoScreen(clsPatient patient)
        {
            InitializeComponent();
            CurrentPatient = patient;
        }

        private void PatientMoreInfo_Load(object sender, EventArgs e)
        {
            ctrPatientCard1.LoadPatientInfo(CurrentPatient);
        }
    }
}
