using System;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;

namespace test
{
    internal class genprim
    {
        static void Main(string[] args)
        {
            string directoryPath = @"C:\test";
            Console.WriteLine("какой поиск хотите использовать?\n линейный-1\n бинарный-2");
            string z = Console.ReadLine();
            if (z == "1") {
                for (int i = 1; i <= 15; i++)
                {
                    string filePath = Path.Combine(directoryPath, $"test{i}.txt");

                    string[] lines = File.ReadAllLines(filePath);
                    int x = 0;



                    // Первая строка: n и x
                    string[] firstLineParts = lines[0].Split(' ');
                    int n = int.Parse(firstLineParts[0]);
                    x = int.Parse(firstLineParts[1]);


                    int[] numbers = new int[n];

                    string[] numberStrings = lines[1].Split(' ');


                    for (int j = 0; j < n; j++)
                    {
                        numbers[j] = int.Parse(numberStrings[j]);
                    }

                    var sw = new Stopwatch();


                    sw.Start();
                    int result = LineSearch(numbers, x);
                    sw.Stop();


                    if (sw.Elapsed > TimeSpan.FromSeconds(0.02))
                    {
                        Console.WriteLine("вы не уложились по времени и не успели найти нужного гостя");
                        return;

                    }

                    if (result != -1)
                    {
                        Console.WriteLine($"В файле {filePath}: Элемент {x} найден на индексе {result}, затраченое время {sw.Elapsed}");
                    }
                    else
                    {
                        Console.WriteLine($"В файле {filePath}: Элемент {x} не найден. затраченое время {sw.Elapsed}");
                    }
                }
            }
            else if (z == "2") {
                for (int i = 1; i <= 15; i++)
                {
                    string filePath = Path.Combine(directoryPath, $"test{i}.txt");

                    string[] lines = File.ReadAllLines(filePath);
                    int x = 0;



                    // Первая строка: n и x
                    string[] firstLineParts = lines[0].Split(' ');
                    int n = int.Parse(firstLineParts[0]);
                    x = int.Parse(firstLineParts[1]);


                    int[] numbers = new int[n];

                    string[] numberStrings = lines[1].Split(' ');


                    for (int j = 0; j < n; j++)
                    {
                        numbers[j] = int.Parse(numberStrings[j]);
                    }

                    var sw = new Stopwatch();


                    sw.Start();
                    int result = binSearch(numbers, x);
                    sw.Stop();


                    if (sw.Elapsed > TimeSpan.FromSeconds(0.02))
                    {
                        Console.WriteLine("вы не уложились по времени и не успели найти нужного гостя");
                        return;

                    }

                    if (result != -1)
                    {
                        Console.WriteLine($"В файле {filePath}: Элемент {x} найден на индексе {result}, затраченое время {sw.Elapsed}");
                    }
                    else
                    {
                        Console.WriteLine($"В файле {filePath}: Элемент {x} не найден. затраченое время {sw.Elapsed}");
                    }
                }
            }
            
        }


        static int binSearch(int[] nums, int x)
        {

            int left = 0;
            int right = nums.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int q = left + (right - left) / 2;
                if (nums[q] < x)
                {
                    left = q + 1;
                }
                else if (nums[q] > x)
                {
                    right = q - 1;
                }
                else
                {
                    result = q;
                    right = q - 1;
                }
            }

            return result;
        }

        static int LineSearch(int[] nums, int x)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == x) { return i; }
            }
            return -1;
        }

    }
}
