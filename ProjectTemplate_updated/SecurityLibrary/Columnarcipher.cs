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
            int vb = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(plaintext.Length) / Convert.ToDouble(key.Count)));
            char[] cipher = new char[vb * key.Count];
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
            return new string(PlainText);
        }
        static public List<int> analysis(string PlainText, string cipherText)
        {

            List<int> keys = new List<int>();
            int LastKeys = 1;
            keys.Add(LastKeys++);
            keys.Add(LastKeys);
            List<char> str_plain = new List<char>(), str_cipher = new List<char>();


            PlainText = PlainText.ToLower();
            cipherText = cipherText.ToLower();
            bool K = true;
            bool ykamel = true;
            int number_of_words = 0;
            while (ykamel)
            {
                string w = encryption(PlainText, keys).ToLower();
                number_of_words = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(PlainText.Count()) / Convert.ToDecimal(keys.Count())));
                for (int s = 0; s < cipherText.Count(); s += number_of_words)
                {
                    for (int x = 0; x < number_of_words; x++)
                    {
                        if (s + x >= cipherText.Length || w[x] != cipherText[s + x])
                        {
                            K = true;
                            break;
                        }
                        else
                        {
                            K = false;
                        }
                    }
                    if (K == false)
                    {
                        break;
                    }
                }
                if (K == false)
                {
                    ykamel = false;
                    break;
                }
                else
                    keys.Add(++LastKeys);


            }

            List<int> finalkeys = new List<int>();
            String fw = encryption(PlainText, keys).ToLower();
            number_of_words = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(PlainText.Count()) / Convert.ToDecimal(keys.Count())));
            int gindexer = 0;
            int v = cipherText.Count();
            char d = cipherText[gindexer];
            for (int s = 0; s < fw.Count(); s += number_of_words)
            {
                K = false;
                int gindex = 0;
                bool k1 = true;
                while (k1 && gindex < cipherText.Length)
                {
                    for (int x = 0; x < number_of_words; x++)
                    {
                        if (s + x >= fw.Length || x + gindex >= cipherText.Length || cipherText[x + gindex] != fw[s + x])
                        {
                            K = true;
                            break;
                        }
                        else
                        {
                            K = false;
                        }
                    }
                    if (K == false)
                    {
                        finalkeys.Add((gindex / number_of_words) + 1);
                        k1 = false;
                        // break;
                    }
                    gindex += number_of_words;
                }

            }
            while (finalkeys.Count() != keys.Count())
            {
                finalkeys.Add(0);
            }
            return finalkeys;
        }

    }

}
