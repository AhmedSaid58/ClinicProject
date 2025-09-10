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
    public partial class ctrUpdatePatient : UserControl
    {
        clsPatient CurrentPatient = null;

        public ctrUpdatePatient()
        {
            InitializeComponent();
        }

        public void LoadPatientInfo(clsPatient patient)
        {
            ctrUpdatePerson1.LoadPersonInfo(patient);
        }

        public void GetPatientInfo(ref clsPatient patient)
        {
            ctrUpdatePerson1.GetPersonInfo(ref patient);
        }


  
    }
}
