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
                for (int g = w; g <= (vb*key)-key; g+=key)
                {
                    //if (g >= plaintext.Length)
                    //    cipher += 'x';
                    //else
                    cipher += plaintext[g];                   
                }
            return (cipher).ToUpper();
        }
        public static string Decryption(string cipher, int key)
        {
            int vb = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cipher.Length) / Convert.ToDouble(key)));
            string plaintext = "";
            for (int w = 0; w < vb; w++)
                for (int g = w; g <= (vb * key) - key; g += vb)
                {
                    plaintext += cipher[g];
                }
            return (plaintext);
        }
        static public List<int> analysis(string PlainText, string cipher)
        {
            cipher = cipher.ToLower();
            List<int> key = new List<int>();
            //int vb = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(PlainText.Length) / Convert.ToDouble(key.Count)));
            //char[] cipher = new char[vb * key.Count];
            //for (int w = 0; w < key.Count; w++)
            //    for (int g = 0; g < vb; g++)
            //    {
            //        if ((key[w] - 1) * (vb) + (g) >= cipher.Length)
            //            continue;
            //        else if (w + (g) * (key.Count) >= plaintext.Length)
            //            cipher[(key[w] - 1) * (vb) + (g)] = 'x';
            //        else
            //            cipher[(key[w] - 1) * (vb) + (g)] = plaintext[w + (g) * (key.Count)];
            //    }
            return key;
        }

    }
}
