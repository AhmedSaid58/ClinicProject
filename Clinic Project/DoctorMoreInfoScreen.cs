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
    public partial class DoctorMoreInfoScreen : Form
    {
        clsDoctor CurrentDoctor = null ;

        public DoctorMoreInfoScreen(clsDoctor doctor)
        {
            InitializeComponent();
            CurrentDoctor = doctor ;

        }

        private void DoctorMoreInfoScreen_Load(object sender, EventArgs e)
        {
            ctrDoctorCard1.LoadDoctorInfo(CurrentDoctor);
        }
    }
}
