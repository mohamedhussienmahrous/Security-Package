using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityLibrary.AES;

namespace SecurityPackageTest
{
    [Ignore]
    [TestClass]
    public class AESTest
    {
        string mainPlain = "0x3243F6A8885A308D313198A2e0370734";
        string mainCipher = "0x3925841D02DC09FBDC118597196A0B32";
        string mainKey = "0x2B7E151628AED2A6ABF7158809CF4F3C";

        string mainPlain2 = "0x00000000000000000000000000000001";
        string mainCipher2 = "0x58e2fccefa7e3061367f1d57a4e7455a";
        string mainKey2 = "0x00000000000000000000000000000000";

        string mainPlain3 = "0x00112233445566778899aabbccddeeff";
        string mainCipher3 = "0x69c4e0d86a7b0430d8cdb78070b4c55a";
        string mainKey3 = "0x000102030405060708090a0b0c0d0e0f";


        [TestMethod]
        public void AESTest1()
        {
            AES algorithm = new AES();
            string cipher = algorithm.Encrypt(mainPlain, mainKey);
            Assert.IsTrue(cipher.Equals(mainCipher, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void AESTest2()
        {
            AES algorithm = new AES();
            string plain = algorithm.Decrypt(mainCipher, mainKey);
            Assert.IsTrue(plain.Equals(mainPlain, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void AESTest3()
        {
            AES algorithm = new AES();
            string cipher = algorithm.Encrypt(mainPlain2, mainKey2);
            Assert.IsTrue(cipher.Equals(mainCipher2, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void AESTest4()
        {
            AES algorithm = new AES();
            string plain = algorithm.Decrypt(mainCipher2, mainKey2);
            Assert.IsTrue(plain.Equals(mainPlain2, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void AESTest5()
        {
            AES algorithm = new AES();
            string cipher = algorithm.Encrypt(mainPlain3, mainKey3);
            Assert.IsTrue(cipher.Equals(mainCipher3, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void AESTest6()
        {
            AES algorithm = new AES();
            string plain = algorithm.Decrypt(mainCipher3, mainKey3);
            Assert.IsTrue(plain.Equals(mainPlain3, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
