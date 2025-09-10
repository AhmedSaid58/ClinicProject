using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;
using static ClinicDataAccessLayer.Models;

namespace ClinicDataAccessLayer
{
     public class Methods
     {

        public class clsPersonMethods
        {
            public static clsPersonModel AddNewPerson(clsPersonModel PersonModel)
            {
                clsPersonModel person = new clsPersonModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Insert into Persons Values \r\n(@FirstName,@LastName, @DateOfBirth, @Gender,@PhoneNumber,@Email,@Address,@ImagePath)\r\nSELECT SCOPE_IDENTITY();";
                
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                
                sqlCommand.Parameters.AddWithValue("@FirstName", PersonModel.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", PersonModel.LastName);
                sqlCommand.Parameters.AddWithValue("@DateOfBirth", PersonModel.DateOfBirth);
                sqlCommand.Parameters.AddWithValue("@Gender", PersonModel.Gender);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", PersonModel.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Email", PersonModel.Email);
                sqlCommand.Parameters.AddWithValue("@Address", PersonModel.Address);
                
                if (PersonModel.ImagePath != null)
                    sqlCommand.Parameters.AddWithValue("@ImagePath", PersonModel.ImagePath);
                else
                    sqlCommand.Parameters.AddWithValue("@ImagePath", DBNull.Value);

                try
                {
                    sqlConnection.Open();

                    object Result = sqlCommand.ExecuteScalar();
  
                    if (Result != null)
                    {
                        person = PersonModel;
                        PersonModel.PersonID = Convert.ToInt32(Result);
                    }
                    else
                        person = null;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding a new Person: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }
                return person;
            }

            public static clsPersonModel FindPerson(int PersonID)
            {

                clsPersonModel PersonModel = new  clsPersonModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select * From Persons where Persons.PersonID = @PersonID";
             
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                
                sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
                
                try
                {
                    sqlConnection.Open();
                    
                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    if (Reader.Read())
                    {
                        PersonModel.PersonID = Convert.ToInt32(Reader["PersonID"]);
                        PersonModel.FirstName = Convert.ToString(Reader["FirstName"]);
                        PersonModel.LastName = Convert.ToString(Reader["LastName"]);
                        PersonModel.DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                        PersonModel.Gender = Convert.ToChar(Reader["Gender"]);
                        PersonModel.PhoneNumber = Convert.ToString(Reader["PhoneNumber"]);
                        PersonModel.Email = Convert.ToString(Reader["Email"]);
                        PersonModel.Address = Convert.ToString(Reader["Address"]);

                        if (Reader["imagePath"] != DBNull.Value)
                            PersonModel.ImagePath = Convert.ToString(Reader["ImagePath"]);
                        else
                            PersonModel.ImagePath = null;

                    }
                    else
                        PersonModel = null;

                    Reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Finding a Person: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return PersonModel;

            }

            public static bool UpdatePerson(clsPersonModel PersonModel)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Update Persons Set FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, Gender = @Gender, PhoneNumber = @PhoneNumber, Email = @Email, Address = @Address, ImagePath = @ImagePath\r\nwhere PersonID = @PersonID ";
                
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@FirstName", PersonModel.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", PersonModel.LastName);
                sqlCommand.Parameters.AddWithValue("@DateOfBirth", PersonModel.DateOfBirth);
                sqlCommand.Parameters.AddWithValue("@Gender", PersonModel.Gender);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", PersonModel.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Email", PersonModel.Email);
                sqlCommand.Parameters.AddWithValue("@Address", PersonModel.Address);
                sqlCommand.Parameters.AddWithValue("@PersonID", PersonModel.PersonID);

                if (PersonModel.ImagePath != null)
                    sqlCommand.Parameters.AddWithValue("@ImagePath", PersonModel.ImagePath);
                else
                    sqlCommand.Parameters.AddWithValue("@ImagePath", DBNull.Value);


                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Update a Person: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

            public static bool DeletePerson(int PersonID)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Delete From Persons Where PersonID = @PersonID";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Deleting a Person: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

        }

        public class clsPatientMethods
        {
            public static clsPatientModel AddNewPatient(clsPatientModel patientModel)
            {
                clsPatientModel patient = new clsPatientModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Insert into Patients (PersonID) Values (@PersonID)\r\nSELECT SCOPE_IDENTITY();";
                
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@PersonID", patientModel.PersonID);
               
                try
                {
                    sqlConnection.Open();
                   
                    object Result = sqlCommand.ExecuteScalar();

                    if (Result != null)
                    {
                        patient = patientModel;
                        patient.PatientID = Convert.ToInt32(Result);
                    }
                    else
                        patient = null;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding a new Patient: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return patient;

            }

            public static bool DeletePatient(int PatientID)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Delete From Patients Where PatientID = @PatientID";
                
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                
                sqlCommand.Parameters.AddWithValue("@PatientID", PatientID);
                
                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Deleting a Patient: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

            public static clsPatientModel FindPatient(int PatientID)
            {
                clsPatientModel PatientModel = new clsPatientModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select Patients.*, Persons.* \r\nFrom Patients Inner join Persons\r\nOn Persons.PersonID = Patients.PersonID\r\nWhere Patients.PatientID = @PatientID";
                
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@PatientID", PatientID);
                
                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    if (Reader.Read())
                    {
                        PatientModel.PatientID = (int)Convert.ToInt16(Reader["PatientID"]);
                        PatientModel.PersonID = (int)Convert.ToInt16(Reader["PersonID"]);
                        PatientModel.PersonID = (int)Convert.ToInt16(Reader["PersonID"]);
                        PatientModel.FirstName = Convert.ToString(Reader["FirstName"]);
                        PatientModel.LastName = Convert.ToString(Reader["LastName"]);
                        PatientModel.DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                        PatientModel.Gender = Convert.ToChar(Reader["Gender"]);
                        PatientModel.PhoneNumber = Convert.ToString(Reader["PhoneNumber"]);
                        PatientModel.Email = Convert.ToString(Reader["Email"]);
                        PatientModel.Address = Convert.ToString(Reader["Address"]);
                        PatientModel.ImagePath = Convert.ToString(Reader["ImagePath"]);
                    }
                    else
                        PatientModel = null;

                    Reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Finding a patient: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return PatientModel;

            }

            public static clsPatientModel FindPatient(string FirstName)
            {
                clsPatientModel clsPatientModel = new clsPatientModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select Patients.*, Persons.* \r\nFrom Patients Inner join Persons\r\nOn Persons.PersonID = Patients.PersonID\r\nWhere Patients.FirstName = @FirstName";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@FirstName", FirstName);
                
                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    if (Reader.Read())
                    {
                        clsPatientModel.PatientID = (int)Convert.ToInt16(Reader["PatientID"]);
                        clsPatientModel.PersonID = (int)Convert.ToInt16(Reader["PersonID"]);
                        clsPatientModel.PersonID = (int)Convert.ToInt16(Reader["PersonID"]);
                        clsPatientModel.FirstName = Convert.ToString(Reader["FirstName"]);
                        clsPatientModel.LastName = Convert.ToString(Reader["LastName"]);
                        clsPatientModel.DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                        clsPatientModel.Gender = Convert.ToChar(Reader["Gender"]);
                        clsPatientModel.PhoneNumber = Convert.ToString(Reader["PhoneNumber"]);
                        clsPatientModel.Email = Convert.ToString(Reader["Email"]);
                        clsPatientModel.Address = Convert.ToString(Reader["Address"]);
                        clsPatientModel.ImagePath = Convert.ToString(Reader["ImagePath"]);
                    }
                    else
                        clsPatientModel = null;

                    Reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Finding a patient: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return clsPatientModel;

            }

            public static DataTable GetAllPatients()
            {
                DataTable dataTable = new DataTable();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select Patients.PatientID, Persons.FirstName ,\r\nPersons.LastName, Persons.DateOfBirth, Persons.Gender, Persons.PhoneNumber,\r\nPersons.Email, Persons.Address\r\nFrom Patients Inner join Persons\r\nOn Persons.PersonID = Patients.PersonID";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                
                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    dataTable.Load(Reader);
                    Reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while Get All Patients " + ex.Message);
                    dataTable = null;
                }
                finally
                {
                    sqlConnection.Close();
                }

                return dataTable;

            }
        }

        public class clsDoctorMethods
        {

            public static clsDoctorModel AddNewDoctor(clsDoctorModel doctorModel)
            {
                clsDoctorModel Doctor = new clsDoctorModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string text = "Insert into Doctors (PersonID, Specialization) Values (@PersonID, @Specialization)\r\nSELECT SCOPE_IDENTITY();";

                SqlCommand sqlCommand = new SqlCommand(text, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@PersonID", doctorModel.PersonID);
                sqlCommand.Parameters.AddWithValue("@Specialization", doctorModel.Specialization);

                try
                {
                    sqlConnection.Open();
                    
                    object Result = sqlCommand.ExecuteScalar();

                    if (Result != null)
                    {
                        Doctor = doctorModel;
                        Doctor.DoctorID = Convert.ToInt32(Result);
                    }
                    else
                        Doctor = null;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding a new Doctor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return Doctor;

            }

            public static bool DeleteDoctor(int DoctorID)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string text = "Delete From Doctors Where DoctorID = @DoctorID";

                SqlCommand sqlCommand = new SqlCommand(text, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@DoctorID", DoctorID);

                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Deleting a Doctor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

            public static bool UpdateDoctor(clsDoctorModel doctorModel)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string text = "Update Doctors Set Specialization = @Specialization where DoctorID = @DoctorID ";

                SqlCommand sqlCommand = new SqlCommand(text, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@DoctorID", doctorModel.DoctorID);
                sqlCommand.Parameters.AddWithValue("@Specialization", doctorModel.Specialization);

                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Update a Doctor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

            public static clsDoctorModel FindDoctor(int DoctorID)
            {
                clsDoctorModel DoctorModel = new clsDoctorModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string text = "Select Doctors.*, Persons.* From Doctors Inner join Persons On Persons.PersonID = Doctors.PersonID  Where DoctorID = @DoctorID";

                SqlCommand sqlCommand = new SqlCommand(text, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@DoctorID", DoctorID);

                try
                {
                    sqlConnection.Open();

                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    if (Reader.Read())
                    {
                        DoctorModel.DoctorID = (int)Convert.ToInt16(Reader["DoctorID"]);
                        DoctorModel.PersonID = (int)Convert.ToInt16(Reader["PersonID"]);
                        DoctorModel.Specialization = Convert.ToString(Reader["Specialization"]);
                        DoctorModel.PersonID = (int)Convert.ToInt16(Reader["PersonID"]);
                        DoctorModel.FirstName = Convert.ToString(Reader["FirstName"]);
                        DoctorModel.LastName = Convert.ToString(Reader["LastName"]);
                        DoctorModel.DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                        DoctorModel.Gender = Convert.ToChar(Reader["Gender"]);
                        DoctorModel.PhoneNumber = Convert.ToString(Reader["PhoneNumber"]);
                        DoctorModel.Email = Convert.ToString(Reader["Email"]);
                        DoctorModel.Address = Convert.ToString(Reader["Address"]);
                        DoctorModel.ImagePath = Convert.ToString(Reader["ImagePath"]);
                    }
                    else
                        DoctorModel = null; 

                    Reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Finding a Doctor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return DoctorModel;

            }

            public static clsDoctorModel FindDoctor(string FirstName)
            {
                clsDoctorModel DoctorModel = new clsDoctorModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string text = "Select Doctors.*, Persons.* From Doctors Inner join Persons On Persons.PersonID = Doctors.PersonID Where FirstName = @FirstName";

                SqlCommand sqlCommand = new SqlCommand(text, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@FirstName", FirstName);

                try
                {
                    sqlConnection.Open();

                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    if (Reader.Read())
                    {
                        DoctorModel.DoctorID = (int)Convert.ToInt16(Reader["DoctorID"]);
                        DoctorModel.PersonID = (int)Convert.ToInt16(Reader["PersonID"]);
                        DoctorModel.Specialization = Convert.ToString(Reader["Specialization"]);
                        DoctorModel.PersonID = (int)Convert.ToInt16(Reader["PersonID"]);
                        DoctorModel.FirstName = Convert.ToString(Reader["FirstName"]);
                        DoctorModel.LastName = Convert.ToString(Reader["LastName"]);
                        DoctorModel.DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                        DoctorModel.Gender = Convert.ToChar(Reader["Gender"]);
                        DoctorModel.PhoneNumber = Convert.ToString(Reader["PhoneNumber"]);
                        DoctorModel.Email = Convert.ToString(Reader["Email"]);
                        DoctorModel.Address = Convert.ToString(Reader["Address"]);
                        DoctorModel.ImagePath = Convert.ToString(Reader["ImagePath"]);
                    }
                    else
                        DoctorModel = null;

                    Reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Finding a Doctor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return DoctorModel;

            }

            public static DataTable GetAllDoctors()
            {
                DataTable dataTable = new DataTable();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select Doctors.DoctorID, Persons.FirstName ,Persons.LastName, Persons.DateOfBirth, Persons.Gender, Persons.PhoneNumber, Persons.Email, Persons.Address, Doctors.Specialization From Doctors Inner join Persons  On Persons.PersonID = Doctors.PersonID";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

                try
                {
                    sqlConnection.Open();

                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    dataTable.Load(Reader);

                    Reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while Get All Doctors " + ex.Message);
                    dataTable = null;
                }
                finally
                {
                    sqlConnection.Close();
                }

                return dataTable;

            }

        }

        public class clsUserMethods
        {
            public static clsUserModel AddNewUser(clsUserModel UserModel)
            {
                clsUserModel User = new clsUserModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Insert Into Users (Users.PersonID, Users.UserName, Users.Password, Users.Permissions) Values (@PersonID, @UserName, @Password, @Permissions)\r\nSELECT SCOPE_IDENTITY();";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@PersonID", UserModel.PersonID);
                sqlCommand.Parameters.AddWithValue("@UserName", UserModel.UserName);
                sqlCommand.Parameters.AddWithValue("@Password", UserModel.Password);
                sqlCommand.Parameters.AddWithValue("@Permissions", UserModel.Permissions);

                try
                {
                    sqlConnection.Open();
                    
                    object Result = sqlCommand.ExecuteScalar();

                    if (Result != null)
                    {
                        User = UserModel;
                        User.UserID = Convert.ToInt32(Result);
                    }
                    else
                        User = null; 

                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while adding a new User: " + ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return User;

            }

            public static bool DeleteUser(int UserID)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string text = "Delete From Users Where UserID = @UserID";

                SqlCommand sqlCommand = new SqlCommand(text, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while Deleting a User: " + ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

            public static bool UpdateUser(clsUserModel UserModel)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);
                string Query = "Update Users Set UserName = @UserName, Password = @Password, Permissions = @Permissions where UserID = @UserID ";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("UserID", UserModel.UserID);
                sqlCommand.Parameters.AddWithValue("@UserName", UserModel.UserName);
                sqlCommand.Parameters.AddWithValue("@Password", UserModel.Password);
                sqlCommand.Parameters.AddWithValue("@Permissions", UserModel.Permissions);

                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while Update a User: " + ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

            public static clsUserModel FindUser(int UserID)
            {
                clsUserModel clsUserModel = new clsUserModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select Users.*, Persons.* From Users Inner join Persons On Persons.PersonID = Users.PersonID Where Users.UserID = @UserID";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    if (Reader.Read())
                    {
                        clsUserModel.UserID = (int)Convert.ToInt16(Reader["UserID"]);
                        clsUserModel.UserName = Convert.ToString(Reader["UserName"]);
                        clsUserModel.Password = Convert.ToString(Reader["Password"]);
                        clsUserModel.Permissions = (int)Convert.ToInt16(Reader["Permissions"]);
                        clsUserModel.PersonID = (int)Convert.ToInt16(Reader["PersonID"]);
                        clsUserModel.FirstName = Convert.ToString(Reader["FirstName"]);
                        clsUserModel.LastName = Convert.ToString(Reader["LastName"]);
                        clsUserModel.DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                        clsUserModel.Gender = Convert.ToChar(Reader["Gender"]);
                        clsUserModel.PhoneNumber = Convert.ToString(Reader["PhoneNumber"]);
                        clsUserModel.Email = Convert.ToString(Reader["Email"]);
                        clsUserModel.Address = Convert.ToString(Reader["Address"]);
                        clsUserModel.ImagePath = Convert.ToString(Reader["ImagePath"]);
                    }
                    else
                        clsUserModel = null;

                    Reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while Finding a User: " + ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return clsUserModel;

            }

            public static clsUserModel FindUser(string UserName)
            {
                clsUserModel clsUserModel = new clsUserModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select Users.*, Persons.* From Users Inner join Persons On Persons.PersonID = Users.PersonID Where Users.UserName = @UserName";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@UserName", UserName);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    if (Reader.Read())
                    {
                        clsUserModel.UserID = (int)Convert.ToInt16(Reader["UserID"]);
                        clsUserModel.UserName = Convert.ToString(Reader["UserName"]);
                        clsUserModel.Password = Convert.ToString(Reader["Password"]);
                        clsUserModel.Permissions = (int)Convert.ToInt16(Reader["Permissions"]);
                        clsUserModel.PersonID = (int)Convert.ToInt16(Reader["PersonID"]);
                        clsUserModel.FirstName = Convert.ToString(Reader["FirstName"]);
                        clsUserModel.LastName = Convert.ToString(Reader["LastName"]);
                        clsUserModel.DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                        clsUserModel.Gender = Convert.ToChar(Reader["Gender"]);
                        clsUserModel.PhoneNumber = Convert.ToString(Reader["PhoneNumber"]);
                        clsUserModel.Email = Convert.ToString(Reader["Email"]);
                        clsUserModel.Address = Convert.ToString(Reader["Address"]);
                        clsUserModel.ImagePath = Convert.ToString(Reader["ImagePath"]);
                    }
                    else
                        clsUserModel = null;

                    Reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while Finding a User: " + ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return clsUserModel;

            }

            public static clsUserModel FindUser(string UserName, string Password)
            {
                clsUserModel clsUserModel = new clsUserModel();
                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select Users.*, Persons.* \r\nFrom Users Inner join Persons\r\nOn Persons.PersonID = Users.PersonID\r\nWhere Users.UserName = @UserName\r\nAnd Users.Password = @Password";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@UserName", UserName);
                sqlCommand.Parameters.AddWithValue("@Password", Password);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    if (Reader.Read())
                    {
                        clsUserModel.UserID = (int)Convert.ToInt16(Reader["UserID"]);
                        clsUserModel.UserName = Convert.ToString(Reader["UserName"]);
                        clsUserModel.Password = Convert.ToString(Reader["Password"]);
                        clsUserModel.Permissions = (int)Convert.ToInt16(Reader["Permissions"]);
                        clsUserModel.PersonID = (int)Convert.ToInt16(Reader["PersonID"]);
                        clsUserModel.FirstName = Convert.ToString(Reader["FirstName"]);
                        clsUserModel.LastName = Convert.ToString(Reader["LastName"]);
                        clsUserModel.DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                        clsUserModel.Gender = Convert.ToChar(Reader["Gender"]);
                        clsUserModel.PhoneNumber = Convert.ToString(Reader["PhoneNumber"]);
                        clsUserModel.Email = Convert.ToString(Reader["Email"]);
                        clsUserModel.Address = Convert.ToString(Reader["Address"]);
                        clsUserModel.ImagePath = Convert.ToString(Reader["ImagePath"]);
                    }
                    else
                        clsUserModel = null;

                    Reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while Finding a User: " + ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return clsUserModel;

            }

            public static DataTable GetAllUsers()
            {
                DataTable dataTable = new DataTable();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select Users.UserID, Users.UserName, Persons.FirstName ,Persons.LastName, Persons.DateOfBirth, Persons.Gender, Persons.PhoneNumber, Persons.Email, Persons.Address, Users.Permissions  From Users Inner join Persons On Persons.PersonID = Users.PersonID";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = sqlCommand.ExecuteReader();
                    dataTable.Load(Reader);
                    Reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while Get All Users " + ex.Message);
                    dataTable = null;
                }
                finally
                {
                    sqlConnection.Close();
                }

                return dataTable;

            }

        }

        public class clsAppointmentMethods
        {

            public static clsAppointmentModel AddNewAppointment(clsAppointmentModel appointmentModel)
            {

                clsAppointmentModel Appointment = new clsAppointmentModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Insert into Appointments \r\n(PatientID, DoctorID, AppointmentDateTime, AppointmentStatus, MedicalRecordID, PaymentID)\r\nValues (@PatientID, @DoctorID, @AppointmentDateTime, @AppointmentStatus, @MedicalRecordID, @PaymentID)\r\nSELECT SCOPE_IDENTITY();";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@PatientID", appointmentModel.PatientID);
                sqlCommand.Parameters.AddWithValue("@DoctorID", appointmentModel.DoctorID);
                sqlCommand.Parameters.AddWithValue("@AppointmentDateTime", appointmentModel.AppointmentDateTime);
                sqlCommand.Parameters.AddWithValue("@AppointmentStatus", appointmentModel.AppointmentStatus);

                if (appointmentModel.MedicalRecordID != -1)
                    sqlCommand.Parameters.AddWithValue("@MedicalRecordID", appointmentModel.MedicalRecordID);
                else
                    sqlCommand.Parameters.AddWithValue("@MedicalRecordID", DBNull.Value);

                if (appointmentModel.PaymentID != -1)
                    sqlCommand.Parameters.AddWithValue("@PaymentID", appointmentModel.PaymentID);
                else
                    sqlCommand.Parameters.AddWithValue("@PaymentID", DBNull.Value);


                try
                {
                    sqlConnection.Open();
                    object Result = sqlCommand.ExecuteScalar();

                    if (Result != null)
                    {
                        Appointment = appointmentModel;
                        Appointment.AppointmentID = Convert.ToInt32(Result);
                    }
                    else
                        Appointment = null;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding a new Appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }
            

                return Appointment;

            }

            public static clsAppointmentModel FindAppointment(int AppointmentID)
            {
                clsAppointmentModel AppointmentModel = new clsAppointmentModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select * From Appointments Where AppointmentID = @AppointmentID";
                
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@AppointmentID", AppointmentID);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    if (Reader.Read())
                    {

                        AppointmentModel.AppointmentID = AppointmentID;
                        AppointmentModel.PatientID = Convert.ToInt32(Reader["PatientID"]);
                        AppointmentModel.DoctorID = Convert.ToInt32(Reader["DoctorID"]);
                        AppointmentModel.AppointmentDateTime = Convert.ToDateTime(Reader["AppointmentDateTime"]);
                        AppointmentModel.AppointmentStatus = Convert.ToByte(Reader["AppointmentStatus"]);

                        if (Reader["MedicalRecordID"] != DBNull.Value)
                            AppointmentModel.MedicalRecordID = Convert.ToInt32(Reader["MedicalRecordID"]);
                        else
                            AppointmentModel.MedicalRecordID = -1;

                        if (Reader["PaymentID"] != DBNull.Value)
                            AppointmentModel.PaymentID = Convert.ToInt32(Reader["PaymentID"]);
                        else
                            AppointmentModel.PaymentID = -1;

                    }
                    else
                        AppointmentModel = null;

                    Reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Finding an Appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return AppointmentModel;

            }

            public static bool DeleteAppointment(int AppointmentID)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Delete From Appointments Where AppointmentID = @AppointmentID";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@AppointmentID", AppointmentID);

                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Deleting an Appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }
                return IsAffected;
            }

            public static bool UpdateAppointment(clsAppointmentModel appointmentModel)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Update Appointments Set\r\nPatientID = @PatientID, DoctorID = @DoctorID,\r\nAppointmentDateTime = @AppointmentDateTime, AppointmentStatus = @AppointmentStatus,\r\nMedicalRecordID = @MedicalRecordID, PaymentID = @PaymentID\r\nwhere AppointmentID = @AppointmentID ";
               
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@AppointmentID", appointmentModel.AppointmentID);
                sqlCommand.Parameters.AddWithValue("@PatientID", appointmentModel.PatientID);
                sqlCommand.Parameters.AddWithValue("@DoctorID", appointmentModel.DoctorID);
                sqlCommand.Parameters.AddWithValue("@AppointmentDateTime", appointmentModel.AppointmentDateTime);
                sqlCommand.Parameters.AddWithValue("@AppointmentStatus", appointmentModel.AppointmentStatus);

                if (appointmentModel.MedicalRecordID != -1)
                    sqlCommand.Parameters.AddWithValue("@MedicalRecordID", appointmentModel.MedicalRecordID);
                else
                    sqlCommand.Parameters.AddWithValue("@MedicalRecordID", DBNull.Value);

                if (appointmentModel.PaymentID != -1)
                    sqlCommand.Parameters.AddWithValue("@PaymentID", appointmentModel.PaymentID);
                else
                    sqlCommand.Parameters.AddWithValue("@PaymentID", DBNull.Value);


                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Update an Appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

            public static DataTable GetAllAppointments()
            {
                DataTable dataTable = new DataTable();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string text = "SELECT A.AppointmentID, A.PatientID, (PP.FirstName + ' ' + PP.LastName) " +
                    "AS PatientName, A.DoctorID, (PD.FirstName + ' ' + PD.LastName) " +
                    "AS DoctorName, A.AppointmentDateTime, CASE A.AppointmentStatus " +
                    "WHEN 0 THEN 'Pending'\r\n " +
                    "WHEN 1 THEN 'Confirmed'\r\n " +
                    "WHEN 2 THEN 'Completed'\r\n " +
                    "WHEN 3 THEN 'Cancelled'\r\n " +
                    "WHEN 4 THEN 'Rescheduled'\r\n " +
                    "WHEN 5 THEN 'No-Show'\r\n " +
                    "ELSE 'Unknown'\r\n " +
                    "END AS AppointmentStatusName,\r\n " +
                    "ISNULL(CAST(A.MedicalRecordID AS VARCHAR), 'Unknown') " +
                    "AS MedicalRecordID,\r\n    " +
                    "ISNULL(CAST(A.PaymentID AS VARCHAR), 'Unknown') " +
                    "AS PaymentID\r\nFROM Appointments A\r\n" +
                    "LEFT JOIN Patients PT ON A.PatientID = PT.PatientID\r\n" +
                    "LEFT JOIN Persons PP ON PT.PersonID = PP.PersonID\r\n" +
                    "LEFT JOIN Doctors DT ON A.DoctorID = DT.DoctorID\r\n" +
                    "LEFT JOIN Persons PD ON DT.PersonID = PD.PersonID;\r\n";

                SqlCommand sqlCommand = new SqlCommand(text, sqlConnection);

                try
                {
                    sqlConnection.Open();

                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    dataTable.Load(Reader);

                    Reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while Get All Appointments " + ex.Message);
                    dataTable = null;
                }
                finally
                {
                    sqlConnection.Close();
                }

                return dataTable;

            }

            public static bool UpdateNoShowAppointments()
            {
                bool IsAffected = false;    

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "UPDATE Appointments\r\nSET AppointmentStatus = 5\r\nWHERE AppointmentStatus IN (0, 1, 4) \r\n  AND AppointmentDateTime < GETDATE();";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred while Updating No Show Appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

            public static DataTable GetAppointmentsByStatus(int status)
            {
                DataTable dataTable = new DataTable();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "SELECT A.AppointmentID, A.PatientID, " +
                    "(PP.FirstName + ' ' + PP.LastName) AS PatientName, " +
                    "A.DoctorID, (PD.FirstName + ' ' + PD.LastName) AS DoctorName, " +
                    "A.AppointmentDateTime, " +
                    "CASE A.AppointmentStatus " +
                    "   WHEN 0 THEN 'Pending' " +
                    "   WHEN 1 THEN 'Confirmed' " +
                    "   WHEN 2 THEN 'Completed' " +
                    "   WHEN 3 THEN 'Cancelled' " +
                    "   WHEN 4 THEN 'Rescheduled' " +
                    "   WHEN 5 THEN 'No-Show' " +
                    "   ELSE 'Unknown' " +
                    "END AS AppointmentStatusName, " +
                    "ISNULL(CAST(A.MedicalRecordID AS VARCHAR), 'Unknown') AS MedicalRecordID, " +
                    "ISNULL(CAST(A.PaymentID AS VARCHAR), 'Unknown') AS PaymentID " +
                    "FROM Appointments A " +
                    "LEFT JOIN Patients PT ON A.PatientID = PT.PatientID " +
                    "LEFT JOIN Persons PP ON PT.PersonID = PP.PersonID " +
                    "LEFT JOIN Doctors DT ON A.DoctorID = DT.DoctorID " +
                    "LEFT JOIN Persons PD ON DT.PersonID = PD.PersonID " +
                    "WHERE A.AppointmentStatus = @Status;";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Status", status);

                try
                {
                    sqlConnection.Open();

                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    dataTable.Load(Reader);

                    Reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while Get Appointments By Status: " + ex.Message);
                    dataTable = null;
                }
                finally
                {
                    sqlConnection.Close();
                }

                return dataTable;
            }

        }

        public class clsMedicalRecordMethods
        {
            public static clsMedicalRecordModel AddNewMedicalRecord(clsMedicalRecordModel medicalRecordModel)
            {
                clsMedicalRecordModel clsMedicalRecordModel = new clsMedicalRecordModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);
                
                string Query = "Insert into MedicalRecords Values \r\n(@PrescriptionID, @VisitDescription, @Diagnosis, @AdditionalNotes)\r\nSELECT SCOPE_IDENTITY()";
                
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
               
                sqlCommand.Parameters.AddWithValue("@PrescriptionID", medicalRecordModel.PrescriptionID);
;
                if (medicalRecordModel.VisitDescription != null)
                    sqlCommand.Parameters.AddWithValue("@VisitDescription", medicalRecordModel.VisitDescription);
                else
                    sqlCommand.Parameters.AddWithValue("@VisitDescription", DBNull.Value);

                if (medicalRecordModel.Diagnosis != null)
                    sqlCommand.Parameters.AddWithValue("@Diagnosis", medicalRecordModel.Diagnosis);
                else
                    sqlCommand.Parameters.AddWithValue("@Diagnosis", DBNull.Value);

                if (medicalRecordModel.AdditionalNotes != null)
                    sqlCommand.Parameters.AddWithValue("@AdditionalNotes", medicalRecordModel.AdditionalNotes);
                else
                    sqlCommand.Parameters.AddWithValue("@AdditionalNotes", DBNull.Value);

                try
                {
                    sqlConnection.Open();

                    object Result = sqlCommand.ExecuteScalar();

                    if (Result != null)
                    {
                        clsMedicalRecordModel = medicalRecordModel;
                        clsMedicalRecordModel.MedicalRecordID = Convert.ToInt32(Result);
                    }
                    else
                        clsMedicalRecordModel = null;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding a new MedicalRecord: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return clsMedicalRecordModel;

            }

            public static clsMedicalRecordModel FindMedicalRecord(int MedicalRecordID)
            {
                clsMedicalRecordModel MedicalRecordModel = new clsMedicalRecordModel(); 

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select * From  MedicalRecords Where MedicalRecordID = @MedicalRecordID";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                
                sqlCommand.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    if (Reader.Read())
                    {
                        MedicalRecordModel.MedicalRecordID = MedicalRecordID;
                        MedicalRecordModel.PrescriptionID = Convert.ToInt32(Reader["PrescriptionID"]);

                        if (Reader["VisitDescription"] != DBNull.Value)
                            MedicalRecordModel.VisitDescription = Convert.ToString(Reader["VisitDescription"]);
                        else
                            MedicalRecordModel.VisitDescription = null;

                        if (Reader["Diagnosis"] != DBNull.Value)
                            MedicalRecordModel.Diagnosis = Convert.ToString(Reader["Diagnosis"]);
                        else
                            MedicalRecordModel.Diagnosis = null;

                        if (Reader["AdditionalNotes"] != DBNull.Value)
                            MedicalRecordModel.AdditionalNotes = Convert.ToString(Reader["AdditionalNotes"]);
                        else
                            MedicalRecordModel.AdditionalNotes = null;

                    }
                    else
                        MedicalRecordModel = null; 

                    Reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Finding a MedicalRecord: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return MedicalRecordModel;

            }

            public static bool DeleteMedicalRecord(int MedicalRecordID)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Delete From MedicalRecords Where MedicalRecordID = @MedicalRecordID";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@MedicalRecordID", MedicalRecordID);

                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Deleting a MedicalRecord: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

            public static bool UpdateMedicalRecord(clsMedicalRecordModel medicalRecordModel)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);
                
                string Query = "Update MedicalRecords Set \r\nPrescriptionsID = @PrescriptionsID, VisitDescription = @VisitDescription,\r\nDiagnosis = @Diagnosis, AdditionalNotes = @AdditionalNotes\r\nwhere MedicalRecordID = @MedicalRecordID ";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                
                sqlCommand.Parameters.AddWithValue("@MedicalRecordID", medicalRecordModel.MedicalRecordID);
                sqlCommand.Parameters.AddWithValue("@PrescriptionsID", medicalRecordModel.PrescriptionID);
                sqlCommand.Parameters.AddWithValue("@VisitDescription", medicalRecordModel.VisitDescription);
                sqlCommand.Parameters.AddWithValue("@Diagnosis", medicalRecordModel.Diagnosis);
                sqlCommand.Parameters.AddWithValue("@AdditionalNotes", medicalRecordModel.AdditionalNotes);
               
                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Update a MedicalRecord: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

            public static DataTable GetAllMedicalRecords()
            {
                DataTable dataTable = new DataTable();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string text = "Select * From MedicalRecords";

                SqlCommand sqlCommand = new SqlCommand(text, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    dataTable.Load(Reader);
                    Reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while Get All MedicalRecords " + ex.Message);
                    dataTable = null;
                }
                finally
                {
                    sqlConnection.Close();
                }

                return dataTable;

            }

        }

        public class clsPrescriptionMethods
        {

            public static clsPrescriptionModel AddNewPrescription(clsPrescriptionModel prescriptionModel)
            {

                clsPrescriptionModel clsPrescriptionModel = null;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Insert Into Prescriptions \r\n(MedicationName, Dosage, Frequency, StartDate, EndDate, SpecialInstructions )\r\nvalues (@MedicationName, @Dosage, @Frequency, @StartDate, @EndDate, @SpecialInstructions)\r\nSELECT SCOPE_IDENTITY()";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@MedicationName", prescriptionModel.MedicationName);
                sqlCommand.Parameters.AddWithValue("@Dosage", prescriptionModel.Dosage);
                sqlCommand.Parameters.AddWithValue("@Frequency", prescriptionModel.Frequency);
                sqlCommand.Parameters.AddWithValue("@StartDate", prescriptionModel.StartDate);
                sqlCommand.Parameters.AddWithValue("@EndDate", prescriptionModel.EndDate);
                sqlCommand.Parameters.AddWithValue("@SpecialInstructions", prescriptionModel.SpecialInstructions);

                try
                {
                    sqlConnection.Open();

                    object Result = sqlCommand.ExecuteScalar();

                    if (Result != null)
                    {
                        clsPrescriptionModel = prescriptionModel;
                        clsPrescriptionModel.PrescriptionID = Convert.ToInt32(Result);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding a new Prescription: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return clsPrescriptionModel;

            }

            public static clsPrescriptionModel FindPrescription(int prescriptionID)
            {
                clsPrescriptionModel clsPrescriptionModel = new clsPrescriptionModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select * From Prescriptions Where PrescriptionID = @PrescriptionID";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@PrescriptionID", prescriptionID);

                try
                {
                    sqlConnection.Open();

                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    if (Reader.Read())
                    {
                        clsPrescriptionModel.PrescriptionID = prescriptionID;
                        clsPrescriptionModel.MedicationName = Convert.ToString(Reader["MedicationName"]);
                        clsPrescriptionModel.Dosage = Convert.ToString(Reader["Dosage"]);
                        clsPrescriptionModel.Frequency = Convert.ToString(Reader["Frequency"]);
                        clsPrescriptionModel.StartDate = Convert.ToDateTime(Reader["StartDate"]);
                        clsPrescriptionModel.EndDate = Convert.ToDateTime(Reader["EndDate"]);
                        clsPrescriptionModel.SpecialInstructions = Convert.ToString("SpecialInstructions");
                    }
                    else
                        clsPrescriptionModel = null;

                    Reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Finding a Prescription: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return clsPrescriptionModel;

            }

            public static bool DeletePrescription(int prescriptionID)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Delete From Prescriptions Where PrescriptionID = @PrescriptionID";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@PrescriptionID", prescriptionID);

                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Deleting a Prescription: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

            public static bool UpdatePrescription(clsPrescriptionModel prescriptionModel)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Update Prescriptions\r\nSet MedicalRecordID = @MedicalRecordID, MedicationName = @MedicationName, Dosage = @Dosage,\r\nFrequency = @Frequency, StartDate = @StartDate, EndDate = @EndDate, SpecialInstructions = @SpecialInstructions\r\nwhere PrescriptionID = @PrescriptionID";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@PrescriptionID", prescriptionModel.PrescriptionID);
                sqlCommand.Parameters.AddWithValue("@MedicationName", prescriptionModel.MedicationName);
                sqlCommand.Parameters.AddWithValue("@Dosage", prescriptionModel.Dosage);
                sqlCommand.Parameters.AddWithValue("@Frequency", prescriptionModel.Frequency);
                sqlCommand.Parameters.AddWithValue("@StartDate", prescriptionModel.StartDate);
                sqlCommand.Parameters.AddWithValue("@EndDate", prescriptionModel.EndDate);
                sqlCommand.Parameters.AddWithValue("@SpecialInstructions", prescriptionModel.SpecialInstructions);

                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Update a Prescription: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

            public static DataTable GetAllPrescriptions()
            {
                DataTable dataTable = new DataTable();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select * From Prescriptions";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = sqlCommand.ExecuteReader();
                    dataTable.Load(Reader);
                    Reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while Get All Prescriptions " + ex.Message);
                    dataTable = null;
                }
                finally
                {
                    sqlConnection.Close();
                }

                return dataTable;

            }
        }

        public class clsPaymentMethods
        {

            public static clsPaymentModel AddNewPayment(clsPaymentModel paymentModel)
            {
                clsPaymentModel PaymentModel = new clsPaymentModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Insert Into Payments \r\n(PaymentDate, PaymentMethod, AmountPaid, AdditionalNotes )\r\nvalues (@PaymentDate, @PaymentMethod, @AmountPaid, @AdditionalNotes)\r\nSELECT SCOPE_IDENTITY();";
                
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@PaymentDate", paymentModel.PaymentDate);
                sqlCommand.Parameters.AddWithValue("@PaymentMethod", paymentModel.PaymentMethod);
                sqlCommand.Parameters.AddWithValue("@AmountPaid", paymentModel.AmountPaid);
                sqlCommand.Parameters.AddWithValue("@AdditionalNotes", paymentModel.AdditionalNotes);
                
                try
                {
                    sqlConnection.Open();
                    object Result = sqlCommand.ExecuteScalar();

                    if (Result != null)
                    {
                        PaymentModel = paymentModel;
                        PaymentModel.PaymentID = Convert.ToInt32(Result);
                    }
                    else
                        PaymentModel = null;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding a new Payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return PaymentModel;

            }

            public static clsPaymentModel FindPayment(int PaymentID)
            {
                clsPaymentModel clsPaymentModel = new clsPaymentModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select * From Payments Where PaymentID = @PaymentID";
                
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@PaymentID", PaymentID);
                
                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    if (Reader.Read())
                    {
                        clsPaymentModel.PaymentID = Convert.ToInt32(Reader["PaymentID"]);
                        clsPaymentModel.PaymentDate = Convert.ToDateTime(Reader["PaymentDate"]);
                        clsPaymentModel.PaymentMethod = Convert.ToString(Reader["PaymentMethod"]);
                        clsPaymentModel.AmountPaid = Convert.ToDouble(Reader["AmountPaid"]);
                        clsPaymentModel.AdditionalNotes = Convert.ToString(Reader["AdditionalNotes"]);
                    }

                    Reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Finding a payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return clsPaymentModel;

            }

            public static bool DeletePayment(int PaymentID)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string text = "Delete From Payments Where PaymentID = @PaymentID";

                SqlCommand sqlCommand = new SqlCommand(text, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@PaymentID", PaymentID);
               
                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Deleting a payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

            public static bool UpdatePayment(clsPaymentModel paymentModel)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Update Payments Set PaymentDate = @PaymentDate,\r\nPaymentMethod = @PaymentMethod, AmountPaid = @AmountPaid,\r\nAdditionalNotes = @AdditionalNotes\r\nwhere PaymentID = @PaymentID";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@PaymentID", paymentModel.PaymentID);
                sqlCommand.Parameters.AddWithValue("@PaymentDate", paymentModel.PaymentDate);
                sqlCommand.Parameters.AddWithValue("@PaymentMethod", paymentModel.PaymentMethod);
                sqlCommand.Parameters.AddWithValue("@AmountPaid", paymentModel.AmountPaid);
                sqlCommand.Parameters.AddWithValue("@AdditionalNotes", paymentModel.AdditionalNotes);
                
                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Update a Payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

            public static DataTable GetAllPayments()
            {
                DataTable dataTable = new DataTable();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select * From Payments";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = sqlCommand.ExecuteReader();
                    dataTable.Load(Reader);
                    Reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while Get All Payments " + ex.Message);
                    dataTable = null;
                }
                finally
                {
                    sqlConnection.Close();
                }

                return dataTable;

            }

        }

        public class clsSystemLogMethods
        {
            public static bool AddNewLog(clsSystemLogModel SystemLogModel)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Insert into SystemLogs (UserID, OperationType, DateTime, Details)\r\nValues (@UserID, @OperationType, @DateTime, @Details)";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@UserID", SystemLogModel.UserID);
                sqlCommand.Parameters.AddWithValue("@OperationType", SystemLogModel.OperationType);
                sqlCommand.Parameters.AddWithValue("@DateTime", SystemLogModel.DateTime);
                sqlCommand.Parameters.AddWithValue("@Details", SystemLogModel.Details);

                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while adding a new System Log: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

            public static clsSystemLogModel FindSystemLog(int SystemLogID)
            {
                clsSystemLogModel clsSystemLogModel = new clsSystemLogModel();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select * From SystemLogs Where LogID = @LogID";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@LogID", SystemLogID);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    if (Reader.Read())
                    {
                        clsSystemLogModel.LogID = SystemLogID;
                        clsSystemLogModel.UserID = Convert.ToInt32(Reader["UserID"]);
                        clsSystemLogModel.OperationType = Convert.ToString(Reader["OperationType"]);
                        clsSystemLogModel.DateTime = Convert.ToDateTime(Reader["DateTime"]);
                        clsSystemLogModel.Details = Convert.ToString(Reader["Details"]);
                    }
                    else
                        clsSystemLogModel = null;

                    Reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Finding a System Log: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return clsSystemLogModel;

            }

            public static DataTable FindSystemLogsByUserID(int UserID)
            {
                DataTable dataTable = new DataTable();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select * From SystemLogs Where UserID = @UserID";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = sqlCommand.ExecuteReader();

                    dataTable.Load(Reader);

                    Reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Finding a System Log: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dataTable = null;
                }
                finally
                {
                    sqlConnection.Close();
                }

                return dataTable;

            }

            public static bool DeleteLog(int LogID)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Delete From SystemLogs Where LogID = @LogID";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@LogID", LogID);

                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Deleting a Log: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

            public static bool UpdateLog(clsSystemLogModel SystemlogModel)
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Update SystemLogs Set UserID = @UserID,\r\nOperationType = @OperationType, DateTime = @DateTime, Details = @Details\r\nwhere LogID = @LogID ";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@LogID", SystemlogModel.LogID);
                sqlCommand.Parameters.AddWithValue("@UserID", SystemlogModel.UserID);
                sqlCommand.Parameters.AddWithValue("@OperationType", SystemlogModel.OperationType);
                sqlCommand.Parameters.AddWithValue("@DateTime", SystemlogModel.DateTime);
                sqlCommand.Parameters.AddWithValue("@Details", SystemlogModel.Details);

                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Update a System Log: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }

            public static DataTable GetAllLogs()
            {
                DataTable dataTable = new DataTable();

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);

                string Query = "Select * From SystemLogs";

                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    SqlDataReader Reader = sqlCommand.ExecuteReader();
                    dataTable.Load(Reader);
                    Reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while Get All SystemLogs " + ex.Message);
                    dataTable = null;
                }
                finally
                {
                    sqlConnection.Close();
                }

                return dataTable;

            }

            public static bool ClearSystemLogs()
            {
                bool IsAffected = false;

                SqlConnection sqlConnection = new SqlConnection(ClinicSettings.ConnectionString);
                string Query = "Delete From SystemLogs";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

                try
                {
                    sqlConnection.Open();
                    IsAffected = sqlCommand.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while Clearing The System Logs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return IsAffected;

            }
        }

     }

}
