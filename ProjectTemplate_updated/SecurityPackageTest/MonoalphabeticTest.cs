using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SecurityPackageTest
{
    [TestClass]
    public class MonoalphabeticTest
    {
        string mainPlain = "meetmeafterthetogaparty";
        string mainCipher = "phhwphdiwhuwkhwrjdsduwb".ToUpper();
        string mainKey = "defghijklmnopqrstuvwxyzabc";


        string mainPlain1 = "abcdefghijklmnopqrstuvwxyz";
        string mainCipher1 = "isyvkjruxedzqmctplofnbwgah".ToUpper();
        string mainKey1 = "isyvkjruxedzqmctplofnbwgah";

        string mainPlain2 = "hellosecuritymonoalphabetic";
        string mainCipher2 = "ukzzcokynlxfaqcmciztuiskfxy".ToUpper();

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
            Regex regex = new Regex("d.{3}hijk.{4}p.rs.u.w.{4}b.");

            Monoalphabetic algorithm = new Monoalphabetic();
            string key = algorithm.Analyse(mainPlain, mainCipher);
            List<char> keyChar = new List<char>(key);
            Assert.AreEqual(key.Length, 26);
            Assert.AreEqual(keyChar.Distinct().Count(), 26);

            Assert.IsTrue(regex.Match(key).Success);
        }

        [TestMethod]
        public void MonoTest4()
        {
            Monoalphabetic algorithm = new Monoalphabetic();
            string cipher = algorithm.Encrypt(mainPlain1, mainKey1);
            Assert.IsTrue(cipher.Equals(mainCipher1, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void MonoTest5()
        {
            Monoalphabetic algorithm = new Monoalphabetic();
            string plain = algorithm.Decrypt(mainCipher1, mainKey1);
            Assert.IsTrue(plain.Equals(mainPlain1, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void MonoTest6()
        {
            Monoalphabetic algorithm = new Monoalphabetic();
            string key = algorithm.Analyse(mainPlain1, mainCipher1);
            List<char> keyChar = new List<char>(key);
            Assert.AreEqual(key.Length, 26);
            Assert.AreEqual(keyChar.Distinct().Count(), 26);
            Assert.IsTrue(key.Equals(mainKey1, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void MonoTest7()
        {
            Monoalphabetic algorithm = new Monoalphabetic();
            string cipher = algorithm.Encrypt(mainPlain2, mainKey1);
            Assert.IsTrue(cipher.Equals(mainCipher2, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void MonoTest8()
        {
            Monoalphabetic algorithm = new Monoalphabetic();
            string plain = algorithm.Decrypt(mainCipher2, mainKey1);
            Assert.IsTrue(plain.Equals(mainPlain2, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void MonoTest9()
        {
            Regex regex = new Regex("isy.k.{2}ux.{2}zqmct.lofn.{3}a.");

            Monoalphabetic algorithm = new Monoalphabetic();
            string key = algorithm.Analyse(mainPlain2, mainCipher2);
            List<char> keyChar = new List<char>(key);
            Assert.AreEqual(key.Length, 26);
            Assert.AreEqual(keyChar.Distinct().Count(), 26);

            Assert.IsTrue(regex.Match(key).Success);
        }
    }
}
