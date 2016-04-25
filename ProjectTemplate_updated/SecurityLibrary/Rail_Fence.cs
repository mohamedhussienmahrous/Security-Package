using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    class Rail_Fence
    {
        public static string encryption(string plaintext, int key)
        {
            int vb = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(plaintext.Length) / Convert.ToDouble(key)));
            string cipher = "";
            for (int w = 0; w < key; w++)
                for (int g = w; g <= (vb * key) - key; g += key)
                {
                  
                    cipher += plaintext[g];                   
                }
            return (cipher).ToUpper();
        }
        public static string Decryption(string cipher, int key)
        {
            int vb = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cipher.Length) / Convert.ToDouble(key)));

            string plaintext = "";
            for (int w = 0; w < vb; w++)
                for (int g = w; g < (key * vb); g += vb)
                {
                    if (g >= cipher.Length)
                        continue;
  
                    plaintext += cipher[g];
                }
            return (plaintext).ToLower();
        }
        static public int analysis(string PlainText, string cipherText)
        {
            PlainText = PlainText.ToLower();
            cipherText = cipherText.ToLower();
            int key = 1;
            int vb = 0, w = 0;
            bool kaml = true;
            while (kaml)
            {
                if (key > PlainText.Length) break;
                vb = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(PlainText.Length) / Convert.ToDouble(key)));
                w = 0;
                for (int g = 0; g <= (vb * key) - key; g += key)
                {

                    if (PlainText[g] != cipherText[w])
                    {
                        ++key;
                        kaml = true;
                        break;

                    }
                    else kaml = false;
                    ++w;
                }
            }
            return key;
        }

    }
}
