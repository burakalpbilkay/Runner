using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SequenceAnalysis
{
    public class SequenceAnalyzer : ISequenceAnalyzer
    {
        /// <summary>
        /// Find the uppercase words in a string, provided as input, and order all characters in these words alphabetically.
        /// Input: "This IS a STRING"  Output: "GIINRSST"
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns></returns>
        public string OrderCharactersInUpperCaseWords(string input)
        {
            ValidateInput(input);
            var upperCaseWords = input.Split(' ').Where(x => string.Equals(x, x.ToUpper()));
            var result = string.Concat(upperCaseWords.Where(x => IsWord(x) == true).SelectMany(x => x).Where(x => char.IsUpper(x)).OrderBy(c => c));
            ValidateResult(result);
            return result;

        }

        private static bool IsWord(string input)
        {
            // Define a regular expression for words.
            var rx = new Regex(@"^'?[A-Za-z]+('|-)?[A-Za-z]+$");

            // Find matches.
            var matches = rx.Matches(input);
            if (matches.Count > 0)
                return true;
            return false;
        }

        private static void ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be null or empty string!");
            }           

        }

        private static void ValidateResult(string result)
        {
            if (string.IsNullOrEmpty(result))
            {
                throw new ArgumentException("Given input does not contain any upper case words!");
            }
        }
    }
}
