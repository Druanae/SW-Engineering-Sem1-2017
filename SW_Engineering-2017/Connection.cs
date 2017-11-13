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
        //private string for the connection
        private static string connectionString;

        //object that is used to store the connection to the database
        private SqlConnection connectionToDatabase;

        //used to open and change tables in the database
        private SqlDataAdapter dataAdapter;

        private static Connection _instance;
       

        //methods
        public static Connection getDBConnectionInstance()
        {
            connectionString = Properties.Settings.Default.Connection;
            if (_instance == null)
                _instance = new Connection();

            return _instance;
        }


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
            //runs the SQL code
            
            //close connection 
            
            //creates an object to minipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(command);

            //creates the dataset
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            //return the dataSet
            return dataSet;

        }
        public DataSet staffDateView(string StaffID,string date)
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
            //runs the SQL code

            //close connection 

            //creates an object to minipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(command);

            //creates the dataset
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            //return the dataSet
            return dataSet;
        }
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
            //runs the SQL code

            //close connection 

            //creates an object to minipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(command);

            //creates the dataset
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            //return the dataSet
            return dataSet;
        }
        public DataSet selectPatientByDOB(string firstname,string surname,string dob)
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
            //runs the SQL code

            //close connection 

            //creates an object to minipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(command);

            //creates the dataset
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            //return the dataSet
            return dataSet;
        }
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
            //runs the SQL code

            //close connection 

            //creates an object to minipulate a table in the database using the connection
            dataAdapter = new SqlDataAdapter(command);

            //creates the dataset
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            //return the dataSet
            return dataSet;
        }
        public void updatePatient(string patientID, string firstname, string surname, DateTime dob, string addressLine, string townCity, string county, string postcode)
        {
            //creates SQL command
            SqlCommand command = new SqlCommand();
            //sets command type to text
            command.CommandType = CommandType.Text;
            //sets the command text to constants insertNewPatient
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


       // "INSERT INTO [dbo].[Appointments] ([Patient_ID], [Staff_ID], [Date], [Time]) VALUES (@patientID,@staffID,@date , @time)"


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
    }

}