using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    class ListOP
    {
      
        public int GCD(int A, int B)
        {
            int newB = 0;
            while (B != 0)
            {
                newB = A % B;
                A = B;
                B = newB;

            }

            return A;
        }

        public List<int> Transpose(List<int> Mat, int row, int ListCount)
        {
            List<int> NewMat = new List<int>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < ListCount; j += row)
                {
                    int temp = Mat[i + j];
                    NewMat.Add(temp);
                }
            }
            return NewMat;
        }

        public int Determenant(List<int> mat, int row, int ListCount)
        {
            int det = 0;
            int X, Y, Z, W;

            if (row == 2)
            {
                det = ((mat[0] * mat[3]) - (mat[1] * mat[2]));
            }
            else
            {
                X = row + 1;
                Y = 2 * X;
                Z = X + 1;
                W = Y - 1;
                for (int i = 0; i < row; i++)
                {
                    if (Math.Pow(-1, i) == -1)
                    {
                        det -= (mat[i] * ((mat[X] * mat[Y]) - (mat[Z] * mat[W])));
                        Y--;
                        Z--;
                    }
                    else
                    {
                        det += (mat[i] * ((mat[X] * mat[Y]) - (mat[Z] * mat[W])));
                        X--;
                        W--;
                    }
                }
            }
            det = det % 26;
            if (det < 0)
                det += 26;
            return det;
        }

        public int Calc_b(int det)
        {
            int c = 1;
            int x = 0;
            int b = 0;
            x = 26 - det;
            bool found = false;

            do
            {
                b = x * c;
                if (b % 26 == 1)
                {
                    found = true;
                    break;
                }
                c++;
            } while (found == false);
            b = 26 - c;
            return b;
        }

        public List<int> CfatorMatrix(List<int> Mat, int row)
        {
            List<int> det = new List<int>();

            if (row == 2)
            {
                det.Add(Mat[3]);
                det.Add(Mat[2]);
                det.Add(Mat[1]);
                det.Add(Mat[0]);

            }
            else if (row == 3)
            {
                det.Add((Mat[4] * Mat[8]) - (Mat[5] * Mat[7]));
                det.Add((Mat[3] * Mat[8]) - (Mat[5] * Mat[6]));
                det.Add((Mat[3] * Mat[7]) - (Mat[4] * Mat[6]));

                det.Add((Mat[1] * Mat[8]) - (Mat[2] * Mat[7]));
                det.Add((Mat[0] * Mat[8]) - (Mat[2] * Mat[6]));
                det.Add((Mat[0] * Mat[7]) - (Mat[1] * Mat[6]));

                det.Add((Mat[1] * Mat[5]) - (Mat[2] * Mat[4]));
                det.Add((Mat[0] * Mat[5]) - (Mat[2] * Mat[3]));
                det.Add((Mat[0] * Mat[4]) - (Mat[1] * Mat[3]));


            }
            return det;
        }

        public List<int> KeyInverse(List<int> Mat, List<int> det, int row, int DetInverse)
        {

            List<int> NewMat = new List<int>();
            int depth = (int)(Math.Log(Mat.Count, 2));
            if (Mat.Count % 2 != 0)
            {
                for (int i = 0; i < depth; i++)
                {
                    for (int j = 0; j < depth; j++)
                    {
                        NewMat.Add((DetInverse * ((int)Math.Pow(-1, i + j)) * det[3 * i + j]) % 26);
                        if (NewMat[3 * i + j] < 0)
                            NewMat[3 * i + j] += 26;

                    }

                }
            }
            else
            {

                for (int i = 0; i < depth; i++)
                {
                    for (int j = 0; j < depth; j++)
                    {
                        NewMat.Add((DetInverse * ((int)Math.Pow(-1, i + j)) * det[2 * i + j]) % 26);
                        if (NewMat[2 * i + j] < 0)
                            NewMat[2 * i + j] += 26;

                    }

                }
            }

            return NewMat;
        }

        public List<int> Multiply(List<int> Mat1, List<int> Mat2, int rowMat2)
        {
            List<int> subMat;
            List<int> NewMat = new List<int>();

            for (int i = 0; i < Mat1.Count; i += rowMat2)
            {
                subMat = new List<int>();
                for (int s = 0; s < rowMat2; s++)
                {
                    subMat.Add(Mat1[i+s]);
                }
                for (int j = 0; j < Mat2.Count; j +=rowMat2)
                {
                    int res = 0;
                    for (int x = 0; x < rowMat2; x++)
                    {

                        res += Mat2[j + x] * subMat[x];

                    }
                    res = res % 26;
                    if (res < 0)
                        res += 26;
                    NewMat.Add(res);
                }
            }
            return NewMat;
        }

        public List<int> ConvertToLI(string Text)
        {
            Text = Text.ToLower();
            List<int> ListOI = new List<int>();
            for (int i = 0; i < Text.Length; i++)
            {
                if (Text[i] >= 'a' && Text[i] <= 'z')
                {
                    ListOI.Add(Convert.ToInt32(Text[i] - 'a'));
                }

            }
            return ListOI;
        }

        public string ConvertToS(List<int> ListOI)
        {
            string Text = "";

            for (int i = 0; i < ListOI.Count; i++)
            {
                if (ListOI[i] >= 0 && ListOI[i] <= 25)
                {

                    Text += Convert.ToChar(ListOI[i] + 'a');
                }

            }
            return Text;
        }

    }
}
