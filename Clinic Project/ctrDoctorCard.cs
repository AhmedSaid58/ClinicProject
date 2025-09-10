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
    public partial class ctrDoctorCard : UserControl
    {
        public ctrDoctorCard()
        {
            InitializeComponent();
        }

        public void LoadDoctorInfo(clsDoctor CurrentDoctor)
        {
            if (CurrentDoctor == null) { return; }  

            ctrPersonCard1.LoadPersonInfo(CurrentDoctor);
            lblDoctorID.Text = Convert.ToString(CurrentDoctor.DoctorID);
            lblSpecialization.Text = CurrentDoctor.Specialization;
        }

    }
}
