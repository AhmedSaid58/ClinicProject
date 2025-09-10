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
    public partial class ctrAddNewPerson : UserControl
    {
        private string CurrentImagePath = string.Empty;

        public ctrAddNewPerson()
        {
            InitializeComponent();
        }

        public void GetPersonInfo(ref clsPatient patient)
        {
            patient.FirstName = tbFirstName.Text;
            patient.LastName = tbLastName.Text;
            patient.DateOfBirth = dtpDateOfBirth.Value;
            patient.Gender = rbMale.Checked ? 'M' : 'F';
            patient.PhoneNumber = tbPhoneNumber.Text;
            patient.Email = tbEmail.Text;
            patient.Address = tbAddress.Text;
            patient.ImagePath = CurrentImagePath;
        }

        public void GetPersonInfo(ref clsDoctor doctor)
        {
            doctor.FirstName = tbFirstName.Text;
            doctor.LastName = tbLastName.Text;
            doctor.DateOfBirth = dtpDateOfBirth.Value;
            doctor.Gender = rbMale.Checked ? 'M' : 'F';
            doctor.PhoneNumber = tbPhoneNumber.Text;
            doctor.Email = tbEmail.Text;
            doctor.Address = tbAddress.Text;
            doctor.ImagePath = CurrentImagePath;

        }

        public void GetPersonInfo(ref clsUser user)
        {
            user.FirstName = tbFirstName.Text;
            user.LastName = tbLastName.Text;
            user.DateOfBirth = dtpDateOfBirth.Value;
            user.Gender = rbMale.Checked ? 'M' : 'F';
            user.PhoneNumber = tbPhoneNumber.Text;
            user.Email = tbEmail.Text;
            user.Address = tbAddress.Text;
            user.ImagePath = CurrentImagePath;

        }

        private void ctrAddNewPerson_Load(object sender, EventArgs e)
        {

        }

        private void pbImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Choose Image";
            openFileDialog.Filter = "Types Images|*.jpg;*.jpeg;*.png;*.bmp;*.gif;";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string ImagePath = openFileDialog.FileName;
                pbImage.Image = Image.FromFile(ImagePath);
                CurrentImagePath = ImagePath;

            }

        }
    }
}
