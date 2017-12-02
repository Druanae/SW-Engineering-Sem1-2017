using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_Engineering_2017
{
    class Connection
    {
        #region Private Variables
        //private string for the connection
        private static string connectionString;

        //object that is used to store the connection to the database
        private SqlConnection connectionToDatabase;

        //used to open and change tables in the database
        private SqlDataAdapter dataAdapter;

        private static Connection _instance;
        #endregion

        #region Instance
        //methods
        public static Connection getDBConnectionInstance()
        {
            connectionString = Properties.Settings.Default.Connection;
            if (_instance == null)
                _instance = new Connection();

            return _instance;
        }
        #endregion

        #region Connection 
        public void openConnection()
        {
            //creates the connection to the database
            connectionToDatabase = new SqlConnection(connectionString);

            //opens the connection to the database
            connectionToDatabase.Open();
        }

        public void closeConnection()
        {
            //close the connection to the database
            connectionToDatabase.Close();
        }
        #endregion

        #region getDataSet
        public DataSet GetDataSet(string sqlStatement)
        {
            DataSet dataSet;

            //creates an object to minipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(sqlStatement, connectionToDatabase);

            //creates the dataset
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            //return the dataSet
            return dataSet;
        }
        #endregion

        #region Patient
        #region Add Patient
        public void addPatient(string firstname, string surname, DateTime dob, string addressLine, string townCity, string county, string postcode)
        {
            //creates SQL command
            SqlCommand command = new SqlCommand();
            //sets command type to text
            command.CommandType = CommandType.Text;
            //sets the command text to constants insertNewPatient
            command.CommandText = Constants.insertNewPatient;
            //adds the values into the database
            command.Parameters.Add(new SqlParameter("Firstname", firstname));
            command.Parameters.Add(new SqlParameter("Surname", surname));
            command.Parameters.Add(new SqlParameter("DOB", dob));
            command.Parameters.Add(new SqlParameter("AddressLine", addressLine));
            command.Parameters.Add(new SqlParameter("TownCity", townCity));
            command.Parameters.Add(new SqlParameter("County", county));
            command.Parameters.Add(new SqlParameter("Postcode", postcode));

            //opens connection
            openConnection();
            //sets the connection
            command.Connection = connectionToDatabase;
            //runs the SQL code
            command.ExecuteNonQuery();
            //close connection 
            closeConnection();
        }
        #endregion

        #region Select Patient by ID
        public DataSet selectPatientByID(string patientID)
        {

            DataSet dataSet;
            //creates SQL command
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.Text;
            //sets the command text 
            command.CommandText = Constants.selectPatientByID;
            //adds the values into the database
            command.Parameters.Add(new SqlParameter("patientID", patientID));
            //opens connection
            openConnection();
            //sets the connection
            command.Connection = connectionToDatabase;

            //creates an object to minipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(command);

            //creates the dataset
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            //return the dataSet
            return dataSet;
        }
        #endregion

        #region Select Patient by Date of Birth
        public DataSet selectPatientByDOB(string firstname, string surname, string dob)
        {

            DataSet dataSet;
            //creates SQL command
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.Text;
            //sets the command text 
            command.CommandText = Constants.selectPatientByDOB;
            //adds the values into the database
            command.Parameters.Add(new SqlParameter("Firstname", firstname));
            command.Parameters.Add(new SqlParameter("Surname", surname));
            command.Parameters.Add(new SqlParameter("DOB", dob));
            //opens connection
            openConnection();
            //sets the connection
            command.Connection = connectionToDatabase;


            //creates an object to minipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(command);

            //creates the dataset
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            //return the dataSet
            return dataSet;
        }
        #endregion

        #region Select Patient By Address
        public DataSet selectPatientByAddress(string firstname, string surname, string address)
        {
            DataSet dataSet;
            //creates SQL command
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.Text;
            //sets the command text 
            command.CommandText = Constants.selectPatientByAddress;
            //adds the values into the database
            command.Parameters.Add(new SqlParameter("Firstname", firstname));
            command.Parameters.Add(new SqlParameter("Surname", surname));
            command.Parameters.Add(new SqlParameter("address", address));
            //opens connection
            openConnection();
            //sets the connection
            command.Connection = connectionToDatabase;


            //creates an object to minipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(command);

            //creates the dataset
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            //return the dataSet
            return dataSet;
        }
        #endregion

        #region UpdatePatient
        public void updatePatient(string patientID, string firstname, string surname, DateTime dob, string addressLine, string townCity, string county, string postcode)
        {
            //creates SQL command
            SqlCommand command = new SqlCommand();
            //sets command type to text
            command.CommandType = CommandType.Text;
            //sets the command text to constants updatePatient
            command.CommandText = Constants.updatePatient;
            //adds the values into the database
            command.Parameters.Add(new SqlParameter("patientID", patientID));
            command.Parameters.Add(new SqlParameter("Firstname", firstname));
            command.Parameters.Add(new SqlParameter("Surname", surname));
            command.Parameters.Add(new SqlParameter("DOB", dob));
            command.Parameters.Add(new SqlParameter("AddressLine", addressLine));
            command.Parameters.Add(new SqlParameter("TownCity", townCity));
            command.Parameters.Add(new SqlParameter("County", county));
            command.Parameters.Add(new SqlParameter("Postcode", postcode));

            //opens connection
            openConnection();
            //sets the connection
            command.Connection = connectionToDatabase;
            //runs the SQL code
            command.ExecuteNonQuery();
            //close connection 
            closeConnection();
        }
        #endregion

        #endregion

        #region Staff
        #region Select Staff by ID
        public DataSet staffView(string StaffID)
        {

            DataSet dataSet;
            //creates SQL command
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.Text;
            //sets the command text 
            command.CommandText = Constants.selectStaffMember;
            //adds the values into the database
            command.Parameters.Add(new SqlParameter("StaffID", StaffID));

            //opens connection
            openConnection();
            //sets the connection
            command.Connection = connectionToDatabase;


            //creates an object to minipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(command);

            //creates the dataset
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            //return the dataSet
            return dataSet;

        }
        #endregion

        #region Staff Member dates
        public DataSet staffDateView(string StaffID, string date)
        {

            DataSet dataSet;
            //creates SQL command
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.Text;
            //sets the command text 
            command.CommandText = Constants.selectTime;
            //adds the values into the database
            command.Parameters.Add(new SqlParameter("StaffID", StaffID));
            command.Parameters.Add(new SqlParameter("Date", date));
            //opens connection
            openConnection();
            //sets the connection
            command.Connection = connectionToDatabase;


            //creates an object to minipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(command);

            //creates the dataset
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            //return the dataSet
            return dataSet;
        }
        #endregion

        #region Select Staff Type
        public DataSet selectStaffType(string StaffID)
        {

            DataSet dataSet;
            //creates SQL command
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.Text;
            //sets the command text 
            command.CommandText = Constants.selectStaffType;
            //adds the values into the database
            command.Parameters.Add(new SqlParameter("StaffID", StaffID));
            //opens connection
            openConnection();
            //sets the connection
            command.Connection = connectionToDatabase;


            //creates an object to minipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(command);

            //creates the dataset
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            //return the dataSet
            return dataSet;
        }
        #endregion

        #endregion

        #region Appointment
        #region Add Appointment
        public void addAppointment(string patientID, string staffID, string date, string time)
        {
            //creates SQL command
            SqlCommand command = new SqlCommand();
            //sets command type to text
            command.CommandType = CommandType.Text;
            //sets the command text to constants insertNewPatient
            command.CommandText = Constants.AddAppointment;
            //adds the values into the database
            command.Parameters.Add(new SqlParameter("patientID", patientID));
            command.Parameters.Add(new SqlParameter("staffID", staffID));
            command.Parameters.Add(new SqlParameter("date", date));
            command.Parameters.Add(new SqlParameter("time", time));


            //opens connection
            openConnection();
            //sets the connection
            command.Connection = connectionToDatabase;
            //runs the SQL code
            command.ExecuteNonQuery();
            //close connection 
            closeConnection();
        }
        #endregion

        #region Update Appointment
        public void UpdateAppointment(string appointmentID, string staffID, string date, string time)
        {
            //creates SQL command
            SqlCommand command = new SqlCommand();
            //sets command type to text
            command.CommandType = CommandType.Text;
            //sets the command text to constants insertNewPatient
            command.CommandText = Constants.UpdateAppointment;
            //adds the values into the database
            command.Parameters.Add(new SqlParameter("appointmentID", appointmentID));
            command.Parameters.Add(new SqlParameter("staffID", staffID));
            command.Parameters.Add(new SqlParameter("date", date));
            command.Parameters.Add(new SqlParameter("time", time));


            //opens connection
            openConnection();
            //sets the connection
            command.Connection = connectionToDatabase;
            //runs the SQL code
            command.ExecuteNonQuery();
            //close connection 
            closeConnection();
        }
        #endregion

        #region Select Appointment by AppointmentID
        public DataSet selectAppointment(string appointmentID)
        {
            DataSet dataSet;
            //creates SQL command
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.Text;
            //sets the command text 
            command.CommandText = Constants.selectAppointment;
            //adds the values into the database
            command.Parameters.Add(new SqlParameter("appointmentID", appointmentID));
            //opens connection
            openConnection();
            //sets the connection
            command.Connection = connectionToDatabase;


            //creates an object to minipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(command);

            //creates the dataset
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            //return the dataSet
            return dataSet;

        }
        #endregion#region Select Patient Appointment

        #region Select Patient Appointment
        public DataSet selectPatentAppointment(string patientID, string date, string time)
        {
            DataSet dataSet;
            //creates SQL command
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.Text;
            //sets the command text 
            command.CommandText = Constants.selectPatientAppointment;
            //adds the values into the database
            command.Parameters.Add(new SqlParameter("patientID", patientID));
            command.Parameters.Add(new SqlParameter("date", date));
            command.Parameters.Add(new SqlParameter("time", time));
            //opens connection
            openConnection();
            //sets the connection
            command.Connection = connectionToDatabase;


            //creates an object to minipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(command);

            //creates the dataset
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            //return the dataSet
            return dataSet;

        }
        #endregion

        #region Delete Appointment
        public void selectDeleteAppointment(string appointmentID)
        {
            //creates SQL command
            SqlCommand command = new SqlCommand();
            //sets command type to text
            command.CommandType = CommandType.Text;
            //sets the command text to constants insertNewPatient
            command.CommandText = Constants.deleteAppointment;
            //adds the values into the database
            command.Parameters.Add(new SqlParameter("appointmentID", appointmentID));

            //opens connection
            openConnection();
            //sets the connection
            command.Connection = connectionToDatabase;
            //runs the SQL code
            command.ExecuteNonQuery();
            //close connection 
            closeConnection();
        }
        #endregion

        #endregion

        #region Medical Records

        #region Add Medical Record
        public void addmedicalRecord(string patientID, string medicalRecord)
        {
            //creates SQL command
            SqlCommand command = new SqlCommand();
            //sets command type to text
            command.CommandType = CommandType.Text;
            //sets the command text to constants insertNewPatient
            command.CommandText = Constants.addMedicalRecord;
            //adds the values into the database
            command.Parameters.Add(new SqlParameter("patientID", patientID));
            command.Parameters.Add(new SqlParameter("medicalRecords", medicalRecord));

            //opens connection
            openConnection();
            //sets the connection
            command.Connection = connectionToDatabase;
            //runs the SQL code
            command.ExecuteNonQuery();
            //close connection 
            closeConnection();
        }
        #endregion

        #region Select Medical Records
        public DataSet selectMedicalRecords(string patientID)
        {
            DataSet dataSet;
            //creates SQL command
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.Text;
            //sets the command text 
            command.CommandText = Constants.selectMedicalRecord;
            //adds the values into the database
            command.Parameters.Add(new SqlParameter("patientID", patientID));
            //opens connection
            openConnection();
            //sets the connection
            command.Connection = connectionToDatabase;

            //creates an object to minipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(command);

            //creates the dataset
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            //return the dataSet
            return dataSet;
        }
        #endregion

        #endregion

        #region Prescriptions

        public DataSet getAllPrescriptions(string patientID)
        {
            // Creates an empty DataSet variable
            DataSet dataSet;

            // Create SQL Command
            SqlCommand command = new SqlCommand();

            // Set the command type to text
            command.CommandType = CommandType.Text;
            // Set the command text
            command.CommandText = Constants.selectAllPrescriptions;
            // Adds the values to the command parameters
            command.Parameters.Add(new SqlParameter("patientID", patientID));

            // Open database connection
            openConnection();
            // Set the connection
            command.Connection = connectionToDatabase;

            // create an object to manipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(command);

            // Create the DataSet and fill it with data
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            // Return the data
            return dataSet;
        }

        public DataSet getPrescriptions(string patientID)
        {
            // Creates an empty DataSet variable
            DataSet dataSet;

            // Create SQL Command
            SqlCommand command = new SqlCommand();

            // Set the command type to text
            command.CommandType = CommandType.Text;
            // Set the command text
            command.CommandText = Constants.selectPrescriptions;
            // Adds the values to the command parameters
            command.Parameters.Add(new SqlParameter("patientID", patientID));

            // Open database connection
            openConnection();
            // Set the connection
            command.Connection = connectionToDatabase;

            // create an object to manipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(command);

            // Create the DataSet and fill it with data
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            // Return the data
            return dataSet;
        }
        #region Select Prescription by Prs_ID
        public DataSet selectPrescriptionByID(string prescriptionID)
        {
            // Creates an empty DataSet variable
            DataSet dataSet;

            // Create SQL Command
            SqlCommand command = new SqlCommand();

            // Set the command type to text
            command.CommandType = CommandType.Text;
            // Set the command text
            command.CommandText = Constants.selectPrescriptionByID;
            // Adds the values to the command parameters
            command.Parameters.Add(new SqlParameter("prescriptionID", prescriptionID));

            // Open database connection
            openConnection();
            // Set the connection
            command.Connection = connectionToDatabase;

            // create an object to manipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(command);

            // Create the DataSet and fill it with data
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            // Return the data
            return dataSet;
        }

        #endregion
        public void addPrescription(string patientID, string staffID, string name, string dosage, string date, string duration, string notes)
        {
            // Creates SQL Command
            SqlCommand command = new SqlCommand();
            // Sets command type to text
            command.CommandType = CommandType.Text;
            // Sets the command text to the value of constants.AddPrescription
            command.CommandText = Constants.AddPrescription;
            // Adds the values to the command parameters
            command.Parameters.Add(new SqlParameter("patientID", patientID));
            command.Parameters.Add(new SqlParameter("staffID", staffID));
            command.Parameters.Add(new SqlParameter("name", name));
            command.Parameters.Add(new SqlParameter("dosage", dosage));
            command.Parameters.Add(new SqlParameter("date", date));
            command.Parameters.Add(new SqlParameter("duration", duration));
            command.Parameters.Add(new SqlParameter("notes", notes));

            // Open database connection
            openConnection();
            // Set the connection
            command.Connection = connectionToDatabase;
            // Run the SQL command
            command.ExecuteNonQuery();
            // Close database connection
            closeConnection();
        }

        #endregion
    }
}