using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leets.Simple
{
    public class threePartitionProblem
    {
        public static void MyMain()
        {
            ///The use of recursion
            ///If the sum of the set of numbers is not divisible by 3 - cannot be used for this 

        }

        public static bool SubsetExists(int[] S, int n, int a, int b, int c, List<int> list)
        {
            if (n == 0 && a == 0 && c == 0) return true;

            if(n < 0 ) return false;

            bool A = false;

            if( a - S[n] >= 0 )
            {
                list[n] = 1;
                A = SubsetExists(S, n - 1, a - S[n], b, c, list);
            }

            bool B = false;
            if (!A && b - S[n] >= 0)
            {
                list[n] = 2;
                A = SubsetExists(S, n - 1, a, b - S[n], c, list);
            }

            bool C = false;
            if (!A && b - S[n] >= 0)
            {
                list[n] = 2;
                A = SubsetExists(S, n - 1, a, b - S[n], c, list);
            }
            return false;
        }
    }
}
