using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Leets.Simple
{
    internal class ValidAnagram
    {
        public bool IsAnagram(string s, string r)
        {
            if (s.Length != r.Length) return false;

            char[] s1 = s.ToCharArray();
            char[] r1 = r.ToCharArray();

            Array.Sort(s1);
            Array.Sort(r1);


            Console.WriteLine(s1.SequenceEqual(r1));


            return true;
        }
    }
}
