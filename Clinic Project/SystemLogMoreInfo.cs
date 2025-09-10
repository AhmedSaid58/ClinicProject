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
    public partial class SystemLogMoreInfo : Form
    {
        clsSystemLog CurrentSystemLog = null;
        public SystemLogMoreInfo(clsSystemLog SystemLog)
        {
            InitializeComponent();
            CurrentSystemLog = SystemLog;
        }

        private void SystemLogMoreInfo_Load(object sender, EventArgs e)
        {
            clsUser CurrentUser = clsUser.FindUser(CurrentSystemLog.UserID);

            ctrSystemLogCard1.LoadSystemLog(CurrentSystemLog);

            if (CurrentUser != null)
                ctrUserCard1.LoadUserInfo(CurrentUser);
        }
    }
}
