using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    static class Mulc_inverse
    {
        public static int calculate_multiplicated_inverse(int number, int baseN)
        {
            List<int> Q = new List<int>();
            List<int> A1 = new List<int>();
            List<int> A2 = new List<int>();
            List<int> A3 = new List<int>();
            List<int> B1 = new List<int>();
            List<int> B2 = new List<int>();
            List<int> B3 = new List<int>();
            Q.Add(0);
            A1.Add(1);
            A2.Add(0);
            A3.Add(baseN);
            B1.Add(0);
            B2.Add(1);
            B3.Add(number);
            while (true)
            {
                if (B3[B3.Count - 1] == 1)
                {
                    if (B2[B2.Count - 1] <0)
                    {
                        B2[B2.Count - 1] += baseN;
                    }
                    return B2[B2.Count - 1]; //w^-1
                }
                else if (B3[B3.Count - 1] <= 0)
                {
                    return -1;
                }


                int temp;

                temp = A3[(A3.Count) - 1] / B3[(B3.Count) - 1];
                Q.Add(temp);

                int s = B1.Count;
                temp = B1[B1.Count - 1];
                A1.Add(temp);
                temp = B2[B2.Count - 1];
                A2.Add(temp);
                temp = B3[B3.Count - 1];
                A3.Add(temp);

                temp = A1[A1.Count - 2] - (Q[Q.Count - 1]) * (B1[B1.Count - 1]);
                B1.Add(temp);
                temp = A2[A2.Count - 2] - (Q[Q.Count - 1]) * (B2[B2.Count - 1]);
                B2.Add(temp);
                temp = A3[A3.Count - 2] - (Q[Q.Count - 1]) * (B3[B3.Count - 1]);
                B3.Add(temp);

            }
        }
    }
}
