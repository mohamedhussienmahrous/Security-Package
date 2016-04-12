using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class RailFence : ICryptographicTechnique<string, int>
    {
        public int Analyse(string plainText, string cipherText)
        {
            throw new NotImplementedException();
        }

        public string Decrypt(string cipherText, int key)
        {
            return Rail_Fence.Decryption(cipherText, key); 
        }

        public string Encrypt(string plainText, int key)
        {
            return Rail_Fence.encryption(plainText, key);
            
        }
    }
}
