using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_Engineering_2017
{
    class Validation
    {
        public string validateFirstname(string firstname)
        {
            string errormessage;
            //check if firstname is blank
            if (firstname == "")
            {
                //error message set
                errormessage = "Requires Firstname\r\n";
                Logger.instance.log("--Validation Firstname: INVALID Firstname Required");
            }
            else if (firstname.All(char.IsLetter) == false)
            {
                //error message set
                errormessage = "Firstname can only have letters \r\n";
                Logger.instance.log("--Validation Firstname: INVALID Firstname can only have letters");
            }
            else if (firstname.Length < 2)
            {
                //error message set
                errormessage = "Firstname is not long enough \r\n";
                Logger.instance.log("--Validation Firstname: INVALID Firstname is not long enough");
            }
            else
            {
                //valid input 
                errormessage = "";
                Logger.instance.log("--Validation Firstname: VALID Firstname Required");
            }

            //return errorMessage
            return errormessage;
        }

        public string validateSurname(string surname)
        {
            string errormessage;

            //checks if Surname is blank
            if (surname == "")
            {
                //error message set
                errormessage = "Requires Surname\r\n";
                Logger.instance.log("--Validation Surname: INVALID Surname Required");
            }
            else if (surname.All(char.IsLetter) == false)
            {
                //error message set
                errormessage = "Surname can only have letters \r\n";
                Logger.instance.log("--Validation Surname: INVALID Surname can only have letters");
            }
            else if (surname.Length < 2)
            {
                //error message set
                errormessage = "Surname is not long enough \r\n";
                Logger.instance.log("--Validation Surname: INVALID Surname is not long enough");
            }
            else
            {
                //valid input 
                errormessage = "";
                Logger.instance.log("--Validation Surname: VALID Surname Required");
            }

            //return errorMessage
            return errormessage;
        }

        public string validateAddressLine(string addressLine)
        {
            string errormessage;

            //checks if addressline is blank
            if (addressLine == "")
            {
                //error message set
                errormessage = "Requires AddressLine\r\n";
                Logger.instance.log("--Validation Address: INVALID Address Required");
            }
            else if (addressLine.Length < 5)
            {
                //error message set
                errormessage = "Address is not long enough need to be min 5 character long\r\n";
                Logger.instance.log("--Validation Address: INVALID Address is not long enough");
            }
            else
            {
                //valid input 
                errormessage = "";
                Logger.instance.log("--Validation Address: VALID Address Required");
            }

            //return errorMessage
            return errormessage;
        }

        public string validateTownCity(string townCity)
        {
            string errormessage;

            //checks if townCity is blank
            if (townCity == "")
            {
                //error message set
                errormessage = "Requires Town/City\r\n";
                Logger.instance.log("--Validation TownCity: INVALID TownCity Required");
            }
            else if (townCity.All(char.IsLetter) == false)
            {
                //error message set
                errormessage = "TownCity can only have letters\r\n";
                Logger.instance.log("--Validation TownCity: INVALID TownCity can only have letters");
            }
            else if (townCity.Length < 3)
            {
                //error message set
                errormessage = "TownCity is not long enough need to be min 3 character long\r\n";
                Logger.instance.log("--Validation TowCity: INVALID TownCity is not long enough");
            }
            else
            {
                //valid input 
                errormessage = "";
                Logger.instance.log("--Validation TownCity: INVALID TownCity Required");
            }

            //return errorMessage
            return errormessage;
        }

        public string validateCounty(string county)
        {
            string errormessage;

            //checks if county is blank
            if (county == "")
            {
                //error message set
                errormessage = "Requires County\r\n";
                Logger.instance.log("--Validation County: INVALID County Required");
            }
            else if (county.All(char.IsLetter) == false)
            {
                //error message set
                errormessage = "County can only have letters \r\n";
                Logger.instance.log("--Validation County: INVALID County can only have letters");
            }
            else if (county.Length < 3)
            {
                //error message set
                errormessage = "County is not long enough need to be min 3 character long\r\n";
                Logger.instance.log("--Validation County: INVALID County is not long enough ");
            }
            else
            {
                //valid input 
                errormessage = "";
                Logger.instance.log("--Validation County: VALID County Required");
            }

            //return errorMessage
            return errormessage;
        }

        public string validatePostcode(string postcode)
        {
            string errormessage;

            //checks if postcode is blank
            if (postcode == "")
            {
                //error message set
                errormessage = "Requires Postcode\r\n";
                Logger.instance.log("--Validation Postcode: INVALID Postcode Required");
            }
            //checks that postcode is the correct length
            else if ((postcode.Length < 6) || (postcode.Length > 7))
            {
                //error message set
                errormessage = "Invalided Postcode\r\n";
                Logger.instance.log("--Validation Postcode: VALID Postcode is not correct valid length");
            }
            else
            {
                //valid input 
                errormessage = "";
            }

            //return errorMessage
            return errormessage;
        }
        public string validateAppointment(string staffType,string staff,string appointmentTime)
        {
            string errormessage = "";
            if (staffType != "")
            {
                //validates staff member was selected
                if (staff != "")
                {
                    //validates time was selected
                    if (appointmentTime != "")
                    {
                        Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "\r\nAdd Appointment to Ap  StaffID:" + staff.ToString() + "\r\n Appointment Valided");
                    }
                    else
                    {
                        //if user doesn't select time then displays errormessage 
                        errormessage = "time needs to be Selected";
                        //Updates logger 
                        Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "\r\nAdd Appointment to Ap  StaffID:" + staff.ToString()+"\r\n Appointment Time not selected");
                    }
                }
                else
                {
                    //if user doesn't select staff member then displays errormessage 
                    errormessage = "staff needs to be Selected";
                    //Updates logger 
                    Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "\r\nAdd Appointment to Appointment Table:\r\nStaffID:" + staff.ToString() + "\r\n  Appointment Date: Not Selected");
                }

            }
            else
            {
                //if user doesn't select staff typ then displays errormessage 
                errormessage = "staff Type needs to be Selected";
                //Updates logger 
                Logger.instance.log(DateTime.Today.ToString("-------------------\r\n" + "dd/MM/yyyy") + " " + DateTime.Now.TimeOfDay + "\r\nAdd Appointment to Appointment Table:\r\nStaffID:" + staff.ToString() + "\r\n Appointment Time not selected");
            }
            return errormessage;
        }
    }
}
