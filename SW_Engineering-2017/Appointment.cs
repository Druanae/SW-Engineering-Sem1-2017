using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SW_Engineering_2017
{
    class Appointment
    {
        private static Appointment _instance;

        private string PatientID;
        private string StaffMember;
        private string AppointmentDate;
        private string AppointmentTime;

        private string AppointmentID;


        public static Appointment instance
        {
            get
            {
                if (_instance == null)
                {
                    //create instance of self unless it already exists
                    _instance = new Appointment();

                }
                return _instance;
            }
        }


        public void SetsAppointments(string patientID,string staffMember,string appointmentDate,string appointmentTime)
        {
            PatientID = patientID;
            StaffMember = staffMember;
            AppointmentDate=appointmentDate;
            AppointmentTime=appointmentTime;
        }

        public void SetAppointmentID(string appointmentID)
        {
            AppointmentID = appointmentID;
        }

        public void addAppointment()
        {
            Connection.getDBConnectionInstance().addAppointment(PatientID, StaffMember, AppointmentDate, AppointmentTime);
            //Updates logger 
            Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "\r\nAdd Appointment to Appoitnemt Table:\r\n  PatientID:" + PatientID + "\r\n  StaffID:" + StaffMember + "\r\n  Appointment Date:" + AppointmentDate + "\r\n Appointment Time:" + AppointmentTime);
        }

        public void changeAppointment()
        {
            Connection.getDBConnectionInstance().UpdateAppointment(AppointmentID, StaffMember, AppointmentDate, AppointmentTime); ;

            //Updates logger 
            Logger.instance.log(DateTime.Today.ToString("dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "\r\nChange Appointment to Appointment Table:\r\n  PatientID:" + PatientID + "\r\n  StaffID:" + StaffMember + "\r\n  Appointment Date:" + AppointmentDate + "\r\n Appointment Time:" + AppointmentTime);
        }

        public DataSet deleteAppointment(string appointment)
        {
            string date = DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Day.ToString(); ;
            string time = DateTime.Now.TimeOfDay.ToString();

            //Updates logger 
            Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "Delete Appointment Confirmed Clicked: Appointment Deleted");
            //delete selected appointment
            Connection.getDBConnectionInstance().selectDeleteAppointment(appointment);

            //resfresh appointment table
            return Connection.getDBConnectionInstance().selectPatentAppointment(PatientID, date, time);
        }

    }
}
