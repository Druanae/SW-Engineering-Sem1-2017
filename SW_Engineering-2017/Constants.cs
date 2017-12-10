using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_Engineering_2017
{
    class Constants
    {

        //times
        public static TimeSpan openTime = new TimeSpan(09, 00, 00);
        public static TimeSpan CloseTime = new TimeSpan(18, 00, 00);
        public static TimeSpan appointmentLength = new TimeSpan(00, 15, 00);
        /*********************************** Selects ****************************************/
        public const string selectMedicalRecord = "SELECT medicalRecord FROM medicalRecords WHERE Patient_ID =@patientID";
        public const string selectAllStaff = "SELECT * FROM Staff";
        public const string selectAllPatients = "SELECT * FROM Patients";
        public const string selectingLogin = "SELECT Staff_ID, Password, Staff_Type FROM Staff";
        public const string selectAllGPAppointment = "SELECT Staff_ID,Firstname,Surname FROM Staff WHERE staff_Type ='GP'";
        public const string selectAllNurseAppointment = "SELECT Staff_ID,Firstname,Surname FROM Staff WHERE staff_Type ='Nurse'";
        public const string selectStaffMember = "SELECT Date,Time From Appointments WHERE Staff_ID = @StaffID";
        public const string selectTime = "SELECT Time From Appointments WHERE Staff_ID = @StaffID AND Date = @Date";
		public const string selectTests = " SELECT * FROM Tests ";


        public const string selectPatientByID = "SELECT * From Patients WHERE Patient_ID =@patientID";
        public const string selectPatientByDOB = "SELECT * From Patients WHERE Firstname=@firstname AND Surname=@surname and DOB=@dob";
        public const string selectPatientByAddress = "SELECT * From Patients WHERE Firstname=@firstname AND Surname=@surname and AddressLine=@address";

        public const string updatePatient = "UPDATE Patients SET Firstname=@firstname, Surname =@Surname , DOB =@DOB, AddressLine=@AddressLine, TownCity=@TownCity, County=@County, Postcode=@Postcode WHERE Patient_ID =@patientID";
		
		


        public const string selectPatientAppointment = "SELECT Appointment_ID, Date, Time From Appointments WHERE Patient_ID =@patientID AND ( Date > @date OR Date = @date AND Time > @time)";

        public const string selectStaffAppointment = "SELECT Appointment_ID, Patient_ID, Date, Time From Appointments WHERE Staff_ID = @staffID";
        public const string selectAppointment = "SELECT Staff_ID, Patient_ID , Date,Time From Appointments WHERE Appointment_ID =@appointmentID";
        //


        // test selection 

        public const string selectPatientTest = " SELECT Test_ID, Patient_ID, Results FROM Tests WHERE Patient_ID =@patientID";


        public const string selectTestByID = " SELECT Test_ID, Patient_ID, Results FROM Tests WHERE Test_ID=@testID";
        

        // Staff Search Selection 
    
        public const string selectStaffDate = "  SELECT Appointment_ID, Staff_ID , Patient_ID, Time FROM Appointments WHERE date=@date ";
        
		public const string selectStaffType = "SELECT Staff_Type FROM Staff WHERE Staff_ID = @StaffID";
        

		//delete Appointment
        public const string deleteAppointment = "DELETE FROM Appointments WHERE Appointment_ID =@appointmentID";

        public const string UpdateAppointment = "UPDATE Appointments SET Staff_ID=@staffID, Date=@date, Time=@time WHERE Appointment_ID= @appointmentID";

        /*************************************** Inserts *******************************************/
        public const string insertNewPatient = "INSERT INTO[dbo].[Patients]([Firstname], [Surname], [DOB], [AddressLine], [TownCity], [County], [Postcode]) VALUES(@Firstname,@Surname,@DOB,@AddressLine,@TownCity,@County,@Postcode)";
        public const string AddAppointment = "INSERT INTO [dbo].[Appointments] ([Patient_ID], [Staff_ID], [Date], [Time]) VALUES (@patientID,@staffID,@date , @time)";
        public const string addMedicalRecord = "INSERT INTO[dbo].[medicalRecords]([Patient_ID], [medicalRecord]) VALUES (@patientID, @medicalRecords)";
    }
}
