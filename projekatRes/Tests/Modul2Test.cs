using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class Modul2Test
    {
        Modul2 modul2 = null;

        Modul2Property modul2Property = null;
        HistoricalCollection historicalCollection = null;
        CollectionDescription collectionDescription = null;

        [TestFixtureSetUp]
        public void SetupMethods()
        {

        }
        [TestFixtureTearDown]
        public void TearDownMethods()
        {

        }

        [SetUp]
        public void SetupTest()
        {
            modul2 = new Modul2();
            modul2Property = new Modul2Property();
            historicalCollection = new HistoricalCollection();
            collectionDescription = new CollectionDescription();
        }

        [TearDown]
        public void TearDownTest()
        {

        }

        [Test]
        public void Modul2Constructor()
        {
            Modul2 modul2 = new Modul2();
            Assert.AreNotEqual(modul2, null);
        }

        [Test]
        public void ReceiveFromModul1BadParameter()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                modul2.ReceiveFromModul1(null);
            });
        }

        [Test]
        public void ReceiveFromModul1GoodParameter()
        {
            ListDescription ld = new ListDescription();
            Modul1Property m1p = new Modul1Property();
            m1p.Code = Code.CODE_ANALOG;
            m1p.Value = 100;
            Modul1Property m1p2 = new Modul1Property();
            m1p2.Code = Code.CODE_DIGITAL;
            m1p2.Value = 300;

            Description d1 = new Description();
            d1.Dataset = 1;
            d1.Id = 12345;
            d1._m1Property.Add(m1p);

            Description d2 = new Description();
            d2.Dataset = 1;
            d2.Id = 12346;
            d2._m1Property.Add(m1p2);


            ld.m_Description.Add(d1);
            ld.m_Description.Add(d2);

            Assert.IsTrue(modul2.ReceiveFromModul1(ld));

        }

        [Test]
        [TestCase(Code.CODE_ANALOG, 1)]
        [TestCase(Code.CODE_DIGITAL, 1)]
        [TestCase(Code.CODE_CONSUMER, 4)]
        [TestCase(Code.CODE_CUSTOM, 2)]
        [TestCase(Code.CODE_LIMITSET, 2)]
        [TestCase(Code.CODE_SOURCE, 4)]
        [TestCase(Code.CODE_SINGLENODE, 3)]
        [TestCase(Code.CODE_MULTIPLENODE, 3)]
        public void ValidationCheckTestOk(Code code, int dataSet)
        {
            Code c = code;
            int ds = dataSet;

            Assert.IsTrue(modul2.ValidationCheck(c, dataSet));
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void ValidationCheckTestNotOk1A(int dataSet)
        {
            Code c = Code.CODE_ANALOG;
            int value = dataSet;

            Assert.IsFalse(modul2.ValidationCheck(c, value));
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void ValidationCheckTestNotOk1D(int dataSet)
        {
            Code c = Code.CODE_DIGITAL;
            int value = dataSet;

            Assert.IsFalse(modul2.ValidationCheck(c, value));
        }

        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(4)]
        public void ValidationCheckTestNotOk2C(int dataSet)
        {
            Code c = Code.CODE_CUSTOM;
            int value = dataSet;

            Assert.IsFalse(modul2.ValidationCheck(c, value));
        }


        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(4)]
        public void ValidationCheckTestNotOk2L(int dataSet)
        {
            Code c = Code.CODE_LIMITSET;
            int value = dataSet;

            Assert.IsFalse(modul2.ValidationCheck(c, value));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        public void ValidationCheckTestNotOk3S(int dataSet)
        {
            Code c = Code.CODE_SINGLENODE;
            int value = dataSet;

            Assert.IsFalse(modul2.ValidationCheck(c, value));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        public void ValidationCheckTestNotOk3M(int dataSet)
        {
            Code c = Code.CODE_MULTIPLENODE;
            int value = dataSet;

            Assert.IsFalse(modul2.ValidationCheck(c, value));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ValidationCheckTestNotOk4C(int dataSet)
        {
            Code c = Code.CODE_CONSUMER;
            int value = dataSet;

            Assert.IsFalse(modul2.ValidationCheck(c, value));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ValidationCheckTestNotOk4S(int dataSet)
        {
            Code c = Code.CODE_SOURCE;
            int value = dataSet;

            Assert.IsFalse(modul2.ValidationCheck(c, value));
        }

        [Test]
        public void CheckDeadbandTestBadParameter()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                modul2.CheckDeadband(null);
            });
        }

       /* [Test]
        [TestCase(Code.CODE_ANALOG, 922, 1)]
        [TestCase(Code.CODE_LIMITSET, 904, 2)]
        [TestCase(Code.CODE_CUSTOM, 946, 2)]
        [TestCase(Code.CODE_SINGLENODE, 1017, 3)]
        [TestCase(Code.CODE_MULTIPLENODE, 1010, 3)]
        [TestCase(Code.CODE_CONSUMER, 830, 4)]
        [TestCase(Code.CODE_SOURCE, 882, 4)]
        public void CheckDeadbandTestOk(Code code, int value, int dataSet)
        {
            
            Modul2Property hp = new Modul2Property() { Code = code, Modul2Value = value };

            HistoricalCollection histColl = new HistoricalCollection();
            histColl.m_Modul2Property[0] = hp;

            CollectionDescription collDesc = new CollectionDescription();
            collDesc.Dataset = dataSet;
            collDesc.Id = 12345;
            collDesc.timeStamp = DateTime.Now;
            collDesc.m_HistoricalCollection = histColl;

            Assert.IsTrue(modul2.CheckDeadband(collDesc));
        }*/
        
        [Test]
        public void CheckDeadbandTestOk1()
        {
            modul2Property.Code = Code.CODE_DIGITAL; //ako je CODE_DIGITAL uvek mora vratiti true
            modul2Property.Modul2Value = 93;

            historicalCollection.m_Modul2Property[0] = modul2Property;
            collectionDescription.Dataset = 1;
            collectionDescription.Id = 12345;
            collectionDescription.timeStamp = DateTime.Now;
            collectionDescription.m_HistoricalCollection = historicalCollection;

            Assert.IsTrue(modul2.CheckDeadband(collectionDescription));
        }

        [Test]
        [TestCase(Code.CODE_ANALOG, 30, 1)]
        [TestCase(Code.CODE_LIMITSET, 40, 2)]
        [TestCase(Code.CODE_CUSTOM, 20, 2)]
        [TestCase(Code.CODE_SINGLENODE, 50, 3)]
        [TestCase(Code.CODE_MULTIPLENODE, 100, 3)]
        [TestCase(Code.CODE_CONSUMER, 60, 4)]
        [TestCase(Code.CODE_SOURCE, 70, 4)]
        public void CheckDeadbandTestNotOk(Code code, int value, int dataSet)
        {
            Modul2Property hp = new Modul2Property() { Code = code, Modul2Value = value };
            //  historicalProperty.Code = code; //ako value nije veza od 2% od stare vresdnosti vratise false
            //  historicalProperty.HistoricalValue = value;

            // historicalCollection.m_HistoricalProperty[0] = historicalProperty;

            HistoricalCollection histColl = new HistoricalCollection();
            histColl.m_Modul2Property[0] = hp;

            CollectionDescription collDesc = new CollectionDescription();
            collDesc.Dataset = dataSet;
            collDesc.Id = 12345;
            collDesc.timeStamp = DateTime.Now;
            collDesc.m_HistoricalCollection = histColl;

            // collectionDescription.DataSet = dataSet;
            //collectionDescription.Id = 12345;
            // collectionDescription.timeStamp = DateTime.Now;
            // collectionDescription.m_HistoricalCollection = historicalCollection;

            //Assert.Throws<Exception>(() =>
            // {
            //    historical.CheckDeadband(collDesc);
            // }); 
            Assert.AreEqual(modul2.CheckDeadband(collDesc), false);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void DESerializeListTest(int dataSet)
        {
            Assert.IsNotNull(modul2.DeserializeList(dataSet));
        }

        [Test]
        public void SerializeListBadParameter1()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                modul2.SerializeList(null);
            });
        }

        [Test]
        public void SerializeListBadParameter2()
        {

            modul2Property.Code = Code.CODE_ANALOG;
            modul2Property.Modul2Value = 30;

            historicalCollection.m_Modul2Property[0] = modul2Property;
            collectionDescription.Dataset = 5;
            collectionDescription.Id = 12345;
            collectionDescription.timeStamp = DateTime.Now;
            collectionDescription.m_HistoricalCollection = historicalCollection;
            Assert.Throws<ArgumentException>(() =>
            {
                modul2.SerializeList(collectionDescription);
            });
        }

        [TestCase(Code.CODE_ANALOG)]
        [TestCase(Code.CODE_DIGITAL)]
        [TestCase(Code.CODE_CONSUMER)]
        [TestCase(Code.CODE_CUSTOM)]
        [TestCase(Code.CODE_LIMITSET)]
        [TestCase(Code.CODE_SOURCE)]
        [TestCase(Code.CODE_SINGLENODE)]
        [TestCase(Code.CODE_MULTIPLENODE)]
        public void ReadDataForReaderTest(Code c)
        {
            Assert.IsNotNull(modul2.ReadDataForReader(c));
        }

        [Test]
        public void SerializeBadParameter()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                modul2.Serialize(null);
            });
        }

        /*[Test]
        [TestCase(Code.CODE_ANALOG, 922, 1)]
        [TestCase(Code.CODE_LIMITSET, 904, 2)]
        [TestCase(Code.CODE_CUSTOM, 946, 2)]
        [TestCase(Code.CODE_SINGLENODE, 1017, 3)]
        [TestCase(Code.CODE_MULTIPLENODE, 1010, 3)]
        [TestCase(Code.CODE_CONSUMER, 830, 4)]
        [TestCase(Code.CODE_SOURCE, 882, 4)]
        public void SerializeOkParameter(Code code, int value, int dataSet)
        {
            Modul2Property hp = new Modul2Property() { Code = code, Modul2Value = value };

            HistoricalCollection histColl = new HistoricalCollection();
            histColl.m_Modul2Property[0] = hp;

            CollectionDescription collDesc = new CollectionDescription();
            collDesc.Dataset = dataSet;
            collDesc.Id = 1235;
            collDesc.timeStamp = DateTime.Now;
            collDesc.m_HistoricalCollection = histColl;
            Assert.IsTrue(modul2.Serialize(collDesc));

        }*/

        [Test]
        [TestCase(Code.CODE_ANALOG, 143)]
        [TestCase(Code.CODE_DIGITAL, 345)]
        [TestCase(Code.CODE_CONSUMER, 234)]
        [TestCase(Code.CODE_CUSTOM, 355)]
        [TestCase(Code.CODE_LIMITSET, 564)]
        [TestCase(Code.CODE_SOURCE, 678)]
        [TestCase(Code.CODE_SINGLENODE, 890)]
        [TestCase(Code.CODE_MULTIPLENODE, 123)]
        public void ReceiveFromInputTest(Code c, int value)
        {
            Assert.IsTrue(modul2.ReceiveFromInput(c, value));
        }



    }

}
