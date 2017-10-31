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

        private static Connection _instance;

        //object that is used to store the connection to the database
        private SqlConnection connectionToDatabase;

        //used to open and change tables in the database
        private SqlDataAdapter dataAdapter;


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


        public void AddPatient( String firstname, String surname, DateTime dob, String address, String townCity, String county, String postcode)
        {
            
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;

            
            command.CommandText = "INSERT INTO Patients (Firstname, Surname, DOB, AddressLine, TownCity, County, Postcode) VALUES (@Firstname,@Surname,@DOB,@AddressLine,@TownCity,@County,@Postcode)";
            command.Parameters.Add(new SqlParameter("Firstname", firstname));
            command.Parameters.Add(new SqlParameter("Surname", surname));
            command.Parameters.Add(new SqlParameter("DOB", dob ));
            command.Parameters.Add(new SqlParameter("AddressLine", address));
            command.Parameters.Add(new SqlParameter("TownCity", townCity));
            command.Parameters.Add(new SqlParameter("County", county));
            command.Parameters.Add(new SqlParameter("Postcode", postcode));

            openConnection();

            command.Connection = connectionToDatabase;

            int noRows = command.ExecuteNonQuery();

            closeConnection();

            Console.WriteLine("n-" + noRows);

        }
    }

}