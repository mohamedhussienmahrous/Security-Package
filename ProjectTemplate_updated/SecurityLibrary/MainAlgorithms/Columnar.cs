﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Columnar : ICryptographicTechnique<string, List<int>>
    {
        public List<int> Analyse(string plainText, string cipherText)
        {
            return Columnarcipher.analysis(plainText, cipherText);
        }

        public string Decrypt(string cipherText, List<int> key)
        {
            return Columnarcipher.Decryption(cipherText, key);
        }

        public string Encrypt(string plainText, List<int> key)
        {
           return Columnarcipher.encryption(plainText, key);
        }
    }
}
