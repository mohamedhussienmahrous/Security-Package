using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    static class Columnarcipher
    {
        public static string encryption(string plaintext, List<int> key)
        {
            int vb = Convert.ToInt32( Math.Ceiling(Convert.ToDouble(plaintext.Length) / Convert.ToDouble(key.Count)));
            char[] cipher = new char[vb*key.Count];
            for (int w = 0; w < key.Count; w++)
                for (int g = 0; g < vb; g++)
                {
                    if ((key[w] - 1) * (vb) + (g) >= cipher.Length)
                        continue;
                    else if (w + (g) * (key.Count) >= plaintext.Length)
                        cipher[(key[w] - 1) * (vb) + (g)] = 'x';
                    else
                        cipher[(key[w] - 1) * (vb) + (g)] = plaintext[w + (g) * (key.Count)];
                }
            return new string(cipher).ToUpper();
        }
        public static string Decryption(string cipher, List<int> key)
        {
            cipher = cipher.ToLower();
            char[] PlainText = new char[cipher.Length];
            int vb = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(PlainText.Length) / Convert.ToDouble(key.Count)));
            int vb1 = Convert.ToInt32(Math.Floor(Convert.ToDouble(PlainText.Length) / Convert.ToDouble(key.Count)));

            for (int w = 0; w < key.Count; w++)
                for (int g = 0; g < vb; g++)
                {
                    if ((key[w] - 1) * (vb) + (g) >= cipher.Length)
                        continue;
                    else if (w + (g) * (key.Count) >= PlainText.Length)
                        continue;
                    else
                        PlainText[w + (g) * (key.Count)] = cipher[(key[w] - 1) * (vb) + (g)];
                }
            string f = new string(PlainText);
            //if (vb - vb1 == 0)
            //    f.Substring(0,f.Length-vb - vb1);

            return new string(PlainText);
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
