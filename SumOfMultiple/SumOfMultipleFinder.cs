using System;

namespace SumOfMultiple
{
    public class SumOfMultipleFinder: ISumOfMultipleFinder
    {
        /// <summary>
        /// Find the sum of all natural numbers that are a multiple of 3 or 5 below a limit provided as input.
        /// </summary>
        /// <param name="limit">The limit for the sum.</param>
        /// <returns></returns>
        public ulong SumOfMultipleThreeOrFive(int limit)
        {
            Validate(limit);
            if (limit < 3) return 0;
            var maxIncluded = (ulong)(limit - 1);
            var sumOfMultipleOf3 = SumOfAllNumbersMultipleOfN(3, maxIncluded);
            var sumOfMultipleOf5 = SumOfAllNumbersMultipleOfN(5, maxIncluded);
            
            //LCM(least common multiple) is 3×5 = 15.
            //This means every number that divides by 15 was counted twice, and thus duplicates shold be removed.            
            var sumOfDivisibleBy15 = SumOfAllNumbersMultipleOfN(15, maxIncluded);

            return sumOfMultipleOf3 + sumOfMultipleOf5 - sumOfDivisibleBy15;
        }
        private static void Validate(int limit)
        {
            if (limit < 0)
            {
                throw new ArgumentException("Limit cannot be a negative value!");
            }
        }

        // The mathematical formula for summation equals to n(a1 + an)/2 where
        // a1 is the 1st member, an is the last member
        // n is the number of members
        private static ulong SumOfAllNumbersMultipleOfN(ulong multipleOf, ulong maxIncluded)
        {
            if (multipleOf == 0 || maxIncluded == 0) return 0;
            var firstMember = multipleOf;
            var lastMember = (maxIncluded / multipleOf) * multipleOf;
            var numberOfMembers = (maxIncluded / multipleOf);
            return numberOfMembers * (firstMember + lastMember) / 2;
        }
    }
}
