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
    public partial class ctrAddNewDoctor : UserControl
    {
        public ctrAddNewDoctor()
        {
            InitializeComponent();
        }

        public void GetDoctorInfo(ref clsDoctor Doctor)
        {
            ctrAddNewPerson1.GetPersonInfo(ref Doctor);
            Doctor.Specialization = tbSpecialization.Text;
        }

       
        private void ctrAddNewDoctor_Load(object sender, EventArgs e)
        {

        }
    }
}
