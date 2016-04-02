using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityLibrary;

namespace SecurityPackageTest
{
    [TestClass]
    public class CeaserTest
    {
        string mainPlain = "meetmeaftertheparty";
        string mainCipher = "phhwphdiwhuwkhsduwb".ToUpper();
        int mainKey = 3;

        [TestMethod]
        public void CeaserTest1()
        {
            Ceaser algorithm = new Ceaser();
            string cipher = algorithm.Encrypt(mainPlain, mainKey);
            Assert.IsTrue(cipher.Equals(mainCipher, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void CeaserTest2()
        {
            Ceaser algorithm = new Ceaser();
            string plain = algorithm.Decrypt(mainCipher, mainKey);
            Assert.IsTrue(plain.Equals(mainPlain, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void CeaserTest3()
        {
            Ceaser algorithm = new Ceaser();
            int key = algorithm.Analyse(mainPlain, mainCipher);
            Assert.AreEqual(mainKey, key);
        }
    }
}
