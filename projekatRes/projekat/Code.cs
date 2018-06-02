///////////////////////////////////////////////////////////
//  Code.cs
//  Implementation of the Enumeration Code
//  Generated by Enterprise Architect
//  Created on:      22-May-2018 5:42:52 PM
//  Original author: Saska
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public enum Code : int {

	CODE_ANALOG,
	CODE_DIGITAL,
	CODE_CUSTOM,
	CODE_LIMITSET,
	CODE_SINGLENOE,
	CODE_MULTIPLENODE,
	CODE_CONSUMER,
	CODE_SOURCE

}//end Code

class Codes
{
    public static int GetDataset(Code code)
    {
        switch (code)
        {
            case Code.CODE_ANALOG:
            case Code.CODE_DIGITAL:
                return 1;

            case Code.CODE_CUSTOM:
            case Code.CODE_LIMITSET:
                return 2;

            case Code.CODE_SINGLENOE:
            case Code.CODE_MULTIPLENODE:
                return 3;

            case Code.CODE_SOURCE:
            case Code.CODE_CONSUMER:
                return 4;

            default:
                return 0;
        }
    }


}