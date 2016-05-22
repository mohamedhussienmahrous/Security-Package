using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.DiffieHellman
{
    public class DiffieHellman
    {
        public List<int> GetKeys(int q, int alpha, int xa, int xb)
        {
            List<int> Key = new List<int>();
            int ya = 0;
            int yb = 0;

            if (xa < q)
            {
                ya = calc_pow(xa, alpha, q);

            }
            if (xb < q)
            {
                yb = calc_pow(xb, alpha, q);
            }

            int k1 = calc_pow(xa, yb, q);
            Key.Add(k1);
            /////////////////////
            int k2 = calc_pow(xb, ya, q);
            Key.Add(k2);

            return Key;
        }
        public int calc_pow(int x, int alpha, int q)
        {
            int y = 1;
            int counter = 0;
            bool check = false;
            if (x % 2 != 0)
            {
                x -= 1;
                check = true;

            }
            while (x > 0)
            {
                x -= 2;
                counter++;
            }

            for (int j = 0; j < counter; j++)
            {
                y *= (int)Math.Pow(alpha, 2);
                y = y % q;
                if (y < 0)
                    y += q;
            }
            if (check)
            {
                y *= alpha;
                y = y % q;
                if (y < 0)
                    y += q;
            }

            return y;
        }
    }
}
