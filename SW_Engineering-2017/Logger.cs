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
        private static Logger _instance;
        private string filePath;
        
        //constructer
        private Logger()
        {
            filePath = Directory.GetCurrentDirectory() + "\\LogFile.txt";
        }
        
        public static Logger instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                    
                }
                return _instance;
            }
        }

        public void log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }

        }

    }
}
