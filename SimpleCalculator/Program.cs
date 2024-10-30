using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CalculatorChallenge
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            // Split by comma or newline
            var parts = numbers.Split(new[] { ',', '\n' }, StringSplitOptions.None);
            int sum = 0;
            var negativeNumbers = new List<int>();

            foreach (var part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    if (number < 0)
                    {
                        negativeNumbers.Add(number); // Collect negative numbers
                    }
                    sum += number;
                }
                else
                {
                    sum += 0; // Invalid numbers are treated as 0
                }
            }

            // If there are any negative numbers, throw an exception
            if (negativeNumbers.Any())
            {
                throw new ArgumentException("Negatives not allowed: " + string.Join(", ", negativeNumbers));
            }

            return sum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new StringCalculator();

            Console.WriteLine("Enter numbers separated by commas (up to 2 numbers):");
            string input = Console.ReadLine();

            try
            {
                int result = calculator.Add(input);
                Console.WriteLine($"Result: {result}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
