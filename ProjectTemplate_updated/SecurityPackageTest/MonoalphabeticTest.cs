using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityLibrary;
using System.Collections.Generic;
using System.Linq;

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
            List<char> keyChar = new List<char>(key);
            Assert.AreEqual(key.Length, 26);
            Assert.AreEqual(keyChar.Distinct().Count(), 26);

            Assert.AreEqual(key[0], 'd'); 
            //Assert.AreEqual(key[1], 'e');
            //Assert.AreEqual(key[2], 'f');
            //Assert.AreEqual(key[3], 'g');
            Assert.AreEqual(key[4], 'h');
            Assert.AreEqual(key[5], 'i');
            Assert.AreEqual(key[6], 'j');
            Assert.AreEqual(key[7], 'k');
            //Assert.AreEqual(key[8], 'l');
            //Assert.AreEqual(key[9], 'm');
            //Assert.AreEqual(key[10], 'n');
            //Assert.AreEqual(key[11], 'o');
            Assert.AreEqual(key[12], 'p');
            //Assert.AreEqual(key[13], 'q');
            Assert.AreEqual(key[14], 'r');
            Assert.AreEqual(key[15], 's');
            //Assert.AreEqual(key[16], 't');
            Assert.AreEqual(key[17], 'u');
            //Assert.AreEqual(key[18], 'v');
            Assert.AreEqual(key[19], 'w');
            //Assert.AreEqual(key[20], 'x');
            //Assert.AreEqual(key[21], 'y');
            //Assert.AreEqual(key[22], 'z');
            //Assert.AreEqual(key[23], 'a');
            Assert.AreEqual(key[24], 'b');
            //Assert.AreEqual(key[25], 'c');
        }
    }
}
