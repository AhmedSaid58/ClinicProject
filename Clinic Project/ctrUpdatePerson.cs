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
//using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace Clinic_Project
{
    public partial class ctrUpdatePerson : UserControl
    {
        private string CurrentImagePath = string.Empty;

        public ctrUpdatePerson()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(clsPatient patient)
        {
            lblPersonID.Text = "PatientID: ";
            tbPersonID.Text = patient.PatientID.ToString();
            tbFirstName.Text = patient.FirstName;
            tbLastName.Text = patient.LastName;
            DateOfBirth.Value = patient.DateOfBirth;
            rbMale.Checked = (patient.Gender == 'M'); rbFemale.Checked = !rbMale.Checked;
            tbPhoneNumber.Text = patient.PhoneNumber;
            tbEmail.Text = patient.Email;
            tbAddress.Text = patient.Address;

            if (patient.ImagePath != null)
            { 
                if (File.Exists(patient.ImagePath))
                {
                    pictureBox1.Image = Image.FromFile(patient.ImagePath);
                }
            }

            CurrentImagePath = patient.ImagePath;
        }

        public void LoadPersonInfo(clsDoctor doctor)
        {
            lblPersonID.Text = "DoctorID: ";
            tbPersonID.Text = doctor.DoctorID.ToString();
            tbFirstName.Text = doctor.FirstName;
            tbLastName.Text = doctor.LastName;
            DateOfBirth.Value = doctor.DateOfBirth;
            rbMale.Checked = (doctor.Gender == 'M'); rbFemale.Checked = !rbMale.Checked;
            tbPhoneNumber.Text = doctor.PhoneNumber;
            tbEmail.Text = doctor.Email;
            tbAddress.Text = doctor.Address;

            if (doctor.ImagePath != null)
            {
                if (File.Exists(doctor.ImagePath))
                {
                    pictureBox1.Image = Image.FromFile(doctor.ImagePath);
                }
            }

            CurrentImagePath = doctor.ImagePath;

        }

        public void LoadPersonInfo(clsUser user)
        {
            lblPersonID.Text = "DoctorID: ";
            tbPersonID.Text = user.UserID.ToString();
            tbFirstName.Text = user.FirstName;
            tbLastName.Text = user.LastName;
            DateOfBirth.Value = user.DateOfBirth;
            rbMale.Checked = (user.Gender == 'M'); rbFemale.Checked = !rbMale.Checked;
            tbPhoneNumber.Text = user.PhoneNumber;
            tbEmail.Text = user.Email;
            tbAddress.Text = user.Address;

            if (user.ImagePath != null)
            {
                if (File.Exists(user.ImagePath))
                {
                    pictureBox1.Image = Image.FromFile(user.ImagePath);
                }
            }

            CurrentImagePath = user.ImagePath;

        }

        public void GetPersonInfo(ref clsPatient patient)
        {
            patient.FirstName = tbFirstName.Text;
            patient.LastName = tbLastName.Text;
            patient.DateOfBirth = DateOfBirth.Value;
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
            doctor.DateOfBirth = DateOfBirth.Value;
            doctor.Gender = rbMale.Checked ? 'M' : 'F';
            doctor.PhoneNumber = tbPhoneNumber.Text;
            doctor.Email = tbEmail.Text;
            doctor.Address = tbAddress.Text;
            doctor.ImagePath = CurrentImagePath;

        }

        public void GetPersonInfo(ref clsUser user)
        {
            user = clsUser.FindUser(Convert.ToInt32(tbPersonID.Text));
            user.FirstName = tbFirstName.Text;
            user.LastName = tbLastName.Text;
            user.DateOfBirth = DateOfBirth.Value;
            user.Gender = rbMale.Checked ? 'M' : 'F';
            user.PhoneNumber = tbPhoneNumber.Text;
            user.Email = tbEmail.Text;
            user.Address = tbAddress.Text;
            user.ImagePath = CurrentImagePath;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Choose Image";
            openFileDialog.Filter = "Types Images|*.jpg;*.jpeg;*.png;*.bmp;*.gif;";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CurrentImagePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(CurrentImagePath);

            }
        }
    }
}
