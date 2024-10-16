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

            for(int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]) && dict[s[i]] >= start)
                {
                    start = dict[s[i]] + 1;
                }
                dict[s[i]] = i;

                max = Math.Max(max, i - start + 1);
                
            }
            return max;

        }
    }

}
