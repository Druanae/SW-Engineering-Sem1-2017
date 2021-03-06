﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SW_Engineering_2017
{
    class Patient
    {
        private static Patient _instance;
        private string Firstname;
        private string Surname;
        private DateTime DOB;
        private string AddressLine;
        private string TownCity;
        private string County;
        private string Postcode;
        private string PatientID;

        public static Patient instance
        {
            get
            {
                if (_instance == null)
                {
                    //create instance of self unless it already exists
                    _instance = new Patient();

                }
                return _instance;
            }
        }
        public void setPatientInfo(string firstname, string surname, DateTime dob, string addressLine, string townCity, string county, string postcode)
        {
            //set private variables to valid inputs
            Firstname = firstname;
            Surname = surname;
            DOB=dob;
            AddressLine = addressLine;
            TownCity= townCity;
            County= county;
            Postcode = postcode;
        }
        public void setPatientID(string patientID)
        {

            PatientID = patientID;
        }

        public string addPatient()
        {
            //Adds patient to the database
            Connection.getDBConnectionInstance().addPatient(Firstname, Surname, DOB, AddressLine, TownCity, County, Postcode);

            //Updates logger 
            Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + "Patient added\r\nFirstname: " + Firstname + "\r\nSurname: " + Surname + "\r\nDOB: " + DOB + "\r\nAddress: " + AddressLine + "\r\nTownCity: " + TownCity + "\r\nCounty: " + County + "\r\nPostcode: " + Postcode);

            //set data set 
            DataSet dataSet = Connection.getDBConnectionInstance().GetDataSet(Constants.selectAllPatients);

            // creates instace and set table 
            DataTable table = dataSet.Tables[0];

            //selects row just added
            DataRow dataRow = table.Rows[table.Rows.Count - 1];

            //clears Text boxs and Datetime

            return dataRow.ItemArray.GetValue(0).ToString();
        }
        public void editPatient()
        {
            //Adds patient to the database
            Connection.getDBConnectionInstance().updatePatient(PatientID, Firstname, Surname, DOB, AddressLine, TownCity, County, Postcode);
            Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "\r\n Attemp to modify patient information - \r\n  PatientID:" + PatientID + "\r\n  Patient Updated?: Yes");

        }
        
    }
}
