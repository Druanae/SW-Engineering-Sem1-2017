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
        public finalUI()
        {
            InitializeComponent();
            mainMenuPanel.Visible = false;
            prescriptionPanel.Visible = false;
            testResultSearchPanel.Visible = false;
            staffScheduleSearchPanel.Visible = false;
            changeStaffSchedulePanel.Visible = false;
            newPatientPanel.Visible = false;   
            findPatientPanel.Visible = false;
            editPatientPanel.Visible = false;
            newAppointmentPanel.Visible = false;
        }

        private void finalUI_Load(object sender, EventArgs e)
        {
            dob_NP_PCK.MaxDate= DateTime.Today;
            dob_NP_PCK.Value = DateTime.Today;

            Connection.getDBConnectionInstance().openConnection();
            /*
            //opens the database connection
            

            //set data set 
            DataSet dataSet = Connection.getDBConnectionInstance().GetDataSet(Constants.selectAllPatients);

            // creates instace and set table 
            DataTable table = dataSet.Tables[0];

            DGV.DataSource = table;
            */
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


        private void confirm_NP_BTN_Click(object sender, EventArgs e)
        {

            Validation val = new Validation();

            String firstname = firstName_NP_TB.Text, surname = surname_NP_TB.Text, addressLine = address_NP_TB.Text, townCity= townCity_NP_TB.Text, county= county_NP_TB.Text, postcode = postcode_NP_TB.Text, errorMessage="";
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
                DataRow dataRow = table.Rows[table.Rows.Count-1];

                //clears Text boxs and Datetime
                firstName_NP_TB.Text = "";
                surname_NP_TB.Text = "";
                address_NP_TB.Text = "";
                dob_NP_PCK.Value = DateTime.Today;
                townCity_NP_TB.Text = "";
                county_NP_TB.Text = "";
                postcode_NP_TB.Text = "";

                //displays to user that the Patient has been added and their ID
                error_NP_L.Text= firstname + " " +surname + " was added to the system.\r\nTheir ID is:" + dataRow.ItemArray.GetValue(0).ToString(); ;

            }
            else
            {
                //display input errors to user
                error_NP_L.Text = errorMessage;
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (!mainMenuPanel.Visible)
            {
                mainMenuPanel.Visible = true;
                loginPanel.Visible = false;
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
            if (!findPatientPanel.Visible)
            {
                findPatientPanel.Visible = true;
                editPatientPanel.Visible = false;
            }
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

    }
}
