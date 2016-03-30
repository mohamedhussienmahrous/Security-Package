using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityLibrary.AES;

namespace SecurityPackageTest
{
    [Ignore]
    [TestClass]
    public class ExtendedEuclidTest
    {
        [TestMethod]
        public void ExtendedEuclidTest1()
        {
            ExtendedEuclid algorithm = new ExtendedEuclid();
            int res = algorithm.GetMultiplicativeInverse(23, 26);
            Assert.AreEqual(res, 17);
        }

        [TestMethod]
        public void ExtendedEuclidTest2()
        {
            ExtendedEuclid algorithm = new ExtendedEuclid();
            int res = algorithm.GetMultiplicativeInverse(22, 26);
            Assert.AreEqual(res, -1);
        }

    }
}
