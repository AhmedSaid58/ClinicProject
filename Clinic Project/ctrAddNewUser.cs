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
    public partial class ctrAddNewUser : UserControl
    {
        public ctrAddNewUser()
        {
            InitializeComponent();
        }

        public void GetUserInfo(ref clsUser user)
        {
            ctrAddNewPerson1.GetPersonInfo(ref user);

            user.UserName = tbUserName.Text;
            user.Password = tbPassword.Text;

            int Permissions = 0;

            if (chbAppointments.Checked == true)
                Permissions += 1;

            if (chbPatients.Checked == true)
                Permissions += 2;

            if (chbDoctors.Checked == true)
                Permissions += 4;

            if (chbUsers.Checked == true)
                Permissions += 8;

            if (chbSystemLogs.Checked == true)
                Permissions += 16;
            
            user.Permissions = Permissions;

        }

    }
}
