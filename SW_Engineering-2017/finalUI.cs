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
        private string privatePatientID;
        public finalUI()
        {
            InitializeComponent();
            mainMenuPanel.Visible = false;
            mainMenuPanel.Location = new Point(15, 15);
            prescriptionPanel.Visible = false;
            testResultSearchPanel.Visible = false;
            staffScheduleSearchPanel.Visible = false;
            changeStaffSchedulePanel.Visible = false;
            newPatientPanel.Visible = false;
            findPatientPanel.Visible = false;
            editPatientPanel.Visible = false;
            newAppointmentPanel.Visible = false;
            loginErrorlbl.Visible = false;
        }
        private void finalUI_Load(object sender, EventArgs e)
        {
            dob_NP_PCK.MaxDate = DateTime.Today;
            dob_NP_PCK.Value = DateTime.Today;

            Connection.getDBConnectionInstance().openConnection();

            //opens the database connection


            //set data set 
            DataSet dataSet = Connection.getDBConnectionInstance().GetDataSet(Constants.selectingLogin);

            // creates instace and set table 
            DataTable table = dataSet.Tables[0];

            //DVG.DataSource = table;
            //DataRow dataRow = table.Rows[table.Rows.Count - 1];
            //testlbl.Text = dataRow.ItemArray.GetValue(1).ToString();

        }


        private void fillInFields(DataTable table, int index)
        {
            /*fills out the UI for information form the table*/
            //dataRow.ItemArray.GetValue(0).ToString();
        }

        private void finalUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            //close database connection 
            Connection.getDBConnectionInstance().closeConnection();
        }

        /****************************** Login Section *****************************************************/

        private void loginBtn_Click(object sender, EventArgs e)
        {

            DataSet dataSet = Connection.getDBConnectionInstance().GetDataSet(Constants.selectingLogin);
            // creates instace and set table 
            DataTable table = dataSet.Tables[0];
            //selects row just added
            DataRow dataRow = table.Rows[table.Rows.Count - 1];
            //Var for special characters//
            int dataRowlogin = table.Rows.Count - 1;

            string loginID = userName_L_tb.Text;
            string loginPassword = password_L_tb.Text;

            if (loginID == "" || loginPassword == "") // Checks for empty login or password
            {
                loginerrorlabel(); //Error message for having nothing in either text box.
            }
            if (loginID.Contains("SELECT") || loginID.Contains("select") || loginID.Contains("WHERE") || loginID.Contains("where")) //Small check for SQL injection
            {
                loginerrorlabel();
            }

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
            loginErrorlbl.Text = "Please fill in username and password correctly.";
        }
        /************************* Add Patient Section *************************************************/
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
            if (!findPatientPanel.Visible)
            {
                findPatientPanel.Location = new Point(15, 15);
                findPatientPanel.Visible = true;
                mainMenuPanel.Visible = false;
            }
        }
        private void testResultsBtn_Click(object sender, EventArgs e)
        {
            if (!testResultSearchPanel.Visible)
            {
                testResultSearchPanel.Location = new Point(15, 15);
                testResultSearchPanel.Visible = true;
                mainMenuPanel.Visible = false;
            }
        }
        private void scheduleBtn_Click(object sender, EventArgs e)
        {
            if (!staffScheduleSearchPanel.Visible)
            {
                staffScheduleSearchPanel.Location = new Point(15, 15);
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
        private void btnPresMenu_Click(object sender, EventArgs e)
        {
            if (!mainMenuPanel.Visible)
            {
                prescriptionPanel.Visible = false;
                mainMenuPanel.Visible = true;
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
        private void MenuTestBNTRS_Click(object sender, EventArgs e)
        {
            if (!mainMenuPanel.Visible)
            {
                testResultSearchPanel.Visible = false;
                mainMenuPanel.Visible = true;
            }
        }
        private void MenuBNTSSS_Click(object sender, EventArgs e)
        {
            if (!mainMenuPanel.Visible)
            {
                staffScheduleSearchPanel.Visible = false;
                mainMenuPanel.Visible = true;
            }
        }
        private void MenuBNTCSS_Click(object sender, EventArgs e)
        {
            if (!mainMenuPanel.Visible)
            {
                changeStaffSchedulePanel.Visible = false;
                mainMenuPanel.Visible = true;
            }
        }
        private void mainMenu_FP_BT_Click(object sender, EventArgs e)
        {
            if (!mainMenuPanel.Visible)
            {

                findPatientPanel.Visible = false;
                mainMenuPanel.Visible = true;
            }
        }
        private void edit_FP_B_Click(object sender, EventArgs e)
        {
            string temp_DOB;

            string userID = Convert.ToString(patients_DGV_FP.CurrentCell.Value);
            error_FP_LBL.Text = Convert.ToString(patients_DGV_FP.CurrentCell.Value);

            DataTable table;
            DataSet dataSet;
            DataRow dataRow;
            dataSet = Connection.getDBConnectionInstance().selectPatientByID(userID);
            table = dataSet.Tables[0];
            patients_DGV_FP.DataSource = table;
            dataRow = table.Rows[0];

            temp_DOB = dataRow.ItemArray.GetValue(3).ToString();

            //error_EP_L.Text = temp_DOB;
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
                 editPatientPanel.Location = new Point(15, 15);
                 editPatientPanel.Visible = true;
                 findPatientPanel.Visible = false;

             }
             
        }
        private void cancel_EP_B_Click(object sender, EventArgs e)
        {
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
            }
            else
            {
                //display input errors to user
                error_EP_L.Text = errorMessage;
            }
            /*if (!findPatientPanel.Visible)
            {
                findPatientPanel.Visible = true;
                editPatientPanel.Visible = false;
            }
            */
        }
        private void newAppointment_FP_B_Click(object sender, EventArgs e)
        {
            if (!newAppointmentPanel.Visible)
            {
                newAppointmentPanel.Location = new Point(15, 15);
                newAppointmentPanel.Visible = true;
                findPatientPanel.Visible = false;
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            if (!findPatientPanel.Visible)
            {
                newAppointmentPanel.Visible = false;
                findPatientPanel.Visible = true;
            }
        }
        private void newPrescriptions_FP_B_Click(object sender, EventArgs e)
        {
            if (!prescriptionPanel.Visible)
            {
                prescriptionPanel.Location = new Point(15, 15);
                prescriptionPanel.Visible = true;
                findPatientPanel.Visible = false;
            }
        }
        private void addPatientBTN_Click(object sender, EventArgs e)
        {
            if (!newPatientPanel.Visible)
            {
                newPatientPanel.Location = new Point(15, 15);
                newPatientPanel.Visible = true;
                mainMenuPanel.Visible = false;
            }
        }
        private void cancel_NP_BTN_Click(object sender, EventArgs e)
        {
            if (!mainMenuPanel.Visible)
            {
                newPatientPanel.Visible = false;
                mainMenuPanel.Visible = true;
            }
        }
        private void find_FP_BT_Click(object sender, EventArgs e)
        {
            string patientID = patientID_FP_TB.Text, firstname = firstName_FP_TB.Text, surname = surname_FP_TB.Text, address = address_FP_TB.Text;
            DateTime DTdob = dob_FP_TB.Value;
            string dob = DTdob.Year.ToString() + "-" + DTdob.Month.ToString() + "-" + DTdob.Day.ToString();


            if (patientID != "")
            {
                DataTable table;
                DataSet dataSet;

                dataSet = Connection.getDBConnectionInstance().selectPatientByID(patientID);
                table = dataSet.Tables[0];
                patients_DGV_FP.DataSource = table;
            }
            else if ((firstname != "") && (surname != "") && (dob != ""))
            {
                DataTable table;
                DataSet dataSet;

                dataSet = Connection.getDBConnectionInstance().selectPatientByDOB(firstname, surname, dob);
                table = dataSet.Tables[0];
                patients_DGV_FP.DataSource = table;
            }
            else if ((firstname != "") && (surname != "") && (address != ""))
            {
                DataTable table;
                DataSet dataSet;

                dataSet = Connection.getDBConnectionInstance().selectPatientByAddress(firstname, surname, address);
                table = dataSet.Tables[0];
                patients_DGV_FP.DataSource = table;
            }

        }
       
    }
}
