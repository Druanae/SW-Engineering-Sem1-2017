using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SW_Engineering_2017
{
    public partial class finalUI : Form
    {
        #region Set up
        /****************************************** Private Strings************************************/
        #region Private variables
        private string privatePatientID, privateAppointmentID, privateStaffID, privateDate, privateTime, privateStaffType;
        private bool PrivatePatientFound = false, NewAppointment = true;
        private int loginAttempt = 0;
        private Validation val = new Validation();

        private Appointment appointment = new Appointment();

        #endregion

        #region form initiation, Load and Close 
        public finalUI()
        {
            InitializeComponent();
            Positioning();
            /******************************************** Hide Panels code *****************************************/
            #region Hide Panels Code
            mainMenuPanel.Visible = false;
            prescriptionPanel.Visible = false;
            testResultSearchPanel.Visible = false;
            staffScheduleSearchPanel.Visible = false;
            changeStaffSchedulePanel.Visible = false;
            newPatientPanel.Visible = false;
            findPatientPanel.Visible = false;
            editPatientPanel.Visible = false;
            newAppointmentPanel.Visible = false;
            loginErrorlbl.Visible = false;
            #endregion
        }

        private void finalUI_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            /************************************ Date related Code*******************************************/
            #region Date Related Code
            //set the values appointments
            DateTime twoWeeks = DateTime.Today;
            twoWeeks = twoWeeks.AddDays(14);
            dob_NP_PCK.MaxDate = DateTime.Today;
            dob_NP_PCK.Value = DateTime.Today;

            appointmentDate_PCK_NA.Value = DateTime.Today;
            appointmentDate_PCK_NA.MinDate = DateTime.Today;
            appointmentDate_PCK_NA.MaxDate = twoWeeks;

            dob_EP_PCK.MaxDate = DateTime.Today;
            dob_EP_PCK.Value = DateTime.Today;
            dob_FP_PCK.MaxDate = DateTime.Today;
            dob_FP_PCK.Value = DateTime.Today;
            #endregion

            /***************************** Database Connection Code ***************************************/
            #region Database Connection Code
            //opens the database connection
            Connection.getDBConnectionInstance().openConnection();
            //set data set 
            DataSet dataSet = Connection.getDBConnectionInstance().GetDataSet(Constants.selectingLogin);
            // creates instace and set table 
            DataTable table = dataSet.Tables[0];
            //DVG.DataSource = table;
            #endregion

            //configuring properties
            patientIDPanel.Visible = false;
            NamePanel.Visible = false;
            DOBPanel.Visible = false;
            addressPanel.Visible = false;
        }

        private void finalUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            //close database connection 
            Connection.getDBConnectionInstance().closeConnection();
        }
        #endregion

        #region Panel Positoning Code
        private void Positioning()
        {
            mainMenuPanel.Location = new Point(this.Width / 2 - mainMenuPanel.Width / 2, this.Height / 2 - mainMenuPanel.Height / 2);
            mainMenuPanel.Anchor = AnchorStyles.None;
            prescriptionPanel.Location = new Point(this.Width / 2 - prescriptionPanel.Width / 2, this.Height / 2 - prescriptionPanel.Height / 2);
            prescriptionPanel.Anchor = AnchorStyles.None;
            testResultSearchPanel.Location = new Point(this.Width / 2 - testResultSearchPanel.Width / 2, this.Height / 2 - testResultSearchPanel.Height / 2);
            testResultSearchPanel.Anchor = AnchorStyles.None;
            staffScheduleSearchPanel.Location = new Point(this.Width / 2 - staffScheduleSearchPanel.Width / 2, this.Height / 2 - staffScheduleSearchPanel.Height / 2);
            staffScheduleSearchPanel.Anchor = AnchorStyles.None;
            changeStaffSchedulePanel.Location = new Point(this.Width / 2 - changeStaffSchedulePanel.Width / 2, this.Height / 2 - changeStaffSchedulePanel.Height / 2);
            changeStaffSchedulePanel.Anchor = AnchorStyles.None;
            newPatientPanel.Location = new Point(this.Width / 2 - newPatientPanel.Width / 2, this.Height / 2 - newPatientPanel.Height / 2);
            changeStaffSchedulePanel.Anchor = AnchorStyles.None;
            findPatientPanel.Location = new Point(this.Width / 2 - findPatientPanel.Width / 2, this.Height / 2 - findPatientPanel.Height / 2);
            findPatientPanel.Anchor = AnchorStyles.None;
            editPatientPanel.Location = new Point(this.Width / 2 - editPatientPanel.Width / 2, this.Height / 2 - editPatientPanel.Height / 2);
            editPatientPanel.Anchor = AnchorStyles.None;
            newAppointmentPanel.Location = new Point(this.Width / 2 - newAppointmentPanel.Width / 2, this.Height / 2 - newAppointmentPanel.Height / 2);
            newAppointmentPanel.Anchor = AnchorStyles.None;
            loginPanel.Location = new Point(this.Width / 2 - loginPanel.Width / 2, this.Height / 2 - loginPanel.Height / 2);
            loginPanel.Anchor = AnchorStyles.None;
            newPatientPanel.Location = new Point(this.Width / 2 - newPatientPanel.Width / 2, this.Height / 2 - newPatientPanel.Height / 2);
            newPatientPanel.Anchor = AnchorStyles.None;

        }
        #endregion

        #endregion

        #region Login 
        // This class is used so that the string can be used to determin what staff member has access to what.
        private static class access
        {
            public static string accessType;
        }
        private void loginBtn_Click(object sender, EventArgs e)
        {
            DataSet dataSet = Connection.getDBConnectionInstance().GetDataSet(Constants.selectingLogin);

            // creates instace and set table 
            DataTable table = dataSet.Tables[0];

            //selects row just added
            DataRow dataRow = table.Rows[table.Rows.Count - 1];

            int dataRowlogin = table.Rows.Count - 1;

            string loginID = userName_L_tb.Text;
            string loginPassword = password_L_tb.Text;
            string loginPermission;
            welcome_L.Text = "Logged in as user: " + loginID;




            if (loginID == "" || loginPassword == "") // Checks for empty login or password
            {
                loginerrorlabel(); //Error message for having nothing in either text box.

            }
            else
            {
                for (int i = 0; i <= dataRowlogin; i++) // For loop for the amount of staff logins 
                {
                    dataRow = table.Rows[i];

                    if (loginID == dataRow.ItemArray.GetValue(0).ToString()) //Get loginID to match against password
                    {
                        if (loginPassword == dataRow.ItemArray.GetValue(1).ToString())
                        {
                            // Logger for successful Login
                            loginAttempt++;
                            Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "\r\n Attempted Login in \r\n  StaffID:" + loginID + "\r\n  Login Successful?: Yes" + "\r\nLogged in on attempt: " + loginAttempt);

                            loginPermission = dataRow.ItemArray.GetValue(2).ToString();
                            access.accessType = loginPermission;
                            if (!mainMenuPanel.Visible) // if correct username and password go to menu page
                            {
                                if (loginPermission == "Receptionist") // if it is the receptionst give access to the add patient section
                                {
                                    addPatientBTN.Visible = true;
                                    newMedicalHistory_FP_B.Visible = false;
                                }
                                else // if not the receptionist disable add patient
                                {
                                    addPatientBTN.Visible = false;
                                    newMedicalHistory_FP_B.Visible = true;

                                }
                                loginErrorlbl.Visible = false;
                                mainMenuPanel.Visible = true;
                                loginPanel.Visible = false;
                                password_L_tb.Text = "";
                                userName_L_tb.Text = "";
                                break;
                            }
                        }
                        else
                            //Logger for failed login

                            loginerrorlabel();
                    }
                    else
                    {

                        loginerrorlabel();
                    }

                }

            }
            loginAttempt++;

        }

        private void password_L_tb_TextChanged(object sender, EventArgs e)
        {
            //make the password hidden
            password_L_tb.PasswordChar = '*';
        }

        private void loginerrorlabel() // error message method 
        {
            loginErrorlbl.Visible = true;
            loginErrorlbl.Text = "Please fill in username and password";
        }
        #endregion

        #region Navigation and Panel Reset
        #region Main Menu Panel Visibility Code
        private void mainMenuShow(object sender, EventArgs e)
        {
            mainMenuPanel.Visible = true;
            prescriptionPanel.Visible = false;
            testResultSearchPanel.Visible = false;
            staffScheduleSearchPanel.Visible = false;
            changeStaffSchedulePanel.Visible = false;
            newPatientPanel.Visible = false;
            findPatientPanel.Visible = false;
            editPatientPanel.Visible = false;
            newAppointmentPanel.Visible = false;
            loginPanel.Visible = false;
            loginErrorlbl.Visible = false;

            clearFindPatient();
        }
        #endregion

        #region Navigation Buttons
        private void logoutBtn_Click(object sender, EventArgs e)
        {
            loginAttempt = 0;
            if (!loginPanel.Visible)
            {
                mainMenuPanel.Visible = false;
                loginPanel.Visible = true;
            }
        }

        private void patientBtn_Click(object sender, EventArgs e)
        {
            //clears error label
            error_FP_LBL.Text = "";
            //Set the access so that receptionist can't change perscriptions and only Nurse / GP can.
            if (access.accessType == "Receptionist")
            {
                newPrescriptions_FP_B.Visible = false;

            }
            else
            {
                newPrescriptions_FP_B.Visible = true;

            }
            if (!findPatientPanel.Visible)
            {
                findPatientPanel.Visible = true;
                mainMenuPanel.Visible = false;
            }
        }

        private void testResultsBtn_Click(object sender, EventArgs e)
        {
            if (!testResultSearchPanel.Visible)
            {
                testResultSearchPanel.Visible = true;
                mainMenuPanel.Visible = false;
            }
        }

        private void scheduleBtn_Click(object sender, EventArgs e)
        {
            if (!staffScheduleSearchPanel.Visible)
            {
                staffScheduleSearchPanel.Visible = true;
                mainMenuPanel.Visible = false;
            }
        }

        private void prescriptionBtn_Click(object sender, EventArgs e)
        {
            if (!prescriptionPanel.Visible)
            {
                prescriptionPanel.Visible = true;
                mainMenuPanel.Visible = false;
            }

        }

        private void btnPresCancel_Click(object sender, EventArgs e)
        {
            if (!findPatientPanel.Visible)
            {
                prescriptionPanel.Visible = false;
                findPatientPanel.Visible = true;
            }
        }

        private void newPrescriptions_FP_B_Click(object sender, EventArgs e)
        {
            if (!prescriptionPanel.Visible)
            {
                prescriptionPanel.Visible = true;
                findPatientPanel.Visible = false;
            }
        }

        private void addPatientBTN_Click(object sender, EventArgs e)
        {
            if (!newPatientPanel.Visible)
            {
                newPatientPanel.Visible = true;
                mainMenuPanel.Visible = false;
            }
        }

        #endregion

        #region Clear Method/ Reset Panels

        private void clearNewAppointment()
        {
            //resets values for next time
            staffType_CB_NA.Text = "";
            Staff_CB_NA.Text = "";
            AppointmentTimes_CB_NA.Text = "";
            Staff_DGV_NA.DataSource = null;
            appointmentDate_PCK_NA.Value = DateTime.Today;
        }
        private void clearAddPatient()
        {
            firstName_NP_TB.Text = "";
            surname_NP_TB.Text = "";
            address_NP_TB.Text = "";
            dob_NP_PCK.Value = DateTime.Today;
            townCity_NP_TB.Text = "";
            county_NP_TB.Text = "";
            postcode_NP_TB.Text = "";
        }
        private void clearFindPatient()
        {
            //resets values for next time
            patientID_FP_TB.Text = "";
            firstName_FP_TB.Text = "";
            surname_FP_TB.Text = "";
            address_FP_TB.Text = "";
            findPatientCB.Text = "";
            PrivatePatientFound = false;
            patients_DGV_FP.DataSource = null;
            appointments_DGV_FP.DataSource = null;
            patients_DGV_FP.DataSource = null;
            medicalHistory_DVG_FP.DataSource = null;
            addMedicalRecord_TB_FP.Clear();

        }
        private void clearEditPatient()
        {
            firstName_EP_TB.Text = "";
            surname_EP_TB.Text = "";
            address_EP_TB.Text = "";
            townCity_EP_TB.Text = "";
            county_EP_TB.Text = "";
            postcode_EP_TB.Text = "";
        }
        private void hideFindPatientPanels()
        {
            patientIDPanel.Visible = false;
            NamePanel.Visible = false;
            DOBPanel.Visible = false;
            addressPanel.Visible = false;
        }

        #endregion

        #endregion

        #region Patient

        #region patient validation method
        private string validate_patient_input(string firstname, string surname, string addressLine, string townCity, string county, string postcode)
        {
            string errorMessage = "";
            Validation val = new Validation();
            //Validates User inputs and stores results in errorMessage
            errorMessage += val.validateFirstname(firstname);
            errorMessage += val.validateSurname(surname);
            errorMessage += val.validateAddressLine(addressLine);
            errorMessage += val.validateTownCity(townCity);
            errorMessage += val.validateCounty(county);
            errorMessage += val.validatePostcode(postcode);
            return errorMessage;
        }
        #endregion

        #region Add Patient Code
        private void confirm_NP_BTN_Click(object sender, EventArgs e)
        {
            string PatientID;
            Patient patient = new Patient();
            String firstname = firstName_NP_TB.Text, surname = surname_NP_TB.Text, addressLine = address_NP_TB.Text, townCity = townCity_NP_TB.Text, county = county_NP_TB.Text, postcode = postcode_NP_TB.Text, errorMessage = "";
            DateTime dob = dob_EP_PCK.Value;

            //error validates the user input
            errorMessage = validate_patient_input(firstname, surname, addressLine, townCity, county, postcode);

            //check if there are no error
            if (errorMessage == "")
            {
                //set patient values 
                patient.setPatientInfo(firstname, surname, dob, addressLine, townCity, county, postcode);

                //adds Patient to database
                PatientID = patient.addPatient();

                //clears form
                clearAddPatient();

                //displays to user that the Patient has been added and their ID
                error_NP_L.Text = firstname + " " + surname + " was added to the system.\r\nTheir ID is:" + PatientID;

            }
            else
            {
                //display input errors to user
                error_NP_L.Text = errorMessage;
            }
        }

        #endregion

        #region  Edit patient

        private void edit_FP_B_Click(object sender, EventArgs e)
        {
            string userID; // String for finding usingID
            if ((PrivatePatientFound == true) && (patients_DGV_FP.Rows.Count > 0))
            {
                int selectedRowIndex = patients_DGV_FP.SelectedCells[0].RowIndex; //Select patient row
                DataGridViewRow selectedRow = patients_DGV_FP.Rows[selectedRowIndex]; // Show in Datagrid view
                userID = selectedRow.Cells[0].Value.ToString(); //Set the USerID to the selected row

                DataTable table; // Get the data from the database
                DataSet dataSet;
                DataRow dataRow;
                dataSet = Connection.getDBConnectionInstance().selectPatientByID(userID); //Make a connection to the database and then pull the userID
                                                                                          // this returns a dataset.

                table = dataSet.Tables[0]; //Stores dataset in the table
                patients_DGV_FP.DataSource = table;
                dataRow = table.Rows[0]; // Stores the table information to the user. 
                privatePatientID = userID;

                firstName_EP_TB.Text = dataRow.ItemArray.GetValue(1).ToString(); //Get Firstname from Database
                surname_EP_TB.Text = dataRow.ItemArray.GetValue(2).ToString(); //Get Surname from Database

                dob_EP_PCK.Value = Convert.ToDateTime(dataRow.ItemArray.GetValue(3).ToString()); //Get DOB from Database and converts to a normal format that the database accepts.

                address_EP_TB.Text = dataRow.ItemArray.GetValue(4).ToString(); //Get Address from Database
                townCity_EP_TB.Text = dataRow.ItemArray.GetValue(5).ToString(); //Get town or city from Database
                county_EP_TB.Text = dataRow.ItemArray.GetValue(6).ToString(); //Get county from Database
                postcode_EP_TB.Text = dataRow.ItemArray.GetValue(7).ToString();//Get postcode from Database
                if (!editPatientPanel.Visible)
                {
                    editPatientPanel.Visible = true;
                    findPatientPanel.Visible = false;
                    clearFindPatient();
                    hideFindPatientPanels();
                }
            }
            else
            {
                error_FP_LBL.Text = "Patient Required"; // If patient hasn't been selected
            }
        }

        private void cancel_EP_B_Click(object sender, EventArgs e) // Cancel edit patient and clear data changes & hides panel
        {
            clearEditPatient();

            if (!findPatientPanel.Visible)
            {
                findPatientPanel.Visible = true;
                editPatientPanel.Visible = false;
            }
        }

        private void confirm_EP_B_Click(object sender, EventArgs e)
        {

            // Get text box information
            String firstname = firstName_EP_TB.Text, surname = surname_EP_TB.Text, addressLine = address_EP_TB.Text, townCity = townCity_EP_TB.Text, county = county_EP_TB.Text, postcode = postcode_EP_TB.Text, errorMessage = "";
            DateTime dob = dob_EP_PCK.Value;

            //Validates User inputs and stores results in errorMessage
            errorMessage = validate_patient_input(firstname, surname, addressLine, townCity, county, postcode);
            //check if there are no error
            if (errorMessage == "")
            {
                //Adds patient to the database
                Connection.getDBConnectionInstance().updatePatient(privatePatientID, firstname, surname, dob, addressLine, townCity, county, postcode);
                Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "\r\n Attemp to modify patient information - \r\n  PatientID:" + privatePatientID + "\r\n  Patient Updated?: Yes");
                error_EP_L.Text = "Patient infomation Updated";
                clearEditPatient(); // Clear text box data.

            }
            else
            {
                //display input errors to user
                error_EP_L.Text = errorMessage;
                Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "\r\n Attemp to modify patient information - \r\n  PatientID:" + privatePatientID + "\r\n  Patient Updated?: No");

            }

        }

        #endregion

        #region  Find patient

        private void find_FP_BT_Click(object sender, EventArgs e)
        {
            medicalHistory_DVG_FP.DataSource = null;
            medicalHistory_DVG_FP.Refresh();
            Validation val = new Validation();
            string PatientID = patientID_FP_TB.Text, firstname = firstName_FP_TB.Text, surname = surname_FP_TB.Text, AdressLine = address_FP_TB.Text, errormessage = "";
            int PatientId;
            DateTime dob = dob_FP_PCK.Value;
            DataTable table;
            DataSet dataSet;

            errormessage += val.validateFirstname(firstname);
            errormessage += val.validateSurname(surname);
            errormessage += val.validateAddressLine(AdressLine);
            if ((findPatientCB.SelectedIndex == 0) && (PatientID != ""))
            {
                if (Int32.TryParse(PatientID, out PatientId))
                {
                    dataSet = Connection.getDBConnectionInstance().selectPatientByID(PatientID);
                    table = dataSet.Tables[0];

                    patients_DGV_FP.DataSource = table;
                    if (table.Rows.Count > 0)
                    {
                        PrivatePatientFound = true;
                    }
                }

            }
            else if ((findPatientCB.SelectedIndex == 1) && (firstname != "") && (surname != "") && (dob != null))
            {
                string dateOfbirthInp = dob.Year.ToString() + "-" + dob.Month.ToString() + "-" + dob.Day.ToString();
                dataSet = Connection.getDBConnectionInstance().selectPatientByDOB(firstname, surname, dateOfbirthInp);
                table = dataSet.Tables[0];

                patients_DGV_FP.DataSource = table;
                if (table.Rows.Count > 0)
                {
                    PrivatePatientFound = true;
                }
            }
            else if ((findPatientCB.SelectedIndex == 2) && (firstname != "") && (surname != "") && (AdressLine != ""))
            {

                dataSet = Connection.getDBConnectionInstance().selectPatientByAddress(firstname, surname, AdressLine);
                table = dataSet.Tables[0];

                patients_DGV_FP.DataSource = table;
                if (table.Rows.Count > 0)
                {
                    PrivatePatientFound = true;
                }
            }
        }
        private void findPatientCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (findPatientCB.SelectedIndex == 0)
            {
                patientIDPanel.Visible = true;
                NamePanel.Visible = false;
                DOBPanel.Visible = false;
                addressPanel.Visible = false;
            }

            else if (findPatientCB.SelectedIndex == 1)
            {
                patientIDPanel.Visible = false;
                NamePanel.Visible = true;
                DOBPanel.Visible = true;
                addressPanel.Visible = false;

            }
            else if (findPatientCB.SelectedIndex == 2)
            {
                patientIDPanel.Visible = false;
                NamePanel.Visible = true;
                DOBPanel.Visible = false;
                addressPanel.Visible = true;
            }

            clearFindPatient();
        }
        #endregion

        #region Appointment

        #region New Appointment
        #region Loading New Appointment Panel
        private void newAppointment_FP_B_Click(object sender, EventArgs e)
        {
            //check there is patient infomation found
            if ((PrivatePatientFound == true) && (patients_DGV_FP.Rows.Count > 0))
            {
                //Updates logger 
                Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + "Add Appointment button clicked : ID SELECTED");

                AppointmentHeader_L_NA.Text = "New Appointment";
                NewAppointment = true;
                //selects row and selects patientID and stores it
                int selectedRowIndex = patients_DGV_FP.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = patients_DGV_FP.Rows[selectedRowIndex];
                privatePatientID = selectedRow.Cells[0].Value.ToString();
                //display PatientID
                PatientID_LB_NA.Text = "PatientID:" + privatePatientID;
                errorMessage_LB_NA.Text = "";

                //Updates logger 
                Logger.instance.log(DateTime.Today.ToString("-----------------\r\n" + "hh:mm") + "Patient:" + privatePatientID.ToString());
                //opens appointment panel
                appointmentPanel();


            }
            else
            {
                //displays error message if user doesnt find a patient before click add appointment
                error_FP_LBL.Text = "Patient Required";
                //Updates logger 
                Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + "Add Appointment button clicked : ID NOT SELECTED");
            }

        }
        #endregion

        #region Select new Appointment
        private void staffType_CB_NA_SelectedIndexChanged(object sender, EventArgs e)
        {
            //variables
            Staff_CB_NA.Text = "";
            DataTable table;
            DataSet dataSet;
            DataRow dataRow;
            int numRows;

            //checks if GP was selected
            if (staffType_CB_NA.SelectedIndex == 0)
            {
                //set data set to all the GP
                dataSet = Connection.getDBConnectionInstance().GetDataSet(Constants.selectAllGPAppointment);
                Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + "Staff Type selected : GP");
            }
            else
            {
                //set data set to all Nurse
                dataSet = Connection.getDBConnectionInstance().GetDataSet(Constants.selectAllNurseAppointment);
                Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + "Staff Type selected : Nurse");

            }
            //sets the table equal to the data set
            table = dataSet.Tables[0];
            //stores the number of rows
            numRows = table.Rows.Count - 1;
            //clear Staff selection combobox
            Staff_CB_NA.Items.Clear();
            Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + "Staff Table load with selected Type");

            //loops throw all the staff in the table and 
            for (int i = 0; i <= numRows; i++)
            {
                //selects data staff ID in the table
                dataRow = table.Rows[i];

                //adds their ID to the combobox
                Staff_CB_NA.Items.Add(dataRow.ItemArray.GetValue(0).ToString());
            }
            //outputs data into data grid view
            Staff_DGV_NA.DataSource = table;

        }

        private void Staff_CB_NA_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check if data and staff have both been selected 
            if ((appointmentDate_PCK_NA.Text != "") && (Staff_CB_NA.Text != ""))
            {
                Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + "Staff Member Selected");
                //call method 
                checkingAppointment();
            }
        }

        private void appointmentDate_PCK_NA_ValueChanged(object sender, EventArgs e)
        {
            //check if data and staff have both been selected 
            if ((appointmentDate_PCK_NA.Text != "") && (Staff_CB_NA.Text != ""))
            {
                //call method
                Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + "Appointmet Selected");
                checkingAppointment();
            }
        }

        private void checkingAppointment()
        {
            //sets variables and clear appointment drop down
            AppointmentTimes_CB_NA.Items.Clear();

            //database variables
            DataTable table;
            DataSet dataSet;
            DataRow dataRow;

            //bools
            bool addTime = true, Today = false;
            //int
            int numRows;
            //strings
            string date = appointmentDate_PCK_NA.Value.Year.ToString() + "-" + appointmentDate_PCK_NA.Value.Month.ToString() + "-" + appointmentDate_PCK_NA.Value.Day.ToString();

            //gets data from database about staff time table on a date
            dataSet = Connection.getDBConnectionInstance().staffDateView(Staff_CB_NA.Text, date);

            //stores data collected in table
            table = dataSet.Tables[0];
            Staff_DGV_NA.DataSource = table;
            //sets the number of rows
            numRows = table.Rows.Count - 1;

            //check if the date selected is today
            if (appointmentDate_PCK_NA.Value == DateTime.Today)
            {
                //if today is the day selected
                Today = true;
            }

            //sets opening time 
            TimeSpan appointment = Constants.openTime;
            //loops through until all appointment have been checked
            while (appointment != Constants.CloseTime)
            {
                addTime = true;
                //loops through each value in the database
                for (int i = 0; i <= numRows; i++)
                {
                    //set dataRow 
                    dataRow = table.Rows[i];
                    //check if there is an appointment already at that time
                    if (dataRow.ItemArray.GetValue(0).ToString() == appointment.ToString())
                    {
                        //sets addtime to false as time is already take and break out of the for loop 
                        addTime = false;
                        break;
                    }
                }
                //check to see the appoiment is today and that the appoint hasnt already passed
                if ((Today == true) && (TimeSpan.Compare(appointment, DateTime.Now.TimeOfDay) == -1))
                {
                    //sets addtime to false as time has already passed
                    addTime = false;
                }

                //if there isnt an appointment at that time it gets add to the dropdown list
                if (addTime == true)
                {
                    //adds appointment to dropdown
                    AppointmentTimes_CB_NA.Items.Add(appointment);
                }

                //add 15 minutes to time slot every time(appointment length)
                appointment += Constants.appointmentLength;

            }
            //checks if there are appointment
            if (AppointmentTimes_CB_NA.Items.Count == 0)
            {
                //if theres no then tells the user
                errorMessage_LB_NA.Text = "There are no more Appointments On selected day";

            }
            //Updates logger 
            Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + "Shows Available Appointments");
        }

        private void appointmentPanel()
        {
            //Updates logger 
            Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + "Clears Appointment Panel");
            //opens Panel 
            if (!newAppointmentPanel.Visible)
            {
                newAppointmentPanel.Visible = true;
                findPatientPanel.Visible = false;
                errorMessage_LB_NA.Text = "";
            }
            //clears findPatient Panel
            clearFindPatient();
            hideFindPatientPanels();
        }
        #endregion

        #region Confirm New Appointment
        private void Confirm_BT_NA_Click(object sender, EventArgs e)
        {
            //strings 
            string staffType = staffType_CB_NA.Text, staff = Staff_CB_NA.Text, appointmentTime = AppointmentTimes_CB_NA.Text;
            string appointmentDate = appointmentDate_PCK_NA.Value.Year.ToString() + "-" + appointmentDate_PCK_NA.Value.Month.ToString() + "-" + appointmentDate_PCK_NA.Value.Day.ToString();

            string errormessage;

            //validates appointment information return errormessage 
            errormessage = val.validateAppointment(staffType, staff, appointmentTime);

            //check if error message is blank (no errors with information)
            if (errormessage == "")
            {
                //check if it a new appointment
                if (NewAppointment == true)
                {
                    //if user has enter all the correct information then it add appointment to the database
                    appointment.SetsAppointments(privatePatientID, staff, appointmentDate, appointmentTime);
                    //add appointment
                    appointment.addAppointment();
                    //displays message to user
                    errorMessage_LB_NA.Text = "Appointment added";

                    //clears inputs
                    clearNewAppointment();
                }
                else
                {
                    //if edit appointment then runs this method
                    confirmChangeAppointment(staff, appointmentDate, appointmentTime);
                    //clears inputs
                    clearNewAppointment();
                }

            }
            else
            {
                //displays error message to user
                errorMessage_LB_NA.Text = errormessage;
            }
        }
        #endregion

        #region navigation
        private void Back_BT_NA_Click(object sender, EventArgs e)
        {
            //Updates logger 
            Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + "Back Button Clicked to Find Patient Panel");
            //clears newAppointment
            clearNewAppointment();
            //changes panel to find patient 
            if (!findPatientPanel.Visible)
            {
                newAppointmentPanel.Visible = false;
                findPatientPanel.Visible = true;
            }
        }
        #endregion

        #endregion

        #region Load Appointment

        private void patients_DGV_FP_Click(object sender, DataGridViewCellEventArgs e)
        {
            //Updates logger 
            Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " Patient Selected");
            //string variables
            string patientID, date, time;
            //database variables
            DataSet dataSet;
            DataTable table;
            //selecting patient ID
            int selectedRowIndex = patients_DGV_FP.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = patients_DGV_FP.Rows[selectedRowIndex];
            patientID = selectedRow.Cells[0].Value.ToString();

            //converts date and time to strings 
            date = DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Day.ToString(); ;
            time = DateTime.Now.TimeOfDay.ToString();

            //pull and stores information about patient appointments
            dataSet = Connection.getDBConnectionInstance().selectPatentAppointment(patientID, date, time);
            table = dataSet.Tables[0];

            //display appoint to user 
            appointments_DGV_FP.DataSource = table;
            privatePatientID = patientID;
            if ((PrivatePatientFound == true) && (patients_DGV_FP.Rows.Count > 0))
            {

                medicalRecordViewer();
            }
        }

        #endregion

        #region Delete Appointment
        private void Cancel_FP_B_Click(object sender, EventArgs e)
        {
            //checks that there is an appointment to delete
            if ((appointments_DGV_FP.DataSource != null) && (appointments_DGV_FP.Rows.Count > 0))
            {
                //Updates logger 
                Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "Delete Appointment Button Clicked: Appointment Select for Deleting");
                //selected appointment
                int selectedRowIndex = appointments_DGV_FP.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = appointments_DGV_FP.Rows[selectedRowIndex];
                //strings variables
                string Selectedappointment = selectedRow.Cells[0].Value.ToString();

                //database variable 
                DataTable table;
                DataSet dataSet;

                //check that the user is sure they 
                if (MessageBox.Show("Do you cancel that appointment?", "Cancel Appointment",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Updates logger 

                    //delete selected appointment and shows returns remaining appointments 
                    dataSet = appointment.deleteAppointment(Selectedappointment);
                    //selects table 0
                    table = dataSet.Tables[0];

                    //output to the table
                    appointments_DGV_FP.DataSource = table;
                }
            }
            else
            {
                // If patient hasn't been selected
                error_FP_LBL.Text = "Patient and Appointment Required ";
                Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "Delete Appointment Button Clicked: NO Appointment Selected");
            }

        }
        #endregion

        #region Change Appointment

        private void changeAppointment_FP_B_Click(object sender, EventArgs e)
        {
            //checks to makes sure there is data to be selected
            if ((appointments_DGV_FP.DataSource != null) && (appointments_DGV_FP.Rows.Count > 0))
            {
                NewAppointment = false;
                AppointmentHeader_L_NA.Text = "Change Appointment";
                DataTable table;
                DataSet dataSet;
                DataRow dataRow;

                //selectappointmentID from selected row 
                int selectedRowIndex = appointments_DGV_FP.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = appointments_DGV_FP.Rows[selectedRowIndex];

                //strings variables
                privateAppointmentID = selectedRow.Cells[0].Value.ToString();

                //pulls the appointment from the appointment tabl
                dataSet = Connection.getDBConnectionInstance().selectAppointment(privateAppointmentID);

                //store the table
                table = dataSet.Tables[0];
                //stores first row in table
                dataRow = table.Rows[0];

                //pulls and stores values from the appointment table
                privateStaffID = dataRow.ItemArray.GetValue(0).ToString();
                privateDate = dataRow.ItemArray.GetValue(1).ToString();
                privateTime = dataRow.ItemArray.GetValue(2).ToString();

                //convert date into correct format and displays it in datetime picker
                appointmentDate_PCK_NA.Value = Convert.ToDateTime(privateDate);
                //display time in timepicker dropdown
                AppointmentTimes_CB_NA.Text = privateTime;

                //gets the staff type 
                dataSet = Connection.getDBConnectionInstance().selectStaffType(privateStaffID);

                //store the table
                table = dataSet.Tables[0];
                //stores first row in table
                dataRow = table.Rows[0];

                //gets the staff members job type
                privateStaffType = dataRow.ItemArray.GetValue(0).ToString();

                //stores and outputs staff type
                staffType_CB_NA.Text = privateStaffType;
                //outputs staff id 
                Staff_CB_NA.Text = privateStaffID;
                //opens Panel 
                appointmentPanel();
                //Updates logger 
                Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "Change Appointment Button Clicked: Loads Panel");

            }
            else
            {
                // If patient hasn't been selected
                error_FP_LBL.Text = "Patient Required";
                //Updates logger 
                Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "Change Appointment Button Clicked: Patient Required");
            }
        }
        private void confirmChangeAppointment(string staff, string date, string time)
        {
            //convert date into datatype
            DateTime Date = Convert.ToDateTime(date);
            //set date string to be validated
            date = Date.ToString();

            //checks user is changing appointment information
            if ((privateStaffID == staff) && (privateDate == date) && (privateTime == time))
            {
                //display message to user that appointment hasnt been changed
                MessageBox.Show("appointment hasnt changed click cancel to exit", "Change Appointment", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            else
            {
                //converts string onto correct format for storing 
                date = Date.Year.ToString() + "-" + Date.Month.ToString() + "-" + Date.Day.ToString(); ;
                //if user has enter all the correct information then it update appointment to the database

                //sets appointment information
                appointment.SetsAppointments(privatePatientID, staff, date, time);
                //sets appoinmentID to change
                appointment.SetAppointmentID(privateAppointmentID);
                //changes the appointment
                appointment.changeAppointment();

                errorMessage_LB_NA.Text = "Appointment Updated";
                //clears the window
                clearNewAppointment();
            }
        }
        #endregion

        #endregion
        #endregion

        #region Medical Record
        private void medicalRecordViewer()
        {
            //set data set 
            DataSet dataSet = Connection.getDBConnectionInstance().selectMedicalRecords(privatePatientID);
            // creates instace and set table 
            DataTable table = dataSet.Tables[0];
            medicalHistory_DVG_FP.DataSource = table;
            // make the datagrid read only
            medicalHistory_DVG_FP.ReadOnly = true;
            //Set the width of the grid to appropiet length
            medicalHistory_DVG_FP.Columns[0].Width = medicalHistory_DVG_FP.Width - 20;
        }

        private void newMedicalHistory_FP_B_Click(object sender, EventArgs e)
        {
            string medicalRecord;

            if ((addMedicalRecord_TB_FP.Text != "") && (PrivatePatientFound == true) && (patients_DGV_FP.Rows.Count > 0))
            {

                int selectedRowIndex = patients_DGV_FP.SelectedCells[0].RowIndex; //Select patient row
                DataGridViewRow selectedRow = patients_DGV_FP.Rows[selectedRowIndex]; // Show in Datagrid view
                privatePatientID = selectedRow.Cells[0].Value.ToString(); //Set the USerID to the selected row
                medicalRecord = addMedicalRecord_TB_FP.Text;


                //Adds medicalRecord to the database
                Connection.getDBConnectionInstance().addmedicalRecord(privatePatientID, medicalRecord);
                //Log for successfu ladding of medical record
                Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "\r\n Added Medical record- \r\n  PatientID:" + privatePatientID + "\r\n  Record Add successful?: Yes");
                medicalRecordViewer();
                addMedicalRecord_TB_FP.Clear(); //Clear Datagrid text box

            }
            else
            {
                Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "\r\n Added Medical record- \r\n  PatientID:" + privatePatientID + "\r\n  Record Add successful?: No");

            }

            #endregion
        }
    }
}