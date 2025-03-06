using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leets.Simple
{
    internal class ValidPalindrome
    {
        public bool IsValid(string ss)
        {
            string s = ss.Trim().ToLower();
            string n = "";

            #region Worked beating 50%
            //if (s.Length == 0 || s.Length == 1) return true;
            ////remove the spacing and other non alphanumerics
            //for(int i = 0; i<s.Length; i++){
            //    if(char.IsLetterOrDigit(s[i])) n = n + s[i];
            //}
            //Console.WriteLine(n);
            //for(int i = 0, j = n.Length - 1; i<n.Length; i++, j--){
            //    if(n[i] != n[j]){
            //        return false;
            //    }
            //}
            //return true;
            #endregion
            #region Worked beaging 76%
            int j = s.Length - 1;
            int i = 0;

            if (s.Length == 0 || s.Length == 1) return true;

            while (i <= j)
            {
                if (!char.IsLetterOrDigit(s[i]))
                {
                    i++;
                    continue;
                }
                if (!char.IsLetterOrDigit(s[j]))
                {
                    j--;
                    continue;
                }
                if (s[i] != s[j]) return false;
                i++;
                j--;
            }

            return true;
            #endregion
        }
    }
}
