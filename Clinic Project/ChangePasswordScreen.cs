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
    public partial class ChangePasswordScreen : Form
    {
        clsUser CurrentUser = null;
        public ChangePasswordScreen(clsUser user)
        {
            InitializeComponent();
            CurrentUser = user;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdatePasswordScreen_Load(object sender, EventArgs e)
        {
            tbOldPassword.UseSystemPasswordChar = false;
            tbNewPassword.UseSystemPasswordChar = false;
            tbConfirmPassword.UseSystemPasswordChar = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (clsUser.FindUser(CurrentUser.UserName, tbOldPassword.Text) != null)
            {
                if (tbNewPassword.Text == tbConfirmPassword.Text)
                {
                    CurrentUser.Password = tbNewPassword.Text;

                    if (clsUser.UpdateUser(CurrentUser))
                    {

                        clsSystemLog systemLog = new clsSystemLog
                       (
                           CurrentUser.UserID,
                           "Change User Password",
                           DateTime.Now,
                           $"Update Current User Password With UserID {CurrentUser.UserID} in {DateTime.Now}"
                       );

                        clsSystemLog.AddNewSystemLog(systemLog);

                        MessageBox.Show("Updated Password Successfuly...");

                        this.Close();
                    }

                }
                else
                    MessageBox.Show("Error, Confirm Password!!!!!");

            }
            else
                MessageBox.Show("Old Password is Wrong!!!!!");

        }

        private void chbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (!chbShowPassword.Checked)
            {
                tbOldPassword.UseSystemPasswordChar = false;
                tbNewPassword.UseSystemPasswordChar = false;
                tbConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tbOldPassword.UseSystemPasswordChar = true;
                tbNewPassword.UseSystemPasswordChar = true;
                tbConfirmPassword.UseSystemPasswordChar = true;

            }
        }
    }
}
