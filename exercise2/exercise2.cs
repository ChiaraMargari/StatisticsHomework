using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Select a .txt file:");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath) && Path.GetExtension(filePath) == ".txt")
        {
            string text = File.ReadAllText(filePath);
            AnalyzeText(text);
        }
        else
        {
            Console.WriteLine("Invalid file or extension. Make sure to select a valid .txt file.");
        }
    }

    static void AnalyzeText(string text)
    {
        string[] words = Regex.Matches(text, @"\w+")
                              .Cast<Match>()
                              .Select(match => match.Value.ToLower())
                              .ToArray();

        int wordCount = words.Length;

        Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

        foreach (string word in words)
        {
            if (wordFrequency.ContainsKey(word))
                wordFrequency[word]++;
            else
                wordFrequency[word] = 1;
        }

        Console.WriteLine("Word\tAbsolute Frequency\tRelative Frequency\tFrequency Percentage");

        foreach (var entry in wordFrequency)
        {
            string word = entry.Key;
            int absoluteFrequency = entry.Value;
            double relativeFrequency = (double)absoluteFrequency / wordCount;
            double percentageFrequency = relativeFrequency * 100;

            Console.WriteLine($"{word}\t{absoluteFrequency}\t{relativeFrequency:F4}\t{percentageFrequency:F2}%");
        }
    }
}
