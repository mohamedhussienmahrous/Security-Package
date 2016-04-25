using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    static class RC4Cipher
    {
        public static string encryption(string plainText, string key)
        {
            int[] S = Initial_Permutation_of_S(key.Length, key);
            string cipherText = Stream_Generation_for_ecryption(S, plainText);
            return cipherText;
        }
        public static string dcryption(string cipherText, string key)
        {
            int[] S = Initial_Permutation_of_S(key.Length, key);
            string decryption = Stream_Generation_for_decryption(S, cipherText);
            return decryption;
        }
        static int[] Initial_Permutation_of_S(int Klength, string Key)
        {
            int[] S = new int[256];
            int[] T = new int[256];
            for (int i = 0; i < 256; i++)
            {
                S[i] = i;
                T[i] = Key[i % Klength];
            }

            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + S[i] + T[i]) % 256;
                int x1 = S[i];
                S[i] = S[j];
                S[j] = x1;
            }
            return S;
        }
        static string Stream_Generation_for_ecryption(int[] S, string Plain_text)
        {
            int K = 0, x1, t;
            int i = 0, j = 0;
            string encryption_text = "";
            for (int g = 0; g < Plain_text.Length; g++)
            {
                i = (i + 1) % 256;
                j = (j + S[i]) % 256;
                x1 = S[i];
                S[i] = S[j];
                S[j] = x1;
                t = Convert.ToInt32(S[i] + S[j]) % 256;
                K = Convert.ToInt32(S[t]);
                encryption_text += Convert.ToChar(Plain_text[g] ^ K);
            }
            return encryption_text;
        }
        static string Stream_Generation_for_decryption(int[] S, string ecryption)
        {
            int K = 0;
            int i = 0, j = 0, x1;
            string plain_text = "";
            for (int g = 0; g < ecryption.Length; g++)
            {
                i = (i + 1) % 256;
                j = (j + S[i]) % 256;
                 x1 = S[i];
                S[i] = S[j];
                S[j] = x1;
                int t = Convert.ToInt32(S[i] + S[j]) % 256;
                K = Convert.ToInt32(S[t]);
                plain_text += Convert.ToChar((ecryption[g]) ^ K);
            }
            return plain_text;
        }
    }
}
