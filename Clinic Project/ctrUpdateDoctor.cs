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
    public partial class ctrUpdateDoctor : UserControl
    {
        public ctrUpdateDoctor()
        {
            InitializeComponent();
        }

        public void LoadDoctorInfo(clsDoctor doctor)
        {
            ctrUpdatePerson1.LoadPersonInfo(doctor);
            tbSpecialization.Text = doctor.Specialization; 
        }

        public void GetDoctorInfoAfterUpdated(ref clsDoctor doctor)
        {
            ctrUpdatePerson1.GetPersonInfo(ref doctor);
            doctor.Specialization = tbSpecialization.Text;
        }

        private void ctrUpdateDoctor_Load(object sender, EventArgs e)
        {
           
        }
    }
}
