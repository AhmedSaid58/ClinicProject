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
    public partial class UpdateUserScreen : Form
    {
        clsUser CurrentUser = null;
        clsUser UpdatedUser = null;
        public UpdateUserScreen(clsUser updatedUser, clsUser currentUser)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            UpdatedUser = updatedUser;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ctrUpdateUser1.GetUserInfoAfterUpdated(ref UpdatedUser);

            if (clsUser.UpdateUser(UpdatedUser))
            {
                MessageBox.Show("Updtated User Successfuly...");

                clsSystemLog systemLog = new clsSystemLog
                    (
                        CurrentUser.UserID,
                        "Update User",
                        DateTime.Now,
                        $"Update User With UserID {UpdatedUser.UserID} by UserID {CurrentUser.UserID} in {DateTime.Now}"
                    );

                clsSystemLog.AddNewSystemLog(systemLog);

                this.Close();   
            }
            else
                MessageBox.Show("Error While Updating The User!!!");

        }

        private void UpdateUserScreen_Load(object sender, EventArgs e)
        {
            if (CurrentUser.UserID == UpdatedUser.UserID)
                ctrUpdateUser1.DisablePermissions();

            ctrUpdateUser1.FillUserInfoBeforeUpdate(UpdatedUser);

        }
    }
}
