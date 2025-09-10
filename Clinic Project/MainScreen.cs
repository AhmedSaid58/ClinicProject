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
using System.IO;

namespace Clinic_Project
{
    public partial class MainScreen: Form
    {
        clsUser CurrentUser = null;

        public MainScreen(clsUser User)
        {
            InitializeComponent();

            CurrentUser = User;
        }

        private void HomePageForm_Load(object sender, EventArgs e)
        {
            lbUserFirstName.Text = $"Hello, {CurrentUser.FirstName}";

            if (CurrentUser.ImagePath != null)
            {

                if (File.Exists(CurrentUser.ImagePath))
                {
                    pbUserImage.Image = Image.FromFile(CurrentUser.ImagePath);

                }
                
            }

        }

        private void btAppointments_Click(object sender, EventArgs e)
        {
            AppointmentsScreen appointmentsScreen = new AppointmentsScreen(CurrentUser);

            if ((Convert.ToInt32(appointmentsScreen.Tag) & CurrentUser.Permissions) != 0)
                appointmentsScreen.ShowDialog();
            else
                MessageBox.Show("Sorry, You Do not Have Permissions To Open This Screen!!!!");

        }

        private void btPersons_Click(object sender, EventArgs e)
        {
            cmsPersons.Show(btPersons, new Point(0, btPersons.Height));
        }

        private void patientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonsScreen PScreen = new PersonsScreen(PersonsScreen.enMode.Patients, CurrentUser);

            PScreen.Tag = 2.ToString();

            if ((Convert.ToInt32(PScreen.Tag) & CurrentUser.Permissions) != 0)
                PScreen.ShowDialog();
            else
                MessageBox.Show("Sorry, You Do not Have Permissions To Open This Screen!!!!");

        }

        private void doctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonsScreen PScreen = new PersonsScreen(PersonsScreen.enMode.Doctors, CurrentUser);
            PScreen.Tag = 4.ToString();

            if ((Convert.ToInt32(PScreen.Tag) & CurrentUser.Permissions) != 0)
                PScreen.ShowDialog();
            else
                MessageBox.Show("Sorry, You Do not Have Permissions To Open This Screen!!!!");

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonsScreen PScreen = new PersonsScreen(PersonsScreen.enMode.Users, CurrentUser);
            PScreen.Tag = 8.ToString();

            if ((Convert.ToInt32(PScreen.Tag) & CurrentUser.Permissions) != 0)
                PScreen.ShowDialog();
            else
                MessageBox.Show("Sorry, You Do not Have Permissions To Open This Screen!!!!");

        }

        private void btnSystemLogs_Click(object sender, EventArgs e)
        {
            SystemLogsScreen logsScreen = new SystemLogsScreen(CurrentUser);

            if ((Convert.ToInt32(logsScreen.Tag) & CurrentUser.Permissions) != 0)
                logsScreen.ShowDialog();
            else
                MessageBox.Show("Sorry, You Do not Have Permissions To Open This Screen!!!!"); 
        }

        private void btnAccountSettings_Click(object sender, EventArgs e)
        {
            cmsAccountSettings.Show(btnAccountSettings, new Point(0, btnAccountSettings.Height));
        }

        private void updateCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUserScreen updateUserScreen = new UpdateUserScreen(CurrentUser, CurrentUser);
            updateUserScreen.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordScreen passwordScreen = new ChangePasswordScreen(CurrentUser);
            passwordScreen.ShowDialog();
        }

        private void updateCurrentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserMoreInfoScreen userMoreInfo = new UserMoreInfoScreen(CurrentUser);
            userMoreInfo.ShowDialog(); 
        }
    }
}
