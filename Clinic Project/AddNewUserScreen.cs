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
    public partial class AddNewUserScreen : Form
    {
        clsUser CurrentUser = null;
        clsUser NewUser = new clsUser("", "", DateTime.Now, 'M', "", "", "", "", "", "", 0);

        public AddNewUserScreen(clsUser User)
        {
            InitializeComponent();
            CurrentUser = User;
        }

        private void AddNewUserScreen_Load(object sender, EventArgs e)
        {

        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            ctrAddNewUser1.GetUserInfo(ref NewUser);

            if (clsUser.AddNewUser(NewUser) != null)
            {
                MessageBox.Show("Added New User Successfuly.");

                clsSystemLog systemLog = new clsSystemLog
                    (
                        CurrentUser.UserID,
                        "Add New User",
                        DateTime.Now,
                        $"Added New User With UserID {NewUser.UserID}, By User With UserID {CurrentUser.UserID}, in {DateTime.Now}"

                    );

                if (!clsSystemLog.AddNewSystemLog(systemLog))
                    MessageBox.Show("Error, While Saving System Log!!!!");

            }
            else
                MessageBox.Show("Error, While Adding New User!!!");

            this.Close();

        }
    }
}
