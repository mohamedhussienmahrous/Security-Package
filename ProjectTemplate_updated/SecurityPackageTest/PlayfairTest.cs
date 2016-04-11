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
    }
}
