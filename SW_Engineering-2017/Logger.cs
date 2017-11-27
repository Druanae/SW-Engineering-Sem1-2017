using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SW_Engineering_2017
{
    class Logger
    {
        //private variables 
        private static Logger _instance;
        private string filePath;

        //constructer
        private Logger()
        {
            //sets the file path for the log
            filePath = Directory.GetCurrentDirectory() + "\\LogFile.txt";
        }

        public static Logger instance
        {
            get
            {
                if (_instance == null)
                {
                    //create instance of self unless it already exists
                    _instance = new Logger();

                }
                return _instance;
            }
        }

        public void log(string message)
        {
            //writes message to the file 
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }

        }

    }
}
