namespace SequenceAnalysis
{
    public interface ISequenceAnalyzer
    {
        /// <summary>
        /// Find the uppercase words in a string, provided as input, and order all characters in these words alphabetically.
        /// Input: "This IS a STRING"  Output: "GIINRSST"
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns></returns>
        public string OrderCharactersInUpperCaseWords(string input);
        
    }
}
