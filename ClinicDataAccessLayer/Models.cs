using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDataAccessLayer
{
    public class Models
    {
        public class clsPersonModel
        {
            public int PersonID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public char Gender { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string ImagePath { get; set; }

            public clsPersonModel()
            {
            }

            public clsPersonModel(int personID, string firstName, string lastName, DateTime dateOfBirth, char gender, string email, string phoneNumber, string address, string imagePath)
            {
                this.PersonID = personID;
                this.FirstName = firstName;
                this.LastName = lastName;
                this.DateOfBirth = dateOfBirth;
                this.Gender = gender;
                this.Email = email;
                this.PhoneNumber = phoneNumber;
                this.Address = address;
                this.ImagePath = imagePath;
            }

        }

        public class clsPatientModel : clsPersonModel
        {
            public int PatientID { get; set; }

            public clsPatientModel()
            {
            }

            public clsPatientModel(clsPersonModel personModel, int patientID)
            {
                base.FirstName = personModel.FirstName;
                base.LastName = personModel.LastName;
                base.DateOfBirth = personModel.DateOfBirth;
                base.Gender = personModel.Gender;
                base.PhoneNumber = personModel.PhoneNumber;
                base.Email = personModel.Email;
                base.Address = personModel.Address;
                base.ImagePath = personModel.ImagePath;
                this.PatientID = patientID;
            }

        }

        public class clsDoctorModel : clsPersonModel
        {
            public int DoctorID { get; set; }
            public string Specialization { get; set; }

            public clsDoctorModel()
            {
            }

            public clsDoctorModel(clsPersonModel personModel, int doctorID, string specialization)
            {
                base.FirstName = personModel.FirstName;
                base.LastName = personModel.LastName;
                base.DateOfBirth = personModel.DateOfBirth;
                base.Gender = personModel.Gender;
                base.PhoneNumber = personModel.PhoneNumber;
                base.Email = personModel.Email;
                base.Address = personModel.Address;
                base.ImagePath = personModel.ImagePath;
                this.DoctorID = doctorID;
                this.Specialization = specialization;
            }

        }

        public class clsUserModel : clsPersonModel
        {
            public int UserID { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public int Permissions { get; set; }

            public clsUserModel()
            {
            }

            public clsUserModel(clsPersonModel personModel, int userID, string userName, string password, int permissions)
            {
                base.FirstName = personModel.FirstName;
                base.LastName = personModel.LastName;
                base.DateOfBirth = personModel.DateOfBirth;
                base.Gender = personModel.Gender;
                base.PhoneNumber = personModel.PhoneNumber;
                base.Email = personModel.Email;
                base.Address = personModel.Address;
                base.ImagePath = personModel.ImagePath;
                this.UserID = userID;
                this.UserName = userName;
                this.Password = password;
                this.Permissions = permissions;
            }

        }

        public class clsAppointmentModel
        {
            public int AppointmentID { get; set; }
            public int PatientID { get; set; }
            public int DoctorID { get; set; }
            public DateTime AppointmentDateTime { get; set; }
            public byte AppointmentStatus { get; set; }
            public int MedicalRecordID { get; set; }
            public int PaymentID { get; set; }

            public clsAppointmentModel()
            {
            }

            public clsAppointmentModel(int appointmentID, int patientID, int doctorID, DateTime appointmentDateTime, byte appointmentStatus, int medicalRecordID, int paymentID)
            {
                this.AppointmentID = appointmentID;
                this.PatientID = patientID;
                this.DoctorID = doctorID;
                this.AppointmentDateTime = appointmentDateTime;
                this.MedicalRecordID = medicalRecordID;
                this.PaymentID = paymentID;
            }

        }

        public class clsPrescriptionModel
        {      
            public int PrescriptionID { get; set; }
            public string MedicationName { get; set; }
            public string Dosage { get; set; }
            public string Frequency { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string SpecialInstructions { get; set; }

            public clsPrescriptionModel()
            {
            }

            public clsPrescriptionModel(int prescriptionID,string medicationName, string dosage, string frequency, DateTime startDate, DateTime endDate, string specialInstructions)
            {
                this.PrescriptionID = prescriptionID;
                this.MedicationName = medicationName;
                this.Dosage = dosage;
                this.Frequency = frequency;
                this.StartDate = startDate;
                this.EndDate = endDate;
                this.SpecialInstructions = specialInstructions;
            }

        }

        public class clsMedicalRecordModel
        {
            public int MedicalRecordID { get; set; }
            public int PrescriptionID { get; set; }
            public string VisitDescription { get; set; }
            public string Diagnosis { get; set; }
            public string AdditionalNotes { get; set; }
            public clsMedicalRecordModel()
            {
            }

            public clsMedicalRecordModel(int medicalRecordID, int prescriptions, string visitDescription, string diagnosis, string additionalNotes)
            {
                this.MedicalRecordID = medicalRecordID;
                this.PrescriptionID = prescriptions;
                this.VisitDescription = visitDescription;
                this.Diagnosis = diagnosis;
                this.AdditionalNotes = additionalNotes;
            }

        }

        public class clsPaymentModel
        {
            public int PaymentID { get; set; }
            public DateTime PaymentDate { get; set; }
            public string PaymentMethod { get; set; }
            public double AmountPaid { get; set; }
            public string AdditionalNotes { get; set; }

            public clsPaymentModel()
            {
            }

            public clsPaymentModel(int paymentID, DateTime paymentDate, string paymentMethod, double amountPaid, string additionalNotes)
            {
                this.PaymentID = paymentID;
                this.PaymentDate = paymentDate;
                this.PaymentMethod = paymentMethod;
                this.AmountPaid = amountPaid;
                this.AdditionalNotes = additionalNotes;
            }

        }

        public class clsSystemLogModel
        {
            public int LogID { get; set; }
            public int UserID { get; set; }
            public string OperationType { get; set; }
            public DateTime DateTime { get; set; }
            public string Details { get; set; }

            public clsSystemLogModel()
            {
            }

            public clsSystemLogModel(int logID, int userID, string OperationType, DateTime LogDateTime, string details)
            {
                this.LogID = logID;
                this.UserID = userID;
                this.OperationType = OperationType;
                this.DateTime = LogDateTime;
                this.Details = details;
            }

        }


    }

}
