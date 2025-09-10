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
    public partial class ctrAddNewPatient : UserControl
    {
        clsPatient CurrentPatient = new clsPatient("","", DateTime.Now, 'M', "", "", "", null);

        public ctrAddNewPatient()
        {
            InitializeComponent();
        }

        public void GetPatientInfo(ref clsPatient patient)
        {
            ctrAddNewPerson1.GetPersonInfo(ref CurrentPatient);
            patient = CurrentPatient;
        }


        private void ctrAddNewPatient_Load(object sender, EventArgs e)
        {
          
        }


    }
}
