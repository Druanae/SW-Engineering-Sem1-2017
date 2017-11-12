using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_Engineering_2017
{
    class Constants
    {
        public static string selectAllStaff = "SELECT * FROM Staff";
        public static string selectAllPatients = "SELECT * FROM Patients";
        public static string selectingLogin = "SELECT Staff_ID, Password FROM Staff";
        public static string updatePatient = "UPDATE Patients SET Firstname=@firstname, Surname =@Surname , DOB =@DOB, AddressLine=@AddressLine, TownCity=@TownCity, County=@County, Postcode=@Postcode WHERE Patient_ID =@patientID";

        // Temp
        public static string selectPatientByID = "SELECT * From Patients WHERE Patient_ID =@patientID";
        public static string selectPatientByDOB = "SELECT * From Patients WHERE Firstname=@firstname AND Surname=@surname and DOB=@dob";
        public static string selectPatientByAddress = "SELECT * From Patients WHERE Firstname=@firstname AND Surname=@surname and AddressLine=@address";



    }
}
