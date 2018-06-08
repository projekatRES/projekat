using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using projekat1;


//[TestFixture] - označava klasu koje sadrži testove i, opciono, metode za postavku i čišćenje testova(Setup & Teardown)
//[Test] - označava određenu metodu, unutar test klase, da sadrži logiku samog testa
// [TestFixtureSetUp] - označava metodu koja postavlja podešavanja na nivou klase.Izvršava se samo jednom, pre svih testova
//[TestFixtureTearDown] - označava metodu koja vrši čišćenje na nivou klase. Izvršava se samo jednom, nakon što se izvrše svi testovi.
//[SetUp] - označava metodu koja postavlja podešavanja na nivou testa. Izvršava se jednom, pre svakog testa
//[TearDown] - označava metodu koja vrši čišćenje na nivou testa. Izvršava se jednom, nakon svakog testa


namespace Tests
{
    [TestFixture]
    public class Modul1Test
    {
        private IModul2 modul2;


        [TestFixtureSetUp]
        public void SetupMethods()
        {

            modul2 = Substitute.For<IModul2>();
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
        public void Modul1Constructor()
        {
            Modul1 modul1 = new Modul1();
            Assert.AreNotEqual(modul1, null);
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
        public void ReceiveFromInput(Code code)
        {
            int value = 50;
            Modul1 md1 = new Modul1();
            md1.m_Modul2 = modul2;

            Assert.IsTrue(md1.ReceiveFromInput(code, value));
        }

    }
}
