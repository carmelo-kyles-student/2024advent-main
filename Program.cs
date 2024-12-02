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

        // Lists to store separated values
        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();

        // Read file line by line
        foreach (var line in File.ReadLines(filePath))
        {
            // Split each line into two parts
            string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Add to respective lists
            if (parts.Length == 2)
            {
                list1.Add(int.Parse(parts[0]));
                list2.Add(int.Parse(parts[1]));
            }
        }

        Console.WriteLine("List 1 Sorted:");
        list1.Sort();
        Console.WriteLine(string.Join(", ", list1));

        Console.WriteLine("\nList 2 Sorted:");
        list2.Sort();
        Console.WriteLine(string.Join(", ", list2));

        // Call checkIfLarger and display result
        int res = CheckIfLarger(list1, list2);
        Console.WriteLine("\nCheckIfLarger Result: " + res);

        // Calculate and display the similarity score
        int similarityScore = CalculateSimilarityScore(list1, list2);
        Console.WriteLine("\nSimilarity Score: " + similarityScore);
    }

    // Function to calculate difference between lists and return sum
    private static int CheckIfLarger(List<int> l1, List<int> l2)
    {
        int sum = 0;
        for (int i = 0; i < Math.Min(l1.Count, l2.Count); i++) // Ensure we don't exceed bounds
        {
            sum += Math.Abs(l1[i] - l2[i]); // Add absolute difference
        }
        return sum;
    }

    // Function to calculate the similarity score
    private static int CalculateSimilarityScore(List<int> list1, List<int> list2)
    {
        // Create a dictionary to count occurrences in list2
        Dictionary<int, int> countMap = new Dictionary<int, int>();
        foreach (int num in list2)
        {
            if (countMap.ContainsKey(num))
                countMap[num]++;
            else
                countMap[num] = 1;
        }

        // Calculate the similarity score
        int similarityScore = 0;
        foreach (int num in list1)
        {
            if (countMap.ContainsKey(num))
            {
                similarityScore += num * countMap[num];
            }
        }

        return similarityScore;
    }
}
