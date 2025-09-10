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
    public partial class ConfirmAppointmentScreen : Form
    {
        clsAppointment CurrentAppointment = null;
        clsUser CurrentUser = null;
        public ConfirmAppointmentScreen(clsAppointment appointment, clsUser user)
        {
            InitializeComponent();
            CurrentAppointment = appointment;
            CurrentUser = user;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmAppointmentScreen_Load(object sender, EventArgs e)
        {

        }

        private void btnAddNewPayment_Click(object sender, EventArgs e)
        {
            clsPayment payment = new clsPayment
                (
                    DateTime.Now,
                    tbPaymentMethod.Text,
                    Convert.ToDouble(tbAmountPaid.Text),
                    tbAdditionalNotes.Text
                );

            payment = clsPayment.AddNewPayment(payment);

            if ( payment != null)
            {
                CurrentAppointment.PaymentID = payment.PaymentID;
                CurrentAppointment.AppointmentStatus = 1;

                if (!clsAppointment.UpdateAppointment(CurrentAppointment))
                    MessageBox.Show("Error, While Confirm the Appointment!!!");
                else
                {
                    MessageBox.Show("Confirm The Appointment Successfuly..");

                    clsSystemLog systemLog = new clsSystemLog
                        (
                            CurrentUser.UserID,
                            "Confirm Appointment",
                            DateTime.Now,
                            $"Added New Payment With PaymentID {payment.PaymentID} For Appointment Whith AppointmentID {CurrentAppointment.AppointmentID}," +
                            $"By User With UserID {CurrentUser.UserID}, in {DateTime.Now}"

                        );

                    if (!clsSystemLog.AddNewSystemLog(systemLog))
                        MessageBox.Show("Error, While Saving System Log!!!!!");

                }

            }
            else
                MessageBox.Show("Error, While Adding New Payment..."); 

            this.Close();

        }

    }
}
