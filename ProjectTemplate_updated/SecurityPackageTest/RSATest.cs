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
    }
}
