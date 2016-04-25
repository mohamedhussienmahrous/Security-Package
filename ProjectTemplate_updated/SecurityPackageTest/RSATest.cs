using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityLibrary.RSA;

namespace SecurityPackageTest
{
    [Ignore]
    [TestClass]
    public class RSATest
    {
        [TestMethod]
        public void RSATest1()
        {
            RSA algorithm = new RSA();
            int cipher = algorithm.Encrypt(11, 17, 88, 7);
            Assert.AreEqual(cipher, 11);
        }

        [TestMethod]
        public void RSATest2()
        {
            RSA algorithm = new RSA();
            int plain = algorithm.Decrypt(11, 17, 11, 7);
            Assert.AreEqual(plain, 88);
        }

        [TestMethod]
        public void RSATest3()
        {
            RSA algorithm = new RSA();
            int cipher = algorithm.Encrypt(13, 19, 65, 5);
            Assert.AreEqual(cipher, 221);
        }

        [TestMethod]
        public void RSATest4()
        {
            RSA algorithm = new RSA();
            int plain = algorithm.Decrypt(13, 19, 221, 5);
            Assert.AreEqual(plain, 65);
        }

        [TestMethod]
        public void RSATest5()
        {
            RSA algorithm = new RSA();
            int cipher = algorithm.Encrypt(61, 53, 70, 7);
            Assert.AreEqual(cipher, 2338);
        }

        [TestMethod]
        public void RSATest6()
        {
            RSA algorithm = new RSA();
            int plain = algorithm.Decrypt(61, 53, 2338, 7);
            Assert.AreEqual(plain, 70);
        }
    }
}
