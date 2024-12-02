using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Program
{
    public static void Main(string[] args)
    {
        // File path to input data
        string filePath = "C:\\Users\\cakye3c\\OneDrive\\2024advent-main\\inp.txt";

        // List to store reports as arrays
        List<int[]> rows = new List<int[]>();

        // Read the file and split each line into an array of integers
        foreach (var line in File.ReadLines(filePath))
        {
            // Split the line into integers and add to the list of rows
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

        // Call the CheckForSafe method and display the result
        int safeCount = CheckForSafe(array2D);
        Console.WriteLine("Number of safe reports: " + safeCount);
    }

    // Method to check for safe reports
    public static int CheckForSafe(int[][] rows)
    {
        int safeCount = 0;

        // Loop through each row
        foreach (var row in rows)
        {
            // Check if the current row is safe
            if (IsRowSafe(row))
            {
                safeCount++;  // Increment safe count if the row is safe
            }
        }

        return safeCount;  // Return the total number of safe rows
    }

    // Method to check if a row is safe
    public static bool IsRowSafe(int[] row)
    {
        bool isIncreasing = true;
        bool isDecreasing = true;

        // Loop through the row and check each pair of adjacent numbers
        for (int i = 0; i < row.Length - 1; i++)
        {
            int diff = row[i + 1] - row[i];

            // Check if the difference is within the acceptable range (between 1 and 3, inclusive)
            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
            {
                return false;  // Unsafe if the difference is not between 1 and 3
            }

            // Check if the row is not strictly increasing or decreasing
            if (diff > 0)
            {
                isDecreasing = false;  // If increasing, mark as not decreasing
            }
            if (diff < 0)
            {
                isIncreasing = false;  // If decreasing, mark as not increasing
            }
        }

        // A row is safe if it's either strictly increasing or strictly decreasing
        return isIncreasing || isDecreasing;
    }
}
