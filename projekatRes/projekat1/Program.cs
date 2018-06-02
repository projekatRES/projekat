using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace projekat1
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader();

            Input input = new Input();
            Thread inputThread = new Thread(input.WriteToModul1);
            inputThread.Start();


            Console.ReadKey();
            inputThread.Abort();
            return;
        }
    }
}
