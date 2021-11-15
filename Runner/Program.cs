using SequenceAnalysis;
using SumOfMultiple;
using System;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var exit = false;
            while (!exit)
            {
                var selection = SelectSolutions();
                switch (selection)
                {
                    //SumOfMultiple
                    case 1:
                        RunSumOfMultiple();
                        break;
                    //SequenceAnalysis
                    case 2:
                        RunSequenceAnalysis();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input...");
                        break;
                }
            }
        }

        public static int SelectSolutions()
        {
            Console.WriteLine();
            Console.WriteLine("Please select the number of problem you want to solve: ");
            Console.WriteLine("1. SumOfMultiple");
            Console.WriteLine("2. SequenceAnalysis");
            Console.WriteLine("0. Exit");
            var input = Console.ReadLine()?.ToLower();

            if (int.TryParse(input, out var result))
            {
                return result;
            }

            return -1;
        }

        public static void RunSumOfMultiple()
        {
            ISumOfMultipleFinder _sumOfMultipleFinder = new SumOfMultipleFinder();
            Console.WriteLine("Selected program finds the sum of all natural numbers that are a multiple of 3 or 5 below a limit provided as input.");
            Console.WriteLine("Please enter a valid limit (1-2147483647) or type `0` for going back to the problem selection:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out var limit))
            {
                if (limit == 0) return;
                try
                {
                    var sumOfMultiple = _sumOfMultipleFinder.SumOfMultipleThreeOrFive(limit);
                    Console.WriteLine($"Total sum = {sumOfMultiple}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid input...");
            }
        }

        public static void RunSequenceAnalysis()
        {
            ISequenceAnalyzer _sequenceAnalyzer = new SequenceAnalyzer();
            Console.WriteLine("Selected program finds the uppercase words in a string, provided as input, and order all characters in these words alphabetically.");
            Console.WriteLine("Please type your input then press enter or type `0` for going back to the problem selection:");
            var input = Console.ReadLine();
            try
            {
                if (input == "0") return;
                var result = _sequenceAnalyzer.OrderCharactersInUpperCaseWords(input);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
