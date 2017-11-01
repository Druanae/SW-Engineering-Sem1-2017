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
            }
            else
            {
                //valid input 
                errormessage = "";
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
            }
            else
            {
                //valid input 
                errormessage = "";
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
            }
            else
            {
                //valid input 
                errormessage = "";
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
            }
            else
            {
                //valid input 
                errormessage = "";
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
            }
            else
            {
                //valid input 
                errormessage = "";
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
            }
            //checks that postcode is the correct length
            else if ((postcode.Length <6) || (postcode.Length > 7))
            {
                //error message set
                errormessage = "Invalided Postcode\r\n";
            }
            else
            {
                //valid input 
                errormessage = "";
            }

            //return errorMessage
            return errormessage;
        }
    }
}
