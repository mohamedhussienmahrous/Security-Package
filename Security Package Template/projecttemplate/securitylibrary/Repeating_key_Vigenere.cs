using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    class Repeating_key_Vigenere
    {
        static string eKey;
        static string dKey;

        public static string encrypt;
        public static string decrypt;
        static string encryption(string text, string key)
        {
            int x, i = 0;
            encrypt = "";
            key.ToUpper();
            text.ToUpper();
           
            while (text.Length != key.Length)
            {
                key += text[i++];
            }
            eKey = key;
            dKey = key;
            for (int g = 0; g < text.Length; g++)
            {
                x = (int.Parse((key[g % text.Length] - 'A').ToString()) + int.Parse((text[g % text.Length] - 'A').ToString())) % 26;
                encrypt += x.ToString();
            }
            return encrypt;
        }

        static string encryption(string text)
        {
            int x, i = 0;
            encrypt = "";
            text.ToUpper();

            for (int g = 0; g < text.Length; g++)
            {
                x = (int.Parse((dKey[g % text.Length] - 'A').ToString()) - int.Parse((text[g % text.Length] - 'A').ToString())) % 26;
                encrypt += x.ToString();
            }
            return encrypt;
        }
    }
}
