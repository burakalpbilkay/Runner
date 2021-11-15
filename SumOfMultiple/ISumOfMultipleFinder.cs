namespace SumOfMultiple
{
    public interface ISumOfMultipleFinder
    {
        /// <summary>
        /// Find the sum of all natural numbers that are a multiple of 3 or 5 below a limit provided as input.
        /// </summary>
        /// <param name="limit">The limit for the sum.</param>
        /// <returns></returns>
        public ulong SumOfMultipleThreeOrFive(int limit);
    }
}
