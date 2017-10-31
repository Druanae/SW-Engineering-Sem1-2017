using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_Engineering_2017
{
    class Validation
    {
        
        public string ValidateFirstname(string firstname)
        {
            string errorMessage;

            if (firstname == "")
            {
                errorMessage = "firstname required \r\n";
                
            }else
            {
                errorMessage = "";
            }

            return errorMessage;
        }

        public string ValidateSurname(string surname)
        {
            string errorMessage;

            if (surname == "")
            {
                errorMessage = "surname required \r\n";

            }
            else
            {
                errorMessage = "";
            }

            return errorMessage;
        }

        public string ValidateDOB(DateTime dob)
        {
            string errorMessage;
            if (dob < Constants.maxDOB) {
                errorMessage = "Date of birth is out of range \r\n";
            }
            else
            {
                errorMessage = "";
            }

            return errorMessage;
        }

        public string ValidateAddress(string address)
        {
            string errorMessage;

            if (address == "")
            {
                errorMessage = "address line required \r\n";

            }
            else
            {
                errorMessage = "";
            }

            return errorMessage;
        }

        public string ValidateTownCity(string townCity)
        {
            string errorMessage;

            if (townCity == "")
            {
                errorMessage = "town/City required \r\n";

            }
            else
            {
                errorMessage = "";
            }

            return errorMessage;
        }
        public string ValidateCounty(string County)
        {
            string errorMessage;

            if (County == "")
            {
                errorMessage = "County required \r\n";

            }
            else
            {
                errorMessage = "";
            }

            return errorMessage;
        }

        public string ValidatePostcode(string postcode)
        {
            string errorMessage;

            if (postcode == "")
            {
                errorMessage = "Postcode required \r\n";

            }else if ((postcode.Length < 6) || (postcode.Length > 7))
            {
                errorMessage = "Invaild Postcode \r\n";

            }
            else
            {
                errorMessage = "";
            }

            return errorMessage;
        }   

           
          
    }
}
