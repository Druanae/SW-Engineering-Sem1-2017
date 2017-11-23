using Microsoft.VisualStudio.TestTools.UnitTesting;
using SW_Engineering_2017;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_Engineering_2017.Tests
{
    [TestClass()]
    public class ValidationTests
    {

        [TestMethod()]
        public void validateFirstnameTest()
        {
            string[] firstname = { "John",""," ","!!!!!","Stick-man","James123","Jack Jack" };
            bool[] firstnameResult = { true,false,false,false,false,false,false};
            Validation val = new Validation();

            for (int i = 0; i < firstname.Length; i++)
            {
                string output = val.validateFirstname(firstname[i]);
                bool valided;
                if (output == "")
                {
                    valided = true;
                }
                else
                {
                    valided = false;
                }

                //compare the actual result with the expected one
                Assert.AreEqual(firstnameResult[i], valided);
            }


        }
        
        [TestMethod()]
        public void validateSurnameTest()
        {

            string[] Surname = { "Smith","", " ", "!!!!!", "stick-man","Clark123","Clark Clark"};
            bool[] SurnameResult = { true, false, false, false, false,false,false };
            Validation val = new Validation();

            for (int i = 0; i < Surname.Length; i++)
            {
                string output = val.validateSurname(Surname[i]);
                bool valided;
                if (output == "")
                {
                    valided = true;
                }
                else
                {
                    valided = false;
                }

                //compare the actual result with the expected one
                Assert.AreEqual(SurnameResult[i], valided);
            }
        }

        [TestMethod()]
        public void validateAddressLineTest()
        {
            string[] AddressLine = { "1 jane lane",""," ","1 Station-Way" };
            bool[] AddressLineResult = { true,false,false,true};
            Validation val = new Validation();

            for (int i = 0; i < AddressLine.Length; i++)
            {
                string output = val.validateAddressLine(AddressLine[i]);
                bool valided;
                if (output == "")
                {
                    valided = true;
                }
                else
                {
                    valided = false;
                }

                //compare the actual result with the expected one
                Assert.AreEqual(AddressLineResult[i], valided);
            }
        }

        [TestMethod()]
        public void validateTownCityTest()
        {
            string[] TownCity = {"Wroxham",""," ","Cambridge!" };
            bool[]  TownCityResult= { true,false,false,false };
            Validation val = new Validation();

            for (int i = 0; i < TownCity.Length; i++)
            {
                string output = val.validateTownCity(TownCity[i]);
                bool valided;
                if (output == "")
                {
                    valided = true;
                }
                else
                {
                    valided = false;
                }

                //compare the actual result with the expected one
                Assert.AreEqual(TownCityResult[i], valided);
            }
        }

        [TestMethod()]
        public void validateCountyTest()
        {
            string[] County = {  "Norfolk",""," ","SouthYorkshire!" };
            bool[] CountyResult = { true,false,false,false };
            Validation val = new Validation();

            for (int i = 0; i < County.Length; i++)
            {
                string output = val.validateCounty(County[i]);
                bool valided;
                if (output == "")
                {
                    valided = true;
                }
                else
                {
                    valided = false;
                }

                //compare the actual result with the expected one
                Assert.AreEqual(CountyResult[i], valided);
            }
        }

        [TestMethod()]
        public void validatePostcodeTest()
        {
            string[] Postcode = { "NR128SW", "NR18SW",""," ", "NR18W", "NR18SWqqq", "AQ!!!SW" };
            bool[] PostcodeResult = { true,true,false,false, false, false,false };
            Validation val = new Validation();

            for (int i = 0; i < Postcode.Length; i++)
            {
                string output = val.validatePostcode(Postcode[i]);
                bool valided;
                if (output == "")
                {
                    valided = true;
                }
                else
                {
                    valided = false;
                }

                //compare the actual result with the expected one
                Assert.AreEqual(PostcodeResult[i], valided);
            }
        }

       /* [TestMethod()]
        public void validateAppointmentTest()
        {
            Assert.Fail();
        }
        */
    }
}