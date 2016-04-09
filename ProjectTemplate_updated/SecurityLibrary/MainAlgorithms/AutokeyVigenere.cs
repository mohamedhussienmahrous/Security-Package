using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class AutokeyVigenere : ICryptographicTechnique<string, string>
    {
        public string Analyse(string plainText, string cipherText)
        {
            return auto_key_Vigenere.Analysis(plainText, cipherText);
        }

        public string Decrypt(string cipherText, string key)
        {
            return auto_key_Vigenere.Decrypt(cipherText, key);
        }

        public string Encrypt(string plainText, string key)
        {
            return auto_key_Vigenere.encryption(plainText, key);
        }
    }
}
