using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityLibrary;

namespace SecurityPackageTest
{
    [TestClass]
    public class MonoalphabeticTest
    {
        string mainPlain = "meetmeafterthetogaparty";
        string mainCipher = "phhwphdiwhuwkhwrjdsduwb".ToUpper();
        string mainKey = "defghijklmnopqrstuvwxyzabc";

        [TestMethod]
        public void MonoTest1()
        {
            Monoalphabetic algorithm = new Monoalphabetic();
            string cipher = algorithm.Encrypt(mainPlain, mainKey);
            Assert.IsTrue(cipher.Equals(mainCipher, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void MonoTest2()
        {
            Monoalphabetic algorithm = new Monoalphabetic();
            string plain = algorithm.Decrypt(mainCipher, mainKey);
            Assert.IsTrue(plain.Equals(mainPlain, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void MonoTest3()
        {
            Monoalphabetic algorithm = new Monoalphabetic();
            string key = algorithm.Analyse(mainPlain, mainCipher);
            Assert.IsTrue(key.Equals(mainKey, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
