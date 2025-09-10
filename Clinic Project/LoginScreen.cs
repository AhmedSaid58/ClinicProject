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
using System.Configuration;

namespace Clinic_Project
{
    public partial class LoginScreen: Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberMe)
            {
                txtUserName.Text = Properties.Settings.Default.SavedUserName;
                txtPassword.Text = Properties.Settings.Default.SavedPassword;
                chkRememberMe.Checked = true;
            }
        }

        private void btLogin_Click(object sender, EventArgs e)
        {

            string UserName = txtUserName.Text;
            string Password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Username or password is incorrect.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsUser user = clsUser.FindUser(UserName, Password);

            if ( user != null)
            {
                
                if (chkRememberMe.Checked)
                {
                    Properties.Settings.Default.SavedUserName = UserName;
                    Properties.Settings.Default.SavedPassword = Password;
                    Properties.Settings.Default.RememberMe = true;
                }
                else
                {
                    Properties.Settings.Default.SavedUserName = "";
                    Properties.Settings.Default.SavedPassword = "";
                    Properties.Settings.Default.RememberMe = false;
                }

                Properties.Settings.Default.Save();

                // Save The Login Operation in The System Logs.
                clsSystemLog systemLog = new clsSystemLog
                    (
                        user.UserID,
                        "Login",
                        DateTime.Now,
                        $"Login to The System By The UserID {user.UserID} in {DateTime.Now}"
                    );

                if (clsSystemLog.AddNewSystemLog(systemLog))
                {
                    // Open the Home Page And Hide The Login Screen.
                    MainScreen Homeform = new MainScreen(user);

                    this.Hide();
                    Homeform.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show("Error While Adding New System Log...!!!");

            }
            else
            {
                MessageBox.Show("Username or password is Wrong!!!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }

    }

}
