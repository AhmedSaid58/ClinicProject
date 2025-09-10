using ClinicBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_Project
{
    public partial class ctrPersonCard : UserControl
    {

        public ctrPersonCard()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(clsPatient CurrentPatient)
        {
            lblName.Text = (CurrentPatient.FirstName + " " + CurrentPatient.LastName);
            lblDateOfBirth.Text = CurrentPatient.DateOfBirth.ToShortDateString();
            lblAddress.Text = CurrentPatient.Address;
            lblEmail.Text = CurrentPatient.Email;
            lblPhoneNumber.Text = CurrentPatient.PhoneNumber;

            if (CurrentPatient.ImagePath != null)
            {
                if(File.Exists(CurrentPatient.ImagePath))
                {
                    pbImage.Image = Image.FromFile(CurrentPatient.ImagePath);
                }
            }
        }
        public void LoadPersonInfo(clsDoctor CurrentDoctor)
        {
            lblName.Text = (CurrentDoctor.FirstName + " " + CurrentDoctor.LastName);
            lblDateOfBirth.Text = CurrentDoctor.DateOfBirth.ToShortDateString();
            lblAddress.Text = CurrentDoctor.Address;
            lblEmail.Text = CurrentDoctor.Email;
            lblPhoneNumber.Text = CurrentDoctor.PhoneNumber;

            if (CurrentDoctor.ImagePath != null)
            {
                if (File.Exists(CurrentDoctor.ImagePath))
                {
                    pbImage.Image = Image.FromFile(CurrentDoctor.ImagePath);
                }
            }
        }
        public void LoadPersonInfo(clsUser CurrentUser)
        {
            lblName.Text = (CurrentUser.FirstName + " " + CurrentUser.LastName);
            lblDateOfBirth.Text = CurrentUser.DateOfBirth.ToShortDateString();
            lblAddress.Text = CurrentUser.Address;
            lblEmail.Text = CurrentUser.Email;
            lblPhoneNumber.Text = CurrentUser.PhoneNumber;

            if (CurrentUser.ImagePath != null)
            {
                if (File.Exists(CurrentUser.ImagePath))
                {
                    pbImage.Image = Image.FromFile(CurrentUser.ImagePath);
                }
            }
        }

        private void ctrPersonCard_Load(object sender, EventArgs e)
        {

        }
    }
}
