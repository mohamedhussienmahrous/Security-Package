using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.AES
{
    /// <summary>
    /// If the string starts with 0x.... then it's Hexadecimal not string
    /// </summary>
    public class AES : CryptographicTechnique
    {
        public override string Decrypt(string cipherText, string key)
        {
            AESAlgorithm AES = new AESAlgorithm();
            return AES.Decrypt(cipherText, key);
        }

        public override string Encrypt(string plainText, string key)
        {
            AESAlgorithm AES = new AESAlgorithm();
            return AES.Encrypt(plainText, key);
        }
    }
}
