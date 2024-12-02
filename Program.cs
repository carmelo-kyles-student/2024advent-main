using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // File path
        string filePath = "C:\\Users\\cakye3c\\Downloads\\2024advent-main\\2024advent-main\\inp.txt";

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
        Console.WriteLine(string.Join(", ",list1 ));

        Console.WriteLine("\nList 2:");
        list2.Sort();
        Console.WriteLine(string.Join(", ", list2));
    }

    public static int[] checkIfLarger(int[] l1,int[]l2){
        int[] l3 = new int[];
        for (int i = 0;  i < l1.Length; i++){
            if(l1[i] > l2[i]){

            }
        }
        return l3;
    }
}