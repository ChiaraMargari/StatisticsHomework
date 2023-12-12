using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Select a .txt file:");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath) && Path.GetExtension(filePath) == ".txt")
        {
            string data = File.ReadAllText(filePath);
            ProcessData(data);
        }
        else
        {
            Console.WriteLine("Invalid file or extension. Make sure to select a valid .txt file.");
        }
    }

    static void ProcessData(string data)
    {
        string[] lines = data.Split('\n');
        Dictionary<string, int> ageCounts = new Dictionary<string, int>();
        Dictionary<string, int> sexCounts = new Dictionary<string, int>();
        int total = lines.Length - 1; // Subtract 1 to exclude the header

        // Calculate absolute frequencies
        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split('\t');
            string age = values[0];
            string sex = values[1];

            if (ageCounts.ContainsKey(age))
                ageCounts[age]++;
            else
                ageCounts[age] = 1;

            if (sexCounts.ContainsKey(sex))
                sexCounts[sex]++;
            else
                sexCounts[sex] = 1;
        }

        // Create the table
        Console.WriteLine("Age\tSex\tAbsolute Frequency\tRelative Frequency\tPercentage Distribution");

        foreach (var ageCount in ageCounts)
        {
            foreach (var sexCount in sexCounts)
            {
                double relativeFrequency = ((double)ageCount.Value / total) * ((double)sexCount.Value / total);
                double percentageDistribution = relativeFrequency * 100;

                Console.WriteLine($"{ageCount.Key}\t{sexCount.Key}\t{ageCount.Value * sexCount.Value}\t{relativeFrequency:F4}\t{percentageDistribution:F2}%");
            }
        }
    }
}
