using Clinic_Project.Properties;
using ClinicBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_Project
{
    public partial class PersonsScreen : Form
    {
        clsUser CurrentUser = null;
        private DataTable _PersonsTable;
        private DataGridViewRow _selectedRow;

        public enum enMode {Patients = 0, Doctors = 1, Users = 2 };

        private enMode _Mode;

        public PersonsScreen(enMode mode, clsUser User)
        {
            InitializeComponent();
            _Mode = mode;
            CurrentUser = User;
        }

        private void LoadPatientsScreen()
        {
            this.Text = "Patients Screen";
            lblPersonsScreen.Text = "Patients Screen";
            lblPerosnID.Text = "Patient ID";
            btnAddNewPerson.Text = "Add New Patients";
            _PersonsTable = clsPatient.GetAllPatients();
            pictureBox1.Image = Resources.patient;
            lblTotalName.Text = "Total Patients: #";
            lblTotalNumber.Text = _PersonsTable.Rows.Count.ToString();

        }
        private void LoadDoctorsScreen()
        {
            this.Text = "Docotrs Screen";
            lblPersonsScreen.Text = "Doctors Screen";
            lblPerosnID.Text = "Doctor ID";
            btnAddNewPerson.Text = "Add New Doctors";
            _PersonsTable = clsDoctor.GetAllDoctors();
            pictureBox1.Image = Resources.doctor;
            lblTotalName.Text = "Total Doctors: #";
            lblTotalNumber.Text = _PersonsTable.Rows.Count.ToString();
        }
        private void LoadUsersScreen()
        {
            this.Text = "Users Screen";
            lblPersonsScreen.Text = "Users Screen";
            lblPerosnID.Text = "User ID";
            btnAddNewPerson.Text = "Add New Users";
            _PersonsTable = clsUser.GetAllUsers();
            pictureBox1.Image = Resources.user__1_;
            lblTotalName.Text = "Total Users: #";
            lblTotalNumber.Text = _PersonsTable.Rows.Count.ToString();
        }

        private void PersonsScreen_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.Patients)
                LoadPatientsScreen();
            else if (_Mode == enMode.Doctors)
                LoadDoctorsScreen();
            else
                LoadUsersScreen();

            dgvPersons.DataSource = _PersonsTable;
        }

        private void dgvPersons_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvPersons.ClearSelection();
                dgvPersons.Rows[e.RowIndex].Selected = true;
                _selectedRow = dgvPersons.Rows[e.RowIndex];

                Rectangle cellRect = dgvPersons.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Point locationOnScreen = dgvPersons.PointToScreen(cellRect.Location);

                cmsPersons.Show(locationOnScreen.X, locationOnScreen.Y + cellRect.Height);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Patients)
                dgvPersons.DataSource = clsPatient.GetAllPatients();
            else if (_Mode == enMode.Doctors)
                dgvPersons.DataSource = clsDoctor.GetAllDoctors();
            else
                dgvPersons.DataSource= clsUser.GetAllUsers();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchID = tbxSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchID))
            {
                dgvPersons.DataSource = _PersonsTable;
                return;
            }

            DataView dv = _PersonsTable.DefaultView;

            if (_Mode == enMode.Patients)
                dv.RowFilter = $"PatientID = '{searchID.Replace("'", "''")}'";
            else if (_Mode == enMode.Doctors)
                dv.RowFilter = $"DoctorID = '{searchID.Replace("'", "''")}'";
            else
                dv.RowFilter = $"UserID = '{searchID.Replace("'", "''")}'";

            dgvPersons.DataSource = dv.ToTable();

        }

        private void cmsPersons_Opening(object sender, CancelEventArgs e)
        {

        }

        private void moreInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Patients)
            {
                if (_selectedRow != null)
                {
                    int PatientID = Convert.ToInt32(_selectedRow.Cells["PatientID"].Value);
                    clsPatient patient = clsPatient.FindPatient(PatientID);

                    PatientMoreInfoScreen patientMoreInfoScreen = new PatientMoreInfoScreen(patient);
                    patientMoreInfoScreen.ShowDialog();
                }

            }
            else if (_Mode == enMode.Doctors)
            {
                if (_selectedRow != null)
                {
                    int DoctroID = Convert.ToInt32(_selectedRow.Cells["DoctorID"].Value);
                    clsDoctor doctor = clsDoctor.FindDoctor(DoctroID);

                    DoctorMoreInfoScreen doctorMoreInfoScreen = new DoctorMoreInfoScreen(doctor);
                    doctorMoreInfoScreen.ShowDialog();
                }
            }
            else
            {
                if (_selectedRow != null)
                {
                    int UserID = Convert.ToInt32(_selectedRow.Cells["UserID"].Value);
                    clsUser user = clsUser.FindUser(UserID);

                    UserMoreInfoScreen userMoreInfoScreen = new UserMoreInfoScreen(user);   
                    userMoreInfoScreen.ShowDialog();
                }
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Patients)
            { 
                AddNewPatientScreen addNewPatientScreen = new AddNewPatientScreen(CurrentUser);
                addNewPatientScreen.ShowDialog();
            }
            else if (_Mode == enMode.Doctors)
            {
                AddNewDoctorScreen addNewDoctorScreen = new AddNewDoctorScreen(CurrentUser);
                addNewDoctorScreen.ShowDialog();
            }
            else
            {
                AddNewUserScreen addNewUserScreen = new AddNewUserScreen(CurrentUser);
                addNewUserScreen.ShowDialog();
            }
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Patients)
            {

                if (_selectedRow != null)
                {
                    int PatientID = Convert.ToInt32(_selectedRow.Cells["PatientID"].Value);

                    DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this Patient?", "Confirm Deletion", MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.Yes)
                    {

                        if (clsPatient.DeletePatient(PatientID))
                        {
                            MessageBox.Show("Patient deleted successfully.");
                            dgvPersons.DataSource = clsPatient.GetAllPatients();
                            
                            clsSystemLog systemLog = new clsSystemLog
                                (
                                    CurrentUser.UserID,
                                    "Delete Patient", DateTime.Now,
                                    $"Deleted Patient With ID {PatientID}, By User With User ID {CurrentUser.UserID} in {DateTime.Now}"
                                );

                            if (!clsSystemLog.AddNewSystemLog(systemLog))
                                MessageBox.Show("Error, While Deleting Patient!!!");

                        }
                        else
                            MessageBox.Show("Patient was not deleted.");

                    }

                }

            }
            else if (_Mode == enMode.Doctors)
            {
                if (_selectedRow != null)
                {
                    int DoctorID = Convert.ToInt32(_selectedRow.Cells["DoctorID"].Value);

                    DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this Doctor?", "Confirm Deletion", MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.Yes)
                    {

                        if (clsDoctor.DeleteDoctor(DoctorID))
                        {
                            MessageBox.Show("Doctor deleted successfully.");
                            dgvPersons.DataSource = clsDoctor.GetAllDoctors();

                            clsSystemLog systemLog = new clsSystemLog
                                (
                                    CurrentUser.UserID,
                                    "Delete Doctor",
                                    DateTime.Now,
                                    $"Deleted Doctor With DoctorID {DoctorID}, By UserID {CurrentUser.UserID}, in {DateTime.Now}"                                
                                );

                            if (!clsSystemLog.AddNewSystemLog(systemLog))
                                MessageBox.Show("Error, While Saving That Transaction");

                        }
                        else
                            MessageBox.Show("Doctor was not deleted.");

                    }

                }
            }
            else
            {
                if (_selectedRow != null)
                {
                    int UserID = Convert.ToInt32(_selectedRow.Cells["UserID"].Value);

                    DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this User?", "Confirm Deletion", MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.Yes)
                    {

                        if (clsUser.DeleteUser(UserID))
                        {
                            MessageBox.Show("User deleted successfully.");
                            dgvPersons.DataSource = clsUser.GetAllUsers();

                            clsSystemLog systemLog = new clsSystemLog
                                (
                                    CurrentUser.UserID,
                                    "Delete User", 
                                    DateTime.Now,
                                    $"Deleted User With UserID {UserID}, By User With UserID {CurrentUser.UserID}, in {DateTime.Now}."
                                
                                );

                            if (!clsSystemLog.AddNewSystemLog(systemLog))
                                MessageBox.Show("Error, While Saving System Log!!!");


                        }
                        else
                            MessageBox.Show("User was not deleted.");

                    }

                }

            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Patients)
            {
                if (_selectedRow != null)
                {
                    int PatientID = Convert.ToInt32(_selectedRow.Cells["PatientID"].Value);

                    clsPatient patient = clsPatient.FindPatient(PatientID);

                    if (patient != null)
                    {
                        UpdatePatientScreen updatePatientScreen = new UpdatePatientScreen(patient, CurrentUser);
                        updatePatientScreen.ShowDialog();
                    }

                }

            }
            else if (_Mode == enMode.Doctors)
            {
                if (_selectedRow != null)
                {
                    int DoctorID = Convert.ToInt32(_selectedRow.Cells["DoctorID"].Value);

                    clsDoctor doctor = clsDoctor.FindDoctor(DoctorID);

                    if (doctor != null)
                    {
                        UpdateDoctorScreen update  = new UpdateDoctorScreen(doctor, CurrentUser);
                        update.ShowDialog();
                    }

                }

            }
            else
            {
                if (_selectedRow != null)
                {
                    int UserID = Convert.ToInt32(_selectedRow.Cells["UserID"].Value);

                    clsUser user = clsUser.FindUser(UserID);

                    if (user != null)
                    {
                        UpdateUserScreen userScreen = new UpdateUserScreen(user, CurrentUser);
                        userScreen.ShowDialog();
                    }

                }
            }
        }
    }


}
    