using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // File path

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
   

}
}