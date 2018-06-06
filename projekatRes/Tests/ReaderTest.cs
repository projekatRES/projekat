﻿using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class ReaderTest
    {
        private IModul2 modul2;
        Reader reader = null;

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
            reader = new Reader();
        }
        [TearDown]
        public void TearDownTest()
        {

        }

        [Test]
        public void ReaderConstructor()
        {
            Reader reader = new Reader();
            Assert.AreNotEqual(reader, null);
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
        public void ReadDataFromModul2(Code code)
        {
            Assert.IsTrue(reader.ReadDataFromModul2(code, DateTime.Now, DateTime.Now.AddMinutes(1)));
        }

    }
}