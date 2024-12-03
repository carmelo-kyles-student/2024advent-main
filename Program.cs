using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // File path
        string filePath = "inp.txt";

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

        // Sort both lists
        list1.Sort();
        list2.Sort();

        // Calculate and print the total distance (Part 1)
        int totalDistance = CalculateTotalDistance(list1, list2);
        Console.WriteLine("Part 1 - Total Distance: " + totalDistance);

        // Calculate and print the similarity score (Part 2)
        int similarityScore = CalculateSimilarityScore(list1, list2);
        Console.WriteLine("Part 2 - Similarity Score: " + similarityScore);
    }

    // Function to calculate the total distance between two sorted lists (Part 1)
    private static int CalculateTotalDistance(List<int> list1, List<int> list2)
    {
        int totalDistance = 0;

        for (int i = 0; i < Math.Min(list1.Count, list2.Count); i++)
        {
            totalDistance += Math.Abs(list1[i] - list2[i]);
        }

        return totalDistance;
    }

    // Function to calculate the similarity score (Part 2)
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
