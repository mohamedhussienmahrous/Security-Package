using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityLibrary;

namespace SecurityPackageTest
{
    [TestClass]
    public class PlayfairTest
    {
        string mainPlain = "armuhsea";
        string mainKey = "monoarchy";
        string mainCipher = "rmcmbpim".ToUpper();

        string mainPlain1 = "hidethegold";
        string mainKey1 = "helloworld";
        string mainCipher1 = "lfgdmwdnwoav".ToUpper();

        string mainPlain2 = "comsecmeanscommunicationssecurity";
        string mainPlain22 = "comsecmeanscommunjcatjonssecurjty";
        string mainKey2 = "galois";
        string mainCipher2 = "dlfdsdndihbddtntuebluoimcvbserulyo".ToUpper();
        string mainCipher22 = "dlfdsdndjhbddtntuebluojmcvbserulyo".ToUpper();


        [TestMethod]
        public void PlayfairTest1()
        {
            PlayFair algorithm = new PlayFair();
            string cipher = algorithm.Encrypt(mainPlain, mainKey);
            Assert.IsTrue(cipher.Equals(mainCipher, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void PlayfairTest2()
        {
            PlayFair algorithm = new PlayFair();
            string plain = algorithm.Decrypt(mainCipher, mainKey);
            Assert.IsTrue(plain.Equals(mainPlain, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void PlayfairTest3()
        {
            PlayFair algorithm = new PlayFair();
            string key = algorithm.Analyse(mainPlain, mainCipher);
            Assert.IsTrue(key.Equals(mainKey, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void PlayfairTest4()
        {
            PlayFair algorithm = new PlayFair();
            string cipher = algorithm.Encrypt(mainPlain1, mainKey1);
            Assert.IsTrue(cipher.Equals(mainCipher1, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void PlayfairTest5()
        {
            PlayFair algorithm = new PlayFair();
            string plain = algorithm.Decrypt(mainCipher1, mainKey1);
            Assert.IsTrue(plain.Equals(mainPlain1, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void PlayfairTest6()
        {
            PlayFair algorithm = new PlayFair();
            string cipher = algorithm.Encrypt(mainPlain2, mainKey2);
            Assert.IsTrue(cipher.Equals(mainCipher2, StringComparison.InvariantCultureIgnoreCase) ||
                cipher.Equals(mainCipher22, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void PlayfairTest7()
        {
            PlayFair algorithm = new PlayFair();
            string plain = algorithm.Decrypt(mainCipher2, mainKey2);
            Assert.IsTrue(plain.Equals(mainPlain2, StringComparison.InvariantCultureIgnoreCase) ||
                plain.Equals(mainPlain22, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
