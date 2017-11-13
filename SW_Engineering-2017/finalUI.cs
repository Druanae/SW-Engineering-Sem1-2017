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
            private string privatePatientID;
            private bool PrivatePatientFound=false;
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
                mainMenuPanel.Location = new Point(0, 0);
                prescriptionPanel.Location = new Point(0, 0);
                testResultSearchPanel.Location = new Point(0, 0);
                staffScheduleSearchPanel.Location = new Point(0, 0);
                changeStaffSchedulePanel.Location = new Point(0, 0);
                newPatientPanel.Location = new Point(0, 0);
                findPatientPanel.Location = new Point(0, 0);
                editPatientPanel.Location = new Point(0, 0);
                newAppointmentPanel.Location = new Point(0, 0);
                loginPanel.Location = new Point(0, 0);
                newPatientPanel.Location = new Point(0, 0);
            }
            #endregion

        #endregion
       
        #region Login 

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
                            if (!mainMenuPanel.Visible) // if correct username and password go to menu page
                            {
                                loginErrorlbl.Visible = false;
                                mainMenuPanel.Visible = true;
                                loginPanel.Visible = false;
                                password_L_tb.Text = "";
                                userName_L_tb.Text = "";
                                break;
                            }
                        }
                        else
                            loginErrorlbl.Visible = true;
                        loginErrorlbl.Text = "Incorrect Username or Password";
                    }
                    else
                    {
                        loginErrorlbl.Visible = true; // return error if text isnt correct
                        loginErrorlbl.Text = "Incorrect Username or Password";
                    }
                }

            }
        }

        private void password_L_tb_TextChanged(object sender, EventArgs e)
        {
            //make the password hidden
            password_L_tb.PasswordChar = '*';
        }

        private void loginerrorlabel()
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

            public void clearNewAppointment()
            {
                //resets values for next time
                staffType_CB_NA.Text = "";
                Staff_CB_NA.Text = "";
                AppointmentTimes_CB_NA.Text = "";
                Staff_DGV_NA.DataSource = null;
                appointmentDate_PCK_NA.Value = DateTime.Today;
            }
            public void clearFindPatient()
            {
                //resets values for next time
                patientID_FP_TB.Text = "";
                firstName_FP_TB.Text = "";
                surname_FP_TB.Text = "";
                address_FP_TB.Text = "";
                findPatientCB.Text = "";
                PrivatePatientFound = false;
                patients_DGV_FP.DataSource = null;
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

            #endregion

        #endregion

        #region Patient

            #region Add Patient Code
            private void confirm_NP_BTN_Click(object sender, EventArgs e)
            {

                Validation val = new Validation();

                String firstname = firstName_NP_TB.Text, surname = surname_NP_TB.Text, addressLine = address_NP_TB.Text, townCity = townCity_NP_TB.Text, county = county_NP_TB.Text, postcode = postcode_NP_TB.Text, errorMessage = "";
                DateTime dob = dob_EP_PCK.Value;

                //Validates User inputs and stores results in errorMessage
                errorMessage += val.validateFirstname(firstname);
                errorMessage += val.validateSurname(surname);
                errorMessage += val.validateAddressLine(addressLine);
                errorMessage += val.validateTownCity(townCity);
                errorMessage += val.validateCounty(county);
                errorMessage += val.validatePostcode(postcode);

                //check if there are no error
                if (errorMessage == "")
                {
                    //Adds patient to the database
                    Connection.getDBConnectionInstance().addPatient(firstname, surname, dob, addressLine, townCity, county, postcode);

                    //set data set 
                    DataSet dataSet = Connection.getDBConnectionInstance().GetDataSet(Constants.selectAllPatients);

                    // creates instace and set table 
                    DataTable table = dataSet.Tables[0];

                    //selects row just added
                    DataRow dataRow = table.Rows[table.Rows.Count - 1];

                    //clears Text boxs and Datetime
                    firstName_NP_TB.Text = "";
                    surname_NP_TB.Text = "";
                    address_NP_TB.Text = "";
                    dob_NP_PCK.Value = DateTime.Today;
                    townCity_NP_TB.Text = "";
                    county_NP_TB.Text = "";
                    postcode_NP_TB.Text = "";

                    //displays to user that the Patient has been added and their ID
                    error_NP_L.Text = firstname + " " + surname + " was added to the system.\r\nTheir ID is:" + dataRow.ItemArray.GetValue(0).ToString();

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
                string temp_DOB, userID;
                if (PrivatePatientFound == true)
                {
                    int selectedRowIndex = patients_DGV_FP.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = patients_DGV_FP.Rows[selectedRowIndex];
                    userID = selectedRow.Cells[0].Value.ToString();

                    DataTable table;
                    DataSet dataSet;
                    DataRow dataRow;
                    dataSet = Connection.getDBConnectionInstance().selectPatientByID(userID);
                    table = dataSet.Tables[0];
                    patients_DGV_FP.DataSource = table;
                    dataRow = table.Rows[0];

                    temp_DOB = dataRow.ItemArray.GetValue(3).ToString();


                    privatePatientID = userID;
                    firstName_EP_TB.Text = dataRow.ItemArray.GetValue(1).ToString();
                    surname_EP_TB.Text = dataRow.ItemArray.GetValue(2).ToString();

                    dob_EP_PCK.Value = Convert.ToDateTime(dataRow.ItemArray.GetValue(3).ToString());

                    address_EP_TB.Text = dataRow.ItemArray.GetValue(4).ToString();
                    townCity_EP_TB.Text = dataRow.ItemArray.GetValue(5).ToString();
                    county_EP_TB.Text = dataRow.ItemArray.GetValue(6).ToString();
                    postcode_EP_TB.Text = dataRow.ItemArray.GetValue(7).ToString();
                    if (!editPatientPanel.Visible)
                    {
                        editPatientPanel.Visible = true;
                        findPatientPanel.Visible = false;
                        clearFindPatient();
                    }
                }
                else
                {
                    error_FP_LBL.Text = "Patient Required";
                }



            }

            private void cancel_EP_B_Click(object sender, EventArgs e)
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

                Validation val = new Validation();

                String firstname = firstName_EP_TB.Text, surname = surname_EP_TB.Text, addressLine = address_EP_TB.Text, townCity = townCity_EP_TB.Text, county = county_EP_TB.Text, postcode = postcode_EP_TB.Text, errorMessage = "";
                DateTime dob = dob_EP_PCK.Value;

                //Validates User inputs and stores results in errorMessage
                errorMessage += val.validateFirstname(firstname);
                errorMessage += val.validateSurname(surname);
                errorMessage += val.validateAddressLine(addressLine);
                errorMessage += val.validateTownCity(townCity);
                errorMessage += val.validateCounty(county);
                errorMessage += val.validatePostcode(postcode);

                //check if there are no error
                if (errorMessage == "")
                {
                    //Adds patient to the database
                    Connection.getDBConnectionInstance().updatePatient(privatePatientID, firstname, surname, dob, addressLine, townCity, county, postcode);

                    error_EP_L.Text = "Patient infomation Updated";
                    clearEditPatient();
                }
                else
                {
                    //display input errors to user
                    error_EP_L.Text = errorMessage;
                }

            }

            #endregion

            #region  Find patient

            private void find_FP_BT_Click(object sender, EventArgs e)
            {
                Validation val = new Validation();
                string PatientID = patientID_FP_TB.Text, firstname = firstName_FP_TB.Text, surname = surname_FP_TB.Text, AdressLine = address_FP_TB.Text, errormessage = "";
                int PatientId;
                DateTime dob = dob_FP_TB.Value;
                DataTable table; DataSet dataSet;

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

        #endregion

        #region Appointment

            #region New Appointment
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
            }
            else
            {
                //set data set to all Nurse
                dataSet = Connection.getDBConnectionInstance().GetDataSet(Constants.selectAllNurseAppointment);

            }
            //sets the table equal to the data set
            table = dataSet.Tables[0];
            //stores the number of rows
            numRows = table.Rows.Count - 1;
            //clear Staff selection combobox
            Staff_CB_NA.Items.Clear();

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
                errorMessage_LB_NA.Text = "There are no more Appointments Today";
            }

        }

        private void newAppointment_FP_B_Click(object sender, EventArgs e)
        {
            //check there is patient infomation found
            if (PrivatePatientFound == true)
            {
                int selectedRowIndex = patients_DGV_FP.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = patients_DGV_FP.Rows[selectedRowIndex];
                privatePatientID = selectedRow.Cells[0].Value.ToString();
                PatientID_LB_NA.Text = "PatientID:" + privatePatientID;
                errorMessage_LB_NA.Text = "";

                //opens Panel 
                if (!newAppointmentPanel.Visible)
                {
                    newAppointmentPanel.Visible = true;
                    findPatientPanel.Visible = false;
                }
                clearFindPatient();
            }
            else
            {
                error_FP_LBL.Text = "Patient Required";
            }

        }

        private void Back_BT_NA_Click(object sender, EventArgs e)
        {
            clearNewAppointment();
            if (!findPatientPanel.Visible)
            {
                newAppointmentPanel.Visible = false;
                findPatientPanel.Visible = true;
            }
        }

        private void Confirm_BT_NA_Click(object sender, EventArgs e)
        {
            //strings 
            string staffType = staffType_CB_NA.Text,staff = Staff_CB_NA.Text, appointmentTime = AppointmentTimes_CB_NA.Text;
            string appointmentDate = appointmentDate_PCK_NA.Value.Year.ToString() + "-" + appointmentDate_PCK_NA.Value.Month.ToString() + "-" + appointmentDate_PCK_NA.Value.Day.ToString();

            //validation 
            if (staffType != "")
            {
                if (staff != "")
                {
                    if (appointmentTime != "")
                    {
                       
                        Connection.getDBConnectionInstance().addAppointment(privatePatientID,staff, appointmentDate, appointmentTime);
                        errorMessage_LB_NA.Text = "Appointment added";
                        //clears the window
                        clearNewAppointment();

                    }
                    else
                    {
                        errorMessage_LB_NA.Text = "time needs to be Selected";
                    }


                }
                else
                {
                    errorMessage_LB_NA.Text = "staff needs to be Selected";
                }

            }
            else
            {
                errorMessage_LB_NA.Text = "staff Type needs to be Selected";
            }
        }



        #endregion

            #region Load Appointment
            
            #endregion

        #endregion
    }
}
