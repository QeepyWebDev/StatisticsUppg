using Statistics;
class Program
{
    public static void Main()
    {
        int[] source = Statistics.Statistics.source;
        Console.WriteLine(Statistics.Statistics.DescriptiveStatistics(source));
        Console.ReadKey();
    }
}
