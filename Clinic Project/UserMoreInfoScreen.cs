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
    public partial class UserMoreInfoScreen : Form
    {
        clsUser CurrentUser = null;

        public UserMoreInfoScreen(clsUser user)
        {
            InitializeComponent();
            CurrentUser = user;
        }

        private void ctrUserCard1_Load(object sender, EventArgs e)
        {

        }

        private void UserMoreInfoScreen_Load(object sender, EventArgs e)
        {
            ctrUserCard1.LoadUserInfo(CurrentUser);
        }
    }
}
