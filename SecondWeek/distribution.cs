using System;

class Program
{
    static int[] GenerateUniformRandomVariates(int N, int k)
    {
        double[] intervals = new double[k];
        int[] counts = new int[k];
        double intervalSize = 1.0 / k;

        for (int i = 0; i < k; i++)
        {
            intervals[i] = i * intervalSize;
        }

        Random random = new Random();

        for (int i = 0; i < N; i++)
        {
            double randomValue = random.NextDouble();
            for (int j = 0; j < k; j++)
            {
                if (randomValue >= intervals[j] && randomValue < intervals[j] + intervalSize)
                {
                    counts[j]++;
                    break;
                }
            }
        }

        return counts;
    }

    static void Main()
    {
        int N = 1000;
        int k = 10;
        int[] distribution = GenerateUniformRandomVariates(N, k);

        Console.WriteLine("Distribuzione delle variabili casuali generate in " + k + " classi:");

        for (int i = 0; i < k; i++)
        {
            double intervalStart = i / (double)k;
            double intervalEnd = (i + 1) / (double)k;
            int frequency = distribution[i];

            Console.WriteLine($"Classe [{intervalStart:F1}, {intervalEnd:F1}): {frequency}");
        }
    }
}
