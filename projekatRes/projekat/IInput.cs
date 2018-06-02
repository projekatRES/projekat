///////////////////////////////////////////////////////////
//  IInput.cs
//  Implementation of the Interface IInput
//  Generated by Enterprise Architect
//  Created on:      22-May-2018 5:42:52 PM
//  Original author: Saska
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public interface IInput  {
    bool WriteToModul2(Code code, int value);
    bool ManualWriteToModul1(Code code, int value);

}//end IInput