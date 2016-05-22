using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    static class Play_Fair
    {


        static public string Analyse(string plainText, string cipherText)
        {
            throw new NotImplementedException();
        }

        static public string Decrypt(string cipherText, string key)
        {
            string sub = "";
            string plain = "";
            char[,] matrxi;
            string final_plain = "";
           matrxi = cal_key(key);
            
           
            cipherText = cipherText.ToLower();
            for (int i = 0; i < cipherText.Length; i += 2)
            {
                sub = cipherText.Substring(i, 2);
                plain += search_in_matrxi(matrxi, sub, "dec");
                
            }
            for (int j = 0; j < plain.Length; j++)
            {

                if (plain[j] == 'x')
                {
                    if (j == (plain.Length - 1) && plain.Length % 2 == 0)
                    { 
                        continue; 
                    }
                        
                    if (j < (plain.Length - 1) && plain[j - 1] == plain[j + 1] && j % 2 != 0)
                    {
                        continue;
                    }


                }
                final_plain += plain[j];
            }
            return final_plain;
        }

        static public string Encrypt(string plainText, string key)
        {
           
            char[,] matrxi;
            string sub = "";
            string f_sub = "";
            matrxi = cal_key(key);
            string chiper = "";
            for (int i = 0; i < plainText.Length; i += 2)
            {
                if (i == plainText.Length - 1)
                {
                    f_sub += plainText[i];
                    f_sub += 'x';
                }
                else
                {
                    sub = plainText.Substring(i, 2);
                    if (sub[0] == sub[1])
                    {
                        f_sub += sub[0];
                        f_sub += 'x';
                        i--;
                    }
                }
                f_sub += sub;
                
                chiper += search_in_matrxi(matrxi,f_sub, "enc");
                f_sub = "";
            }
            return chiper;
        }
        static public char[,] cal_key(string key)
        {
            string array_chars;
            string new_key = "";
            new_key += key;
            array_chars = "abcdefghijklmnopqrstuvwxyz";
            new_key += array_chars;
            new_key = find_repeation(new_key);
            char[,] matrxi;
            matrxi = new char[5, 5];
            int counter = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrxi[i, j] = new_key[counter];
                    counter++;
                }
            }
            return matrxi;

        }
        static public string find_repeation(string str)
        {

            string keyword = "";
            int len = str.Length;
            for (int i = 0; i < len; i++)
            {
                if (!keyword.Contains(str[i]))
                {
                    if (str[i] == 'j')
                    {
                        if (!keyword.Contains('i'))
                        {
                            keyword += "i";
                        }
                    }
                    else if (str[i] == 'i' || str[i] == 'j')
                    {
                        keyword += "i";
                    }



                    else
                        keyword += str[i];
                }
            }
            return keyword;
        }
     
       static string search_in_matrxi(char[,] array, string str, string satutes)
        {
            string cipher = "";
            int row1 = 0, row2 = 0, col1 = 0, col2 = 0;
            bool element1 = false;
            bool element2 = false;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (str[0] == array[i, j])
                    {
                        row1 = i;
                        col1 = j;
                        element1 = true;
                    }
                    if (str[1] == array[i, j])
                    {
                        row2 = i;
                        col2 = j;
                        element2 = true;
                    }
                    if (element1 == true && element2 == true)
                        break;
                }
                if (element1 == true && element2 == true)
                    break;
            }
            if (row1 == row2)//same row
            {
                if (satutes == "enc")
                {
                    cipher += array[row1, (col1 + 1) % 5];
                    cipher += array[row2, (col2 + 1) % 5];
                }
                else if (satutes == "dec")
                {
                     if (col1 == 0)
                    {
                        cipher += array[row1, 4];
                        cipher += array[row1, col2 - 1];
                    }
                    else if (col2 == 0)
                    {
                        cipher += array[row1, col1 - 1];
                        cipher += array[row1, 4];
                    }
                    else
                    {
                        cipher += array[row1, (col1 - 1) % 5];
                        cipher += array[row2, (col2 - 1) % 5];
                    }
                }
            }
            else if (col1 == col2) //same colum
            {
                if (satutes == "enc")
                {
                    cipher += array[(row1 + 1) % 5, col1];
                    cipher += array[(row2 + 1) % 5, col1];
                }
                else
                {
                   
                    if (row1 == 0)
                    {
                        cipher += array[4, col1];
                        cipher += array[row2 - 1, col1];
                    }
                    else if (row2 == 0)
                    {
                        cipher += array[row1 - 1, col1];
                        cipher += array[4, col1];
                    }
                    else
                    {
                        cipher += array[(row1 - 1) % 5, col1];
                        cipher += array[(row2 - 1) % 5, col1];
                    }
                }
            }
            else ///different row and col
            {
                cipher += array[row1, col2];
                cipher += array[row2, col1];
            }
            return cipher;
        }

    }

}

