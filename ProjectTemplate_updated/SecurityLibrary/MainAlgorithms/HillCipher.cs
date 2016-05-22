using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    /// <summary>
    /// The List<int> is row based. Which means that the key is given in row based manner.
    /// </summary>
    public class HillCipher : ICryptographicTechnique<string, string>, ICryptographicTechnique<List<int>, List<int>>
    {
        public List<int> Analyse(List<int> plainText, List<int> cipherText)
        {
            return HillcipherClass.Analyse(plainText, cipherText);
        }

        public string Analyse(string plainText, string cipherText)
        {
            return HillcipherClass.Analyse(plainText, cipherText);
        }

        public List<int> Decrypt(List<int> cipherText, List<int> key)
        {
            return HillcipherClass.Decrypt(cipherText, key);
        }

        public string Decrypt(string cipherText, string key)
        {

            return HillcipherClass.Decrypt(cipherText, key);
        }

        public List<int> Encrypt(List<int> plainText, List<int> key)
        {
            return HillcipherClass.Encrypt(plainText, key);
        }

        public string Encrypt(string plainText, string key)
        {
            return HillcipherClass.Encrypt(plainText, key);
        }

        public List<int> Analyse3By3Key(List<int> plainText, List<int> cipherText)
        {
            return HillcipherClass.Analyse3By3(plainText, cipherText);
        }

        public string Analyse3By3Key(string plainText, string cipherText)
        {
            return HillcipherClass.Analyse3By3(plainText, cipherText);
        }
    }
}
