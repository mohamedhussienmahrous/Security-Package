using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
  static public class Vigenere_with_Repeating_key
    {
     
       public static string encrypt(string pt, string k)
        {
            pt.ToUpper();
            k.ToUpper();
            string output = "";
            string originalkey=k;
            int len = originalkey.Length;
            int  x,i=0;
            char ch;
            while (k.Length < pt.Length )
            {
                k += originalkey[i++% len];
            }
            for (int j = 0; j < pt.Length;j++ )
            {
                x = (int.Parse((pt[j] - 'a').ToString()) + int.Parse((k[j] - 'a').ToString())) % 26;
                ch = Convert.ToChar(x + 'a');
                output += ch;
            }
            return output.ToUpper();
        }
       public static string decrypt(string ct, string k)
        {
            ct = ct.ToLower();
            k  =  k.ToLower();
            string output = "";
            string originalkey = k;
            int len = originalkey.Length;
            int x, i = 0;
            char ch;
            while (k.Length < ct.Length)
            {
                k += originalkey[i++ % len];
            }
            for (int j = 0; j < ct.Length; j++)
            {
                x = (int.Parse((ct[j] - 'a').ToString()) - int.Parse((k[j] - 'a').ToString())) % 26;
                if (x < 0)
                    x += 26;
                ch = Convert.ToChar(x + 'a');
                output += ch;
            }
            return output;
        }
       public static string Analyse(string pt, string ct)
       {
           pt =  pt.ToLower();
           ct = ct.ToLower();
           string output = "";
           int x;
           char ch;
           for (int j = 0; j < ct.Length; j++)
           {
               x = (int.Parse((ct[j] - 'a').ToString()) - int.Parse((pt[j] - 'a').ToString())) % 26;
               if (x < 0)
                   x += 26;
               ch = Convert.ToChar(x + 'a');
               output += ch;
           }
           return getthekey(output);    
       }
      public static string getthekey (string k)
       {
           char x;
           int index2=0;
           int i=0;
           int j = 0;
           string Key="";
           
               x=k[i];
               for ( j = i+1; j < k.Length; j++)
               {
                   if (k[j] == x)
                   {
                       index2 =j;
                       break;
                   }
               }
             
          
           for (int f = 0; f < index2; f++)
           {
               Key += k[f];
           }
           return Key;
       }
              
    }
}
