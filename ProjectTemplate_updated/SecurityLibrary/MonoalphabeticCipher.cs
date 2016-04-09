using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    static class MonoalphabeticCipher
    {
        public static string Encrypt(string Plain,string Key)
        {
            string Cipher = "";
            Plain = Plain.ToLower();
            Key = Key.ToLower();
            for(int i=0;i<Plain.Length;++i)
            {
                int index = Plain[i] - 'a';
                Cipher += Key[index];
            }
                return Cipher;
        }
        public static string Decrypt(string Cipher, string Key)
        {
            string Plain = "";
            Cipher = Cipher.ToLower();
            Key = Key.ToLower();
            for (int i = 0; i < Cipher.Length;++i )
            {
                int C = search(Key, Cipher[i]);
                Plain += Convert.ToChar('a' + C);
            }

                return Plain;

        }
        private static int search(string Key,char ch)
        {
            for(int i=0;i<Key.Length;i++)
            if (ch == Key[i])
                    return i;
            
            return 0;
        }
        public static string Analysis(string Plain,string Cipher)
        {
            char[] Key = new char[26];
            Plain = Plain.ToLower();
            Cipher = Cipher.ToLower();
            for (int i = 0; i < Plain.Length;++i )
            {
                int index = Convert.ToInt32(Plain[i] - 'a');
                Key[index] = Cipher[i];
            }

            return new string(Key);
        }
    }
}
