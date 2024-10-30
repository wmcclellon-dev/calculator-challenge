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

            var parts = numbers.Split(',');
            int sum = 0;

            foreach (var part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    sum += number;
                }
                else
                {
                    sum += 0; // Invalid numbers are treated as 0
                }
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
