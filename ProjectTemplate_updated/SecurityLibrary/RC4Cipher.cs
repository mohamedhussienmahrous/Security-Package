using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    class RC4Cipher
    {
        public static string encryption(string plainText, string key)
        {
            char[] S = Initial_Permutation_of_S(key.Length, key);
            string cipherText = Stream_Generation_for_ecryption(S, plainText);
            return cipherText;
        }
        public static string dcryption(string cipherText, string key)
        {
            char[] S = Initial_Permutation_of_S(key.Length, key);
            string decryption = Stream_Generation_for_decryption(S, cipherText);
            return decryption;
        }
        static char[] Initial_Permutation_of_S(int Klength, string Key)
        {
            char[] S = new char[256];
            char[] T = new char[256];
            for (int i = 0; i < 256; i++)
            {
                S[i] = Convert.ToChar(i);
                T[i] = Key[i % Klength];
            }

            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + S[i] + T[i]) % 256;
                char x1 = S[i];
                S[i] = S[j];
                S[j] = x1;
            }
            return S;
        }
        static string Stream_Generation_for_ecryption(char[] S, string Plain_text)
        {
            int K = 0;
            int i = 0, j = 0;
            string encryption_text = "";
            for (int g = 0; g < Plain_text.Length; g++)
            {
                i = (i + 1) % 256;
                j = (j + S[j]) % 256;
                char x1 = S[i];
                S[i] = S[j];
                S[j] = x1;
                int t = Convert.ToInt32(S[i] + S[j]) % 256;
                K = Convert.ToInt32(S[t]);
                encryption_text += (Convert.ToInt32(Plain_text[g]) ^ K).ToString();
            }
            return encryption_text;
        }
        static string Stream_Generation_for_decryption(char[] S, string ecryption)
        {
            int K = 0;
            int i = 0, j = 0;
            string plain_text = "";
            for (int g = 0; g < ecryption.Length; g++)
            {
                i = (i + 1) % 256;
                j = (j + S[j]) % 256;
                char x1 = S[i];
                S[i] = S[j];
                S[j] = x1;
                int t = Convert.ToInt32(S[i] + S[j]) % 256;
                K = Convert.ToInt32(S[t]);
                plain_text += (Convert.ToInt32(ecryption[g]) ^ K).ToString();
            }
            return plain_text;
        }
    }
}
