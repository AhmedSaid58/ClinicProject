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
    public partial class UpdateDoctorScreen : Form
    {
        clsDoctor CurrentDoctor = null;
        clsUser CurrentUser = null;

        public UpdateDoctorScreen(clsDoctor doctor, clsUser user)
        {
            InitializeComponent();
            CurrentDoctor = doctor;
            CurrentUser = user; 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateDoctorScreen_Load(object sender, EventArgs e)
        {
            ctrUpdateDoctor1.LoadDoctorInfo(CurrentDoctor);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ctrUpdateDoctor1.GetDoctorInfoAfterUpdated(ref CurrentDoctor);

            if (clsDoctor.UpdateDoctor(CurrentDoctor))
            { 
                MessageBox.Show("Updated Doctor Successfuly.....");

                clsSystemLog systemLog = new clsSystemLog
                    (
                        CurrentUser.UserID,
                        "Update Doctor",
                        DateTime.Now,
                        $"Updated Doctor With DoctorID {CurrentDoctor.DoctorID} By UserID {CurrentUser.UserID}, in {DateTime.Now}"

                    );

                if (!clsSystemLog.AddNewSystemLog(systemLog))
                    MessageBox.Show("Error, While Saving The Updating Doctor Operation !!!");

            }
            else
                MessageBox.Show("Errer While Updating Docotr!!!");

            this.Close();

        }
    }
}
