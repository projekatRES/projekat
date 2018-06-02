using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat
{
    public enum ECodes
    {
        CodeAnalog,
        CodeDigital,
        CodeCustom,
        CodeLimitset,
        CodeSinglenode,
        CodeMultinode,
        CodeConsumer,
        CodeSource
    }

    class Codes
    {
        public static int GetDataset(ECodes code)
        {
            switch (code)
            {
                case ECodes.CodeAnalog:
                case ECodes.CodeDigital:
                    return 1;

                case ECodes.CodeCustom:
                case ECodes.CodeLimitset:
                    return 2;

                case ECodes.CodeSinglenode:
                case ECodes.CodeMultinode:
                    return 3;

                case ECodes.CodeSource:
                case ECodes.CodeConsumer:
                    return 4;

                default:
                    return 0;
            }
        }
    }
