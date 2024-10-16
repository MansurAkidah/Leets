using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leets
{
    public class LengthOfLongestSubstring
    {
        public int Substring(string s)
        {
            int[] lastIndex = new int[128];
            Array.Fill(lastIndex, -1);

            int maxLength = 0;
            int start = 0;

            Console.WriteLine($"Input string: {s}");
            Console.WriteLine("Index\tChar\tWindow\t\tLength\tMax Length");
            Console.WriteLine("-----\t----\t------\t\t------\t----------");

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (lastIndex[c] >= start)
                {
                    start = lastIndex[c] + 1;
                }

                lastIndex[c] = i;
                int currentLength = i - start + 1;
                maxLength = Math.Max(maxLength, currentLength);

                string window = s.Substring(start, currentLength);
                Console.WriteLine($"{i}\t{c}\t{window,-10}\t{currentLength}\t{maxLength}");
            }

            return maxLength;

        }
    }

}
