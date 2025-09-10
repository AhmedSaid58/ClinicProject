using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using static ClinicDataAccessLayer.Methods;
using static ClinicDataAccessLayer.Models;

namespace ClinicBusinessLayer
{

    public class clsPerson
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

        protected clsPerson()
        {
            FirstName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gender = 'M';
            PhoneNumber = "";
            Email = "";
            Address = "";
            ImagePath = "";
        }

    }

    public class clsUser : clsPerson
    {
        public int UserID { get; private set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Permissions { get; set; }

        public clsUser(string firstName, string lastName, DateTime dateOfBirth, char gender,
            string phoneNumber, string email, string address, string imagepath,
            string userName, string password, int permissions)
        {
            // Fill inherited clsPerson Properties.
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Address = address;
            this.ImagePath = imagepath;

            // Fill clsUser Properties.
            this.UserName = userName;
            this.Password = password;
            this.Permissions = permissions;
        }

        private clsUser(int personID,string firstName, string lastName, DateTime dateOfBirth, char gender,
            string phoneNumber, string email, string address, string imagepath,
            int userID, string userName, string password, int permissions)
        {
            // Fill inherited clsPerson Properties.
            this.PersonID = personID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Address = address;
            this.ImagePath = imagepath;

            // Fill clsUser Properties.
            this.UserID = userID;
            this.UserName = userName;
            this.Password = password;
            this.Permissions = permissions;
        }

        private static string HashPassword(string password)
        {
           
            try
            {
                byte[] decoded = Convert.FromBase64String(password);
                if (decoded.Length == 32)
                {
                    return password; 
                }
            }
            catch
            {
                // Not a Base64 string, so the password is not hashed — hash it now
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public static clsUser AddNewUser(clsUser User)
        {
            clsPersonModel personModel = new clsPersonModel
                (
                    User.PersonID,
                    User.FirstName,
                    User.LastName,
                    User.DateOfBirth,
                    User.Gender,
                    User.Email,
                    User.PhoneNumber,
                    User.Address,
                    User.ImagePath
                );

            clsUserModel UserModel = new clsUserModel
                (
                    personModel,
                    User.UserID,
                    User.UserName,
                    HashPassword(User.Password),
                    User.Permissions
                );
 

            if (clsPersonMethods.AddNewPerson(UserModel) != null)
            {
                if (clsUserMethods.AddNewUser(UserModel) != null)
                    return new clsUser(UserModel.PersonID, UserModel.FirstName, UserModel.LastName, UserModel.DateOfBirth, UserModel.Gender, UserModel.PhoneNumber, UserModel.Email, UserModel.Address, UserModel.ImagePath, UserModel.UserID, UserModel.UserName, UserModel.Password, UserModel.Permissions);
            }

            return null;
        }
        public static bool DeleteUser(int UserID)
        {
            clsUserModel UserModel = clsUserMethods.FindUser(UserID);

            if (UserModel != null)
            {
                if (clsUserMethods.DeleteUser(UserModel.UserID))
                    return (clsPersonMethods.DeletePerson(UserModel.PersonID));
            }

            return false;
        }
        public static bool UpdateUser(clsUser User)
        {
            clsUserModel UserModel = clsUserMethods.FindUser(User.UserID);

            if (UserModel != null)
            {
                // Update these Data in Persons Table...
                UserModel.PersonID = User.PersonID;
                UserModel.FirstName = User.FirstName;
                UserModel.LastName = User.LastName;
                UserModel.DateOfBirth = User.DateOfBirth;
                UserModel.Gender = User.Gender;
                UserModel.Email = User.Email;
                UserModel.PhoneNumber = User.PhoneNumber;
                UserModel.Address = User.Address;
                UserModel.ImagePath = User.ImagePath;

                // Update These Date in Users Table...
                UserModel.UserName = User.UserName;
                UserModel.Password = HashPassword(User.Password);
                UserModel.Permissions = User.Permissions;

            }
            else
                return false;

            return (clsUserMethods.UpdateUser(UserModel) && clsPersonMethods.UpdatePerson(UserModel));

        }
        public static clsUser FindUser(int UserID)
        {
            clsUserModel UserModel = clsUserMethods.FindUser(UserID);

            if (UserModel != null)
            {
               
                return new clsUser
                    (UserModel.PersonID,
                     UserModel.FirstName,
                     UserModel.LastName,
                     UserModel.DateOfBirth,
                     UserModel.Gender,
                     UserModel.PhoneNumber,
                     UserModel.Email,
                     UserModel.Address,
                     UserModel.ImagePath,
                     UserModel.UserID,
                     UserModel.UserName,
                     UserModel.Password,
                     UserModel.Permissions
                     );
            }

            return null;

        }
        public static clsUser FindUser(string UserName)
        {
            clsUserModel UserModel = clsUserMethods.FindUser(UserName);

            if (UserModel != null)
            {

                return new clsUser
                     (UserModel.PersonID,
                      UserModel.FirstName,
                      UserModel.LastName,
                      UserModel.DateOfBirth,
                      UserModel.Gender,
                      UserModel.PhoneNumber,
                      UserModel.Email,
                      UserModel.Address,
                      UserModel.ImagePath,
                      UserModel.UserID,
                      UserModel.UserName,
                      UserModel.Password,
                      UserModel.Permissions
                      );
            }

            return null;

        }
        public static clsUser FindUser(string UserName, string Password)
        {
            clsUserModel UserModel = clsUserMethods.FindUser(UserName, HashPassword(Password));

            if (UserModel != null)
            {

                return new clsUser
                    (UserModel.PersonID,
                     UserModel.FirstName,
                     UserModel.LastName,
                     UserModel.DateOfBirth,
                     UserModel.Gender,
                     UserModel.PhoneNumber,
                     UserModel.Email,
                     UserModel.Address,
                     UserModel.ImagePath,
                     UserModel.UserID,
                     UserModel.UserName,
                     UserModel.Password,
                     UserModel.Permissions
                     );
            }

            return null;

        }
        public static DataTable GetAllUsers()
        {
            return (clsUserMethods.GetAllUsers());
        }

    }

    public class clsDoctor  : clsPerson
    {

        public int DoctorID { get; private set; }
        public string Specialization { get; set; }

        public clsDoctor(string firstName, string lastName, DateTime dateOfBirth, char gender,
            string phoneNumber, string email, string address, string imagepath,
            string specialization)
        {
            // Fill inherited clsPerson Properties.
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Address = address;
            this.ImagePath = imagepath;

            // Fill clsDoctor Properties.
            this.Specialization = specialization;

        }

        private clsDoctor(int personID, string firstName, string lastName, DateTime dateOfBirth, char gender,
            string phoneNumber, string email, string address, string imagepath,
            int doctorID, string specialization)
        {
            // Fill inherited clsPerson Properties.
            this.PersonID = personID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Address = address;
            this.ImagePath = imagepath;

            // Fill clsDoctor Properties.
            this.DoctorID = doctorID;
            this.Specialization = specialization;

        }

        public static clsDoctor AddNewDoctor(clsDoctor Doctor)
        {



            clsPersonModel personModel = new clsPersonModel
                (
                    Doctor.PersonID,
                    Doctor.FirstName,
                    Doctor.LastName,
                    Doctor.DateOfBirth,
                    Doctor.Gender,
                    Doctor.Email,
                    Doctor.PhoneNumber,
                    Doctor.Address,
                    Doctor.ImagePath
                );

            clsDoctorModel DoctorModel = new clsDoctorModel(personModel, Doctor.DoctorID, Doctor.Specialization);


            if (clsPersonMethods.AddNewPerson(DoctorModel) != null)
            {
                if (clsDoctorMethods.AddNewDoctor(DoctorModel) != null)
                    return new clsDoctor(DoctorModel.PersonID, DoctorModel.FirstName, DoctorModel.LastName, DoctorModel.DateOfBirth, DoctorModel.Gender, DoctorModel.PhoneNumber, DoctorModel.Email, DoctorModel.Address, DoctorModel.ImagePath, DoctorModel.DoctorID, DoctorModel.Specialization) ;
            }

            return null;

        }
        public static bool DeleteDoctor(int DoctorID)
        {
            clsDoctorModel doctorModel = clsDoctorMethods.FindDoctor(DoctorID);

            if (doctorModel != null)
            {
                if (clsDoctorMethods.DeleteDoctor(doctorModel.DoctorID))
                    return (clsPersonMethods.DeletePerson(doctorModel.PersonID));
            }

            return false;
        }
        public static clsDoctor FindDoctor(int DoctorID)
        {
            clsDoctorModel doctorModel = clsDoctorMethods.FindDoctor(DoctorID);

            if (doctorModel != null)
                return new clsDoctor
                    (
                        doctorModel.PersonID,
                        doctorModel.FirstName,
                        doctorModel.LastName,
                        doctorModel.DateOfBirth,
                        doctorModel.Gender,
                        doctorModel.PhoneNumber,
                        doctorModel.Email,
                        doctorModel.Address,
                        doctorModel.ImagePath,
                        doctorModel.DoctorID,
                        doctorModel.Specialization
                    );

            return null;

        }
        public static clsDoctor FindDoctor(string FirstName)
        {
            clsDoctorModel doctorModel = clsDoctorMethods.FindDoctor(FirstName);

            if (doctorModel != null)
                return new clsDoctor
                    (
                        doctorModel.PersonID,
                        doctorModel.FirstName,
                        doctorModel.LastName,
                        doctorModel.DateOfBirth,
                        doctorModel.Gender,
                        doctorModel.PhoneNumber,
                        doctorModel.Email,
                        doctorModel.Address,
                        doctorModel.ImagePath,
                        doctorModel.DoctorID,
                        doctorModel.Specialization
                    );

            return null;

        }
        public static bool UpdateDoctor(clsDoctor doctor)
        {
            clsDoctorModel doctorModel = clsDoctorMethods.FindDoctor(doctor.DoctorID);

            if (doctorModel != null)
            {

                // Update these Data in Persons Table...
                doctorModel.PersonID = doctor.PersonID;
                doctorModel.FirstName = doctor.FirstName;
                doctorModel.LastName = doctor.LastName;
                doctorModel.DateOfBirth = doctor.DateOfBirth;
                doctorModel.Gender = doctor.Gender;
                doctorModel.Email = doctor.Email;
                doctorModel.PhoneNumber = doctor.PhoneNumber;
                doctorModel.Address = doctor.Address;
                doctorModel.ImagePath = doctor.ImagePath;

                // Update These Date in Doctor Table...
                doctorModel.DoctorID = doctor.DoctorID;
                doctorModel.Specialization = doctor.Specialization;

            }

            return (clsDoctorMethods.UpdateDoctor(doctorModel) && clsPersonMethods.UpdatePerson(doctorModel));

        }
        public static DataTable GetAllDoctors()
        {
            return (clsDoctorMethods.GetAllDoctors());
        }

    }

    public class clsPatient: clsPerson
    {

        public int PatientID { get; private set; }

        public clsPatient(string firstName, string lastName, DateTime dateOfBirth, char gender,
           string phoneNumber, string email, string address, string imagepath)
        {
            // Fill inherited clsPerson Properties.
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Address = address;
            this.ImagePath = imagepath;

        }

        private clsPatient(int personID, string firstName, string lastName, DateTime dateOfBirth, char gender,
           string phoneNumber, string email, string address, string imagepath,
           int patientID)
        {
            // Fill inherited clsPerson Properties.
            this.PersonID = personID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Address = address;
            this.ImagePath = imagepath;

            // Fill clsPatient Properties.
            this.PatientID = patientID;

        }

        public static clsPatient AddNewPatient(clsPatient patient)
        {
            clsPersonModel personModel = new clsPersonModel
                (
                    patient.PersonID,
                    patient.FirstName,
                    patient.LastName,
                    patient.DateOfBirth,
                    patient.Gender,
                    patient.Email,
                    patient.PhoneNumber,
                    patient.Address,
                    patient.ImagePath
                );

            clsPatientModel patientModel = new clsPatientModel(personModel, patient.PatientID);

            if (clsPersonMethods.AddNewPerson(patientModel) != null)
            {
                if (clsPatientMethods.AddNewPatient(patientModel) != null)
                    return (new clsPatient(patientModel.PersonID, patientModel.FirstName, patientModel.LastName, patientModel.DateOfBirth, patientModel.Gender, patientModel.PhoneNumber, patientModel.Email, patientModel.Address, patientModel.ImagePath, patientModel.PatientID));
            }

            return null;
        }

        public static bool DeletePatient(int PatientID)
        {
            clsPatientModel patientModel = clsPatientMethods.FindPatient(PatientID);

            if (patientModel != null)
            {
                if (clsPatientMethods.DeletePatient(PatientID))
                    return (clsPersonMethods.DeletePerson(patientModel.PersonID));
            }

            return false;
        }

        public static bool UpdatePatient(clsPatient patient)
        {
            clsPatientModel PatientModel = clsPatientMethods.FindPatient(patient.PatientID);

            if (PatientModel != null)
            {

                // Update these Data in Persons Table...
                PatientModel.PersonID = patient.PersonID;
                PatientModel.FirstName = patient.FirstName;
                PatientModel.LastName = patient.LastName;
                PatientModel.DateOfBirth = patient.DateOfBirth;
                PatientModel.Gender = patient.Gender;
                PatientModel.Email = patient.Email;
                PatientModel.PhoneNumber = patient.PhoneNumber;
                PatientModel.Address = patient.Address;
                PatientModel.ImagePath = patient.ImagePath;

            }

            return (clsPersonMethods.UpdatePerson(PatientModel));

        }

        public static clsPatient FindPatient(int PatientID)
        {
            clsPatientModel patientModel = clsPatientMethods.FindPatient(PatientID);

            if (patientModel != null)
                return new clsPatient
                    (
                        patientModel.PersonID,
                        patientModel.FirstName,
                        patientModel.LastName,
                        patientModel.DateOfBirth,
                        patientModel.Gender,
                        patientModel.PhoneNumber,
                        patientModel.Email,
                        patientModel.Address,
                        patientModel.ImagePath,
                        patientModel.PatientID
                    );

            return null;

        }

        public static clsPatient FindPatient(string FirstName)
        {
            clsPatientModel patientModel = clsPatientMethods.FindPatient(FirstName);

            if (patientModel != null)
                return new clsPatient
                    (
                        patientModel.PersonID,
                        patientModel.FirstName,
                        patientModel.LastName,
                        patientModel.DateOfBirth,
                        patientModel.Gender,
                        patientModel.PhoneNumber,
                        patientModel.Email,
                        patientModel.Address,
                        patientModel.ImagePath,
                        patientModel.PatientID
                    );

            return null;

        }

        public static DataTable GetAllPatients()
        {
            return (clsPatientMethods.GetAllPatients());
        }


    }

    public class clsMedicalRecord
    {

        public int MedicalRecordID { get; private set; }
        public int PrescriptionsID { get; set; }
        public string VisitDescription { get; set; }
        public string Diagnosis { get; set; }
        public string AdditionalNotes { get; set; }

        public clsMedicalRecord(int prescriptionsID, string visitDescription, string diagnosis, string additionalNotes)
        {
            PrescriptionsID = prescriptionsID;
            VisitDescription = visitDescription;
            Diagnosis = diagnosis;
            AdditionalNotes = additionalNotes;
        }

        private clsMedicalRecord(int medicalRecordID, int prescriptionsID, string visitDescription, string diagnosis, string additionalNotes)
        {
            MedicalRecordID = medicalRecordID;
            PrescriptionsID = prescriptionsID;
            VisitDescription = visitDescription;
            Diagnosis = diagnosis;
            AdditionalNotes = additionalNotes;
        }

        public static clsMedicalRecord AddNewMedicalRecord(clsMedicalRecord medicalRecord)
        {
            clsMedicalRecordModel MedicalRecord = new clsMedicalRecordModel();

            MedicalRecord.PrescriptionID = medicalRecord.PrescriptionsID;
            MedicalRecord.VisitDescription = medicalRecord.VisitDescription;
            MedicalRecord.Diagnosis = medicalRecord.Diagnosis;
            MedicalRecord.AdditionalNotes = medicalRecord.AdditionalNotes;

            MedicalRecord = clsMedicalRecordMethods.AddNewMedicalRecord(MedicalRecord);

            if (MedicalRecord != null)
                return new clsMedicalRecord(MedicalRecord.MedicalRecordID, MedicalRecord.PrescriptionID,  MedicalRecord.VisitDescription, MedicalRecord.Diagnosis, MedicalRecord.AdditionalNotes);
            else
                return null;
        }

        public static clsMedicalRecord FindMedicalRecord(int MedicalRecord)
        {
            if (MedicalRecord == -1)
                return null;
                
            clsMedicalRecordModel medicalRecordModel
                = clsMedicalRecordMethods.FindMedicalRecord(MedicalRecord);

            if (medicalRecordModel != null)
            {
                return new clsMedicalRecord
                    (
                        medicalRecordModel.MedicalRecordID,
                        medicalRecordModel.PrescriptionID,
                        medicalRecordModel.VisitDescription,
                        medicalRecordModel.Diagnosis,
                        medicalRecordModel.AdditionalNotes
                    );
            }

            return null;

        }

        public static bool DeleteMedicalRecord(int MedicalRecordID)
        {
            clsMedicalRecordModel medicalRecordModel =
                clsMedicalRecordMethods.FindMedicalRecord(MedicalRecordID);

            if (medicalRecordModel != null)
            {
                return (clsMedicalRecordMethods.DeleteMedicalRecord(MedicalRecordID));
            }

            return false;
        }

        public static bool UpdateMedicalRecord(clsMedicalRecord medicalRecord)
        {
            clsMedicalRecordModel MedicalRecordModel =
                clsMedicalRecordMethods.FindMedicalRecord(medicalRecord.MedicalRecordID);

            if (MedicalRecordModel != null)
            {
                MedicalRecordModel.PrescriptionID = medicalRecord.PrescriptionsID;
                MedicalRecordModel.VisitDescription = medicalRecord.VisitDescription;
                MedicalRecordModel.Diagnosis = medicalRecord.Diagnosis;
                MedicalRecordModel.AdditionalNotes = medicalRecord.AdditionalNotes;
            }
            else
                return false;

            return (clsMedicalRecordMethods.UpdateMedicalRecord(MedicalRecordModel));

        }

        public static DataTable GetAllMedicalRecords()
        {
            return (clsMedicalRecordMethods.GetAllMedicalRecords());
        }


    }

    public class clsPayment
    {
        public int PaymentID { get;  private set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public double AmountPaid { get; set; }
        public string AdditionalNotes { get; set; }

        public clsPayment(DateTime paymentDate, string paymentMethod, double amountPaid, string additionalNotes)
        {
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
            AmountPaid = amountPaid;
            AdditionalNotes = additionalNotes;
        }
        private clsPayment(int paymentID, DateTime paymentDate, string paymentMethod, double amountPaid, string additionalNotes)
        {
            PaymentID = paymentID;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
            AmountPaid = amountPaid;
            AdditionalNotes = additionalNotes;
        }

        public static clsPayment AddNewPayment(clsPayment payment)
        {
            clsPaymentModel paymentModel = new clsPaymentModel();

            paymentModel.PaymentDate = payment.PaymentDate;
            paymentModel.PaymentMethod = payment.PaymentMethod;
            paymentModel.AmountPaid = payment.AmountPaid;
            paymentModel.AdditionalNotes = payment.AdditionalNotes;

            if (clsPaymentMethods.AddNewPayment(paymentModel) != null)
                return new clsPayment(paymentModel.PaymentID, paymentModel.PaymentDate, paymentModel.PaymentMethod, paymentModel.AmountPaid, paymentModel.AdditionalNotes);

            return null;

        }
        public static clsPayment FindPayment(int PaymentID)
        {
            if (PaymentID == -1)
                return null;

            clsPaymentModel paymentModel = clsPaymentMethods.FindPayment(PaymentID);

            if (paymentModel != null)
            {

                return new clsPayment
                    (
                        paymentModel.PaymentID,
                        paymentModel.PaymentDate,
                        paymentModel.PaymentMethod,
                        paymentModel.AmountPaid,
                        paymentModel.AdditionalNotes
                    );
            }

            return null;
        }
        public static bool DeletePayment(int PaymentID)
        {
            clsPaymentModel paymentModel = clsPaymentMethods.FindPayment(PaymentID);

            if (paymentModel != null )
            {
                return (clsPaymentMethods.DeletePayment(PaymentID));
            }

            return false;

        }
        public static bool UpdatePayment(clsPayment payment)
        {
            clsPaymentModel paymentModel = clsPaymentMethods.FindPayment(payment.PaymentID);

            if (paymentModel != null)
            {
                paymentModel.PaymentDate = payment.PaymentDate;
                paymentModel.PaymentMethod = payment.PaymentMethod;
                paymentModel.AmountPaid = payment.AmountPaid;
                paymentModel.AdditionalNotes = payment.AdditionalNotes;
            }

            return (clsPaymentMethods.UpdatePayment(paymentModel));

        }
        public static DataTable GetAllPayments()
        {
            return (clsPaymentMethods.GetAllPayments());
        }

    }

    public class clsPrescription
    {
        public int PrescriptionID { get; private set; }
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SpecialInstructions { get; set; }

        public clsPrescription(string medicationName,
            string dosage, string frequency, DateTime startDate, DateTime endDate, string specialInstructions)
        {
            MedicationName = medicationName;
            Dosage = dosage;
            Frequency = frequency;
            StartDate = startDate;
            EndDate = endDate;
            SpecialInstructions = specialInstructions;

        }
        private clsPrescription(int prescriptionID,string medicationName,
            string dosage, string frequency, DateTime startDate, DateTime endDate, string specialInstructions)
        {
            PrescriptionID = prescriptionID;
            MedicationName = medicationName;
            Dosage = dosage;
            Frequency = frequency;
            StartDate = startDate;
            EndDate = endDate;
            SpecialInstructions = specialInstructions;

        }


        public static clsPrescription AddNewPrescription(clsPrescription prescription)
        {
            clsPrescriptionModel prescriptionModel = new clsPrescriptionModel();

            prescriptionModel.MedicationName = prescription.MedicationName;
            prescriptionModel.Dosage = prescription.Dosage;
            prescriptionModel.Frequency = prescription.Frequency;
            prescriptionModel.StartDate = prescription.StartDate;
            prescriptionModel.EndDate = prescription.EndDate;
            prescriptionModel.SpecialInstructions = prescription.SpecialInstructions;

            if (clsPrescriptionMethods.AddNewPrescription(prescriptionModel) != null)
                return (new clsPrescription(prescriptionModel.PrescriptionID, prescriptionModel.MedicationName, prescriptionModel.Dosage, prescriptionModel.Frequency, prescriptionModel.StartDate, prescriptionModel.EndDate, prescriptionModel.SpecialInstructions));

            return null;

        }

        public static clsPrescription FindPrescription(int PrescriptionID)
        {
            clsPrescriptionModel prescription = clsPrescriptionMethods.FindPrescription(PrescriptionID);

            if (prescription != null)
            {

                return new clsPrescription
                    (
                        prescription.PrescriptionID,
                        prescription.MedicationName,
                        prescription.Dosage,
                        prescription.Frequency,
                        prescription.StartDate,
                        prescription.EndDate,
                        prescription.SpecialInstructions

                    );

            }

            return null;
        }

        public static bool DeletePrescription(int PrescriptionID)
        {
            clsPrescriptionModel prescriptionModel = clsPrescriptionMethods.FindPrescription(PrescriptionID);

            if (prescriptionModel != null)
            {
                return (clsPrescriptionMethods.DeletePrescription(PrescriptionID));
            }

            return false;

        }
       
        public static bool UpdatePrescription(clsPrescription prescription)
        {
            clsPrescriptionModel prescriptionModel = clsPrescriptionMethods.FindPrescription(prescription.PrescriptionID);

            if (prescriptionModel != null)
            {
                prescriptionModel.MedicationName = prescription.MedicationName;
                prescriptionModel.Dosage = prescription.Dosage;
                prescriptionModel.Frequency = prescription.Frequency;
                prescriptionModel.StartDate = prescription.StartDate;
                prescriptionModel.EndDate = prescription.EndDate;
                prescriptionModel.SpecialInstructions = prescription.SpecialInstructions;
            }

            return (clsPrescriptionMethods.UpdatePrescription(prescriptionModel));

        }

        public static DataTable GetAllPrescriptions()
        {
            return (clsPrescriptionMethods.GetAllPrescriptions());
        }

    }

    public class clsAppointment
    {
        public int AppointmentID { get; private set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public byte AppointmentStatus { get; set; }
        public int MedicalRecordID { get; set; }
        public int PaymentID { get; set; }

        public clsAppointment(int patientID, int doctorID,
           DateTime appointmentDateTime, byte appointmentStatus, int medicalRecordID, int paymentID)
        {
            PatientID = patientID;
            DoctorID = doctorID;
            AppointmentDateTime = appointmentDateTime;
            AppointmentStatus = appointmentStatus;
            MedicalRecordID = medicalRecordID;
            PaymentID = paymentID;
        }
        private clsAppointment(int appointmentID, int patientID, int doctorID,
            DateTime appointmentDateTime, byte appointmentStatus, int medicalRecordID, int paymentID)
        {
            AppointmentID = appointmentID;
            PatientID = patientID;
            DoctorID = doctorID;
            AppointmentDateTime = appointmentDateTime;
            AppointmentStatus = appointmentStatus;
            MedicalRecordID = medicalRecordID;
            PaymentID = paymentID;
        }


        public static clsAppointment AddNewAppointment(clsAppointment Appointment)
        {

            clsAppointmentModel appointmentModel = new clsAppointmentModel();

            appointmentModel.PatientID = Appointment.PatientID;
            appointmentModel.DoctorID = Appointment.DoctorID;
            appointmentModel.AppointmentDateTime = Appointment.AppointmentDateTime;
            appointmentModel.AppointmentStatus = Appointment.AppointmentStatus;
            appointmentModel.MedicalRecordID = Appointment.MedicalRecordID;
            appointmentModel.PaymentID = Appointment.PaymentID;

            if (clsAppointmentMethods.AddNewAppointment(appointmentModel) != null)
                return (new clsAppointment(appointmentModel.AppointmentID, appointmentModel.PatientID, appointmentModel.DoctorID, appointmentModel.AppointmentDateTime, appointmentModel.AppointmentStatus, appointmentModel.MedicalRecordID, appointmentModel.PaymentID));

            return null;
        }

        public static clsAppointment FindAppointment(int AppointmentID)
        {

            clsAppointmentModel appointmentModel = clsAppointmentMethods.FindAppointment(AppointmentID);

            if (appointmentModel != null)
            {
                return new clsAppointment
                    (
                        appointmentModel.AppointmentID,
                        appointmentModel.PatientID,
                        appointmentModel.DoctorID,
                        appointmentModel.AppointmentDateTime,
                        appointmentModel.AppointmentStatus,
                        appointmentModel.MedicalRecordID,
                        appointmentModel.PaymentID
                    );
            }

            return null;

        }

        public static bool DeleteAppointment(int AppointmentID)
        {
            if (clsAppointmentMethods.FindAppointment(AppointmentID)!= null)
            {
                return (clsAppointmentMethods.DeleteAppointment(AppointmentID));
            }

            return false;

        }

        public static bool UpdateAppointment(clsAppointment appointment)
        {
            clsAppointmentModel appointmentModel = clsAppointmentMethods.FindAppointment(appointment.AppointmentID);

            if (appointmentModel != null)
            {
                appointmentModel.PatientID = appointment.PatientID;
                appointmentModel.DoctorID = appointment.DoctorID;
                appointmentModel.AppointmentDateTime = appointment.AppointmentDateTime;
                appointmentModel.AppointmentStatus = appointment.AppointmentStatus;
                appointmentModel.MedicalRecordID = appointment.MedicalRecordID;
                appointmentModel.PaymentID = appointment.PaymentID;

                return (clsAppointmentMethods.UpdateAppointment(appointmentModel));
            }

            return false;

        }
        public static DataTable GetAllAppointments()
        {
            return (clsAppointmentMethods.GetAllAppointments());
        }

        public static DataTable GetAppointmentsByStatus(int Status)
        {
            return clsAppointmentMethods.GetAppointmentsByStatus(Status);
        }

        public static bool UpdateNoShowAppointments()
        {
            return clsAppointmentMethods.UpdateNoShowAppointments();
        }

    }

    public class clsSystemLog
    {
        public int LogID { get; private set; }
        public int UserID { get; set; }
        public string OperationType { get; set; }
        public DateTime DateTime { get; set; }
        public string Details { get; set; }

        public clsSystemLog(int UserID, string OperationType, DateTime DateTime, string Details)
        {
            this.UserID = UserID;
            this.OperationType = OperationType;
            this.DateTime = DateTime;
            this.Details = Details;
        }

        private clsSystemLog(int LogID, int UserID, string OperationType, DateTime DateTime, string Details)
        {
            this.LogID = LogID;
            this.UserID = UserID;
            this.OperationType = OperationType;
            this.DateTime = DateTime;
            this.Details = Details;
        }

        public static bool AddNewSystemLog(clsSystemLog Systemlog)
        {
            clsSystemLogModel SystemlogModel = new clsSystemLogModel();

            SystemlogModel.UserID = Systemlog.UserID;
            SystemlogModel.OperationType = Systemlog.OperationType;
            SystemlogModel.DateTime = Systemlog.DateTime;
            SystemlogModel.Details = Systemlog.Details;

            return (clsSystemLogMethods.AddNewLog(SystemlogModel));

        }

        public static clsSystemLog FindSystemLog(int SystemLogID)
        {
            clsSystemLogModel SystemLogModel = clsSystemLogMethods.FindSystemLog(SystemLogID); 

            if (SystemLogModel != null)
            {
                return new clsSystemLog
                    (
                        SystemLogModel.LogID,
                        SystemLogModel.UserID,
                        SystemLogModel.OperationType,
                        SystemLogModel.DateTime,
                        SystemLogModel.Details
                    );
            }

            return null;

        }

        public static DataTable FindSystemLogsByUserID(int UserID)
        {
            return clsSystemLogMethods.FindSystemLogsByUserID(UserID);
        }

        public static bool DeleteSystemLog(int SystemLogID)
        {
            clsSystemLogModel SystemlogModel = clsSystemLogMethods.FindSystemLog(SystemLogID);

            if (SystemlogModel != null)
            {
                return (clsSystemLogMethods.DeleteLog(SystemLogID));
            }

            return false;

        }

        public static bool UpdateSystemLog(clsSystemLog Systemlog)
        {
            clsSystemLogModel SystemlogModel = clsSystemLogMethods.FindSystemLog(Systemlog.LogID);

            if (SystemlogModel != null)
            {
                SystemlogModel.UserID = Systemlog.UserID;
                SystemlogModel.OperationType = Systemlog.OperationType;
                SystemlogModel.DateTime = Systemlog.DateTime;
                SystemlogModel.Details = Systemlog.Details;

                return (clsSystemLogMethods.UpdateLog(SystemlogModel));

            }

            return false;

        }

        public static DataTable GetAllSystemLogs()
        {
            return (clsSystemLogMethods.GetAllLogs());
        }

        public static bool ClearSystemLogs()
        {
            return clsSystemLogMethods.ClearSystemLogs();
        }

    }

}