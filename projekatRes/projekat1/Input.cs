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
using projekat;
using System.Threading;
using projekat1;

public class Input : IInput {

    public IModul1 m_Modul1 = new Modul1();
    public IModul2 m_Modul2 = new Modul2();

	public Input(){

	}

	~Input(){

	}

    // salje generisane podatke direktno Modulu2
    public bool WriteToModul2(Code code, int value)
    {
        Logger.Log("\n\nSlanje podataka iz Inputa direktno Modulu2\nPodaci: " + code + ", " + value + "\nTime:" + DateTime.Now);

        return m_Modul2.ReceiveFromInput(code, value);
    }

    // salje direktno podatke Modulu1 na svake 3 sekunde
    public bool WriteToModul1(Code code, int value)
    {
        Logger.Log("\n\nSlanje podataka iz Inputa Modulu1\nPodaci: " + code + ", " + value + "\nTime:" + DateTime.Now);
        
        return m_Modul1.ReceiveFromInput(code, value);
    }

    //Generise podatke koji ce biti poslati i poziva Input metode
    public void GenerateData()
    {
        int counter = 0;
        while (true)
        {
            Random rnd = new Random();
            Code c = (Code)rnd.Next(8);
            int value = rnd.Next(1000);

            if (counter % 5 == 0)
            {
                WriteToModul2(c, value);
            }
            else
            {
                WriteToModul1(c, value);
            }
            counter++;

            Thread.Sleep(3000);
        }
    }

}