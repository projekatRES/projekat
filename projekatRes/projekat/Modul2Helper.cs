using projekat1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat
{
    public class Modul2Helper
    {
        public Dictionary<Code, int> pairs = new Dictionary<Code, int>();
        public CollectionDescription m_CollectionDescription;
        public List<CollectionDescription> cd1 = new List<CollectionDescription>();
        public List<CollectionDescription> cd2 = new List<CollectionDescription>();
        public List<CollectionDescription> cd3 = new List<CollectionDescription>();
        public List<CollectionDescription> cd4 = new List<CollectionDescription>();

        

        public bool CheckDeadband(CollectionDescription primljeniPodaci)
        {

            List<CollectionDescription> procitaniPodaci = null;
            if (primljeniPodaci == null)
            {
                throw new ArgumentNullException("cd");
            }
            if (primljeniPodaci.m_HistoricalCollection.m_Modul2Property[0].Code.Equals(Code.CODE_DIGITAL))
            {
                return true;
            }
            procitaniPodaci = DeserializeList(primljeniPodaci.Dataset);

            if (procitaniPodaci.Count == 0)
                return true;

            foreach (CollectionDescription item in procitaniPodaci)
            {
                if (item.m_HistoricalCollection.m_Modul2Property[0].Code == primljeniPodaci.m_HistoricalCollection.m_Modul2Property[0].Code)
                {
                    if (primljeniPodaci.m_HistoricalCollection.m_Modul2Property[0].Modul2Value < (item.m_HistoricalCollection.m_Modul2Property[0].Modul2Value * 1.02))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool ValidationCheck(Code code, int value)
        {
            pairs = new Dictionary<Code, int>();
            pairs.Add(Code.CODE_ANALOG, 1);
            pairs.Add(Code.CODE_DIGITAL, 1);
            pairs.Add(Code.CODE_CUSTOM, 2);
            pairs.Add(Code.CODE_LIMITSET, 2);
            pairs.Add(Code.CODE_SINGLENODE, 3);
            pairs.Add(Code.CODE_MULTIPLENODE, 3);
            pairs.Add(Code.CODE_CONSUMER, 4);
            pairs.Add(Code.CODE_SOURCE, 4);

            //provera da li su vrednostri saglasne
            foreach (KeyValuePair<Code, int> k in pairs)
            {
                if (k.Key == code)
                {
                    if (k.Value == value)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public List<CollectionDescription> DeserializeList(int dataSet)
        {
            List<CollectionDescription> pomocnaLista = new List<CollectionDescription>();
            switch (dataSet)
            {
                case 1:
                    if (!File.Exists("CollectionDescription1.xml"))
                        File.Create("CollectionDescription1.xml").Dispose();
                    pomocnaLista = DataBase.serializer.DeSerializeObject<List<CollectionDescription>>("CollectionDescription1.xml");
                    break;
                case 2:
                    if (!File.Exists("CollectionDescription2.xml"))
                        File.Create("CollectionDescription2.xml").Dispose();
                    pomocnaLista = DataBase.serializer.DeSerializeObject<List<CollectionDescription>>("CollectionDescription2.xml");
                    break;

                case 3:
                    if (!File.Exists("CollectionDescription3.xml"))
                        File.Create("CollectionDescription3.xml").Dispose();
                    pomocnaLista = DataBase.serializer.DeSerializeObject<List<CollectionDescription>>("CollectionDescription3.xml");
                    break;
                case 4:
                    if (!File.Exists("CollectionDescription4.xml"))
                        File.Create("CollectionDescription4.xml").Dispose();
                    pomocnaLista = DataBase.serializer.DeSerializeObject<List<CollectionDescription>>("CollectionDescription4.xml");
                    break;

            }
            if (pomocnaLista == null)
            {
                pomocnaLista = new List<CollectionDescription>();
            }
            return pomocnaLista;
        }

        public bool SerializeList(CollectionDescription cd)
        {
            if (cd == null)
            {
                throw new ArgumentNullException("cd");
            }
            switch (cd.Dataset)
            {
                case 1:
                    cd1 = DeserializeList(1);
                    cd1.Add(cd);
                    DataBase.serializer.SerializeObject<List<CollectionDescription>>(cd1, "CollectionDescription1.xml");
                    return true;
                case 2:
                    cd2 = DeserializeList(2);
                    cd2.Add(cd);
                    DataBase.serializer.SerializeObject<List<CollectionDescription>>(cd2, "CollectionDescription2.xml");
                    return true;
                case 3:
                    cd3 = DeserializeList(3);
                    cd3.Add(cd);
                    DataBase.serializer.SerializeObject<List<CollectionDescription>>(cd3, "CollectionDescription3.xml");
                    return true;
                case 4:
                    cd4 = DeserializeList(4);
                    cd4.Add(cd);
                    DataBase.serializer.SerializeObject<List<CollectionDescription>>(cd4, "CollectionDescription4.xml");
                    return true;
                default:
                    throw new ArgumentException("Dataset nije validan.");
            }

        }

        //skladisti objekat CD ako je validan Deadband
        public bool Serialize(CollectionDescription cd)
         {
             if (cd != null)
             {
                 if (CheckDeadband(cd))
                 {
                     cd.timeStamp = DateTime.Now;
                     if (SerializeList(cd))
                     {
                         Logger.Log("\n\nCollectionDescription u Modulu2 je serijalizovan.\n");
                         return true;
                     }

                     return false;

                 }
                 else
                 {
                     Logger.Log("\n\nCollectionDescription u Modulu2 nije serijalizovan.\n Njegova vrednost nije 2% veca od njegove stare vrednosti.\n");
                     return false;
                 }
             }
             else
             {
                 throw new ArgumentNullException("cd");
             }
         }
    }
}
