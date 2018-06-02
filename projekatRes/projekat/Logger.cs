using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat
{
   public class Logger
    {
        //klasa koja vrsi zapis aktivnost svih komponeneti u 
        //projektu, i to se nalazi u text file-u(ono sto se 
        //nalazi u konzoli)
        private static Logger _instance;
        private readonly object _lockObj = new object();
        public static string FilePath = @"log.txt";

        private Logger()
        {

        }
        //da ne bi doslo do konflikta u pristupu fajlu i da bi
        //svako mogao u bilo kom trenutku  da dobavi fajl
        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Logger();
                if (!File.Exists(FilePath))
                {
                    File.CreateText(FilePath);
                }
            }
            return _instance;
        }
        public void Log(string message)
        {
            try
            {
                lock (_lockObj)
                {

                    using (StreamWriter streamWriter = new StreamWriter(FilePath, true))

                    {
                        streamWriter.WriteLine(message);
                        streamWriter.Close();

                    }

                }
            }
            catch (Exception e)
            {

            }

        }
    }
}
