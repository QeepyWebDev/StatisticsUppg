using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Statistics
{
    public static class Statistics
    {
        public static int[] source = JsonConvert.DeserializeObject<int[]>(File.ReadAllText("data.json"));
        public static dynamic DescriptiveStatistics(int[] source)
        {
            Dictionary<string, dynamic> StatisticsList = new Dictionary<string, dynamic>()
            {
                { "Maximum", Maximum(source) },
                { "Minimum", Minimum(source) },
                { "Medelvärde", Mean(source) },
                { "Median", Median(source) },
                { "Typvärde", String.Join(", ", Mode(source)) },
                { "Variationsbredd", Range(source) },
                { "Standardavvikelse", StandardDeviation(source) }
            };

            string output =
                $"Maximum: {StatisticsList["Maximum"]}\n" +
                $"Minimum: {StatisticsList["Minimum"]}\n" +
                $"Medelvärde: {StatisticsList["Medelvärde"]}\n" +
                $"Median: {StatisticsList["Median"]}\n" +
                $"Typvärde: {StatisticsList["Typvärde"]}\n" +
                $"Variationsbredd: {StatisticsList["Variationsbredd"]}\n" +
                $"Standardavvikelse: {StatisticsList["Standardavvikelse"]}";

            return output;
        }

        public static int Maximum(int[] source)
        {
            return source.Max();
        }

        public static int Minimum(int[] source)
        {
            return source.Min();
        }

        public static double Mean(int[] source)
        {
            return source.Average();
        }

        public static double Median(int[] source) /*Med mitt första unit test upptäckte jag att metoden endast fungerar för arrayer som har ett udda antal värden, 
                                                   därför skulle jag göra följande ändringar för att det ska funka även med arrayer som har ett jämnt antal värden: */
        {
            Array.Sort(source);
            int size = source.Length;
            if (size % 2 == 0)
            {
                return (source[size / 2 - 1] + source[size / 2]) / 2.0;
                /* 
                double firstMiddle = source[size / 2 - 1];
                double secondMiddle = source[size / 2];
                return new double[] { firstMiddle, secondMiddle };
                 */
            }
            else
            {
                return source[size / 2];
                /*
                double middle = source[size / 2];
                return new double[] { middle };
                 */
            }
        }

        public static int[] Mode(int[] source)
        {
            var frequency = source.GroupBy(x => x)
                                  .ToDictionary(g => g.Key, g => g.Count());

            int maxFrequency = frequency.Values.Max();
            return frequency.Where(kv => kv.Value == maxFrequency)
                            .Select(kv => kv.Key)
                            .ToArray();
        }

        public static int Range(int[] source)
        {
            return source.Max() - source.Min();
        }

        public static double StandardDeviation(int[] source) /*Med mitt unit test upptäckte jag även att denna metoden är inkorrekt. 
                                                              För att resultatet ska bli rätt behöver metoden se ut på följande sätt:*/
        {
            /*
            double mean = source.Average();
            double sumOfSquaredDifferences = source.Select(val => (val - mean) * (val - mean)).Sum();
            double sd = Math.Sqrt(sumOfSquaredDifferences / source.Length);
            return Math.Round(sd, 2);
             */
            double average = source.Average();
            double sumOfSquaresOfDifferences = source.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / source.Length);
            return Math.Round(sd, 1);
        }
    }
}