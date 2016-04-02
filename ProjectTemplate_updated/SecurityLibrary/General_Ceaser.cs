using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    static class General_Ceaser
    {
        static int eKey;
        static int dKey;

        public static string encrypt;
        public static string decrypt;

        /*
         * 
         e(x) = (x+K)mod 26;
         * to encrypt the input text
         */
        public static string encryption(string text, int K)
        {
            int x = 0;
            int e;
            eKey = K;
            encrypt = "";
            for (int index = 0; index < text.Length; index++)
            {
                if ('a' <= text[index] && text[index] <= 'z')
                {
                    x = Convert.ToInt32(text[index] - 'a');
                }
                e = (x + eKey) % 26;
                if (e < 0) e += 26;
                encrypt += Convert.ToChar(e + 'a');

            }
            return encrypt;
        }
        /*
         d(x) = (x-K)%26
         * to decrypt the target text
         * */
        public static string decryption(string encyrpt, int K)
        {
            encyrpt = encyrpt.ToLower();
            int x = 0;
            int e;
            decrypt = "";
            for (int index = 0; index < encyrpt.Length; ++index)
            {
                x = Convert.ToInt32(encyrpt[index] - 'a');
                e = (x - K) % 26;
                if (e < 0) e += 26;
                decrypt += Convert.ToChar(e + 'a');
            }
            return decrypt;
        }

    }
}