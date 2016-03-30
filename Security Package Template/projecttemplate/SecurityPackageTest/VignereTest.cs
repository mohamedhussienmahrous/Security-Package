using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityLibrary;

namespace SecurityPackageTest
{
    [TestClass]
    public class VignereTest
    {
        string mainPlain = "wearediscoveredsaveyourself";
        string mainCipherRep = "zicvtwqngrzgvtwavzhcqyglmgj".ToUpper();
        string mainCipherAuto = "zicvtwqngkzeiigasxstslvvwla".ToUpper();
        string mainKey = "deceptive";

        [TestMethod]
        public void RepVignereTest1()
        {
            Monoalphabetic algorithm = new Monoalphabetic();
            string cipher = algorithm.Encrypt(mainPlain, mainKey);
            Assert.IsTrue(cipher.Equals(mainCipherRep, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void RepVignereTest2()
        {
            Monoalphabetic algorithm = new Monoalphabetic();
            string plain = algorithm.Decrypt(mainCipherRep, mainKey);
            Assert.IsTrue(plain.Equals(mainPlain, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void RepVignereTest3()
        {
            Monoalphabetic algorithm = new Monoalphabetic();
            string key = algorithm.Analyse(mainPlain, mainCipherRep);
            Assert.IsTrue(key.Equals(mainKey, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void AutoVignereTest1()
        {
            Monoalphabetic algorithm = new Monoalphabetic();
            string cipher = algorithm.Encrypt(mainPlain, mainKey);
            Assert.IsTrue(cipher.Equals(mainCipherAuto, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void AutoVignereTest2()
        {
            Monoalphabetic algorithm = new Monoalphabetic();
            string plain = algorithm.Decrypt(mainCipherAuto, mainKey);
            Assert.IsTrue(plain.Equals(mainPlain, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void AutoVignereTest3()
        {
            Monoalphabetic algorithm = new Monoalphabetic();
            string key = algorithm.Analyse(mainPlain, mainCipherAuto);
            Assert.IsTrue(key.Equals(mainKey, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
