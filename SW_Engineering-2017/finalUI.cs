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
        //creates instance of Connection and DataSet
        Connection databaseCon;
        DataSet dataSet;


        private void finalUI_Load(object sender, EventArgs e)
        {
            //set the connection string
            string connectionString = Properties.Settings.Default.Connection;

            //sends connection string to the database 
            databaseCon = new Connection(connectionString);

            //opens the database connection
            databaseCon.openConnection();

            //set data set 
            dataSet = databaseCon.GetDataSet(Constants.selectAll);

            // creates instace and set table 
            DataTable table = dataSet.Tables[0];

            //calls fillInField
            fillInFields(table, 1);


        }

        private void fillInFields(DataTable table, int index)
        {
            /*fills out the UI for information form the table*/
            //dataRow.ItemArray.GetValue(0).ToString();
        }

        private void finalUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            //close database connection 
            databaseCon.closeConnection();
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
                prescriptionPanel.Visible = true;
                findPatientPanel.Visible = false;
            }
        }
    }
}
