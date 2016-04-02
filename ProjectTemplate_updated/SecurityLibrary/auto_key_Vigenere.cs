using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    class auto_key_Vigenere
    {
        static string eKey;
        static string dKey;


        public static string encryption(string text, string key)
        {
            string encrypt = "";
            int x, i = 0;
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
                x = (int.Parse((key[g] - 'a').ToString()) + int.Parse((text[g] - 'a').ToString())) % 26;

                encrypt += Convert.ToChar(x + 'a');
            }
            return encrypt.ToUpper();
        }

        public static string Decrypt(string text, string Key)
        {
            string decrypt = "";
            int x = 0, i = 0;
            text.ToLower();
            while (text.Length != Key.Length)
            {
                Key += text[i++];
            }
            //for (int g = 0; g < text.Length; g++)
            //{
            //    x = (int.Parse((Key[g] - 'a').ToString()) + int.Parse((text[g] - 'a').ToString())) % 26;
            //    if (x < 0)
            //        x += 26;
            //    decrypt += Convert.ToChar(x + 'a');
            //}
            return decrypt;
        }
    }
}
