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
            //Thread inputThread = new Thread(input.WriteToModul1);
            Thread inputThread = new Thread(input.GenerateData);
            inputThread.Start();

            Meni(reader);


            Console.ReadKey();
           // inputThread.Abort();
            //return;
        }

        private static void Meni(Reader reader)
        {
            string c = "";

            do
            {
                try
                {
                    Console.WriteLine("Izberite interval: ");
                    Console.WriteLine("Pocetak: ");
                    Console.WriteLine("Unesite sat: ");
                    int satPocetak = int.Parse(Console.ReadLine());
                    Console.WriteLine("Unesite minut: ");
                    int minutPocetak = int.Parse(Console.ReadLine());
                    Console.WriteLine("Unesite sekundu: ");
                    int sekundaPocetak = int.Parse(Console.ReadLine());
                    DateTime pocetak = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, satPocetak, minutPocetak, sekundaPocetak);

                    Console.WriteLine("Izberite interval: ");
                    Console.WriteLine("Kraj: ");
                    Console.WriteLine("Unesite sat: ");
                    int satKraj = int.Parse(Console.ReadLine());
                    Console.WriteLine("Unesite minut: ");
                    int minutKraj = int.Parse(Console.ReadLine());
                    Console.WriteLine("Unesite sekundu: ");
                    int sekundaKraj = int.Parse(Console.ReadLine());
                    DateTime kraj = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, satKraj, minutKraj, sekundaKraj);

                    Console.WriteLine("Izaberite CODE: ");
                    Console.WriteLine("1. CODE_ANALOG");
                    Console.WriteLine("2. CODE_DIGITAL");
                    Console.WriteLine("3. CODE_CUSTOM");
                    Console.WriteLine("4. CODE_LIMITSET");
                    Console.WriteLine("5. CODE_SINGLENODE");
                    Console.WriteLine("6. CODE_MULTIPLENODE");
                    Console.WriteLine("7. CODE_CONSUMER");
                    Console.WriteLine("8. CODE_SOURCE");
                    Console.WriteLine("\n\t>>");
                    Code code = (Code)(int.Parse(Console.ReadLine()) - 1);

                    Console.Clear();
                    reader.ReadDataFromModul2(code, pocetak, kraj);

                    Console.WriteLine("Pritisnite bilo koji taster ako zelite da nastavite ili N/n ukoliko ne zelite. ");
                    c = Console.ReadLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Pogresan input .. Pokusajte ponovo. Exception: " + ex.Message);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("Pogresan input .. Pokusajte ponovo. Exception: " + ex.Message);
                }

            } while (c != "N" && c != "n");
        }
    }
}
