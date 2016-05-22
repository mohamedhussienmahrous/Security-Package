using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    static class HillcipherClass
    {

        static public List<int> Encrypt(List<int> plainText, List<int> key)
        {
            ListOP Matrix = new ListOP();
            List<int> CipherText = Matrix.Multiply(plainText, key, (int)(Math.Log(key.Count, 2)));
            return CipherText;
        }


        static public string Encrypt(string plainText, string key)
        {
            ListOP Matrix = new ListOP();
            List<int> plainText_ = new List<int>();
            List<int> Key_ = new List<int>();
            string CipherText_ = "";
            plainText_ = Matrix.ConvertToLI(plainText);
            Key_ = Matrix.ConvertToLI(key);
            List<int> CipherText = Matrix.Multiply(plainText_, Key_, (int)(Math.Log(Key_.Count, 2)));
            CipherText_ = Matrix.ConvertToS(CipherText);
            return CipherText_;
        }

        static public List<int> Decrypt(List<int> cipherText, List<int> key)
        {
            ListOP Matrix = new ListOP();
            List<int> Key_inverse = new List<int>();
            List<int> plainText = new List<int>();
            List<int> dete = new List<int>();
            int x = (int)(Math.Log(key.Count, 2));

            int det = Matrix.Determenant(key, x, key.Count);
            int b = 0;
            if (Matrix.GCD(26, det) == 1)
            {
                b = Matrix.Calc_b(det);
                dete = Matrix.CfatorMatrix(key, x);
                Key_inverse = Matrix.KeyInverse(key, dete, x, b);
                Key_inverse = Matrix.Transpose(Key_inverse, x, Key_inverse.Count);
                plainText = Matrix.Multiply(cipherText, Key_inverse, x);

            }
            else
            {
                InvalidAnlysisException exc = new InvalidAnlysisException();
                throw (exc);
            }
            return plainText;
        }


        static public string Decrypt(string cipherText, string key)
        {
            ListOP Matrix = new ListOP();
            List<int> cipherText_ = new List<int>();
            List<int> Key_ = new List<int>();
            string plainText_ = "";
            cipherText_ = Matrix.ConvertToLI(cipherText);
            Key_ = Matrix.ConvertToLI(key);

            //convert to list

            List<int> Key_inverse = new List<int>();
            List<int> plainText = new List<int>();
            List<int> dete = new List<int>();
            int x = (int)(Math.Log(Key_.Count, 2));

            int det = Matrix.Determenant(Key_, x, Key_.Count);
            int b = 0;
            if (Matrix.GCD(26, det) == 1)
            {
                b = Matrix.Calc_b(det);
                dete = Matrix.CfatorMatrix(Key_, x);
                Key_inverse = Matrix.KeyInverse(Key_, dete, x, b);
                Key_inverse = Matrix.Transpose(Key_inverse, x, Key_inverse.Count);
                plainText = Matrix.Multiply(cipherText_, Key_inverse, x);
                plainText_ = Matrix.ConvertToS(plainText);
            }
            else
            {
                InvalidAnlysisException exc = new InvalidAnlysisException();
                throw (exc);
            }
            return plainText_;

        }



        static public List<int> Analyse(List<int> plainText, List<int> cipherText)
        {
            ListOP Matrix = new ListOP();
            int depth = 2;
            List<int> key = new List<int>();
            for (int j = 0; j < plainText.Count - 2; j += 2)
            {
                List<int> subMatrix1 = new List<int>();
                List<int> subMatrix2 = new List<int>();
                subMatrix1.Add(plainText[j]);
                subMatrix1.Add(plainText[j + 1]);
                subMatrix2.Add(cipherText[j]);
                subMatrix2.Add(cipherText[j + 1]);
                for (int i = j + 2; i < plainText.Count - 2; i += 2)
                {
                    int b = 0;
                    List<int> det = new List<int>();
                    List<int> InvKeydet = new List<int>();
                    List<int> Inverse = new List<int>();



                    subMatrix1.Add(plainText[i]);
                    subMatrix1.Add(plainText[i + 1]);
                    subMatrix2.Add(cipherText[i]);
                    subMatrix2.Add(cipherText[i + 1]);


                    subMatrix2 = Matrix.Transpose(subMatrix2, depth, subMatrix2.Count);

                    int det1 = Matrix.Determenant(subMatrix1, depth, (depth * depth));

                    if (Matrix.GCD(26, det1) == 1)
                    {
                        key = new List<int>();
                        b = Matrix.Calc_b(det1);
                        det = Matrix.CfatorMatrix(subMatrix1, depth);
                        Inverse = Matrix.KeyInverse(subMatrix1, det, depth, b);
                        Inverse = Matrix.Transpose(Inverse, depth, Inverse.Count);
                        key = Matrix.Multiply(Inverse, subMatrix2, depth);
                        key = Matrix.Transpose(key, depth, key.Count);
                        return key;
                    }

                    subMatrix2 = Matrix.Transpose(subMatrix2, depth, subMatrix2.Count);
                    subMatrix1.RemoveAt(3);
                    subMatrix1.RemoveAt(2);
                    subMatrix2.RemoveAt(3);
                    subMatrix2.RemoveAt(2);

                }
                subMatrix1.RemoveRange(0, 2);
                subMatrix2.RemoveRange(0, 2);
            }
            if (key.Count == 0)
            {

                InvalidAnlysisException exc = new InvalidAnlysisException();
                throw (exc);

            }
            return key;

        }
        static public string Analyse(string plainText, string cipherText)
        {
            ListOP Matrix = new ListOP();
            List<int> cipherText_ = new List<int>();
            List<int> plainText_ = new List<int>();
            string Key_ = "";
            cipherText_ = Matrix.ConvertToLI(cipherText);
            plainText_ = Matrix.ConvertToLI(plainText);
            //////////
            int depth = 2;
            List<int> key = new List<int>();

            for (int j = 0; j < plainText_.Count - 2; j += 2)
            {
                List<int> subMatrix1 = new List<int>();
                List<int> subMatrix2 = new List<int>();
                subMatrix1.Add(plainText_[j]);
                subMatrix1.Add(plainText_[j + 1]);
                subMatrix2.Add(cipherText_[j]);
                subMatrix2.Add(cipherText_[j + 1]);
                for (int i = j + 2; i < plainText_.Count - 2; i += 2)
                {
                    int b = 0;
                    List<int> det = new List<int>();
                    List<int> InvKeydet = new List<int>();
                    List<int> Inverse = new List<int>();



                    subMatrix1.Add(plainText_[i]);
                    subMatrix1.Add(plainText_[i + 1]);
                    subMatrix2.Add(cipherText_[i]);
                    subMatrix2.Add(cipherText_[i + 1]);


                    subMatrix2 = Matrix.Transpose(subMatrix2, depth, subMatrix2.Count);

                    int det1 = Matrix.Determenant(subMatrix1, depth, (depth * depth));

                    if (Matrix.GCD(26, det1) == 1)
                    {
                        key = new List<int>();
                        b = Matrix.Calc_b(det1);
                        det = Matrix.CfatorMatrix(subMatrix1, depth);
                        Inverse = Matrix.KeyInverse(subMatrix1, det, depth, b);
                        Inverse = Matrix.Transpose(Inverse, depth, Inverse.Count);
                        key = Matrix.Multiply(Inverse, subMatrix2, depth);
                        key = Matrix.Transpose(key, depth, key.Count);
                        Key_ = Matrix.ConvertToS(key);
                        return Key_;
                    }

                    subMatrix2 = Matrix.Transpose(subMatrix2, depth, subMatrix2.Count);
                    subMatrix1.RemoveAt(3);
                    subMatrix1.RemoveAt(2);
                    subMatrix2.RemoveAt(3);
                    subMatrix2.RemoveAt(2);

                }
                subMatrix1.RemoveRange(0, 2);
                subMatrix2.RemoveRange(0, 2);
            }
            if (key.Count == 0)
            {

                InvalidAnlysisException exc = new InvalidAnlysisException();
                throw (exc);

            }

            Key_ = Matrix.ConvertToS(key);

            return Key_;


        }
        static public List<int> Analyse3By3(List<int> plainText, List<int> cipherText)
        {
            ListOP Matrix = new ListOP();
            int depth = 3;
            List<int> key = new List<int>();
            for (int j = 0; j < plainText.Count - 3; j += 3)
            {
                List<int> subMatrix1 = new List<int>();
                List<int> subMatrix2 = new List<int>();
                subMatrix1.Add(plainText[j]);
                subMatrix1.Add(plainText[j + 1]);
                subMatrix1.Add(plainText[j + 2]);
                subMatrix2.Add(cipherText[j]);
                subMatrix2.Add(cipherText[j + 1]);
                subMatrix2.Add(cipherText[j + 2]);
                for (int i = j + 3; i < plainText.Count - 3; i += 3)
                {

                    subMatrix1.Add(plainText[i]);
                    subMatrix1.Add(plainText[i + 1]);
                    subMatrix1.Add(plainText[i + 2]);
                    subMatrix2.Add(cipherText[i]);
                    subMatrix2.Add(cipherText[i + 1]);
                    subMatrix2.Add(cipherText[i + 2]);

                    for (int g = i + 3; g < plainText.Count; g += 3)
                    {
                        int b = 0;
                        List<int> det = new List<int>();
                        List<int> InvKeydet = new List<int>();
                        List<int> Inverse = new List<int>();
                        subMatrix1.Add(plainText[g]);
                        subMatrix1.Add(plainText[g + 1]);
                        subMatrix1.Add(plainText[g + 2]);
                        subMatrix2.Add(cipherText[g]);
                        subMatrix2.Add(cipherText[g + 1]);
                        subMatrix2.Add(cipherText[g + 2]);
                        subMatrix2 = Matrix.Transpose(subMatrix2, depth, subMatrix2.Count);

                        int det1 = Matrix.Determenant(subMatrix1, depth, (depth * depth));

                        if (Matrix.GCD(26, det1) == 1)
                        {
                            key = new List<int>();
                            b = Matrix.Calc_b(det1);
                            det = Matrix.CfatorMatrix(subMatrix1, depth);
                            Inverse = Matrix.KeyInverse(subMatrix1, det, depth, b);
                            Inverse = Matrix.Transpose(Inverse, depth, Inverse.Count);
                            key = Matrix.Multiply(Inverse, subMatrix2, depth);
                            key = Matrix.Transpose(key, depth, key.Count);
                            return key;
                        }

                        subMatrix2 = Matrix.Transpose(subMatrix2, depth, subMatrix2.Count);
                        subMatrix1.RemoveAt(8);
                        subMatrix1.RemoveAt(7);
                        subMatrix1.RemoveAt(6);
                        subMatrix2.RemoveAt(8);
                        subMatrix2.RemoveAt(7);
                        subMatrix2.RemoveAt(6);
                    }
                    subMatrix1.RemoveAt(5);
                    subMatrix1.RemoveAt(4);
                    subMatrix1.RemoveAt(3);
                    subMatrix2.RemoveAt(5);
                    subMatrix2.RemoveAt(4);
                    subMatrix2.RemoveAt(3);

                }
                subMatrix1.RemoveRange(0, 3);
                subMatrix2.RemoveRange(0, 3);
            }
            if (key.Count == 0)
            {

                InvalidAnlysisException exc = new InvalidAnlysisException();
                throw (exc);

            }
            return key;

        }
        static public string Analyse3By3(string plainText, string cipherText)
        {
            ListOP Matrix = new ListOP();
            List<int> cipherText_ = new List<int>();
            List<int> plainText_ = new List<int>();
            string Key_ = "";
            cipherText_ = Matrix.ConvertToLI(cipherText);
            plainText_ = Matrix.ConvertToLI(plainText);
            //////////////
            int depth = 3;
            List<int> key = new List<int>();
            for (int j = 0; j < plainText_.Count - 3; j += 3)
            {
                List<int> subMatrix1 = new List<int>();
                List<int> subMatrix2 = new List<int>();
                subMatrix1.Add(plainText_[j]);
                subMatrix1.Add(plainText_[j + 1]);
                subMatrix1.Add(plainText_[j + 2]);
                subMatrix2.Add(cipherText_[j]);
                subMatrix2.Add(cipherText_[j + 1]);
                subMatrix2.Add(cipherText_[j + 2]);
                for (int i = j + 3; i < plainText_.Count - 3; i += 3)
                {

                    subMatrix1.Add(plainText_[i]);
                    subMatrix1.Add(plainText_[i + 1]);
                    subMatrix1.Add(plainText_[i + 2]);
                    subMatrix2.Add(cipherText_[i]);
                    subMatrix2.Add(cipherText_[i + 1]);
                    subMatrix2.Add(cipherText_[i + 2]);

                    for (int g = i + 3; g < plainText_.Count; g += 3)
                    {
                        int b = 0;
                        List<int> det = new List<int>();
                        List<int> InvKeydet = new List<int>();
                        List<int> Inverse = new List<int>();
                        subMatrix1.Add(plainText_[g]);
                        subMatrix1.Add(plainText_[g + 1]);
                        subMatrix1.Add(plainText_[g + 2]);
                        subMatrix2.Add(cipherText_[g]);
                        subMatrix2.Add(cipherText_[g + 1]);
                        subMatrix2.Add(cipherText_[g + 2]);
                        subMatrix2 = Matrix.Transpose(subMatrix2, depth, subMatrix2.Count);

                        int det1 = Matrix.Determenant(subMatrix1, depth, (depth * depth));

                        if (Matrix.GCD(26, det1) == 1)
                        {
                            key = new List<int>();
                            b = Matrix.Calc_b(det1);
                            det = Matrix.CfatorMatrix(subMatrix1, depth);
                            Inverse = Matrix.KeyInverse(subMatrix1, det, depth, b);
                            Inverse = Matrix.Transpose(Inverse, depth, Inverse.Count);
                            key = Matrix.Multiply(Inverse, subMatrix2, depth);
                            key = Matrix.Transpose(key, depth, key.Count);
                            Key_ = Matrix.ConvertToS(key);
                            return Key_;
                           
                        }

                        subMatrix2 = Matrix.Transpose(subMatrix2, depth, subMatrix2.Count);
                        subMatrix1.RemoveAt(8);
                        subMatrix1.RemoveAt(7);
                        subMatrix1.RemoveAt(6);
                        subMatrix2.RemoveAt(8);
                        subMatrix2.RemoveAt(7);
                        subMatrix2.RemoveAt(6);
                    }
                    subMatrix1.RemoveAt(5);
                    subMatrix1.RemoveAt(4);
                    subMatrix1.RemoveAt(3);
                    subMatrix2.RemoveAt(5);
                    subMatrix2.RemoveAt(4);
                    subMatrix2.RemoveAt(3);

                }
                subMatrix1.RemoveRange(0, 3);
                subMatrix2.RemoveRange(0, 3);
            }
            if (key.Count == 0)
            {

                InvalidAnlysisException exc = new InvalidAnlysisException();
                throw (exc);

            }
            Key_ = Matrix.ConvertToS(key);
            return Key_;
        }

    }
}
