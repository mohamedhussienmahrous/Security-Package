using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SecurityLibrary;

namespace SecurityPackageTest
{
    [TestClass]
    public class ColumnarTest
    {
        string mainPlain1 = "attackpostponeduntiltwoam";
        string mainPlain2 = "attackpostponeduntiltwoamxxx";

        List<int> key = new List<int>() { 4, 3, 1, 2, 5, 6, 7 };

        string mainCipher1 = "ttnaaptmtsuoaodwcoiknlpet".ToUpper();
        string mainCipher2 = "ttnaaptmtsuoaodwcoixknlxpetx".ToUpper();

        [TestMethod]
        public void ColumnarTest1()
        {
            Columnar algorithm = new Columnar();
            string cipher = algorithm.Encrypt(mainPlain1, key);
            // Add x's or not
            Assert.IsTrue(cipher.Equals(mainCipher1, StringComparison.InvariantCultureIgnoreCase)
                       || cipher.Equals(mainCipher2, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void ColumnarTest2()
        {
            Columnar algorithm = new Columnar();
            string plain1 = algorithm.Decrypt(mainCipher1, key);
            string plain2 = algorithm.Decrypt(mainCipher2, key);

            Assert.IsTrue(plain1.Equals(mainPlain1, StringComparison.InvariantCultureIgnoreCase)
             || plain2.Equals(mainPlain2, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void ColumnarTest3()
        {
            Columnar algorithm = new Columnar();
            List<int> key1 = algorithm.Analyse(mainPlain1, mainCipher1);
            List<int> key2 = algorithm.Analyse(mainPlain2, mainCipher2);
            for (int i = 0; i < key.Count; i++)
            {
                Assert.IsTrue(key[i] == key1[i] || key[i] == key2[i]);
            }
        }
    }
}
