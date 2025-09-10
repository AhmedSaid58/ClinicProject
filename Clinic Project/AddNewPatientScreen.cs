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
    public partial class AddNewPatientScreen : Form
    {
        clsUser CurrentUser = null ;
        clsPatient CurrentPatient = null;
  
        public AddNewPatientScreen(clsUser user)
        {
            InitializeComponent();
            CurrentUser = user;
        }

        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            ctrAddNewPatient1.GetPatientInfo(ref CurrentPatient);

            clsPatient NewPatient = new clsPatient
                (
                    CurrentPatient.FirstName,
                    CurrentPatient.LastName,
                    CurrentPatient.DateOfBirth,
                    CurrentPatient.Gender,
                    CurrentPatient.PhoneNumber,
                    CurrentPatient.Email,
                    CurrentPatient.Address,
                    CurrentPatient.ImagePath
                );

            NewPatient = clsPatient.AddNewPatient(NewPatient);

            if (NewPatient != null)
            {

                MessageBox.Show("Added A New Patient Successfuly...");

                clsSystemLog systemLog = new clsSystemLog
                    (
                        CurrentUser.UserID,
                        "Add New Patient",
                        DateTime.Now,
                        $"Added A New Patient With ID {NewPatient.PatientID} By User ID {CurrentUser.UserID} in {DateTime.Now}."
                    );

                if (!clsSystemLog.AddNewSystemLog(systemLog))
                    MessageBox.Show("Error, While Save The Operation System Log!!!!!");

            }
            else
                MessageBox.Show("Error, While Adding New Patient!!!!!");

            this.Close();

        }

    }
}
