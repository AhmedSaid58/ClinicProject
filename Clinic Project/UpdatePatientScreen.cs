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
    public partial class UpdatePatientScreen : Form
    {
        clsUser CurrentUser = null; 
        clsPatient CurrentPatient = null;

        public UpdatePatientScreen(clsPatient patient, clsUser User)
        {
            InitializeComponent();
            CurrentPatient = patient;
            CurrentUser = User;
        }

        private void UpdatePatientScreen_Load(object sender, EventArgs e)
        {
            ctrUpdatePatient1.LoadPatientInfo(CurrentPatient);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ctrUpdatePatient1.GetPatientInfo(ref CurrentPatient);

            if (clsPatient.UpdatePatient(CurrentPatient))
            { 
                MessageBox.Show("Updated Patient Successfuly...");
            
                clsSystemLog systemLog = new clsSystemLog
                    (
                        CurrentUser.UserID,
                        "Update Patient",
                        DateTime.Now,
                        $"Updated Patint With Patient ID {CurrentPatient.PatientID} By User With User ID {CurrentUser.UserID} Successfuly."
                    );

                if (!clsSystemLog.AddNewSystemLog(systemLog))
                    MessageBox.Show("Error, while Saving system Log");
            
            }
            else
                MessageBox.Show("Error While Updating Patient!!!");

            this.Close();
        }
    }
}
