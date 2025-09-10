using ClinicBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_Project
{
    public partial class ctrPatientCard : UserControl
    {
        public ctrPatientCard()
        {
            InitializeComponent();
        }


        public void LoadPatientInfo(clsPatient patient)
        {
            if (patient == null) {return; }

            lblPatientID.Text = patient.PatientID.ToString();
            ctrPersonCard1.LoadPersonInfo(patient);
        }

    }
}
