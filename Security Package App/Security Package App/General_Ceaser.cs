using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security_Package_App
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
        static string encryption(string text, int K)
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
                encrypt += e.ToString();

            }
            return encrypt;
        }
        /*
         d(x) = (x-K)%26
         * to decrypt the target text
         * */
        static string decryption(string encyrpt, int K)
        {
            int x = 0;
            int e;
            dKey = K;
            decrypt = "";
            for (int index = 0; index < encyrpt.Length; ++index)
            {
                x = Convert.ToInt32(encyrpt[index]);
                e = (x - dKey) % 26;
                decrypt += e.ToString();
            }
            return decrypt;
        }

    }
}
