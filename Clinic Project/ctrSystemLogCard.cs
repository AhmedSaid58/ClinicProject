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
    public partial class ctrSystemLogCard : UserControl
    {
        public ctrSystemLogCard()
        {
            InitializeComponent();
        }

        public void LoadSystemLog(clsSystemLog CurrentSystemLog)
        {
            lblSystemLogID.Text = CurrentSystemLog.LogID.ToString();
            lblUserID.Text = CurrentSystemLog.UserID.ToString();
            lblOperationType.Text = CurrentSystemLog.OperationType.ToString();
            lblSystemLogDateTime.Text = CurrentSystemLog.DateTime.ToString();
            rtbDetails.Text = CurrentSystemLog.Details.ToString();
        }

        private void ctrSystemLogCard_Load(object sender, EventArgs e)
        {

        }
    }
}
