using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Monoalphabetic : ICryptographicTechnique<string, string>
    {
        public string Analyse(string plainText, string cipherText)
        {
            return MonoalphabeticCipher.Analysis(plainText, cipherText);
        }

        public string Decrypt(string cipherText, string key)
        {
            return MonoalphabeticCipher.Decrypt(cipherText, key);
        }

        public string Encrypt(string plainText, string key)
        {
            //throw new NotImplementedException();
            return MonoalphabeticCipher.Encrypt(plainText, key).ToUpper();
        }
    }
}
