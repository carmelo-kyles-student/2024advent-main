using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Program
{
    public static void Main(string[] args)
    {
        // File path to input data
        string filePath = "inp.txt";

        // List to store reports as arrays
        List<int[]> rows = new List<int[]>();

        // Read the file and split each line into an array of integers
        foreach (var line in File.ReadLines(filePath))
        {
            int[] row = Array.ConvertAll(line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
            rows.Add(row);
        }

        // Convert the list of rows into a 2D array
        int[][] array2D = rows.ToArray();

        // Display the 2D array (optional for debugging)
        Console.WriteLine("2D Array:");
        foreach (var row in array2D)
        {
            Console.WriteLine(string.Join(" ", row));
        }

        // Call the CheckForSafe method for Part 1
        int safeCountPart1 = CheckForSafe(array2D);
        Console.WriteLine("Part 1: Number of safe reports: " + safeCountPart1);

        // Call the CheckForSafeWithDampener method for Part 2
        int safeCountPart2 = CheckForSafeWithDampener(array2D);
        Console.WriteLine("Part 2: Number of safe reports with Problem Dampener: " + safeCountPart2);
    }

    // Method to check for safe reports
    public static int CheckForSafe(int[][] rows)
    {
        int safeCount = 0;

        foreach (var row in rows)
        {
            if (IsRowSafe(row))
            {
                safeCount++;
            }
        }

        return safeCount;
    }

    // Method to check for safe reports with the Problem Dampener
    public static int CheckForSafeWithDampener(int[][] rows)
    {
        int safeCount = 0;

        foreach (var row in rows)
        {
            if (IsRowSafe(row))
            {
                safeCount++;
            }
            else
            {
                for (int i = 0; i < row.Length; i++)
                {
                    // Create a new array without the level at index `i`
                    int[] modifiedRow = row.Where((_, index) => index != i).ToArray();

                    // Check if the modified row is safe
                    if (IsRowSafe(modifiedRow))
                    {
                        safeCount++;
                        break; // Stop checking further if already safe
                    }
                }
            }
        }

        return safeCount;
    }

    // Method to check if a row is safe
    public static bool IsRowSafe(int[] row)
    {
        bool isIncreasing = true;
        bool isDecreasing = true;

        for (int i = 0; i < row.Length - 1; i++)
        {
            int diff = row[i + 1] - row[i];

            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
            {
                return false; // Unsafe if difference is not between 1 and 3
            }

            if (diff > 0)
            {
                isDecreasing = false;
            }
            if (diff < 0)
            {
                isIncreasing = false;
            }
        }

        return isIncreasing || isDecreasing;
    }
}
