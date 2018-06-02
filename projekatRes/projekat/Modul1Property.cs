using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat
{
    public class Modul1Property
    {
        private ECodes _code;
        private int _value;

        public Modul1Property()
        {

        }

        public Modul1Property(ECodes code, int value)
        {
            if(value == null)
            {
                throw new ArgumentNullException("Value is null");
            }
            if(code == null)
            {
                throw new ArgumentNullException("Value is null");
            }
            _code = code;
            _value = value;

        }

        public ECodes Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public override string ToString()
        {
            return "Code: " + _code + "\tValue: " + _value;
        }
    }
}
