using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Insert values to calculate the frequency");

        Console.Write("Enter N (number of random variates): ");
        int N = int.Parse(Console.ReadLine());

        Console.Write("Enter k (number of intervals): ");
        int k = int.Parse(Console.ReadLine());

        // Genera variabili casuali
        double[] variates = new double[N];
        Random random = new Random();
        for (int i = 0; i < N; i++)
        {
            variates[i] = random.NextDouble();
        }

        // Inizializza un array per contare le frequenze
        int[] counter = new int[k];

        // Calcola le frequenze
        foreach (double value in variates)
        {
            int index = (int)(value * k);
            counter[index]++;
        }

        // Mostra i risultati
        Console.WriteLine("Interval\tFrequency");
        for (int i = 0; i < k; i++)
        {
            double lowerBound = i / (double)k;
            double upperBound = (i + 1) / (double)k;
            string interval = $"[{lowerBound:F2}, {upperBound:F2})";
            Console.WriteLine($"{interval}\t{counter[i]}");
        }
    }
}
