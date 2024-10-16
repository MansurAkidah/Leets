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
            Dictionary<char, int> lastSeen = new Dictionary<char, int>();
            int longestLength = 0;
            int startOfWindow = 0;

            Console.WriteLine($"Input string: {s}");

            for (int endOfWindow = 0; endOfWindow < s.Length; endOfWindow++)
            {
                char currentChar = s[endOfWindow];

                Console.WriteLine($"\nProcessing character: {currentChar} at index {endOfWindow}");

                if (lastSeen.ContainsKey(currentChar))
                {
                    int oldStart = startOfWindow;
                    startOfWindow = Math.Max(startOfWindow, lastSeen[currentChar] + 1);
                    Console.WriteLine($"Character '{currentChar}' seen before. Moving start from {oldStart} to {startOfWindow}");
                }
                else
                {
                    Console.WriteLine($"New character '{currentChar}'");
                }

                int currentLength = endOfWindow - startOfWindow + 1;
                longestLength = Math.Max(longestLength, currentLength);

                lastSeen[currentChar] = endOfWindow;

                Console.WriteLine($"Current window: {s.Substring(startOfWindow, currentLength)}");
                Console.WriteLine($"Current length: {currentLength}, Longest length: {longestLength}");
                Console.WriteLine($"lastSeen: {string.Join(", ", lastSeen)}");
            }

            return longestLength;

        }
    }

}
