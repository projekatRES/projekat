///////////////////////////////////////////////////////////
//  IModul2.cs
//  Implementation of the Interface IModul2
//  Generated by Enterprise Architect
//  Created on:      22-May-2018 5:42:52 PM
//  Original author: Saska
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


public interface IModul2 {
    bool ReceiveFromInput(Code code, int value);
    bool ReceiveFromModul1(ListDescription listDescription);

    List<CollectionDescription> ReadDataForReader(Code code);
}