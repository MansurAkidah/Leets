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
            Dictionary<char, int> dict = new();
            int start = 0;
            int max = 0;

            Console.WriteLine($"Input string: {s}");
            Console.WriteLine("Index\tChar\tWindow\t\tStart\tMax\tDictionary");
            Console.WriteLine("-----\t----\t------\t\t-----\t---\t----------");

            for (int i = 0; i < s.Length; i++)
            {
                char currentChar = s[i];


                if (dict.ContainsKey(currentChar) && dict[currentChar] >= start)
                {
                    start = dict[currentChar] + 1;
                    Console.WriteLine($"Updating start to {start} ");
                }

                dict[currentChar] = i;
                max = Math.Max(max, i - start + 1);

                string window = s.Substring(start, i - start + 1);
                Console.Write($"{i}\t{currentChar}\t{window,-10}\t{start}\t{max}\t");
                // Print dictionary content
                Console.WriteLine(string.Join(", ", dict.Select(kvp => $"{kvp.Key}:{kvp.Value}")));
            }

            return max;

        }
    }

}
