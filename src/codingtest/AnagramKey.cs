using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codingtest
{
    internal class AnagramKey
    {
        Dictionary<char, int> NumberCharsInString = new Dictionary<char, int>();

        public AnagramKey(string AnagramLine)
        {
            if (string.IsNullOrWhiteSpace(AnagramLine)) { throw new ArgumentException("Empty line encountered"); }
            NumberCharsInString = CalculateFrequency(AnagramLine);
        }

        private Dictionary<char, int> CalculateFrequency(string input)
        {
            var frequency = new Dictionary<char, int>();
            foreach (var c in input)
            {
                if (!frequency.ContainsKey(c))
                {
                    frequency.Add(c, 0);
                }
                frequency[c]++;
            }
            return frequency;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is AnagramKey)) return false;
            var castableAnagram = obj as AnagramKey;

            if (NumberCharsInString.Count != castableAnagram?.NumberCharsInString.Count)
                return false;

            foreach (var key in NumberCharsInString.Keys)
            {
                if (!castableAnagram.NumberCharsInString.ContainsKey(key)) return false;
                if (NumberCharsInString[key] != castableAnagram.NumberCharsInString[key]) return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            int res = 0;
            foreach (var key in NumberCharsInString.Keys)
            {
                res += (int)key ^ NumberCharsInString[key];
            }
            return res;
        }

    }
}
