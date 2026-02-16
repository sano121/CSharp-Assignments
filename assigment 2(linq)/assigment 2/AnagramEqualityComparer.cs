using System.Collections;

namespace assigment_2
{
    // Custom comparer for grouping words with same characters
    public class AnagramEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y)
        {
            if (x == null || y == null)
                return x == y;

            return GetCanonicalString(x) == GetCanonicalString(y);
        }

        public int GetHashCode(string obj)
        {
            return GetCanonicalString(obj).GetHashCode();
        }

        private string GetCanonicalString(string word)
        {
            char[] characters = word.ToLower().ToCharArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
