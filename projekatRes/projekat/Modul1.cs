using ProjekatRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat
{
    public class Modul1
    {
        private Logger _log = Logger.GetInstance();
        private static Modul1 _instance;

        private Dictionary<string, Description> _data;

        public static Modul1 GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Modul1();
            }
            return _instance;
        }

        private Modul1()
        {
            _data = new Dictionary<string, Description>();

        }

        private readonly object _lockObj = new object();

        public void WriteMessage(WriterMessage msg)
        {
            //prima poruku od writera stavlja u odg.listu,gleda ako ima bar 2 poruke koje pripadaju istom datasetu i prosledjuje ih historic.
            lock (_lockObj)
            {
                //na osnovu codetype-a saznajemo kom datasetu pripada ova poruka,kad imamo 2 poruke iz istog dataseta prosledjujemo dalje historicalu
                string dataset = Constants.GetDataSetFileNameForCodeType(msg.Code);
                // mapa je organizovana po datasetovima
                // ako je ovo prvi put da pisemo u mapu pod ovim datasetom
                // napravimo novi collectiondescription u njoj
                if (!_data.ContainsKey(dataset))
                {
                    _data[dataset] = new Description();    //pravimo novu listu za ovaj dataset
                    _data[dataset].DataSet = dataset;

                }

                // sada je sigurno kljuc definisan
                Description cd = _data[dataset];

                Modul1Property dp = new Modul1Property(msg);
                if (!CheckIfDifferent(dp, cd))
                {
                    return;
                }

                cd.DataToSend.Add(dp);

                if (cd.DataToSend.Count == 2)
                {
                    // saljemo Modulu2...
                    Modul2.Modul2.GetInstance().WriteFromDumpingBuffer(cd);
                    cd.DataToSend.Clear();
                }

            }
        }
    }


}
