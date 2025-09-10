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
    public partial class ctrUpdateUser : UserControl
    {
        public ctrUpdateUser()
        {
            InitializeComponent();
        }

        public void FillUserInfoBeforeUpdate(clsUser user)
        {
            ctrUpdatePerson1.LoadPersonInfo(user);
            tbUserName.Text = user.UserName;

            if ((user.Permissions & 1) != 0)
                chbAppointments.Checked = true;

            if ((user.Permissions & 2) != 0)
                chbPatients.Checked = true;

            if ((user.Permissions & 4) != 0)
                chbDoctors.Checked = true;

            if ((user.Permissions & 8) != 0)
                chbUsers.Checked = true;

            if ((user.Permissions & 16) != 0)
                chbSystemLogs.Checked = true;

        }

        public void GetUserInfoAfterUpdated(ref clsUser user)
        {
            ctrUpdatePerson1.GetPersonInfo(ref user);
            user.UserName = tbUserName.Text;

            user.Permissions = 0;

            if (chbAppointments.Checked)
                user.Permissions += 1;

            if (chbPatients.Checked)
                user.Permissions += 2;

            if (chbDoctors.Checked)
                user.Permissions += 4;

            if (chbUsers.Checked)
                user.Permissions += 8;

            if (chbSystemLogs.Checked)
                user.Permissions += 16;

        }

        public void DisablePermissions()
        {
            chbAppointments.Enabled = false;
            chbPatients.Enabled = false;
            chbDoctors.Enabled = false;
            chbUsers.Enabled = false;
            chbSystemLogs.Enabled = false;
        }

    }
}
