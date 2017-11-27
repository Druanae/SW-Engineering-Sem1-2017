using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_Engineering_2017
{
    class medicalRecord
    {
        private static medicalRecord _instance;
        public static medicalRecord instance
        {
            get
            {
                if (_instance == null)
                {
                    //create instance of self unless it already exists
                    _instance = new medicalRecord();

                }
                return _instance;
            }
        }
        public void addMedicalRecord(string patientID, string MedicalRecord)
        {

            Connection.getDBConnectionInstance().addmedicalRecord(patientID, MedicalRecord);
            //Log for successfu ladding of medical record
            Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "\r\n Added Medical record- \r\n  PatientID:" + patientID + "\r\n  Record Add successful?: Yes");

        }
    }
}

