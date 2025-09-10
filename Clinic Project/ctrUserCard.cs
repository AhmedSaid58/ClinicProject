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
    public partial class ctrUserCard : UserControl
    {
        public ctrUserCard()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(clsUser CurrentUser)
        {
            lblUserID.Text = CurrentUser.UserID.ToString();
            lblUserName.Text = CurrentUser.UserName.ToString();
            ctrPersonCard1.LoadPersonInfo(CurrentUser);

            if ((CurrentUser.Permissions & 1) != 0)
                chbAppointments.Checked = true;

            if ((CurrentUser.Permissions & 2) != 0)
                chbPatients.Checked = true;

            if ((CurrentUser.Permissions & 4) != 0)
                chbDoctors.Checked = true;

            if ((CurrentUser.Permissions & 8) != 0)
                chbUsers.Checked = true;

            if ((CurrentUser.Permissions & 16) != 0)
                chbSystemLogs.Checked = true;
        }

    }
}
