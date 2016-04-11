﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityLibrary;

namespace SecurityPackageTest
{
    [TestClass]
    public class RailFenceTest
    {
        string mainPlain = "meetmeaftertheparty";
        string mainCipher = "mematrhpryetefeteat".ToUpper();

        string mainCipher2 = "mtaehayemfrerxeettptx".ToUpper();
        string mainCipher3 = "mtaehayemfrereettpt".ToUpper();

        int mainKey = 2;
        int mainKey2 = 3;

        [TestMethod]
        public void RailFenceTest1()
        {
            RailFence algorithm = new RailFence();
            string cipher = algorithm.Encrypt(mainPlain, mainKey);
            Assert.IsTrue(cipher.Equals(mainCipher, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void RailFenceTest2()
        {
            RailFence algorithm = new RailFence();
            string plain = algorithm.Decrypt(mainCipher, mainKey);
            Assert.IsTrue(plain.Equals(mainPlain, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void RailFenceTest3()
        {
            RailFence algorithm = new RailFence();
            int key = algorithm.Analyse(mainPlain, mainCipher);
            Assert.AreEqual(mainKey, key);
        }

        [TestMethod]
        public void RailFenceTest4()
        {
            RailFence algorithm = new RailFence();
            string cipher = algorithm.Encrypt(mainPlain, mainKey2);
            // Add x's or not
            Assert.IsTrue(cipher.Equals(mainCipher2, StringComparison.InvariantCultureIgnoreCase) 
                       || cipher.Equals(mainCipher3, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void RailFenceTest5()
        {
            RailFence algorithm = new RailFence();
            string plain1 = algorithm.Decrypt(mainCipher2, mainKey2);
            string plain2 = algorithm.Decrypt(mainCipher3, mainKey2);

            Assert.IsTrue(plain1.Equals(mainPlain, StringComparison.InvariantCultureIgnoreCase)
             || plain2.Equals(mainPlain, StringComparison.InvariantCultureIgnoreCase));

        }

        [TestMethod]
        public void RailFenceTest6()
        {
            RailFence algorithm = new RailFence();
            int key = algorithm.Analyse(mainPlain, mainCipher2);
            int key2 = algorithm.Analyse(mainPlain, mainCipher3);
            Assert.IsTrue(mainKey2 ==  key || mainKey2 == key2);
        }
    }
}
