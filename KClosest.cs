using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leets
{
    public class KClosest
    {
        public int[][] Closest(int[][] points, int k)
        {
            Array.Sort(points, ComparePoints);

            return points.Take(k).ToArray();
        }

        private int ComparePoints(int[] a, int[] b)
        {
            var dist1 =  a[0] * a[0] + a[1] * a[1];
            var dist2 = b[0] * b[0] + b[1] * b[1];
            var n = dist1.CompareTo(dist2);
            return n ;
        }
        
    }
}
#region Explanation
/*
The CompareTo method is part of the IComparable interface in C#. It's used to define a natural ordering between instances of a class.
It returns an integer value.
If the return value is less than 0, it means the object on which the method is called is considered "less than" the object passed as an argument vice versa
If the return value is 0, it means the two objects are considered "equal"

Array.Sort calls ComparePoints multiple times to determine the correct order of the points.
Eg for the test case of [[3,3],[5,-1],[-2,4]]
 - a. Compare [3,3] and [5,-1]: [3,3] comes before [5,-1]
 - b. Compare [5,-1] and [-2,4]: [-2,4] comes before [5,-1]
 - c. Compare [3,3] and [-2,4]: [3,3] stays before [-2,4]
 */
#endregion
