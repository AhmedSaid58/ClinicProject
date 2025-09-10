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
    public partial class AddNewDoctorScreen : Form
    {
        clsDoctor CurrentDoctor = new clsDoctor("" ,"", DateTime.Now, 'M', "", "", "", null, "");
        clsUser CurrentUser = null;

        public AddNewDoctorScreen(clsUser user )
        {
            InitializeComponent();
            CurrentUser = user;
        }

        private void AddNewDoctorScreen_Load(object sender, EventArgs e)
        {

        }

        private void btnAddNewDoctor_Click(object sender, EventArgs e)
        {
            ctrAddNewDoctor1.GetDoctorInfo(ref CurrentDoctor);

            CurrentDoctor = clsDoctor.AddNewDoctor(CurrentDoctor);

            if (CurrentDoctor != null)
            {
                MessageBox.Show("Added New Doctor Successfuly..");

                clsSystemLog SystemLog = new clsSystemLog
                    (
                        CurrentUser.UserID,
                        "Added New Doctor",
                        DateTime.Now,
                        $"Added A New Doctor With DoctorID {CurrentDoctor.DoctorID} By UserID {CurrentUser.UserID} in {DateTime.Now}"

                    );

                if (!clsSystemLog.AddNewSystemLog(SystemLog))
                    MessageBox.Show("Error, While Saving The Operation For The Addding Doctor!!!!");

            }
            else
                MessageBox.Show("Error, While Adding New Doctor!!!!!"); 

            this.Close();

        }
    }
}
