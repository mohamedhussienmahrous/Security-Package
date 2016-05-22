using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class RepeatingkeyVigenere : ICryptographicTechnique<string, string>
    {
        public string Analyse(string plainText, string cipherText)
        {
            return Vigenere_with_Repeating_key.Analyse(plainText,cipherText);
        }

        public string Decrypt(string cipherText, string key)
        {
            return Vigenere_with_Repeating_key.decrypt(cipherText, key);
        }

        public string Encrypt(string plainText, string key)
        {
            return Vigenere_with_Repeating_key.encrypt(plainText, key);
        }
    }
}