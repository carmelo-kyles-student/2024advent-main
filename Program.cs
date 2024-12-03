using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Correct file path
        string filePath = "C:\\Users\\whydo\\Documents\\advent2024\\2024advent-main\\inp.txt";

        try
        {
            // Read the file contents
            string fileContents = File.ReadAllText(filePath);

            // Calculate results for both parts
            int part1Result = CalculateDay1(fileContents);
            int part2result = CalculateDay2(fileContents);

            // Print results
            Console.WriteLine("Part 1: The sum of all valid mul instructions is: " + part1Result);
            Console.WriteLine("Part 2: The sum of all valid and enabled mul instructions is: " + part2result);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: The file was not found at the specified path: {filePath}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: The file contains invalid data.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }

    static int CalculateDay1(string fileContents)
    {
        // Regex pattern to extract valid `mul(X,Y)` instructions
        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

        // Initialize sum
        int totalSum = 0;

        // Match all valid instructions
        foreach (Match match in Regex.Matches(fileContents, pattern))
        {
            // Extract numbers X and Y
            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);

            // Calculate and add to the total sum
            totalSum += x * y;
        }

        return totalSum;
    }

    static int CalculateDay2(string fileContents)
    {
        // Regex patterns
        string mulPattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        string doPattern = @"do\(\)";
        string dontPattern = @"don't\(\)";

        // Initialize sum and state
        int totalSum = 0;
        bool mulEnabled = true;

        // Match all instructions
        var matches = Regex.Matches(fileContents, $"{mulPattern}|{doPattern}|{dontPattern}");

        foreach (Match match in matches)
        {
            if (Regex.IsMatch(match.Value, doPattern))
            {
                // Enable mul instructions
                mulEnabled = true;
            }
            else if (Regex.IsMatch(match.Value, dontPattern))
            {
                // Disable mul instructions
                mulEnabled = false;
            }
            else if (Regex.IsMatch(match.Value, mulPattern) && mulEnabled)
            {
                // Extract numbers and compute multiplication
                var mulMatch = Regex.Match(match.Value, mulPattern);
                int x = int.Parse(mulMatch.Groups[1].Value);
                int y = int.Parse(mulMatch.Groups[2].Value);
                totalSum += x * y;
            }
        }

        return totalSum;
    }
}
