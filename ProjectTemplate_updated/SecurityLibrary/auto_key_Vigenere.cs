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
           text= text.ToLower();
           Key = Key.ToLower();
            //while (text.Length != Key.Length)
            //{
            //    Key += Key[i++];
            //    if (i > Key.Length) i = 0;
            //}
            for (int g = 0; g < text.Length; g++)
            {
                x = (int.Parse((text[g] - 'a').ToString()) - int.Parse((Key[g] - 'a').ToString())) % 26;
                if (x < 0)
                    x += 26;
                char ch= Convert.ToChar(x + 'a');
                decrypt += ch;
                Key += ch;
            }
            return decrypt;
        }

        public static string Analysis(string text, string Cipher)
        {
            string Key = "";
            int x = 0;
            text = text.ToLower();
            Cipher = Cipher.ToLower();

            for (int g = 0; g < text.Length; g++)
            {
                x = (int.Parse((Cipher[g] - 'a').ToString()) - int.Parse((text[g] - 'a').ToString())) % 26;
                if (x < 0)
                    x += 26;
                char ch = Convert.ToChar(x + 'a');
                Key += ch;
               
            }
            string Common = LCS(text, Key);
            Key= Key.Substring(0,(Key.Length-Common.Length));
            
            return Key;
        }
        private static string LCS(string str1,string str2)
        {
            string common="";
            ////LCS dynamic programing

            return common;
        }
    }
}
