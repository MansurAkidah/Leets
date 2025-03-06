using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leets.Simple
{
    public class LengthOfLongestSubstring
    {
        public int Substring(string s)
        {
            HashSet<char> hash = new();
            int start = 0;
            int max = 0;

            Console.WriteLine($"Input string: {s}");

            for (int i = 0; i < s.Length; i++)
            {
                char currentChar = s[i];

                while (hash.Contains(currentChar))
                {
                    hash.Remove(s[start]);
                    start++;
                }
                hash.Add(currentChar);
                max = Math.Max(max++, hash.Count);

            }

            return max;

        }
    }

}
