using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityLibrary.DiffieHellman;
using System.Collections.Generic;

namespace SecurityPackageTest
{
    [Ignore]
    [TestClass]
    public class DeffieHelmanTest
    {
        [TestMethod]
        public void DeffieHelmanTest1()
        {
            DiffieHellman algorithm = new DiffieHellman();
            List<int> key = algorithm.GetKeys(353, 3, 97, 233);
            Assert.AreEqual(key[0], 11);
            Assert.AreEqual(key[1], 11);
        }
    }
}
