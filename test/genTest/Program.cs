using System;
using System.IO;
namespace genTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string directoryPath = @"C:\test";



            for (int i = 0; i < 15; i++)
            {

                using (StreamWriter writer = new StreamWriter(Path.Combine(directoryPath, $"test{i + 1}.txt")))
                {

                    int n = random.Next(1, 1000001);


                    int[] nums = new int[n];
                    for (int j = 0; j < n; j++)
                    {
                        nums[j] = random.Next(-1000000000, 1000000000);
                    }


                    Array.Sort(nums);


                    int x = random.Next(-1000000000, 1000000000);


                    writer.WriteLine($"{n} {x}");
                    writer.WriteLine(string.Join(" ", nums));
                }
            }
        }
    }
}

