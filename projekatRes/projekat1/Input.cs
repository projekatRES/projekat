///////////////////////////////////////////////////////////
//  Input.cs
//  Implementation of the Class Input
//  Generated by Enterprise Architect
//  Created on:      22-May-2018 5:42:52 PM
//  Original author: Saska
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using projekat1;
using System.Threading;

public class Input : IInput {

    public IModul1 m_Modul1 = new Modul1();
    public IModul2 m_Modul2 = new Modul2();

	public Input(){

	}

	~Input(){

	}


    // salje podatke Modulu2 koje unosi korisnik
    public bool WriteToModul2()
    {
        Code code;
        int value;
        int i;

        do
        {
            Console.WriteLine("Unesite redni broj Code-a:");
            Console.WriteLine("1. CODE_ANALOG");
            Console.WriteLine("2. CODE_DIGITAL");
            Console.WriteLine("3. CODE_CUSTOM");
            Console.WriteLine("4. CODE_LIMITSET");
            Console.WriteLine("5. CODE_SINGLENODE");
            Console.WriteLine("6. CODE_MULTIPLENODE");
            Console.WriteLine("7. CODE_CONSUMER");
            Console.WriteLine("8. CODE_SOURCE");
            Console.WriteLine("\n\t>>");
            i = Int32.Parse(Console.ReadLine());
        }
        while (i < 1 || i > 8);
        code = (Code)(i - 1);

        do
        {
            Console.WriteLine("Unesite vrednost za code(0-1000):");
            i = Int32.Parse(Console.ReadLine());
        } while (i < 1 || i > 1000);
        value = i;
        
        bool m = m_Modul2.ReceiveFromInput(code, value);
        Logger.Log("\n\nSlanje podataka iz Inputa direktno u Modul1\nPodatak: " + code + ", " + value + "\nVreme:" + DateTime.Now);
        
        return m;
    }

   
    // salje direktno podatke Modulu1 na svake 3 sekunde
    public void WriteToModul1()
    {
        bool res= true;
        while ( res == true)
        {
            Random rnd = new Random();
            Code c = (Code)rnd.Next(8);
            int value = rnd.Next(1000);

            res = m_Modul1.ReceiveFromInput(c, value);
            Thread.Sleep(2000);
        }

        //return res;
        // res nikad nece vratiti true, dokle god je true nece izaci iz fje
    }

}//end Input