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
    public partial class ctrPaymentCard : UserControl
    {
        public ctrPaymentCard()
        {
            InitializeComponent();
        }

        public void LoadPayment(clsPayment payment)
        {
            if (payment == null) { return; }

            lblPaymentID.Text = payment.PaymentID.ToString();
            lblPaymentDate.Text = payment.PaymentDate.ToLongDateString();
            lblPaymentMethod.Text = payment.PaymentMethod.ToString();
            lblAmountPaid.Text = payment.AmountPaid.ToString();
            lblAdditionalNotes.Text = payment.AdditionalNotes.ToString();

        }


    }
}
