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

            List<string> delimiters = new List<string> { ",", "\n" }; // Default delimiters are comma and newline

            // Check for custom delimiter format
            if (numbers.StartsWith("//"))
            {
                int delimiterEndIndex = numbers.IndexOf('\n');
                if (delimiterEndIndex != -1)
                {
                    string delimiterPart = numbers.Substring(2, delimiterEndIndex - 2);

                    // If there are square brackets, handle multiple or multi-character delimiters
                    if (delimiterPart.StartsWith("[") && delimiterPart.EndsWith("]"))
                    {
                        var matches = Regex.Matches(delimiterPart, @"\[(.*?)\]");
                        foreach (Match match in matches)
                        {
                            delimiters.Add(match.Groups[1].Value); // Add each custom delimiter
                        }
                    }
                    else
                    {
                        // Single-character custom delimiter without brackets
                        delimiters.Add(delimiterPart);
                    }

                    numbers = numbers.Substring(delimiterEndIndex + 1); // Remove delimiter declaration from input
                }
            }

            // Split by all delimiters
            var parts = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
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
                    else if (number <= 1000)
                    {
                        sum += number; // Only add numbers less than or equal to 1000
                    }
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
