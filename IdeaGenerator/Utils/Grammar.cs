using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaGenerator.Utils
{
    public class Grammar
    {
        public static string DeterminerFor(string word)
        {
            if (string.IsNullOrEmpty(word)) return string.Empty;

            return IsVowel(word[0]) ? "an" : "a";
        }

        public static bool IsVowel(char c)
        {
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                return true;

            return false;
        }
    }
}
