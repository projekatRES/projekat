﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace Tests
{
    public class InputTest
    {
        //[TestFixture] - označava klasu koje sadrži testove i, opciono, metode za postavku i čišćenje testova(Setup & Teardown)
        //[Test] - označava određenu metodu, unutar test klase, da sadrži logiku samog testa
        // [TestFixtureSetUp] - označava metodu koja postavlja podešavanja na nivou klase.Izvršava se samo jednom, pre svih testova
        //[TestFixtureTearDown] - označava metodu koja vrši čišćenje na nivou klase. Izvršava se samo jednom, nakon što se izvrše svi testovi.
        //[SetUp] - označava metodu koja postavlja podešavanja na nivou testa. Izvršava se jednom, pre svakog testa
        //[TearDown] - označava metodu koja vrši čišćenje na nivou testa. Izvršava se jednom, nakon svakog testa

        private IModul1 modul1;
        private IModul2 modul2;

        [TestFixtureSetUp]
        public void SetupMethods()
        {
            modul1 = Substitute.For<IModul1>();
            modul2 = Substitute.For<IModul2>();

            modul1.ReceiveFromInput(Arg.Any<Code>(), Arg.Any<int>()).Returns(true);
            modul2.ReceiveFromInput(Arg.Any<Code>(), Arg.Any<int>()).Returns(true);

        }

        [TestFixtureTearDown]
        public void TearDownMethods()
        {

        }

        [SetUp]
        public void SetupTest()
        {

        }
        [TearDown]
        public void TearDownTest()
        {

        }

        [Test]
        public void WriterConstructor()
        {
            Input input = new Input();
            Assert.AreNotEqual(input, null);
        }

        [Test]
        [TestCase(Code.CODE_ANALOG)]
        [TestCase(Code.CODE_DIGITAL)]
        [TestCase(Code.CODE_CONSUMER)]
        [TestCase(Code.CODE_CUSTOM)]
        [TestCase(Code.CODE_LIMITSET)]
        [TestCase(Code.CODE_SOURCE)]
        [TestCase(Code.CODE_SINGLENODE)]
        [TestCase(Code.CODE_MULTIPLENODE)]
        public void WriteToModul1(Code code)
        {
            int value = 50;

            Input i = new Input();
            i.m_Modul1 = modul1;



            Assert.IsTrue(i.WriteToModul1(code, value));

        }


        [Test]
        [TestCase(Code.CODE_ANALOG)]
        [TestCase(Code.CODE_DIGITAL)]
        [TestCase(Code.CODE_CONSUMER)]
        [TestCase(Code.CODE_CUSTOM)]
        [TestCase(Code.CODE_LIMITSET)]
        [TestCase(Code.CODE_SOURCE)]
        [TestCase(Code.CODE_SINGLENODE)]
        [TestCase(Code.CODE_MULTIPLENODE)]
        public void WriteToModul2(Code code)
        {

            int value = 50;

            Input i = new Input();
            i.m_Modul2 = modul2;

            Assert.IsTrue(i.WriteToModul2(code, value));

        }
    }
}
