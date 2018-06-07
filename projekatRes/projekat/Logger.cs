using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat1
{
    public class Logger
    {
        public static void Log(string str)
        {
            try
            {
                File.AppendAllText("Logger.txt", str);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
