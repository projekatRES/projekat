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



public class Input : IInput {

	public Modul1 m_Modul1;

	public Input(){

	}

	~Input(){

	}

    public bool WriteToModul1(Code code, int value)
    {


        return true;
    }
    public bool ManualWriteToModul2(Code code, int value)
    {


        return true;
    }

}//end Input