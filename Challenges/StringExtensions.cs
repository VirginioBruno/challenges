using System.Linq;

namespace Challenges
{
    public static class StringExtensions
    {
        public static string ToLexicograficOrder(this string[] a)
        {
            var n = a.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if((a[i] + a[j]).CompareTo(a[j] + a[i]) > 0)
                    {
                        var temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }

            return string.Concat(a);
        }

        public static string SuperReduce(this string s)
        {
            var result = s;

            while(ExistsDuplicatedChar(result))
            {
                var array = result.ToCharArray();

                for (int i = 0; i < array.Length - 1; i++)
                {
                    var letter = array[i].ToString();
                    var nextLetter = array[i + 1].ToString();

                    if (nextLetter == letter && result.Contains(letter + nextLetter))
                        result = result.Remove(result.IndexOf(letter + nextLetter), 2);
                }
            }

            return string.IsNullOrEmpty(result) ? "Empty String" : result;
        }

        private static bool ExistsDuplicatedChar(string text)
        {
            var array = text.ToCharArray().Distinct().ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                var letter = array[i].ToString();

                if (text.Contains(letter + letter))
                    return true;
            }

            return false;
        }
    }
}
