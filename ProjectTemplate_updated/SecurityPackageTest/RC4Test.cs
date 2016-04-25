using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityLibrary.RC4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityPackageTest
{
    [TestClass]
    public class RC4Test
    {
        [TestMethod]
        public void RC4Test1()
        {
            RC4 algorithm = new RC4();
            string cipher = algorithm.Encrypt("abcd", "test");
            Assert.IsTrue(cipher.Equals("ÏíDu"));
        }

        [TestMethod]
        public void RC4Test2()
        {
            RC4 algorithm = new RC4();
            string cipher = algorithm.Decrypt("ÏíDu", "test");
            Assert.IsTrue(cipher.Equals("abcd"));
        }

        [TestMethod]
        public void RC4Test3()
        {
            RC4 algorithm = new RC4();
            string cipher = algorithm.Encrypt("0x61626364", "0x74657374");
            Assert.IsTrue(cipher.Equals("0xcfed4475", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void RC4Test4()
        {
            RC4 algorithm = new RC4();
            string cipher = algorithm.Encrypt("0xcfed4475", "0x74657374");
            Assert.IsTrue(cipher.Equals("0x61626364", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
