using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace projekat1
{
    class Program
    {
        static int Main(string[] args)
        {
            Logger logger = new Logger();
            logger.Delete();
            Reader reader = new Reader();

            Input input = new Input();
            //Thread inputThread = new Thread(input.WriteToModul1);
            Thread inputThread = new Thread(input.GenerateData);
            inputThread.Start();

            Meni(reader);
           
            inputThread.Abort();
            //File.Delete("CollectionDescription1.xml");
            return 0;
        }

        private static void Meni(Reader reader)
        {
            string c = "";

            do
            {
                try
                {
                    Console.WriteLine("IZABERITE INTERVAL ZA POCETAK");
                    Console.WriteLine("Unesite sat: ");
                    int satPocetak = int.Parse(Console.ReadLine());
                    Console.WriteLine("Unesite minut: ");
                    int minutPocetak = int.Parse(Console.ReadLine());
                    Console.WriteLine("Unesite sekundu: ");
                    int sekundaPocetak = int.Parse(Console.ReadLine());
                    DateTime pocetak = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, satPocetak, minutPocetak, sekundaPocetak);

                    Console.WriteLine("IZABERITE INTERVAL ZA KRAJ");
                    Console.WriteLine("Unesite sat: ");
                    int satKraj = int.Parse(Console.ReadLine());
                    Console.WriteLine("Unesite minut: ");
                    int minutKraj = int.Parse(Console.ReadLine());
                    Console.WriteLine("Unesite sekundu: ");
                    int sekundaKraj = int.Parse(Console.ReadLine());
                    DateTime kraj = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, satKraj, minutKraj, sekundaKraj);

                    Console.WriteLine("Izaberite CODE: ");
                    Console.WriteLine("1. CODE_ANALOG       2. CODE_DIGITAL");
                    Console.WriteLine("3. CODE_CUSTOM       4. CODE_LIMITSET");
                    Console.WriteLine("5. CODE_SINGLENODE   6. CODE_MULTIPLENODE");
                    Console.WriteLine("7. CODE_CONSUMER     8. CODE_SOURCE");
                    Console.WriteLine("\n\t>>");
                    Code code = (Code)(int.Parse(Console.ReadLine()) - 1);

                    Console.Clear();
                    reader.ReadDataFromModul2(code, pocetak, kraj);

                    Console.WriteLine("Pritisnite bilo koji taster ako zelite da nastavite ili 'N/n' ukoliko ne zelite. ");
                    c = Console.ReadLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Pokusajte ponovo.Greska: " + ex.Message);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("Pokusajte ponovo.Greska: " + ex.Message);
                }

            } while (c != "N" && c != "n");

            return;
        }
    }
}
