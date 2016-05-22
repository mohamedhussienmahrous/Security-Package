using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{

    public class Monoalphabetic : ICryptographicTechnique<string, string>
    {


        public string Analyse(string plainText, string cipherText)
        {
            return MonoalphabeticCipher.Analysis(plainText, cipherText);
        }

        public string Decrypt(string cipherText, string key)
        {
            return MonoalphabeticCipher.Decrypt(cipherText, key);
        }

        public string Encrypt(string plainText, string key)
        {

            return MonoalphabeticCipher.Encrypt(plainText, key).ToUpper();
        }

        
        /// <summary>
        /// Frequency Information:
        /// E   12.51%
        /// T	9.25
        /// A	8.04
        /// O	7.60
        /// I	7.26
        /// N	7.09
        /// S	6.54
        /// R	6.12
        /// H	5.49
        /// L	4.14
        /// D	3.99
        /// C	3.06
        /// U	2.71
        /// M	2.53
        /// F	2.30
        /// P	2.00
        /// G	1.96
        /// W	1.92
        /// Y	1.73
        /// B	1.54
        /// V	0.99
        /// K	0.67
        /// X	0.19
        /// J	0.16
        /// Q	0.11
        /// Z	0.09
        /// </summary>
        /// <param name="cipher"></param>
        /// <returns>Plain text</returns>
        public string AnalyseUsingCharFrequency(string cipher)
        {
            List<char> arr = new List<char>();
            arr.Add('E');
            arr.Add('T');
            arr.Add('A');
            arr.Add('O');
            arr.Add('I');
            arr.Add('N');
            arr.Add('S');
            arr.Add('R');
            arr.Add('H');
            arr.Add('L');
            arr.Add('D');
            arr.Add('C');
            arr.Add('U');
            arr.Add('M');
            arr.Add('F');
            arr.Add('P');
            arr.Add('G');
            arr.Add('W');
            arr.Add('Y');
            arr.Add('B');
            arr.Add('V');
            arr.Add('K');
            arr.Add('X');
            arr.Add('J');
            arr.Add('Q');
            arr.Add('Z');
           

            string all_char_from_cipher = new String(cipher.Distinct().ToArray());
            //int index = 0;
            double[] freq_for_cip = new double[all_char_from_cipher.Length];

            for (int S = 0; S < cipher.Length; S++)
            {
                for (int b = 0; b < all_char_from_cipher.Length; b++)
                {
                    if (cipher[S] == all_char_from_cipher[b])
                    {
                        freq_for_cip[b]++;
                        break;
                    }
                }
            }

            List<KeyValuePair<char, double>> all = new List<KeyValuePair<char, double>>();

            for (int indx = 0; indx < arr.Count(); indx++)
            {
                all.Add(new KeyValuePair<char, double>(all_char_from_cipher[indx], freq_for_cip[indx]));
            }

            all = all.OrderBy(x => x.Value).ToList();
            string Plain_text = "";

            int yX;
            for (int i = 0; i < cipher.Length; i++)
            {
                yX = all.FindIndex(x => x.Key == cipher[i]);
                Plain_text += arr[25 - yX];

            }
            return Plain_text.ToLower();
        }
    }

}

