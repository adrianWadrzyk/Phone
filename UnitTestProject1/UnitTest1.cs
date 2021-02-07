using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Phone p1 = new Phone("Adrian", "000111222");
            Assert.AreEqual("Adrian", p1.Owner);
            Assert.AreEqual("000111222", p1.PhoneNumber);
        }


        [TestMethod]
        public void TestMethod2()
        {
            try
            {
                Phone p1 = new Phone("", "000111222");
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual($"Owner name is empty or null!", e.Message);
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            try
            {
                Phone p1 = new Phone("aa", "");
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual($"Phone number is empty or null!", e.Message);
            }
        }

        [TestMethod]
        public void TestMethod4()
        {
            try
            {
                Phone p1 = new Phone("aa", "23232");
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual($"Invalid phone number!", e.Message);
            }
        }

        [TestMethod]
        public void TestMethod5()
        {

                Phone p1 = new Phone("aasds", "232323323");
                Assert.AreEqual(0, p1.Count);
        }

        [TestMethod]
        public void TestMethod6()
        {

            Phone p1 = new Phone("aasds", "232323323");
            Assert.IsTrue(p1.AddContact("Marek", "123456789"));
            Assert.IsFalse(p1.AddContact("Marek", "123456789"));
        }

        [TestMethod]
        public void TestMethod7()
        {

            Phone p1 = new Phone("aasds", "232323323");
            try
            {
                for (int i = 0; i < 101; i++)
                    p1.AddContact("Marek" +i, "123456789");
                Assert.Fail();
            }
            catch(InvalidOperationException e)
            {
                Assert.AreEqual("Phonebook is full!", e.Message);
            }
        }

        [TestMethod]
        public void TestMethod8()
        {

            Phone p1 = new Phone("aasds", "232323323");
            p1.AddContact("Marek", "123456789");
            Assert.AreEqual("Calling 123456789 (Marek) ...", p1.Call("Marek"));
        }

        [TestMethod]
        public void TestMethod9()
        {
            try
            {
                Phone p1 = new Phone("aa", "232323323");
                p1.Call("Marek");
                Assert.Fail();
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("Person doesn't exists!", e.Message);
            }
        }


    }
}
