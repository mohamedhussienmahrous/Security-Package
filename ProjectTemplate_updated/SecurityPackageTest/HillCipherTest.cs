using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityLibrary;
using System.Collections.Generic;

namespace SecurityPackageTest
{
    [TestClass]
    public class HillCipherTest
    {
        List<int> key = new List<int>() { 3, 2, 8, 5 };
        List<int> plain = new List<int>() { 15, 0, 24, 12, 14, 17, 4, 12, 14, 13, 4, 24 };
        List<int> cipher = new List<int>() { 19, 16, 18, 18, 24, 15, 10, 14, 16, 21, 8, 22 };

        string mainPlain = "paymoremoney";
        string mainCipher = "tqssypkoqviw".ToUpper();

        string mainPlainError = "lkdi";
        string mainCipherError = "SDEK".ToUpper();

        List<int> mainPlainError2 = new List<int>() { 11, 10, 3, 8 };
        List<int> mainCipherError2 = new List<int>() { 18, 3, 4, 10 };

        string mainKey = "dcif";

        [TestMethod]
        public void HillCipherTest1()
        {
            HillCipher algorithm = new HillCipher();
            string cipher = algorithm.Encrypt(mainPlain, mainKey);
            Assert.IsTrue(cipher.Equals(mainCipher, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void HillCipherTest2()
        {
            HillCipher algorithm = new HillCipher();
            string plain = algorithm.Decrypt(mainCipher, mainKey);
            Assert.IsTrue(plain.Equals(mainPlain, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void HillCipherTest3()
        {
            HillCipher algorithm = new HillCipher();
            string key = algorithm.Analyse(mainPlain, mainCipher);
            Assert.IsTrue(key.Equals(mainKey, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void HillCipherTest4()
        {
            HillCipher algorithm = new HillCipher();
            
            List<int> cipher2 = algorithm.Encrypt(plain, key);
            for (int i = 0; i < cipher.Count; i++)
            {
                Assert.AreEqual(cipher[i], cipher2[i]);
            }
        }

        [TestMethod]
        public void HillCipherTest5()
        {
            HillCipher algorithm = new HillCipher();

            List<int> plain2 = algorithm.Decrypt(cipher, key);
            for (int i = 0; i < plain2.Count; i++)
            {
                Assert.AreEqual(plain[i], plain2[i]);
            }
        }

        [TestMethod]
        public void HillCipherTest6()
        {
            HillCipher algorithm = new HillCipher();

            List<int> key2 = algorithm.Analyse(plain, cipher);
            for (int i = 0; i < key2.Count; i++)
            {
                Assert.AreEqual(key[i], key2[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAnlysisException))]
        public void HillCipherError1()
        {
            HillCipher algorithm = new HillCipher();

            string key2 = algorithm.Analyse(mainPlainError, mainCipherError);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAnlysisException))]
        public void HillCipherError2()
        {
            HillCipher algorithm = new HillCipher();

            List<int> key2 = algorithm.Analyse(mainPlainError2, mainCipherError2);
        }
    }
}
